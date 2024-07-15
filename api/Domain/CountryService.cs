using CountriesApi.Infrastructure;
using CountriesApi.Shared;
using CSharpFunctionalExtensions;

namespace CountriesApi.Domain
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public Maybe<Country> GetCountry(string countryCode)
        {
            var country = this.countryRepository.GetCountry(countryCode);

            return country;
        }
    }
}
