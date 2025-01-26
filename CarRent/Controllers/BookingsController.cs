using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace CarRent.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bookings.Include(b => b.Cars);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Cars)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        // GET: Bookings/Create
        public IActionResult Create()
        {
            var cars = _context.Cars.ToList();
            if (cars == null || !cars.Any())
            {
                ModelState.AddModelError("", "No cars available for booking.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            ViewData["CarId"] = new SelectList(cars, "CarId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["StatusOptions"] = new SelectList(new List<SelectListItem>
    {
        new SelectListItem { Value = "Pending", Text = "Pending" },
        new SelectListItem { Value = "Confirmed", Text = "Confirmed" },
        new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
    }, "Value", "Text");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,UserId,CarId,StartDate,EndDate,Status")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "Name", booking.CarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", booking.UserId);
            ViewData["StatusOptions"] = new SelectList(new List<SelectListItem>
    {
        new SelectListItem { Value = "Pending", Text = "Pending" },
        new SelectListItem { Value = "Confirmed", Text = "Confirmed" },
        new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
    }, "Value", "Text");
            return View(booking);
        }


        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "Name", booking.CarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", booking.UserId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Pending", "Confirmed", "Cancelled" }, booking.Status);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,UserId,CarId,StartDate,EndDate,Status")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "Name", booking.CarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", booking.UserId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Pending", "Confirmed", "Cancelled" }, booking.Status);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Cars)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
