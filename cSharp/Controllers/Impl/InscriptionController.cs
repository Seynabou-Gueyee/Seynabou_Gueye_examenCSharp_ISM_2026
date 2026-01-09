using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using cSharp.Models;
using cSharp.Services;

namespace cSharp.Controllers.Impl;

public class InscriptionController : Controller, IInscriptionController
{
    private readonly IInscriptionService _inscriptionService;
    private readonly IEtudiantService _etudiantService;
    private readonly IClasseService _classeService;
    private readonly IAnneeScolaireService _anneeScolaireService;

    public InscriptionController(
        IInscriptionService inscriptionService,
        IEtudiantService etudiantService,
        IClasseService classeService,
        IAnneeScolaireService anneeScolaireService)
    {
        _inscriptionService = inscriptionService;
        _etudiantService = etudiantService;
        _classeService = classeService;
        _anneeScolaireService = anneeScolaireService;
    }

    // GET: Inscription
    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        const int pageSize = 5;
        var allInscriptions = await _inscriptionService.GetAllInscriptionsAsync();
        var totalInscriptions = allInscriptions.Count();
        var totalPages = (int)Math.Ceiling(totalInscriptions / (double)pageSize);
        
        var inscriptions = allInscriptions
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalInscriptions = totalInscriptions;
        
        return View(inscriptions);
    }

    // GET: Inscription/Create
    public async Task<IActionResult> Create()
    {
        var model = new InscriptionViewModel { Date = DateTime.Now };
        return View(model);
    }

    // POST: Inscription/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InscriptionViewModel model)
    {
        if (ModelState.IsValid)
        {
            var classesExistantes = await _classeService.GetAllClassesAsync();
            var classe = classesExistantes.FirstOrDefault(c => c.Code == model.Niveau);

            if (classe == null)
            {
                classe = new Classe
                {
                    Code = model.Niveau,
                    Libelle = model.Niveau
                };
                classe = await _classeService.CreateClasseAsync(classe);
            }

            var anneesScolairesExistantes = await _anneeScolaireService.GetAllAnnesScolairesAsync();
            var anneeScolaire = anneesScolairesExistantes.FirstOrDefault(a => a.Code == model.AnneeScolaire);

            if (anneeScolaire == null)
            {
                anneeScolaire = new AnneeScolaire
                {
                    Code = model.AnneeScolaire,
                    Libelle = model.AnneeScolaire,
                    Statut = Statut.ENCOURS
                };
                anneeScolaire = await _anneeScolaireService.CreateAnneeScolaireAsync(anneeScolaire);
            }

            var etudiantsExistants = await _etudiantService.GetAllEtudiantsAsync();
            var etudiant = etudiantsExistants.FirstOrDefault(e => 
                e.Nom.Equals(model.Nom, StringComparison.OrdinalIgnoreCase) && 
                e.Prenom.Equals(model.Prenom, StringComparison.OrdinalIgnoreCase));

            if (etudiant == null)
            {
                string matricule;
                bool matriculeExists;
                do
                {
                    matricule = $"ETU{DateTime.Now:yyyyMMddHHmmssfff}";
                    matriculeExists = await _etudiantService.MatriculeExistsAsync(matricule);
                } while (matriculeExists);

                etudiant = new Etudiant
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Libelle = $"{model.Prenom} {model.Nom}",
                    Matricule = matricule,
                    ClasseId = classe.Id
                };
                etudiant = await _etudiantService.CreateEtudiantAsync(etudiant);
            }

            var inscription = new Inscription
            {
                Date = model.Date,
                Montant = model.Montant,
                EtudiantId = etudiant.Id,
                ClasseId = classe.Id,
                AnneeScolaireId = anneeScolaire.Id
            };

            await _inscriptionService.CreateInscriptionAsync(inscription);
            TempData["SuccessMessage"] = "Inscription enregistrée avec succès!";
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: Inscription/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inscription = await _inscriptionService.GetInscriptionByIdAsync(id.Value);
        if (inscription == null)
        {
            return NotFound();
        }

        return View(inscription);
    }

    // GET: Inscription/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inscription = await _inscriptionService.GetInscriptionByIdAsync(id.Value);
        if (inscription == null)
        {
            return NotFound();
        }

        return View(inscription);
    }

    // POST: Inscription/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _inscriptionService.DeleteInscriptionAsync(id);
        TempData["SuccessMessage"] = "Inscription supprimée avec succès!";
        return RedirectToAction(nameof(Index));
    }
}
