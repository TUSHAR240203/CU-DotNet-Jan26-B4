using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans = new List<Loan>()
        {
            new Loan { Id = 1, BorrowerName = "Rahul", LenderName = "ABC Bank", Amount = 50000, IsSettled = false },
            new Loan { Id = 2, BorrowerName = "Priya", LenderName = "City Finance", Amount = 120000, IsSettled = true }
        };

        public IActionResult Index()
        {
            return View(loans);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return View(loan);
            }

            loan.Id = loans.Count + 1;
            loans.Add(loan);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
                return NotFound();

            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return View(loan);
            }

            var existing = loans.FirstOrDefault(x => x.Id == loan.Id);

            if (existing == null)
                return NotFound();

            existing.BorrowerName = loan.BorrowerName;
            existing.LenderName = loan.LenderName;
            existing.Amount = loan.Amount;
            existing.IsSettled = loan.IsSettled;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan != null)
            {
                loans.Remove(loan);
            }

            return RedirectToAction("Index");
        }
    }
}