using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonalizationServiceAPI.Data;
using PersonalizationServiceAPI.Models;
using System.Security.Claims;

namespace PersonalizationServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalizationController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<PersonalizationController> _logger;
        public PersonalizationController(IConfiguration configuration, AppDBContext db_context, ILogger<PersonalizationController> logger)
        {
            _context = db_context;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> SetPersonalizationSettings([FromBody] PersonalizationSettings settings)
        {
            if (settings != null)
            {
                PersonalizationSettings new_settings = new PersonalizationSettings()
                {
                    
                    UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    EmailNotifications = settings.EmailNotifications,
                    NightMode = settings.NightMode
                };

                _context.Settings.Add(new_settings);
                await _context.SaveChangesAsync();
                return Ok(new { id = new_settings.UserId, message = "Settings updated successfully." });
            }
            return BadRequest("Event parameters are invalid.");

        }
        [Authorize]
        [HttpGet]
        
        public async Task<ActionResult> GetPersonalizationSettings()
        {

            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId))
            {
                return Unauthorized("User authentication failed.");
            }

            PersonalizationSettings sett = await _context.Settings.FirstOrDefaultAsync(u => u.UserId == userId);
            if (sett == null)
            {
                return NotFound("Settings not found or you don't have permission to access this settings.");
            }
            return Ok(sett);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> EditPersonalizationSettings([FromBody] PersonalizationSettingsObject settings)
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId))
            {
                return Unauthorized("User authentication failed.");
            }
            if (settings != null)
            {
                PersonalizationSettings set = await _context.Settings.FirstOrDefaultAsync(u => u.UserId == userId);
                set.EmailNotifications = settings.EmailNotifications;
                set.NightMode = settings.NightMode;
    
                
                await _context.SaveChangesAsync();
                return Ok(new { id = set.UserId, message = "Settings updated successfully." });
            }
            return BadRequest("Event parameters are invalid.");

        }
    }
}
