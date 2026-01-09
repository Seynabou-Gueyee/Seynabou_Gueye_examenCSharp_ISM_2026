using System.ComponentModel.DataAnnotations;

namespace cSharp.Models;

public class InscriptionViewModel
{
    [Required(ErrorMessage = "Le nom est requis")]
    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le prénom est requis")]
    [StringLength(100)]
    public string Prenom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le niveau est requis")]
    public string Niveau { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'année scolaire est requise")]
    [StringLength(50)]
    public string AnneeScolaire { get; set; } = string.Empty;

    [Required(ErrorMessage = "La date est requise")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Le montant est requis")]
    [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être positif")]
    public decimal Montant { get; set; }
}
