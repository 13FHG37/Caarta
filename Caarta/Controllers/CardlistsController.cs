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
using Caarta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Caarta.Services.Services;

namespace Caarta.Controllers
{
    public class CardlistsController : Controller
    {
        private readonly IDeckService _deckService;
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly ICardlistService _cardlistService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public CardlistsController(IDeckService deckService, ICardlistService cardlistService, ICategoryService categoryService, ILanguageService languageService, UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _deckService = deckService;
            _cardlistService = cardlistService;
            _categoryService = categoryService;
            _languageService = languageService;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Cardlists
        public async Task<IActionResult> Index()
        {
            return View(await _cardlistService.GetAllAsync());
        }

        // GET: Cardlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardlist = await _cardlistService.GetByIdAsync(id.Value);
            if (cardlist == null)
            {
                return NotFound();
            }

            return View(cardlist);
        }

        // GET: Cardlists/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {

            var userId = (await _userManager.GetUserAsync(User)).Id;
            if (userId == null)
            {
                return NotFound();
            }
            var cardlistDto = new CreateCardlistDTO()
            {
                CreatorId = userId,
                Languages = (await _languageService.GetAllAsync())
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList()
            };

            return View(cardlistDto);
        }

        // POST: Cardlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCardlistDTO model)
        {
            model.TimeOfCreation = DateTime.Now;
            if (ModelState.IsValid)
            {
                var cardlist = new CardlistDTO()
                {
                    Name = model.Name,
                    CreatorId = model.CreatorId,
                    LanguageId = model.LanguageId,
                    TimeOfCreation = model.TimeOfCreation
                };
                await _cardlistService.CreateAsync(cardlist);

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

        // GET: Cardlists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardlist = await _cardlistService.GetByIdAsync(id.Value);
            if (cardlist == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin") && cardlist.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            var createCardlist = new CreateCardlistDTO()
            {
                Name = cardlist.Name,
                CreatorId = cardlist.CreatorId,
                LanguageId = cardlist.LanguageId,
                Languages = (await _languageService.GetAllAsync())
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList(),
                IsPublic = cardlist.IsPublic,
                TimeOfCreation = cardlist.TimeOfCreation
            };

            return View(createCardlist);
        }

        // POST: Cardlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateCardlistDTO cardlist)
        {
            if (id != cardlist.Id)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && cardlist.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _cardlistService.UpdateAsync(cardlist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CardlistExistsAsync(cardlist.Id))
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
            return View(cardlist);
        }

        // GET: Cardlists/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardlist = await _cardlistService.GetByIdAsync(id.Value);
            if (cardlist == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && cardlist.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            return View(cardlist);
        }

        // POST: Cardlists/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.IsInRole("Admin") && (await _cardlistService.GetByIdAsync(id)).CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }
            await _cardlistService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CardlistExistsAsync(int id)
        {
            var cardlist = await _cardlistService.GetByIdAsync(id);
            return cardlist != null;
        }

        public async Task<IActionResult> CheckYourself(int id)
        {
            var cardlist = await _cardlistService.GetByIdAsync(id);
            if (cardlist == null)
            {
                return NotFound();
            }
            var simpleCardlist = new CardlistSimpleDTO()
            {
                Id = cardlist.Id,
                Name = cardlist.Name,
                LanguageId = cardlist.LanguageId,
                TimeOfCreation = cardlist.TimeOfCreation,
                SimpleCards = cardlist.Decks
                    .Where(d => d.Deck != null)
                    .SelectMany(d => d.Deck.Cards)
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => new CardSimpleDTO
                    {
                        FrontText = c.FrontText,
                        BackText = c.BackText,
                        FrontPictureUrl = c.FrontPictureUrl,
                        BackPictureUrl = c.BackPictureUrl
                    }).ToList()
            };

            return View(simpleCardlist);
        }

        public async Task<IActionResult> Test(int id)
        {
            var cardlist = await _cardlistService.GetByIdAsync(id);
            if (cardlist == null)
            {
                return NotFound();
            }
            var simpleCardlist = new CardlistSimpleDTO()
            {
                Id = cardlist.Id,
                Name = cardlist.Name,
                LanguageId = cardlist.LanguageId,
                TimeOfCreation = cardlist.TimeOfCreation,
                SimpleCards = cardlist.Decks
                    .Where(d => d.Deck != null)
                    .SelectMany(d => d.Deck.Cards)
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => new CardSimpleDTO
                    {
                        FrontText = c.FrontText,
                        BackText = c.BackText,
                        FrontPictureUrl = c.FrontPictureUrl,
                        BackPictureUrl = c.BackPictureUrl
                    }).ToList()
            };

            return View(simpleCardlist);
        }
        public async Task<IActionResult> TestReversed(int id)
        {
            var cardlist = await _cardlistService.GetByIdAsync(id);
            if (cardlist == null)
            {
                return NotFound();
            }
            var simpleCardlist = new CardlistSimpleDTO()
            {
                Id = cardlist.Id,
                Name = cardlist.Name,
                LanguageId = cardlist.LanguageId,
                TimeOfCreation = cardlist.TimeOfCreation,
                SimpleCards = cardlist.Decks
                    .Where(d => d.Deck != null)
                    .SelectMany(d => d.Deck.Cards)
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => new CardSimpleDTO
                    {
                        FrontText = c.FrontText,
                        BackText = c.BackText,
                        FrontPictureUrl = c.FrontPictureUrl,
                        BackPictureUrl = c.BackPictureUrl
                    }).ToList()
            };

            return View(simpleCardlist);
        }
    }
}
