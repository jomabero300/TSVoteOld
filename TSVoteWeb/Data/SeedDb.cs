using Microsoft.EntityFrameworkCore;
using TSVoteWeb.Common;
using TSVoteWeb.Data.Entities.Gene;
using TSVoteWeb.Enum;
using TSVoteWeb.Helpers.Gene;

namespace TSVoteWeb.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly IGenderHelper _genderHelper;
        private readonly ICountryHelper _countryHelper;
        private readonly IApiServiceHelper _apiServiceHelper;

        public SeedDb(IUserHelper userHelper,
                      IZoneHelper zoneHelper,
                      IGenderHelper genderHelper,
                      ICountryHelper countryHelper,
                      ApplicationDbContext context,
                      IApiServiceHelper apiServiceHelper)
        {
            _userHelper = userHelper;
            _zoneHelper = zoneHelper;
            _genderHelper = genderHelper;
            _countryHelper = countryHelper;
            _context = context;
            _apiServiceHelper = apiServiceHelper;
        }

        public async Task SeedAsync()
        {
            await CheckZoneAsync();
            await CheckGenderAsync();
            await CheckRolesAsync();
            await CheckCountriesAsync();
        }
        private async Task CheckZoneAsync()
        {
            List<Zone> model=await _zoneHelper.ListAsync();

            if(model.Count()==0)
            {
                await _zoneHelper.AddUpdateAsync(new Zone{Name="Rural"});
                await _zoneHelper.AddUpdateAsync(new Zone{Name="Urbano"});
            }
        }
        private async Task CheckGenderAsync()
        {
            List<Gender> model=await _genderHelper.ListAsync();
            
            if(model.Count()==0)
            {
                await _genderHelper.AddUpdateAsync(new Gender{Name="Masculino"});
                await _genderHelper.AddUpdateAsync(new Gender{Name="Femenino"});
            }
        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(TypeUser.Administrador.ToString());
            await _userHelper.CheckRoleAsync(TypeUser.Coordinador.ToString());
            await _userHelper.CheckRoleAsync(TypeUser.Supervisor.ToString());
            await _userHelper.CheckRoleAsync(TypeUser.Digitador.ToString());
            await _userHelper.CheckRoleAsync(TypeUser.votante.ToString());
        }
        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Response responseCountries = await _apiServiceHelper.GetListAsync<CountryResponse>("/v1", "/countries");

                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        if (countryResponse.Name == "Colombia")
                        {


                            Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryResponse.Name);
                            if (country == null)
                            {
                                country = new() { Name = countryResponse.Name, States = new List<State>() };

                                Response responseStates = await _apiServiceHelper.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                                if (responseStates.IsSuccess)
                                {
                                    List<StateResponse> states = (List<StateResponse>)responseStates.Result;
                                    foreach (StateResponse stateResponse in states)
                                    {
                                        if (stateResponse.Name == "Arauca")
                                        {


                                            State state = country.States.FirstOrDefault(s => s.Name == stateResponse.Name);
                                            if (state == null)
                                            {
                                                state = new() { Name = stateResponse.Name, Cities = new List<City>() };
                                                Response responseCities = await _apiServiceHelper.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                                if (responseCities.IsSuccess)
                                                {
                                                    List<CityResponse> cities = (List<CityResponse>)responseCities.Result;
                                                    foreach (CityResponse cityResponse in cities)
                                                    {
                                                        if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                        {
                                                            continue;
                                                        }
                                                        City city = state.Cities.FirstOrDefault(c => c.Name == cityResponse.Name);
                                                        if (city == null)
                                                        {
                                                            state.Cities.Add(new City() { Name = cityResponse.Name });
                                                        }
                                                    }
                                                }
                                                if (state.CityNumber > 0)
                                                {
                                                    country.States.Add(state);
                                                }
                                            }
                                        }
                                    }
                                }
                                if (country.CitiesNumber > 0)
                                {
                                    _context.Countries.Add(country);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
            }            
        }
    }
}