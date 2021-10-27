using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Database.Models;
using WebApplication1.Code;

namespace WebApplication1.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("[controller]/[action]")]
    [Authorize("RequiredAuthenticatedUser")]
    public class LoginsController : Controller
    {
        private readonly testDBContext _context;
        private readonly IHashing _iHashing;

        public LoginsController(testDBContext context, IHashing iHashing)
        {
            _context = context;
            _iHashing = iHashing;
        }

        // GET: Database/Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Database/Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User1,Password,Salt")] Login login)
        {
            if (ModelState.IsValid)
            {
                login.Password = _iHashing.BcryptHash(login.Password);

                _context.Add(login);
                await _context.SaveChangesAsync();
                return View("Views/Home/Index.cshtml");
            }
            return View(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.Id == id);
        }
    }
}
