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
using Caarta.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Caarta.Controllers
{
    public class DecksController : Controller
    {
        private readonly IDeckService _deckService;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly UserManager<AppUser> _userManager;

        public DecksController(IDeckService deckService, ICategoryService categoryService, ILanguageService languageService, UserManager<AppUser> userManager)
        {
            _deckService = deckService;
            _categoryService = categoryService;
            _languageService = languageService;
            _userManager = userManager;
        }

        // GET: Decks
        public async Task<IActionResult> Index()
        {
            return View(await _deckService.GetAllAsync());
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _deckService.GetByIdAsync(id.Value);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Decks/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;
            if (userId == null)
            {
                return NotFound();
            }
            var deckDto = new CreateDeckDTO()
            {
                CreatorId = userId,
                Categories = (await _categoryService.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList(),
                Languages = (await _languageService.GetAllAsync())
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text =  l.Name})
                    .ToList()
            };

            return View(deckDto);
        }

        // POST: Decks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDeckDTO model)
        {
            model.TimeOfCreation = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _deckService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("-------------------------------------------------");
            foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(modelError.ErrorMessage);
            }
            Console.WriteLine("-------------------------------------------------");
            return View(model);
        }

        // GET: Decks/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _deckService.GetByIdAsync(id.Value);
            if (deck == null)
            {
                return NotFound();
            }

            var createDeck = new CreateDeckDTO()
            {
                Name = deck.Name,
                CreatorId = deck.CreatorId,
                CategoryId = deck.CategoryId,
                LanguageId = deck.LanguageId,
                Categories = (await _categoryService.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList(),
                Languages = (await _languageService.GetAllAsync())
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList()
            };

            return View(createDeck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateDeckDTO deck)
        {
            if (id != deck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _deckService.UpdateAsync(deck);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DeckExistsAsync(deck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _deckService.GetByIdAsync(id.Value);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _deckService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DeckExistsAsync(int id)
        {
            var deck = await _deckService.GetByIdAsync(id);
            return deck != null;
        }
    }
}
