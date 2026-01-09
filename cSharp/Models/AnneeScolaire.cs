using System.ComponentModel.DataAnnotations;

namespace cSharp.Models;

public class AnneeScolaire
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le libellé est requis")]
    [StringLength(100)]
    public string Libelle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le code est requis")]
    [StringLength(20)]
    public string Code { get; set; } = string.Empty;

    [Required]
    public Statut Statut { get; set; } = Statut.ENCOURS;

    
    public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
