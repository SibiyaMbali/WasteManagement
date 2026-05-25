
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasteManagement.Models;
using WasteManagement.Data;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: REPORTS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Reports.ToListAsync());
    }


    // GET: REPORTS/Details/5
    public async Task<IActionResult> Details(int? reportid)
    {
        if (reportid == null)
        {
            return NotFound();
        }

        var report = await _context.Reports
            .FirstOrDefaultAsync(m => m.ReportId == reportid);
        if (report == null)
        {
            return NotFound();
        }

        return View(report);
    }

    // GET: REPORTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: REPORTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReportId,Title,Description,Location,ImageUrl,Status,DateReported")] Report report)
    {
        if (ModelState.IsValid)
        {
            _context.Add(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(report);
    }

    // GET: REPORTS/Edit/5
    public async Task<IActionResult> Edit(int? reportid)
    {
        if (reportid == null)
        {
            return NotFound();
        }

        var report = await _context.Reports.FindAsync(reportid);
        if (report == null)
        {
            return NotFound();
        }
        return View(report);
    }

    // POST: REPORTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? reportid, [Bind("ReportId,Title,Description,Location,ImageUrl,Status,DateReported")] Report report)
    {
        if (reportid != report.ReportId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(report);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(report.ReportId))
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
        return View(report);
    }

    // GET: REPORTS/Delete/5
    public async Task<IActionResult> Delete(int? reportid)
    {
        if (reportid == null)
        {
            return NotFound();
        }

        var report = await _context.Reports
            .FirstOrDefaultAsync(m => m.ReportId == reportid);
        if (report == null)
        {
            return NotFound();
        }

        return View(report);
    }

    // POST: REPORTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? reportid)
    {
        var report = await _context.Reports.FindAsync(reportid);
        if (report != null)
        {
            _context.Reports.Remove(report);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReportExists(int? reportid)
    {
        return _context.Reports.Any(e => e.ReportId == reportid);
    }
}
