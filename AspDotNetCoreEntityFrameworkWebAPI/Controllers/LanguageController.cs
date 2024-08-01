using AspDotNetCoreEntityFrameworkWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreEntityFrameworkWebAPI.Controllers
{
    [Route("api/Languages")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguage()
        {
            var result = await (from languages in _appDbContext.Languages
                          select languages).ToListAsync();

            return Ok(result);
        } 
    }
}
