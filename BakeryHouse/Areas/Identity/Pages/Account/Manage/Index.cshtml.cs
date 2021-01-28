using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BakeryHouse.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly BakeryHouseContext _context;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            BakeryHouseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Voornaam")]
            public string Voornaam { get; set; }

            [Required]
            [Display(Name = "Naam")]
            public string Naam { get; set; }

            [Required]
            [Display(Name = "Postcode")]
            public string Postcode { get; set; }

            [Required]
            [Display(Name = "Telefoon")]
            [Phone]
            public string PhoneNumber { get; set; }

        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync((CustomUser)user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync((CustomUser)user);
            
            Username = userName;

            Klant klant = await _context.Klanten.FirstOrDefaultAsync(x => x.UserId == user.Id);
            user.Klant = klant;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Naam = user.Klant.Naam,
                Voornaam = user.Klant.Voornaam,
                Email = user.Email,
                Postcode = user.Klant.Postcode
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            Klant klant = await _context.Klanten.FirstOrDefaultAsync(x => x.UserId == user.Id);
            user.Klant = klant;

            user.Klant.Voornaam = Input.Voornaam;
            user.Klant.Naam = Input.Naam;
            user.Klant.Postcode = Input.Postcode;
            user.Klant.Email = Input.Email;
            user.Klant.Telefoon = Input.PhoneNumber;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
