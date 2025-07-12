using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternAPI.Data;
using InternAPI.Models;
using InternAPI.Services; // ✅ Add this for VaultService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly VaultService _vaultService;

        public InternsController(AppDbContext context, VaultService vaultService)
        {
            _context = context;
            _vaultService = vaultService;
        }

        // ✅ GET: api/Interns/dbcreds (demo Vault secret access)
        [HttpGet("dbcreds")]
        public async Task<IActionResult> GetDbCreds()
        {
            var (username, password) = await _vaultService.GetDbCredentialsAsync();
            return Ok(new { username, password });
        }

        // GET: api/Interns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intern>>> GetInterns()
        {
            return await _context.Interns.ToListAsync();
        }

        // GET: api/Interns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intern>> GetIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);

            if (intern == null)
            {
                return NotFound();
            }

            return intern;
        }

        // POST: api/Interns
        [HttpPost]
        public async Task<ActionResult<Intern>> PostIntern([FromBody] Intern intern)
        {
            _context.Interns.Add(intern);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntern), new { id = intern.Id }, intern);
        }

        // PUT: api/Interns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntern(int id, [FromBody] Intern intern)
        {
            if (id != intern.Id)
            {
                return BadRequest();
            }

            var existingIntern = await _context.Interns.FindAsync(id);
            if (existingIntern == null)
            {
                return NotFound();
            }

            // Update fields
            existingIntern.Name = intern.Name;
            existingIntern.Email = intern.Email;
            existingIntern.Education = intern.Education;
            existingIntern.Phone = intern.Phone;
            existingIntern.Gender = intern.Gender;
            existingIntern.Duration = intern.Duration;

            _context.Entry(existingIntern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Interns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);
            if (intern == null)
            {
                return NotFound();
            }

            _context.Interns.Remove(intern);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternExists(int id)
        {
            return _context.Interns.Any(e => e.Id == id);
        }
    }
}
