using TSVoteWeb.Common;

namespace TSVoteWeb.Helpers.Gene
{
    public interface IApiServiceHelper
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}