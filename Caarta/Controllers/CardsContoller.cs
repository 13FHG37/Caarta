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
    public class CardsController : Controller
    {
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public CardsController(IDeckService deckService, ICardService cardService, UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _deckService = deckService;
            _cardService = cardService;
            _userManager = userManager;
            _environment = environment;
        }


        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _cardService.GetByIdAsync(id.Value);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Decks/Create
        [Authorize]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            var deck = await _deckService.GetByIdAsync(id.Value);
            if (user.Id == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && deck.CreatorId != user.Id)
            {
                return NotFound();
            }
            var cardDto = new CreateCardDTO()
            {
                DeckId = deck.Id,
            };

            return View(cardDto);
        }

        // POST: Decks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCardDTO model, int? id)
        {
            if (ModelState.IsValid)
            {
                if (model.FrontPicture != null && model.FrontPicture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(model.FrontPicture, _environment.WebRootPath);
                    model.FrontPictureUrl = newFileName;
                }
                if (model.BackPicture != null && model.BackPicture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(model.BackPicture, _environment.WebRootPath);
                    model.BackPictureUrl = newFileName;
                }
                var card = new CardDTO()
                {
                    DeckId = model.DeckId,
                    FrontText = model.FrontText,
                    BackText = model.BackText,
                    FrontPictureUrl = model.FrontPictureUrl,
                    BackPictureUrl = model.BackPictureUrl
                };
                await _cardService.CreateAsync(card);

                return RedirectToAction("Details", "Decks", new { id = card.DeckId });
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

            var card = await _cardService.GetByIdAsync(id.Value);
            if (card == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin") && card.Deck.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            var createCard = new CreateCardDTO()
            {
                CreatorId = card.Deck.CreatorId,
                DeckId = card.DeckId,
                FrontText = card.FrontText,
                BackText = card.BackText,
                FrontPictureUrl = card.FrontPictureUrl,
                BackPictureUrl = card.BackPictureUrl,
            };

            return View(createCard);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateCardDTO card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && card.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
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
                try
                {
                    await _cardService.UpdateAsync(card);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CardExistsAsync(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Decks", new { id = card.DeckId });
            }
            return View(card);
        }

        // GET: Decks/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _cardService.GetByIdAsync(id.Value);
            if (card == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Admin") && card.Deck.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Decks/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (!User.IsInRole("Admin") && card.Deck.CreatorId != (await _userManager.GetUserAsync(User)).Id)
            {
                return NotFound();
            }
            await _cardService.DeleteByIdAsync(id);
            return RedirectToAction("Details", "Decks", new { id = card.DeckId });
        }

        private async Task<bool> CardExistsAsync(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            return card != null;
        }
    }
}
