using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface IGroupTypeHelper
    {
        Task<Response> AddUpdateAsync(GroupType model);
        Task<GroupType> ByIdAsync(int Id);
        Task<List<GroupType>> ComboAsync();
        Task<List<GroupType>> ListAsync();
    }
}