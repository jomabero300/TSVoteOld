using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class ZoneHelper : IZoneHelper
    {
        private readonly ApplicationDbContext _context;

        public ZoneHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Zone model)
        {
            Response response = new Response() { IsSuccess = true };
            
            if (model.Id == 0)
            {
                _context.Zones.Add(model);

                response.Message = "Zona guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.Zones.Update(model);

                response.Message = "Zona actualizado(a) satisfactoriamente.!!!";
            }

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe una zona con el mismo nombre.!!!";
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

        public async Task<List<Zone>> ComboAsync()
        {
            List<Zone> model = await _context.Zones.ToListAsync();

            model.Add(new Zone { Id = 0, Name = $"[Seleccione la zona..]" });

            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<Zone>> ListAsync()
        {
            List<Zone> model=await _context.Zones.ToListAsync();

            return model.OrderBy(c=>c.Name).ToList();
        }
    }
}