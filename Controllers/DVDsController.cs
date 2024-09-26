using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zara_GestionDVD.Data;
using Zara_GestionDVD.Models;

namespace Zara_GestionDVD.Controllers
{
    public class DVDsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool DVDExists(int id)
        {
            return _context.DVDs.Any(e => e.Id == id);
        }
        public DVDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DVDs
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = GetCategories();
            return View(await _context.DVDs.ToListAsync());
        }

        // GET: DVDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVDs.FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View(new DVD());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitreFrancais,TitreOriginal,AnneeSortie,Categorie,DerniereMiseAJour,DerniereMiseAJourPar,DescriptionSuppléments,Duree,EstDVDOriginal,Format,ImagePochette,LanguesDisponibles,NombreDisques,NomProducteur,NomRealisateur,ActeursPrincipaux,ResumeFilm,SousTitresDisponibles,PropriétaireId,EmprunteurId,VersionEtendue,VisibleATous")] DVD dVD)
        {
            // Vérification si la catégorie est valide
            if (!GetCategories().Any(c => c.Value == dVD.Categorie))
            {
                ModelState.AddModelError("Categorie", "La catégorie sélectionnée n'est pas valide.");
            }

        
            if (dVD.Duree.TotalMinutes <= 0)
            {
                ModelState.AddModelError("Duree", "La durée doit être supérieure à zéro minutes.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(dVD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = GetCategories();
            return View(dVD);
        }

        private List<SelectListItem> GetCategories()
        {
            return new List<SelectListItem>
    {
        new SelectListItem { Value = "Action", Text = "Action" },
        new SelectListItem { Value = "Adolescent", Text = "Adolescent" },
        new SelectListItem { Value = "Biographie", Text = "Biographie" },
        new SelectListItem { Value = "Cape et d'épée", Text = "Cape et d'épée" },
        new SelectListItem { Value = "Catastrophe", Text = "Catastrophe" },
        new SelectListItem { Value = "Chronique", Text = "Chronique" },
        new SelectListItem { Value = "Comédie de mœurs", Text = "Comédie de mœurs" },
        new SelectListItem { Value = "Comédie d'horreur", Text = "Comédie d'horreur" },
        new SelectListItem { Value = "Comédie dramatique", Text = "Comédie dramatique" },
        new SelectListItem { Value = "Comédie fantaisiste", Text = "Comédie fantaisiste" },
        new SelectListItem { Value = "Comédie musicale", Text = "Comédie musicale" },
        new SelectListItem { Value = "Comédie policière", Text = "Comédie policière" },
        new SelectListItem { Value = "Comédie satirique", Text = "Comédie satirique" },
        new SelectListItem { Value = "Comédie sentimentale", Text = "Comédie sentimentale" },
        new SelectListItem { Value = "Comédie", Text = "Comédie" },
        new SelectListItem { Value = "Criminel", Text = "Criminel" },
        new SelectListItem { Value = "Danse", Text = "Danse" },
        new SelectListItem { Value = "Dessins animés", Text = "Dessins animés" },
        new SelectListItem { Value = "Documentaire", Text = "Documentaire" },
        new SelectListItem { Value = "Drame de guerre", Text = "Drame de guerre" },
        new SelectListItem { Value = "Drame de mœurs", Text = "Drame de mœurs" },
        new SelectListItem { Value = "Drame d'horreur", Text = "Drame d'horreur" },
        new SelectListItem { Value = "Drame judiciaire", Text = "Drame judiciaire" },
        new SelectListItem { Value = "Drame musical", Text = "Drame musical" },
        new SelectListItem { Value = "Drame poétique", Text = "Drame poétique" },
        new SelectListItem { Value = "Drame policier", Text = "Drame policier" },
        new SelectListItem { Value = "Drame psychologique", Text = "Drame psychologique" },
        new SelectListItem { Value = "Drame sentimental", Text = "Drame sentimental" },
        new SelectListItem { Value = "Drame social", Text = "Drame social" },
        new SelectListItem { Value = "Drame", Text = "Drame" },
        new SelectListItem { Value = "Espionnage", Text = "Espionnage" },
        new SelectListItem { Value = "Expérimental", Text = "Expérimental" },
        new SelectListItem { Value = "Fantastique", Text = "Fantastique" },
        new SelectListItem { Value = "Film à sketches", Text = "Film à sketches" },
        new SelectListItem { Value = "Film d'animation", Text = "Film d'animation" },
        new SelectListItem { Value = "Film d'art martial", Text = "Film d'art martial" },
        new SelectListItem { Value = "Historique", Text = "Historique" },
        new SelectListItem { Value = "Horreur", Text = "Horreur" },
        new SelectListItem { Value = "Humoristique", Text = "Humoristique" },
        new SelectListItem { Value = "Marionnettes", Text = "Marionnettes" },
        new SelectListItem { Value = "Mélodrame", Text = "Mélodrame" },
        new SelectListItem { Value = "Musical", Text = "Musical" },
        new SelectListItem { Value = "Road movie", Text = "Road movie" },
        new SelectListItem { Value = "Romantique", Text = "Romantique" },
        new SelectListItem { Value = "Science-fiction", Text = "Science-fiction" },
        new SelectListItem { Value = "Série policière", Text = "Série policière" },
        new SelectListItem { Value = "Série TV", Text = "Série TV" },
        new SelectListItem { Value = "Spectacle d'humour", Text = "Spectacle d'humour" },
        new SelectListItem { Value = "Spectacle musical", Text = "Spectacle musical" },
        new SelectListItem { Value = "Suspense", Text = "Suspense" },
        new SelectListItem { Value = "Western", Text = "Western" }
    };
        }

        // GET: DVDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVDs.FindAsync(id);
            if (dVD == null)
            {
                return NotFound();
            }
            ViewBag.Categories = GetCategories();
            return View(dVD);
        }

        // POST: DVDs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitreFrancais,TitreOriginal,AnneeSortie,Categorie,DerniereMiseAJour,DerniereMiseAJourPar,DescriptionSuppléments,Duree,EstDVDOriginal,Format,ImagePochette,LanguesDisponibles,NombreDisques,NomProducteur,NomRealisateur,ActeursPrincipaux,ResumeFilm,SousTitresDisponibles,PropriétaireId,EmprunteurId,VersionEtendue,VisibleATous")] DVD dVD)
        {
            if (id != dVD.Id)
            {
                return NotFound();
            }

            // Vérifiez si la catégorie est valide
            if (!GetCategories().Any(c => c.Value == dVD.Categorie))
            {
                ModelState.AddModelError("Categorie", "La catégorie sélectionnée n'est pas valide.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDExists(dVD.Id))
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
            ViewBag.Categories = GetCategories();
            return View(dVD);
        }

        // GET: DVDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVDs.FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        // POST: DVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dVD = await _context.DVDs.FindAsync(id);
            if (dVD != null) // Vérifiez si l'entité n'est pas null avant de la supprimer
            {
                _context.DVDs.Remove(dVD);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Gérer le cas où l'entité est null (par exemple, rediriger vers Index avec un message d'erreur)
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}