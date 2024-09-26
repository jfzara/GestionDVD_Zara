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

    

    public class UtilisateursController : Controller
    {
        private readonly ApplicationDbContext _context;
        private bool DVDExists(int id)
        {
            return _context.DVDs.Any(e => e.Id == id);
        }
        public UtilisateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utilisateurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilisateurs.ToListAsync());
        }

        // GET: Utilisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Utilisateur == null)
            {
                return NotFound();
            }

            return View(Utilisateur);
        }

        // GET: Utilisateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prenom,Courriel,MotDePasse,RecevoirNotifications")] Utilisateur Utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Utilisateur);
        }


        // GET: Utilisateurs/Login
        public IActionResult Login()
        {
            return View(); // Cela retournera Login.cshtml
        }

        // POST: Utilisateurs/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Vérifiez si l'utilisateur existe dans la base de données
                var Utilisateur = await _context.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Courriel == model.Courriel && u.MotDePasse == model.MotDePasse);

                if (Utilisateur != null)
                {
                    // Si la connexion réussit, redirigez l'utilisateur
                    // Vous pouvez aussi stocker des informations de session ou un jeton JWT ici
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Ajoutez une erreur si les identifiants sont incorrects
                    ModelState.AddModelError(string.Empty, "Identifiants incorrects. Veuillez réessayer.");
                }
            }
            // Si le modèle n'est pas valide ou si la connexion échoue, retournez le modèle avec des erreurs
            return View(model);
        }



        // GET: Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (Utilisateur == null)
            {
                return NotFound();
            }
            return View(Utilisateur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitreFrancais,TitreOriginal,AnneeSortie,Categorie,DerniereMiseAJour,DerniereMiseAJourPar,DescriptionSuppléments,Duree,EstDVDOriginal,Format,LanguesDisponibles,NombreDisques,NomProducteur,NomRealisateur,ActeursPrincipaux,ResumeFilm,SousTitresDisponibles,PropriétaireId,EmprunteurId,VersionEtendue,VisibleATous")] DVD dvd)
        {
            if (id != dvd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDExists(dvd.Id))
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
            return View(dvd);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Utilisateur == null)
            {
                return NotFound();
            }

            return View(Utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (Utilisateur != null)
            {
                _context.Utilisateurs.Remove(Utilisateur);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Utilisateurs/Register
        public IActionResult Register()
        {
            return View(); // Cela retournera Register.cshtml
        }

        // POST: Utilisateurs/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Prenom,Courriel,MotDePasse,RecevoirNotifications")] Utilisateur Utilisateur)
        {
            if (ModelState.IsValid)
            {
                // Vérifiez si l'utilisateur existe déjà
                if (_context.Utilisateurs.Any(u => u.Courriel == Utilisateur.Courriel))
                {
                    ModelState.AddModelError("Courriel", "Cet e-mail est déjà utilisé.");
                    return View(Utilisateur);
                }

                _context.Add(Utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login)); // Redirige vers la page de connexion après l'inscription
            }
            return View(Utilisateur);
        }
        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateurs.Any(e => e.Id == id);
        }
    }
}