using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class CityHelper : ICityHelper
    {
        private readonly ApplicationDbContext _context;

        public CityHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> ComboAsync(int stateId)
        {
             List<City> model = await _context.Cities.Where(s=>s.State.Id==stateId).ToListAsync();

            model.Add(new City { Id = 0, Name = $"[Seleccione la ciudad..]" });

            return model.OrderBy(m => m.Name).ToList();
        }
    }
}