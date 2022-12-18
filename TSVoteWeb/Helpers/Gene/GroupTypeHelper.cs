using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;

namespace TSVoteWeb.Helpers.Gene
{
    public class GroupTypeHelper : IGroupTypeHelper
    {
        private readonly ApplicationDbContext _context;

        public GroupTypeHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(GroupType model)
        {
            Response response = new Response() { IsSuccess = true };
            
            if (model.Id == 0)
            {
                _context.GroupTypes.Add(model);

                response.Message = "Tipo grupo guardado(a) satisfactoriamente.!!!";
            }
            else
            {
                _context.GroupTypes.Update(model);

                response.Message = "Tipo grupo actualizado(a) satisfactoriamente.!!!";
            }

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe un tipo grupo con el mismo nombre.!!!";
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

        public async Task<GroupType> ByIdAsync(int Id) 
        {
            GroupType model = await _context.GroupTypes
                                            .Where(c=>c.Id==Id).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<GroupType>> ComboAsync()
        {
            List<GroupType> model = await _context.GroupTypes.ToListAsync();

            model.Add(new GroupType { Id = 0, Name = $"[Seleccione un grupo..]" });

            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<GroupType>> ListAsync()
        {
            List<GroupType> model=await _context.GroupTypes.ToListAsync();

            return model.OrderBy(c=>c.Name).ToList();
        }
    }
}