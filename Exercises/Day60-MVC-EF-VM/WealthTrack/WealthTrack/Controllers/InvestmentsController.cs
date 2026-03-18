using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WealthTrack.Data;
using WealthTrack.Models;
using WealthTrack.ViewModels;

namespace WealthTrack.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly WealthTrackContext _context;

        public InvestmentsController(WealthTrackContext context)
        {
            _context = context;
        }

        // GET: Investments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investments.ToListAsync());
        }

        // GET: Investments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // GET: Investments/Create
        public IActionResult Create()
        {
            return View(new InvestmentCreateViewModel());
        }

        // POST: Investments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvestmentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Investment investment = new Investment();
                investment.TickerSymbol = vm.TickerSymbol;
                investment.AssetName = vm.TickerSymbol;
                investment.PurchasePrice = vm.Price;
                investment.Quantity = vm.Quantity;
                investment.PurchaseDate = DateTime.Now;

                _context.Investments.Add(investment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Investments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // POST: Investments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TickerSymbol,AssetName,PurchasePrice,Quantity,PurchaseDate")] Investment investment)
        {
            if (id != investment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentExists(investment.Id))
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

            return View(investment);
        }

        // GET: Investments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            if (investment != null)
            {
                _context.Investments.Remove(investment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentExists(int id)
        {
            return _context.Investments.Any(e => e.Id == id);
        }
    }
}