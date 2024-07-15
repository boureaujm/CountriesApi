using CountriesApi.Shared;
using Newtonsoft.Json;

namespace CountriesApi.Infrastructure
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private Dictionary<string, Country> countriesList;

        public CountryRepository(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        private void GetCountryList()
        {
            if (this.countriesList is null) {
                string webRootPath = this.webHostEnvironment.ContentRootPath;

                var jsonStr = File.ReadAllText(Path.Combine(webRootPath + "App_Data", "countries.json"));

                var countries = JsonConvert.DeserializeObject<Dictionary<string,Country>>(jsonStr);

                this.countriesList = countries is null ? new Dictionary<string, Country>() : countries;
            }
        }

        public Country GetCountry(string countryCode)
        {
            GetCountryList();

            this.countriesList.TryGetValue(countryCode, out Country country);

            return country;
        }
    }
}
