using CountriesApi.Shared;
using CSharpFunctionalExtensions;

namespace CountriesApi.Domain
{
    public interface ICountryService
    {
        Maybe<Country> GetCountry(string countryCode);
    }
}