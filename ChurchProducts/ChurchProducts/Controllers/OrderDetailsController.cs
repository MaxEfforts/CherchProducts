using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbModels;
using DbModels.ViewModels;

namespace ChurchProducts.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index(int OrderId)
        {
            var applicationDbContext = _context.orderDetails.Where(x => x.orderIDFK == OrderId).Include(o => o.order).Include(o => o.product);
            return View(await applicationDbContext.ToListAsync());
        }

        #region Hold
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetails = await _context.orderDetails
        //        .Include(o => o.order)
        //        .Include(o => o.product)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (orderDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderDetails);
        //}

        //// GET: OrderDetails/Create
        //public IActionResult Create()
        //{
        //    ViewData["orderIDFK"] = new SelectList(_context.orders, "Id", "UserIDFK");
        //    ViewData["productIDFK"] = new SelectList(_context.products, "Id", "ProductName");
        //    return View();
        //}

        //// POST: OrderDetails/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,productIDFK,orderIDFK")] OrderDetails orderDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(orderDetails);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["orderIDFK"] = new SelectList(_context.orders, "Id", "UserIDFK", orderDetails.orderIDFK);
        //    ViewData["productIDFK"] = new SelectList(_context.products, "Id", "ProductName", orderDetails.productIDFK);
        //    return View(orderDetails);
        //}

        //// GET: OrderDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetails = await _context.orderDetails.FindAsync(id);
        //    if (orderDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["orderIDFK"] = new SelectList(_context.orders, "Id", "UserIDFK", orderDetails.orderIDFK);
        //    ViewData["productIDFK"] = new SelectList(_context.products, "Id", "ProductName", orderDetails.productIDFK);
        //    return View(orderDetails);
        //}

        //// POST: OrderDetails/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,productIDFK,orderIDFK")] OrderDetails orderDetails)
        //{
        //    if (id != orderDetails.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(orderDetails);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderDetailsExists(orderDetails.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["orderIDFK"] = new SelectList(_context.orders, "Id", "UserIDFK", orderDetails.orderIDFK);
        //    ViewData["productIDFK"] = new SelectList(_context.products, "Id", "ProductName", orderDetails.productIDFK);
        //    return View(orderDetails);
        //}

        //// GET: OrderDetails/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetails = await _context.orderDetails
        //        .Include(o => o.order)
        //        .Include(o => o.product)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (orderDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderDetails);
        //}

        //// POST: OrderDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var orderDetails = await _context.orderDetails.FindAsync(id);
        //    _context.orderDetails.Remove(orderDetails);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderDetailsExists(int id)
        //{
        //    return _context.orderDetails.Any(e => e.Id == id);
        //} 
        #endregion
    }
}
