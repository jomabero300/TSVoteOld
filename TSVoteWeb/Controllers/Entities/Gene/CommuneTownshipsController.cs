using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data;
using TSVoteWeb.Data.Entities.Gene;
using TSVoteWeb.Helpers.Gene;

namespace TSVoteWeb.Controllers.Entities.Gene
{
    public class CommuneTownshipsController : Controller
    {
        private readonly ICommuneTownshipHelper _communeTownshipHelper;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalkHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICityHelper _cityHelper;
        private readonly ApplicationDbContext _context;

        public CommuneTownshipsController(ICommuneTownshipHelper communeTownshipHelper, IZoneHelper zoneHelper, ICityHelper cityHelper, ApplicationDbContext context, INeighborhoodSidewalkHelper neighborhoodSidewalkHelper)
        {
            _communeTownshipHelper = communeTownshipHelper;
            _zoneHelper = zoneHelper;
            _cityHelper = cityHelper;
            _context = context;
            _neighborhoodSidewalkHelper = neighborhoodSidewalkHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CommuneTownship> model=await _communeTownshipHelper.ListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            CommuneTownship model = await _communeTownshipHelper.ByIdAsync(id);

            ViewData["ComuCorr"]=model.Zone.Name.Contains("Urban")?"Comuna":"Corregemiento";
            
            ViewData["BarrioVereda"]=model.Zone.Name.Contains("Urban")?"Barrios":"Veredas";

            return View(model);
        }

        [HttpGet]
        // GET: CategoryTypes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name");

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,ZoneId,Name")]CommuneTownship model)
        {
            if (ModelState.IsValid)
            {
                model.Name=Utilities.StartCharacterToUpper(model.Name);

                Response response = await _communeTownshipHelper.AddUpdateAsync(model);

                if (response.IsSuccess)
                {
                    TempData["AlertMessage"] = response.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name",model.ZoneId);

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name",model.CityId);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CommuneTownship model = await _communeTownshipHelper.ByIdAsync(id);

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name",model.ZoneId);

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name",model.CityId);

            ViewData["ComuCorr"]=model.Zone.Name.Contains("Urban")?"Comuna":"Corregemiento";

            ViewData["BarrioVereda"]=model.Zone.Name.Contains("Urban")?"Barrios":"Veredas";
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,CityId,ZoneId,Name")]CommuneTownship model)
        {
            if (ModelState.IsValid)
            {
                model.Name=Utilities.StartCharacterToUpper(model.Name);

                Response response = await _communeTownshipHelper.AddUpdateAsync(model);

                if (response.IsSuccess)
                {
                    TempData["AlertMessage"] = response.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name",model.ZoneId);

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name",model.CityId);
            
            ViewData["ComuCorr"]=model.Zone.Name.Contains("Urban")?"Comuna":"Corregemiento";
            
            ViewData["BarrioVereda"]=model.Zone.Name.Contains("Urban")?"Barrios":"Veredas";

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            CommuneTownship model = await _communeTownshipHelper.ByIdAsync(id);

            ViewData["ComuCorr"]=model.Zone.Name.Contains("Urban")?"Comuna":"Corregemiento";

            ViewData["BarrioVereda"]=model.Zone.Name.Contains("Urban")?"Barrios":"Veredas";
            
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Response responsed = await _communeTownshipHelper.DeleteAsync(id);
            
            TempData["AlertMessage"] = responsed.Message;

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> GetCommun(int cityId, int zoneId)
        {
            List<CommuneTownship> model=await _communeTownshipHelper.ComboAsync(zoneId,cityId);

            return Json(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetNeighborhood(int communeTownshipId)
        {
            List<NeighborhoodSidewalk> model=await _neighborhoodSidewalkHelper.ComboAsync(communeTownshipId);
            
            return Json(model);
        }
    }
}