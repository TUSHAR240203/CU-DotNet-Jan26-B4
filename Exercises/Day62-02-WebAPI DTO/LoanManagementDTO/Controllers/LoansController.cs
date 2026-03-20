using LoanManagementDTO.Data;
using LoanManagementDTO.DTO;
using LoanManagementDTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanManagementDTOContext _context;

        public LoansController(LoanManagementDTOContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoans()
        {
            var loans = await _context.Loan
                .Select(l => new LoanReadDto
                {
                    Id = l.Id,
                    BorrowerName = l.BorrowerName,
                    Amount = l.Amount,
                    LoanTermMonths = l.LoanTermMonths,
                    IsApproved = l.IsApproved
                })
                .ToListAsync();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanReadDto>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            var loanDto = new LoanReadDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return Ok(loanDto);
        }

        [HttpPost]
        public async Task<ActionResult<LoanReadDto>> CreateLoan(LoanCreateDto loanCreateDto)
        {
            var loan = new Loan
            {
                BorrowerName = loanCreateDto.BorrowerName,
                Amount = loanCreateDto.Amount,
                LoanTermMonths = loanCreateDto.LoanTermMonths,
                IsApproved = loanCreateDto.IsApproved
            };

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            var loanReadDto = new LoanReadDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loanReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, LoanUpdateDto loanUpdateDto)
        {
            if (id != loanUpdateDto.Id)
            {
                return BadRequest("Loan ID mismatch.");
            }

            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            loan.BorrowerName = loanUpdateDto.BorrowerName;
            loan.Amount = loanUpdateDto.Amount;
            loan.LoanTermMonths = loanUpdateDto.LoanTermMonths;
            loan.IsApproved = loanUpdateDto.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}