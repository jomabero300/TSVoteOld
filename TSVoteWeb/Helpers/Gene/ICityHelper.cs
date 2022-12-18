using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public interface ICityHelper
    {
        Task<List<City>> ComboAsync(int stateId);
    }
}