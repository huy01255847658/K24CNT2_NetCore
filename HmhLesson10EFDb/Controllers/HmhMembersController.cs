
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HmhLesson10EFDb.Models;

public class HmhMembersController : Controller
{
    private readonly HmhLesson10EfdbContext _context;

    public HmhMembersController(HmhLesson10EfdbContext context)
    {
        _context = context;
    }

    // GET: HMHMEMBERS
    public async Task<IActionResult> Index()
    {
        var members = await _context.HmhMembers.ToListAsync();

        return View("~/Views/HmhMembers/Index.cshtml", members);
    }

    // GET: HMHMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhmember = await _context.HmhMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hmhmember == null)
        {
            return NotFound();
        }

        return View(hmhmember);
    }

    // GET: HMHMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HMHMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,HmhUserName,HmhPassword,HmhFullName,HmhEmail,HmhPhone,HmhStatus")] HmhMember hmhmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hmhmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hmhmember);
    }

    // GET: HMHMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhmember = await _context.HmhMembers.FindAsync(id);
        if (hmhmember == null)
        {
            return NotFound();
        }
        return View(hmhmember);
    }

    // POST: HMHMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,HmhUserName,HmhPassword,HmhFullName,HmhEmail,HmhPhone,HmhStatus")] HmhMember hmhmember)
    {
        if (id != hmhmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hmhmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HmhMemberExists(hmhmember.Id))
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
        return View(hmhmember);
    }

    // GET: HMHMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hmhmember = await _context.HmhMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hmhmember == null)
        {
            return NotFound();
        }

        return View(hmhmember);
    }

    // POST: HMHMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var hmhmember = await _context.HmhMembers.FindAsync(id);
        if (hmhmember != null)
        {
            _context.HmhMembers.Remove(hmhmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HmhMemberExists(long? id)
    {
        return _context.HmhMembers.Any(e => e.Id == id);
    }
}
