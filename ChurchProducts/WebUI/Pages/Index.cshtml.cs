using DbModels;
using DbModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _Context;

        public List<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext Context)
        {
            _logger = logger;
            _Context = Context;
        }

        public void OnGet()
        {
            Products = _Context.products.ToList();
        }
    }
}
