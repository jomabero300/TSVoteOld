using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface INeighborhoodSidewalkHelper
    {
        Task<Response> AddUpdateAsync(NeighborhoodSidewalk model);
        Task<NeighborhoodSidewalk> ByIdAsync(int Id);
        Task<List<NeighborhoodSidewalk>> ComboAsync(int comunaId);
        Task<List<NeighborhoodSidewalk>> ListAsync();        
    }
}