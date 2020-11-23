using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication27.Data;
using WebApplication27.Models;

namespace WebApplication27.Controllers
{
    public class UsersGroupsController : Controller
    {
        private readonly WebApplication27Context _context;

        public UsersGroupsController(WebApplication27Context context)
        {
            _context = context;
        }

        // GET: UsersGroups
        public async Task<IActionResult> Index()
        {
            var webApplication27Context = _context.UsersGroups.Include(u => u.Group).Include(u => u.User);
            return View(await webApplication27Context.ToListAsync());
        }

        // GET: UsersGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroups = await _context.UsersGroups
                .Include(u => u.Group)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersGroups == null)
            {
                return NotFound();
            }

            return View(usersGroups);
        }

        // GET: UsersGroups/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: UsersGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,GroupId")] UsersGroups usersGroups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersGroups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", usersGroups.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usersGroups.UserId);
            return View(usersGroups);
        }

        // GET: UsersGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroups = await _context.UsersGroups.FindAsync(id);
            if (usersGroups == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", usersGroups.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usersGroups.UserId);
            return View(usersGroups);
        }

        // POST: UsersGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,GroupId")] UsersGroups usersGroups)
        {
            if (id != usersGroups.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersGroups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersGroupsExists(usersGroups.UserId))
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
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", usersGroups.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", usersGroups.UserId);
            return View(usersGroups);
        }

        // GET: UsersGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroups = await _context.UsersGroups
                .Include(u => u.Group)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersGroups == null)
            {
                return NotFound();
            }

            return View(usersGroups);
        }

        // POST: UsersGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersGroups = await _context.UsersGroups.FindAsync(id);
            _context.UsersGroups.Remove(usersGroups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersGroupsExists(int id)
        {
            return _context.UsersGroups.Any(e => e.UserId == id);
        }
    }
}
