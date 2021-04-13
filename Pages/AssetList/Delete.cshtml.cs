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
    public class DeleteModel : PageModel
    {
        private readonly OwlApp.Data.OwlAppContext _context;

        public DeleteModel(OwlApp.Data.OwlAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Asset.FirstOrDefaultAsync(m => m.ID == id);

            if (Asset == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Asset.FindAsync(id);

            if (Asset != null)
            {
                _context.Asset.Remove(Asset);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
