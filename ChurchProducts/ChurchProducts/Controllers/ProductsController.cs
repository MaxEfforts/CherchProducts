using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbModels;
using DbModels.ViewModels;
using ChurchProducts.Model;
using static ChurchProducts.Helper;

namespace ChurchProducts.Controllers
{
    public class ProductsController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.products.ToListAsync());
        }
        // Get : Products/AddOrEdit
        // Get : Products/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                var product = await _context.products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);

            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,ProductName,ProductPrice")] Product product)
        { 
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                if (id == 0)
                {
                    return Json(new { isValid = true,  Message = "تمة الاضافة بنجاح",html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList())  });
                    
                }
                else
                {
                   
                    return Json(new { isValid = true, Message = "تم التعديل بنحاح", html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList()) });
                }
                }
            
            return Json(new { isValid = false,Message = "حدث خطا برجاء مراجعة البيانات واعادة المحاولة", html = Helper.RenderRazorViewToString(this, "AddOrEdit", product) });
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
          
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllProducts", _context.products.ToList()) , Message = "تم الحذف بنجاح" });
        }

        private bool ProductExists(int id)
        {
         
            return _context.products.Any(e => e.Id == id);
        }
    }
}
