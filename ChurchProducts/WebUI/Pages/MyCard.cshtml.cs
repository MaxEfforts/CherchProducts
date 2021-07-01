using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModels;
using DbModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class MyCardModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }
        public MyCardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ShopingCard> products { get; set; }

        public void OnGet()
        {
            products = _context.shopingCards.Where(x => x.applicationUser.UserName == User.Identity.Name).ToList();
        }
    }
}
