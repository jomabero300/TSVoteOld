using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface ICommuneTownshipHelper
    {
        Task<Response> AddUpdateAsync(CommuneTownship model);
        Task<CommuneTownship> ByIdAsync(int id);
        Task<List<CommuneTownship>> ComboAsync(int ZoneId,int CityId);
        Task<Response> DeleteAsync(int id);
        Task<List<CommuneTownship>> ListAsync();        
    }
}