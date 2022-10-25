using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigurationAPI.Models;

namespace ConfigurationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ConfigurationContext _context;

        public ConfigurationsController(ConfigurationContext context)
        {
            _context = context;
        }

        // GET: api/Configurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuration>>> GetConfigurations()
        {
            return await _context.Configurations.ToListAsync();
        }

        // GET: api/Configurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> GetConfiguration(Guid id)
        {
            var configuration = await _context.Configurations.FindAsync(id);

            if (configuration == null)
            {
                return NotFound();
            }

            return configuration;
        }

        // PUT: api/Configurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguration(Guid id, Configuration configuration)
        {
            if (id != configuration.ConfigurationId)
            {
                return BadRequest();
            }

            _context.Entry(configuration).State = EntityState.Modified;
            if (configuration.CreatedOn == new DateTime())
            {
                configuration.CreatedOn = DateTime.UtcNow;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationExists(id))
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

        // POST: api/Configurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Configuration>> PostConfiguration(Configuration configuration)
        {
            if (configuration.CreatedOn == new DateTime())
            {
                configuration.CreatedOn = DateTime.UtcNow;
            }
            _context.Configurations.Add(configuration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConfiguration), new { id = configuration.ConfigurationId }, configuration);
        }

        // DELETE: api/Configurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguration(Guid id)
        {
            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }

            _context.Configurations.Remove(configuration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigurationExists(Guid id)
        {
            return _context.Configurations.Any(e => e.ConfigurationId == id);
        }
    }
}
