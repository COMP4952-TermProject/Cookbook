using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechnicalProgrammingProject.Models;

namespace TechnicalProgrammingProject.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Profile
        public ActionResult Index(string id)
        {
            //id is not present in url
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }

            var user = db.Users.Find(id);
            //id is not found
            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new ProfileViewModel
            {
                ID = user.Id,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Biography = user.Biography,
                Age = user.Age,
                DateOfBirth = user.Birthday,
                Email = user.Email,
                Gender = user.Gender,
                ProfilePicture = user.ProfileImage
            };

            //direct to public profile view
            if (id != User.Identity.GetUserId())
            {
                return View(model); // Make a public viewModel for a profile. !!!!!!!!!!!!!!!!!!!!!!
            }

            //direct to personal profile view
            return View("~/Views/Profile/Current/index.cshtml", model);
        }

        public ActionResult Edit(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.UpdateProfileSuccess ? "Successfully updated profile."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            EditProfileViewModel model = new EditProfileViewModel();
            var user = db.Users.Find(User.Identity.GetUserId());

            if (user.ProfileImage != null)
            {
                model.Image = user.ProfileImage;
            }
            model.DisplayName = user.DisplayName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Biography = user.Biography;
            model.Age = user.Age;
            model.DateOfBirth = user.Birthday;
            model.Email = user.Email;
            model.Gender = user.Gender;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (model.ProfilePicture != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //copy to memorystream
                    model.ProfilePicture.InputStream.CopyTo(ms);
                    //store bytes inside recipe
                    byte[] image = ms.GetBuffer();
                    user.ProfileImage = image;
                }
            }

            user.DisplayName = model.DisplayName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Biography = model.Biography;
            user.Age = model.Age;
            user.Birthday = model.DateOfBirth;
            user.Email = model.Email;
            user.Gender = model.Gender;

            var result = await UserManager.UpdateAsync(user);

            if (result != null)
            {
                await HttpContext.GetOwinContext().Get<ApplicationSignInManager>().SignInAsync(user, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Edit", new { message = ManageMessageId.UpdateProfileSuccess });
            }

            AddErrors(result);
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public enum ManageMessageId
        {
            UpdateProfileSuccess,
            ChangePasswordSuccess,
            Error
        }
    }
}