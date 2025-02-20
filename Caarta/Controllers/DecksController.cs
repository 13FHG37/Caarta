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
using Microsoft.Extensions.Hosting;
using Caarta.Services;

namespace Caarta.Controllers
{
    public class DecksController : Controller
    {
        private readonly IDeckService _deckService;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public DecksController(IDeckService deckService, ICategoryService categoryService, ILanguageService languageService, UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _deckService = deckService;
            _categoryService = categoryService;
            _languageService = languageService;
            _userManager = userManager;
            _environment = environment;
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
                    .ToList(),
                Cards = new List<CreateCardDTO> { new CreateCardDTO() }
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
                foreach (var card in model.Cards)
                {
                    if (card.FrontPicture != null && card.FrontPicture.Length > 0)
                    {
                        var newFileName = await FileUpload.UploadAsync(card.FrontPicture, _environment.WebRootPath);
                        card.FrontPictureUrl = newFileName;
                    }
                    if (card.BackPicture != null && card.BackPicture.Length > 0)
                    {
                        var newFileName = await FileUpload.UploadAsync(card.BackPicture, _environment.WebRootPath);
                        card.BackPictureUrl = newFileName;
                    }
                    
                }
                var deck = new DeckDTO()
                {
                    Name = model.Name,
                    CreatorId = model.CreatorId,
                    CategoryId = model.CategoryId,
                    LanguageId = model.LanguageId,
                    TimeOfCreation = model.TimeOfCreation,
                    Cards = model.Cards.Select(c => new CardDTO
                    {
                        FrontText = c.FrontText,
                        BackText = c.BackText,
                        FrontPictureUrl = c.FrontPictureUrl,
                        BackPictureUrl = c.BackPictureUrl
                    }).ToList()
                };
                await _deckService.CreateAsync(deck);

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
            await _deckService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DeckExistsAsync(int id)
        {
            var deck = await _deckService.GetByIdAsync(id);
            return deck != null;
        }

        public async Task<IActionResult> Save(int id)
        {
            var deck = await _deckService.GetByIdAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Saved.Any(item => item.DeckId == id))
            {
                return NotFound();
            }
            var userSaveDeck = new UserSaveDeckDTO()
            {
                DeckId = deck.Id,
                AppUserId = user.Id,
                TimeOfSaving = DateTime.Now
            };
            await _deckService.AddUserSaveDeckAsync(userSaveDeck);
            return RedirectToAction(nameof(Index));
        }
    }
}
