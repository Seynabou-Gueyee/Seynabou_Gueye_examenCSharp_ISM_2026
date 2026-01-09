using System.ComponentModel.DataAnnotations;

namespace cSharp.Models;

public class Classe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le libellé est requis")]
    [StringLength(100)]
    public string Libelle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le code est requis")]
    [StringLength(20)]
    public string Code { get; set; } = string.Empty;

    
    public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    
    public ICollection<Etudiant> Etudiants { get; set; } = new List<Etudiant>();
}
