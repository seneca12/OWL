using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OwlApp.Data;
using OwlApp.Models;

namespace OwlApp.Pages.AssetList
{
    public class IndexModel : PageModel
    {
        private readonly OwlApp.Data.OwlAppContext _context;

        public IndexModel(OwlApp.Data.OwlAppContext context)
        {
            _context = context;
        }

        public IList<Asset> Asset { get;set; }

        public async Task OnGetAsync()
        {
            Asset = await _context.Asset.ToListAsync();
        }
    }
}
