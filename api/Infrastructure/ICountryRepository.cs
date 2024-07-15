using CountriesApi.Shared;

namespace CountriesApi.Infrastructure
{
    public interface ICountryRepository
    {
        Country GetCountry(string countryCode);
    }
}