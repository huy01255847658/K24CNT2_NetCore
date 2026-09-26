
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoangManhHuy2410900040_exam.Models;

public class HmhEmployeesController : Controller
{
    private readonly HmhEmployee2410900040DbSqlContext _context;

    public HmhEmployeesController(HmhEmployee2410900040DbSqlContext context)
    {
        _context = context;
    }

    // GET: HMHEMPLOYEES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.HmhEmployees.ToListAsync());
    }

    // GET: HMHEMPLOYEES/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhemployee = await _context.HmhEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hmhemployee == null)
        {
            return NotFound();
        }

        return View(hmhemployee);
    }

    // GET: HMHEMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HMHEMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,HmhName,HmhGender,HmhBirthDay,HmhEmail,HmhPhone,HmhActive")] HmhEmployee hmhemployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hmhemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hmhemployee);
    }

    // GET: HMHEMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhemployee = await _context.HmhEmployees.FindAsync(id);
        if (hmhemployee == null)
        {
            return NotFound();
        }
        return View(hmhemployee);
    }

    // POST: HMHEMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,HmhName,HmhGender,HmhBirthDay,HmhEmail,HmhPhone,HmhActive")] HmhEmployee hmhemployee)
    {
        if (id != hmhemployee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hmhemployee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HmhEmployeeExists(hmhemployee.Id))
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
        return View(hmhemployee);
    }

    // GET: HMHEMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhemployee = await _context.HmhEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hmhemployee == null)
        {
            return NotFound();
        }

        return View(hmhemployee);
    }

    // POST: HMHEMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var hmhemployee = await _context.HmhEmployees.FindAsync(id);
        if (hmhemployee != null)
        {
            _context.HmhEmployees.Remove(hmhemployee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HmhEmployeeExists(long? id)
    {
        return _context.HmhEmployees.Any(e => e.Id == id);
    }
}
