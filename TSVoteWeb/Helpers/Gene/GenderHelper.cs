using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class GenderHelper : IGenderHelper
    {
        private readonly ApplicationDbContext _context;

        public GenderHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Gender model)
        {
            Response response = new Response() { IsSuccess = true };
            
            if (model.Id == 0)
            {
                _context.Genders.Add(model);

                response.Message = "Género guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.Genders.Update(model);

                response.Message = "Género actualizado(a) satisfactoriamente.!!!";
            }

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe un género con el mismo nombre.!!!";
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

        public async Task<Gender> ByIdAsync(int Id)
        {
            Gender model = await _context.Genders
                                            .Where(c=>c.Id==Id).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<Gender>> ComboAsync()
        {
            List<Gender> model = await _context.Genders.ToListAsync();

            model.Add(new Gender { Id = 0, Name = $"[Seleccione un género..]" });

            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<Gender>> ListAsync()
        {
            List<Gender> model=await _context.Genders.ToListAsync();

            return model.OrderBy(c=>c.Name).ToList();
        }
    }
}