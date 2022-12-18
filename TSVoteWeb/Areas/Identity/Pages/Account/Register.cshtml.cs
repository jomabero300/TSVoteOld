// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TSVoteWeb.Data;
using TSVoteWeb.Helpers.Gene;

namespace TSVoteWeb.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICityHelper _cityHelper;
        private readonly IGenderHelper _genderHelper;
        private readonly ICommuneTownshipHelper _communeTownshipHelper;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalkHelper;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IZoneHelper zoneHelper,
            ICityHelper cityHelper,
            IGenderHelper genderHelper,
            ICommuneTownshipHelper communeTownshipHelper,
            INeighborhoodSidewalkHelper neighborhoodSidewalkHelper)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _zoneHelper = zoneHelper;
            _cityHelper = cityHelper;
            _genderHelper = genderHelper;
            _communeTownshipHelper = communeTownshipHelper;
            _neighborhoodSidewalkHelper = neighborhoodSidewalkHelper;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [EmailAddress(ErrorMessage = "El campo de correo electrónico no es una dirección válida")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Documento No")]
            [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Document { get; set; }

            [Display(Name = "Nombres")]
            [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string FirstName { get; set; }

            [Display(Name = "Apellidos")]
            [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string LastName { get; set; }

            [Display(Name = "Género")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int GenderId { get; set; }

            [Display(Name = "Municipio")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int CityId { get; set; }

            [Display(Name = "Zona")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int ZoneId { get; set; }

            [Display(Name = "Comuna/Corregimiento")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int CommuneTownshipId { get; set; }

            [Display(Name = "Barrio/Vereda")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int NeighborhoodSidewalkId { get; set; }

            [Display(Name = "Dirección")]
            [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Address { get; set; }

            [Display(Name = "Celular")]
            [MaxLength(18, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Phone { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]            
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirme contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "Id", "Name");

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name");

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name");

            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownshipHelper.ComboAsync(0,0), "Id", "Name");
            
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalkHelper.ComboAsync(0), "Id", "Name");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.Document=Input.Document;

                user.FirstName=Input.FirstName;
                
                user.LastName=Input.LastName;

                user.Address=Input.Address;

                user.NeighborhoodSidewalk=await _neighborhoodSidewalkHelper.ByIdAsync(Input.NeighborhoodSidewalkId);

                user.Gender=await _genderHelper.ByIdAsync(Input.GenderId);

                user.PhoneNumber=Input.Phone;


                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "Id", "Name",Input.GenderId);

            ViewData["CityId"] = new SelectList(await _cityHelper.ComboAsync(1), "Id", "Name",Input.CityId);

            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "Id", "Name",Input.ZoneId);

            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownshipHelper.ComboAsync(Input.ZoneId,Input.CityId), "Id", "Name",Input.CommuneTownshipId);
            
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalkHelper.ComboAsync(Input.CommuneTownshipId), "Id", "Name",Input.NeighborhoodSidewalkId);

            //If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
