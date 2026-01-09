using System.ComponentModel.DataAnnotations;

namespace cSharp.Models;

public class Etudiant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le matricule est requis")]
    [StringLength(50)]
    public string Matricule { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le libellé est requis")]
    [StringLength(100)]
    public string Libelle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le prénom est requis")]
    [StringLength(100)]
    public string Prenom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nom est requis")]
    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    
    public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

   
    public int? ClasseId { get; set; }
    public Classe? Classe { get; set; }
}
