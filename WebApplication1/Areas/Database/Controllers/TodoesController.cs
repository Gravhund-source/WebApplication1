using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Database.Models;
using WebApplication1.Code;
namespace WebApplication1.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("[controller]/[action]")]
    public class TodoesController : Controller
    {
        private readonly testDBContext _context;
        private readonly Crypt _crypt;
        private readonly IDataProtector _protector;

        public TodoesController(testDBContext context, Crypt crypt, IDataProtectionProvider protector)
        {
            _context = context;
            _crypt = crypt;
            _protector = protector.CreateProtector("WebApplication1.TodolistsController.VictorGawron");
        }

        // GET: Database/Todoes
        public async Task<IActionResult> Index()
        {
            var userIdentityName = User.Identity.Name;

            var rows = await _context.Todos.Where(t => t.User == userIdentityName).ToListAsync();
            bool matchFound = rows.Count > 0;

            if (matchFound)
            {
                foreach (Todo row in rows)
                {
                    string TextEncrypted = row.Description;
                    string TitleEncrypted = row.Title;
                    row.Title = _crypt.Decrypt(TitleEncrypted, _protector);
                    row.Description = _crypt.Decrypt(TextEncrypted, _protector);
                }
                return View(rows);
            }
            else
            {
                return View(new List<Todo>());
            }
        }

        // GET: Database/Todoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Database/Todoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Database/Todoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Title,Description")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                string description = todo.Description;
                string title = todo.Title;
                todo.Title = _crypt.Encrypt(title, _protector);
                todo.Description = _crypt.Encrypt(description, _protector);

                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Database/Todoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Database/Todoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Title,Description")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
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
            return View(todo);
        }

        // GET: Database/Todoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Database/Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
