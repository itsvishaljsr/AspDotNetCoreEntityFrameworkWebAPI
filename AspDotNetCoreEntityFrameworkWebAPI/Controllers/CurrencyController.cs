using AspDotNetCoreEntityFrameworkWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AspDotNetCoreEntityFrameworkWebAPI.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = _appDbContext.currencies.ToList();

            var result = await (from Currencies in _appDbContext.currencies
                                select Currencies).ToListAsync();
            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id)
        {
            var result = await _appDbContext.currencies.FindAsync(id);

            return Ok(result);
        }
        /*
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string name)
        {
            //return records if there is one or more value is matched otherwise exception
            //var result = await _appDbContext.currencies.FirstAsync(value => value.Title == name);
            
            //return records if there is one or more value is matched otherwise null
            var result = await _appDbContext.currencies.FirstOrDefaultAsync(value => value.Title == name);
           
            //return records if there is only single value is matched otherwise exception also there is exception if no value is matched
             //var result = await _appDbContext.currencies.SingleAsync(value => value.Title == name);
           
            //return records if there is only single value is matched otherwise exception if no value is matched then it will return null
            // var result = await _appDbContext.currencies.SingleOrDefaultAsync(value => value.Title == name);

            return Ok(result);
        }
        */
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameandDescription([FromRoute] string name, [FromQuery] string? description)
         {
            //   var result = await _appDbContext.currencies.FirstOrDefaultAsync(val =>
            //   val.Title == name &&
            //   (string.IsNullOrEmpty(description) || val.Description == description));


            var result = await _appDbContext.currencies.Where(val =>
            val.Title == name &&
            (string.IsNullOrEmpty(description) || val.Description == description)).ToListAsync();
            
            return Ok(result);
        }
    }
}
