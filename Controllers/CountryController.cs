using CountriesApi.Domain;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> logger;
        private readonly ICountryService countryService;

        public CountryController(
            ILogger<CountryController> logger,
            ICountryService countryService
            )
        {
            this.logger = logger;
            this.countryService = countryService;
        }

        [HttpGet]
        public ActionResult Get(string countryCode)
        {
            return this.countryService.GetCountry(countryCode)
                .ToResult("Not found: " + countryCode)
                .TapError(country =>
                {
                    this.logger.LogError($"Error when Get : {countryCode}");
                })
                .Tap(() =>
                {
                    this.logger.LogInformation($"country with this code is found:  {countryCode}");
                })
                .Finally(result =>
                {
                    return (ActionResult)(result.IsSuccess ? Ok(result.Value) : NotFound(result.Error));
                });
        }
    }
}