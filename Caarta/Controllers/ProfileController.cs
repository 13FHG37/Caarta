using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caarta.Data;
using Caarta.Data.Entities;
using Caarta.Services.Abstractions;
using Caarta.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Caarta.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Caarta.Models;
using Caarta.Services;

namespace Caarta.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public ProfileController(UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && id != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            var createUser = new UserEditViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                ColorThemeId = user.ColorThemeId,
                ProfilePictureUrl = user.ProfilePictureUrl
            };

            return View(createUser);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && id != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                try
                {
                    user.ProfilePictureUrl = model.ProfilePictureUrl;
                    if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                    {
                        var newFileName = await FileUpload.UploadAsync(model.ProfilePicture, _environment.WebRootPath);
                        user.ProfilePictureUrl = newFileName;
                    }
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.ColorThemeId = model.ColorThemeId;
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserExistsAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Profile", new { id = user.Id });
            }
            Console.WriteLine("-------------------------------------------------");
            foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(modelError.ErrorMessage);
            }
            Console.WriteLine("-------------------------------------------------");

            return View(model);
        }

        // GET: Decks/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && id != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Decks/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && id != user.Id)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserExistsAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user != null;
        }
    }
}
