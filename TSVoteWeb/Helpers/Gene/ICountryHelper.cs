using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface ICountryHelper
    {
        Task<Response> AddUpdateAsync(Country model);
        Task<Country> ByNameAsync(string name);
        Task<List<Country>> ListAsync();
    }
}