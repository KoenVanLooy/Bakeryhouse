using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BakeryHouse.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly BakeryHouseContext _context;

        public PersonalDataModel(
            UserManager<CustomUser> userManager,
            ILogger<PersonalDataModel> logger,
            BakeryHouseContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }
    }
}