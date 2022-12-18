using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface IZoneHelper
    {
        Task<Response> AddUpdateAsync(Zone model);
        Task<List<Zone>> ComboAsync();
        Task<List<Zone>> ListAsync();
    }
}