using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class CountryHelper : ICountryHelper
    {
        private readonly ApplicationDbContext _context;

        public CountryHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Country model)
        {
            Response response = new Response() { IsSuccess = true };
            
            if (model.Id == 0)
            {
                _context.Countries.Add(model);

                response.Message = "País guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.Countries.Update(model);

                response.Message = "País actualizado(a) satisfactoriamente.!!!";
            }

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe un País con el mismo nombre.!!!";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }

                response.IsSuccess = false;
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;

                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<Country> ByNameAsync(string name)
        {
            Country model = await _context.Countries
                                            .Where(c=>c.Name==name).FirstOrDefaultAsync();
            return model;

        }

        public async Task<List<Country>> ListAsync()
        {
            List<Country> model = await _context.Countries.ToListAsync();

            return model.OrderBy(m => m.Name).ToList();
        }
    }
}