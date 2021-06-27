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

namespace ChurchProducts.Controllers
{
    public class ProductsController : Controller 
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        public ProductsController(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.products.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, ProductModel productModel)
        {
           var Product =  IdentityMapper.Mapper.Map<Product>(productModel);
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        Product.ProductImgPath = _fileService.UploadFile(productModel.photoUrl, "images/Products");
                        _context.Add(Product);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        if (productModel.photoUrl != null)
                        {
                            Product.ProductImgPath = _fileService.UploadFile(productModel.photoUrl, "images/Products");
                        }
                        else
                        {
                            var oldPro = _context.products.AsNoTracking().FirstOrDefault(x => x.Id == productModel.Id);
                            Product.ProductImgPath = oldPro.ProductImgPath;
                        }
                        _context.Update(Product);
                        await _context.SaveChangesAsync();
                    }
                    if (id == 0)
                    {
                        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList()) });
                    }
                    else
                    {
                        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList()) });
                    }
                }
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", Product) });
            }
            catch (Exception ex)
            { 
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", Product) });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditForm(int id)
        {
            var product = await _context.products.FindAsync(id);
            var productModel = new DbModels.Model.ProductModel();
            productModel.Id = product.Id;
            productModel.ProductName = product.ProductName;
            productModel.ProductPrice = product.ProductPrice;
            productModel.ProductImgPath = product.ProductImgPath;
             return View("Edit", productModel);
            // return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_AddOrEdit", productModel) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
          
            return Json(new {Message = "تم الحذف بنجاح", html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList()) });
        }
    }
}
