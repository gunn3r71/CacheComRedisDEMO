using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Countries.API.Models.Countries.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Countries.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private const string COUNTRIES_KEY = "Countries";

        public CountriesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (_memoryCache.TryGetValue(COUNTRIES_KEY, out IEnumerable<CountryViewModel> countries))
                {
                    return Ok(countries);
                }
                else
                {
                    const string countriesUrl = "https://restcountries.eu/rest/v2/all";
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.GetAsync(countriesUrl);
                        var responseData = await response.Content.ReadAsStringAsync();
                        var countriesFromAPI =
                            JsonConvert.DeserializeObject<IEnumerable<CountryViewModel>>(responseData);
                        var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = new TimeSpan(0,0,0,30),
                            SlidingExpiration = new TimeSpan(0,0,1,0)
                        };

                        _memoryCache.Set(COUNTRIES_KEY, countriesFromAPI, memoryCacheEntryOptions);

                        return Ok(countriesFromAPI);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
