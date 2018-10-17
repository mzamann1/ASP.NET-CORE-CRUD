using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MVA_Beginner_Razor_CRUD.Pages
{
    public class EditModel : PageModel
    {
        readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer customer { get; set; }
        public async Task<IActionResult> OnGetAsync(int id )
        {
            customer = await _db.Customers.FindAsync(id);
            if (customer==null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Attach(customer).State = EntityState.Modified;


            try
            {
                await _db.SaveChangesAsync();
                Message = $"customer {customer.Name} updated";
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new Exception($"Customer {customer.Id} not found",e);
            }
            return RedirectToPage("/Index");
        }
    }
}