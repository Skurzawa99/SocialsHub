using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SocialsHub.Core;
using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Dtos;
using SocialsHub.Core.Services;
using SocialsHub.Core.ViewModels;
using SocialsHub.Persistance;
using SocialsHub.Persistance.Converters;
using SocialsHub.Persistance.Extensions;
using SocialsHub.Persistance.Services;
using SocialsHub.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.EntityFrameworkCore.Metadata;
using Syncfusion.EJ2.Spreadsheet;

namespace SocialsHub.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IReferenceService _referenceService;

        public ProfileController(IProfileService profileService, IReferenceService referenceService)
        {
            _profileService = profileService;
            _referenceService = referenceService;
        }

        public async Task<IActionResult> Profiles(string currentFilter, string searchString, int? pageNumber)
        {
            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            var profiles = _profileService.GetAll(searchString).ToDtos();

            var results = await PaginatedList<ProfileDto>.CreateAsync(profiles.AsNoTracking(), pageNumber ?? 1, 4);

            return View(results);
        }


        public IActionResult UserProfile(string userId = null)
        {
            if (userId == null)
                userId = User.GetUserId();

            var vm = new ProfileViewModel
            {
                ProfileDto = _profileService.Get(userId).ToDto(),
                References = _referenceService.Get(userId).ToDtos(),
            };

            return View(vm);
        }

        public IActionResult FullImage(string id)
        {
            var profile = _profileService.Get(id).ToDto();

            return PartialView("_FullImageDetails", profile);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult FullImage(ProfileViewModel viewModel)
        {
            var userId = User.GetUserId();
            var profile = _profileService.Get(userId).ToDto();
            profile.Image = _profileService.UploadFile(viewModel.Image);

            if (!ModelState.IsValid)
            {
                PartialView("_FullImageDetails", profile);
            }

            _profileService.UpdateImage(profile.Image, userId);

            return RedirectToAction("UserProfile");
        }

        public IActionResult EditDescription()
        {
 
            var userId = User.GetUserId();
            var profile = _profileService.Get(userId).ToDto();

            return PartialView("_EditDesc", profile);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditDescription(ProfileDto profile)
        {
            var userId = User.GetUserId();
            var profileDao = profile.ToDao();
            _profileService.UpdateDesc(profileDao, userId);

            return RedirectToAction("UserProfile");
        }

        public IActionResult EditIcon()
        {
            var userId = User.GetUserId();
            var icons = _profileService.Get(userId).ToDto();

            return PartialView("_EditIcon", icons);
        }


        [HttpPost]
        [Authorize]
        public IActionResult EditIcon(ProfileDto icons)
        {
            var userId = User.GetUserId();
            var iconDao = icons.ToDao();
            _profileService.UpdateIcon(iconDao, userId);

            return RedirectToAction("UserProfile");
        }

        public IActionResult AddEditReference(int id = 0)
        {
            var userId = User.GetUserId();

            var reference = id == 0 ?
                new ReferenceDto { 
                    Id = 0, 
                    UserId = userId, 
                    Enable = true,
                    CreatedDate = DateTime.Now } : _referenceService.Get(userId, id).ToDto();

            return PartialView("_AddEditReferenceDetails", reference);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditReference(ReferenceDto reference)
        {
            reference.UserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                PartialView("_AddEditReferenceDetails", reference);
            }

            var referenceDao = reference.ToDao();

            if (reference.Id == 0)
                _referenceService.Add(referenceDao);
            else
                _referenceService.Update(referenceDao);

            return RedirectToAction("UserProfile");
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteReference(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _referenceService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}
