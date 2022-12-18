using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class CommuneTownshipHelper : ICommuneTownshipHelper
    {
        private readonly ApplicationDbContext _context;
        public CommuneTownshipHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(CommuneTownship model)
        {
            Response response = new Response() { IsSuccess = true };
            
            string name=model.ZoneId==2?"Comuna":"Corregimiento";

            if (model.Id == 0)
            {
                _context.communeTownships.Add(model);

                response.Message = $"{name} guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.communeTownships.Update(model);

                response.Message = $"{name} actualizado(a) satisfactoriamente.!!!";
            }


            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe una {name} con el mismo nombre.!!!";
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

        public async Task<CommuneTownship> ByIdAsync(int id)
        {
            CommuneTownship model = await _context.communeTownships
                                            .Include(c=>c.Zone)
                                            .Include(d=>d.City)
                                            .Include(n=>n.NeighborhoodSidewalks)
                                            .Where(c=>c.Id==id).FirstOrDefaultAsync();

            return model;

        }

        public async Task<List<CommuneTownship>> ComboAsync(int zoneId,int cityId)
        {
            string name="Municipio y zona";
            
            Zone zona=await _context.Zones.Where(z=>z.Id==zoneId).FirstOrDefaultAsync();

            List<CommuneTownship> model = await _context.communeTownships
                                 .Where(x => x.Zone.Id == zoneId && x.City.Id==cityId).ToListAsync();
            if(model.Count()>0)
            {
                name=zona.Name=="Urbano"?"la comuna":"el corregimiento";
            }                  

            model.Add(new CommuneTownship { Id = 0, Name = $"[Seleccione {name}..]" });


            model = model.Select(x=> new CommuneTownship{
                CityId=x.CityId,
                Id=x.Id,
                Name=x.Name,
                ZoneId=x.ZoneId
            }).ToList();


            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            Response response = new Response() { IsSuccess = true };

            CommuneTownship model = await _context.communeTownships.FindAsync(id);
            
            string name=model.Zone.Name=="Urbano"?"Comuna":"Corregimiento";
            
            try
            {
                response.Message = $"{name} borrado(a) satisfactoriamente.!!!";

                _context.communeTownships.Remove(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = $"{name} no se puede eliminar porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<CommuneTownship>> ListAsync()
        {
            List<CommuneTownship> model = await _context.communeTownships.Include(z=>z.Zone).Include(c=>c.City).ToListAsync();

            return model.OrderBy(m => m.Name).ToList();
        }
    }
}