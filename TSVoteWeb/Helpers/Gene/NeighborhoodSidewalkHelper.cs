using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class NeighborhoodSidewalkHelper : INeighborhoodSidewalkHelper
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodSidewalkHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(NeighborhoodSidewalk model)
        {
            Response response = new Response() { IsSuccess = true };
            
            if (model.Id == 0)
            {
                _context.NeighborhoodSidewalks.Add(model);

                response.Message = "Barrio/Vereda guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.NeighborhoodSidewalks.Update(model);

                response.Message = "Barrio/Vereda actualizado(a) satisfactoriamente.!!!";
            }

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe un Barrio/Vereda con el mismo nombre.!!!";
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

        public async Task<NeighborhoodSidewalk> ByIdAsync(int Id)
        {
            NeighborhoodSidewalk model = await _context.NeighborhoodSidewalks
                                            .Where(c=>c.Id==Id).FirstOrDefaultAsync();

            return model;

        }

        public async Task<List<NeighborhoodSidewalk>> ComboAsync(int comunaId)
        {

            string ltname="";
            
            List<NeighborhoodSidewalk> model = await _context.NeighborhoodSidewalks
                                                            .Include(n=>n.CommuneTownship)
                                                            .ThenInclude(c=>c.Zone)
                                                            .Where(n=>n.CommuneTownship.Id==comunaId).ToListAsync();


            if(model.Count()>0)
            {
                ltname=model.First().CommuneTownship.Zone.Name=="Urbano"?"el barrio":"la vereda";
            }

            model.Add(new NeighborhoodSidewalk { Id = 0, Name = $"[Seleccione {ltname}..]" });

            model = model.Select(x=> new NeighborhoodSidewalk{
                Id=x.Id,
                Name=x.Name,
            }).ToList();


            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<NeighborhoodSidewalk>> ListAsync()
        {
            List<NeighborhoodSidewalk> model=await _context.NeighborhoodSidewalks.ToListAsync();

            return model.OrderBy(c=>c.Name).ToList();
        }
    }
}