using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbModels;
using DbModels.ViewModels;
using ChurchProducts.IServices;
using ChurchProducts.Model;
using Services.Mappers.Identity;
using static ChurchProducts.Helper;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using DbModels.Identity;
using Services.IServices;

namespace ChurchProducts.Controllers
{
    public class UsersController : Controller 
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly IEncrptionAndDecreption _encrptionAndDecreption;

        public UsersController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, IEncrptionAndDecreption encrptionAndDecreption)
        {
            _context = context;
            _userManager = userManager;
            _encrptionAndDecreption = encrptionAndDecreption;
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public IActionResult GetUserWallet(string id)
        {
          var userWallet =  _context.userWallets.Where(x => x.UserIDFK == id).FirstOrDefault();
            ViewBag.userId = id;
            if (userWallet != null)
            {
                return View("UserWallet", userWallet);
            }
            return View("UserWallet", new UserWallet());
            // return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_AddOrEdit", productModel) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditWallet(string id, UserWallet userWallet)
        {
            try
            {
                
                var user = _context.userWallets.Where(h => h.UserIDFK == id).FirstOrDefault();
                if (user == null)
                {
                    _context.userWallets.Add(new UserWallet() { 
                    Balance = userWallet.Balance,
                    UserIDFK = id
                    });
                }
                else
                { 
                 user.Balance = userWallet.Balance;
                _context.userWallets.Update(user);
                }
               
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUsers", _userManager.Users) });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "UserWallet", userWallet) });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, ApplicationUser applicationUser)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
               
                
                if (user != null)
                {  
                    var Encryptedpassword = _encrptionAndDecreption.EncryptString(applicationUser.NewUserPassword, applicationUser.Id);
                    var unEncryptedpassword = _encrptionAndDecreption.DecryptString(user.UserSecretKey, user.Id);
                    user.FirstName = applicationUser.FirstName;
                    user.LastName = applicationUser.LastName;
                    user.Address = applicationUser.Address;
                    user.Email = applicationUser.Email;
                    user.UserSecretKey = Encryptedpassword;
                    user.NormalizedEmail =(applicationUser.Email).ToUpper();
                    user.UserName = applicationUser.FirstName + applicationUser.LastName;
                    user.NormalizedUserName = user.UserName.ToUpper();
                    user.PhoneNumber = applicationUser.PhoneNumber;
                    await _userManager.UpdateAsync(user);
                 
                await _context.SaveChangesAsync();
                   
                  var res =  await _userManager.ChangePasswordAsync(user, unEncryptedpassword, applicationUser.NewUserPassword);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUsers", _userManager.Users) });
                }
                var userwallet = _context.userWallets.Where(h => h.UserIDFK == id).FirstOrDefault();
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "UserWallet", userwallet) });

            }
            catch (Exception ex)
            {
                var userwallet = _context.userWallets.Where(h => h.UserIDFK == id).FirstOrDefault();
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "UserWallet", userwallet) });
            }
        }
     
        
        [HttpGet]
        public async Task<IActionResult> EditForm(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var unEncryptedpassword = _encrptionAndDecreption.DecryptString(user.UserSecretKey,user.Id);
            user.NewUserPassword = unEncryptedpassword;
            return View("EditUser", user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userwalet = _context.userWallets.Where(h => h.UserIDFK == id).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(id);
            if (userwalet != null)
            { 
              _context.userWallets.Remove(userwalet);
            }
          
            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUsers", _userManager.Users) });
        }
    }
}
