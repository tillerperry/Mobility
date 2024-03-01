using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilityWeb.DataContext;
using MobilityWeb.Models;

namespace MobilityWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
             

              return View();
        }
        
        
        public async Task<IActionResult> ListView()
        {
            return _context.BaseEntity != null ? 
                View(await _context.Customers.ToListAsync()) :
                Problem("Something bad happened");
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> SearchView(string? id)
        {
            if (id is null)
            {
                return View(new List<Customer>());
            }
            var baseEntity =   _context.Customers.Where(m => m.FirstName.Contains(id)  || m.Surname.Contains(id)).AsEnumerable();
            if (!baseEntity.Any())
            {
                return NotFound();
            }

            await Task.CompletedTask;
            return View(baseEntity);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind($"{nameof(Customer.FirstName)}," +
                                                      $"{nameof(Customer.Surname)},{nameof(Customer.Age)}")] Customer baseEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseEntity);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var baseEntity = await _context.Customers.FindAsync(id);
            if (baseEntity == null)
            {
                return NotFound();
            }
            return View(baseEntity);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,CreatedAt,CreatedBy,UpdatedAt")] Customer baseEntity)
        {
            if (id != baseEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseEntityExists(baseEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(baseEntity);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var baseEntity = await _context.Customers
                .FirstOrDefaultAsync(m => m.FirstName == id || m.Surname == id);
            if (baseEntity == null)
            {
                return NotFound();
            }

            return View(baseEntity);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BaseEntity'  is null.");
            }
            var baseEntity = await  _context.Customers.FirstOrDefaultAsync(
                x=>x.Surname.Contains(id) ||x.FirstName.Contains(id) );
            if (baseEntity != null)
            {
                _context.Customers.Remove(baseEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListView));
        }

        private bool BaseEntityExists(string id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
