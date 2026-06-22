
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteManagement.Models;
using WasteManagement.Data;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]


public class WorkersController : Controller
{
    private readonly ApplicationDbContext _context;

    public WorkersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: WORKERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Workers.ToListAsync());
    }

    // GET: WORKERS/Details/5
    public async Task<IActionResult> Details(int? workerid)
    {
        if (workerid == null)
        {
            return NotFound();
        }

        var worker = await _context.Workers
            .FirstOrDefaultAsync(m => m.WorkerId == workerid);
        if (worker == null)
        {
            return NotFound();
        }

        return View(worker);
    }

    // GET: WORKERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: WORKERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("WorkerId,Name,PhoneNumber,Email")] Worker worker)
    {
        if (ModelState.IsValid)
        {
            _context.Add(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(worker);
    }

    // GET: WORKERS/Edit/5
    public async Task<IActionResult> Edit(int? workerid)
    {
        if (workerid == null)
        {
            return NotFound();
        }

        var worker = await _context.Workers.FindAsync(workerid);
        if (worker == null)
        {
            return NotFound();
        }
        return View(worker);
    }

    // POST: WORKERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? workerid, [Bind("WorkerId,Name,PhoneNumber,Email")] Worker worker)
    {
        if (workerid != worker.WorkerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(worker);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(worker.WorkerId))
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
        return View(worker);
    }

    // GET: WORKERS/Delete/5
    public async Task<IActionResult> Delete(int? workerid)
    {
        if (workerid == null)
        {
            return NotFound();
        }

        var worker = await _context.Workers
            .FirstOrDefaultAsync(m => m.WorkerId == workerid);
        if (worker == null)
        {
            return NotFound();
        }

        return View(worker);
    }

    // POST: WORKERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? workerid)
    {
        var worker = await _context.Workers.FindAsync(workerid);
        if (worker != null)
        {
            _context.Workers.Remove(worker);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WorkerExists(int? workerid)
    {
        return _context.Workers.Any(e => e.WorkerId == workerid);
    }
}
