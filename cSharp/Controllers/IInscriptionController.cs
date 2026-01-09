using Microsoft.AspNetCore.Mvc;
using cSharp.Models;

namespace cSharp.Controllers;

public interface IInscriptionController
{
    Task<IActionResult> Index(int pageNumber = 1);
    Task<IActionResult> Create();
    Task<IActionResult> Create(InscriptionViewModel model);
    Task<IActionResult> Details(int? id);
    Task<IActionResult> Delete(int? id);
    Task<IActionResult> DeleteConfirmed(int id);
}
