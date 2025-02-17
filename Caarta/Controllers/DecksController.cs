﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caarta.Data;
using Caarta.Data.Entities;
using Caarta.Services.Abstractions;

namespace Caarta.Controllers
{
    public class DecksController : Controller
    {
        private readonly IDeckService _deckService;

        public DecksController(IDeckService deckService)
        {
            _deckService = deckService;
        }

        // GET: Decks
        public async Task<IActionResult> Index()
        {
            return View(await _deckService.GetDecksAsync());
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _deckService.GetDeckByIdAsync(id.Value);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Decks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CreatorId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            return View();
        }

        // POST: Decks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CreatorId,CategoryId,LanguageId,Id")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", deck.CategoryId);
            ViewData["CreatorId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", deck.CreatorId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", deck.LanguageId);
            return View(deck);
        }

        // GET: Decks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Decks.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", deck.CategoryId);
            ViewData["CreatorId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", deck.CreatorId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", deck.LanguageId);
            return View(deck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CreatorId,CategoryId,LanguageId,Id")] Deck deck)
        {
            if (id != deck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", deck.CategoryId);
            ViewData["CreatorId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", deck.CreatorId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", deck.LanguageId);
            return View(deck);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Decks
                .Include(d => d.Category)
                .Include(d => d.Creator)
                .Include(d => d.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var deck = await _context.Decks.FindAsync(id);
            if (deck != null)
            {
                _context.Decks.Remove(deck);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
            return _context.Decks.Any(e => e.Id == id);
        }
    }
}
*/