using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface IGenderHelper
    {
        Task<Response> AddUpdateAsync(Gender model);
        Task<Gender> ByIdAsync(int Id);
        Task<List<Gender>> ComboAsync();
        Task<List<Gender>> ListAsync();
    }
}