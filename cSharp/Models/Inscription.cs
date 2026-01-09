using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharp.Models;

public class Inscription
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La date est requise")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Le montant est requis")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être positif")]
    public decimal Montant { get; set; }

    // Relation : Une inscription appartient à un étudiant
    [Required(ErrorMessage = "L'étudiant est requis")]
    public int EtudiantId { get; set; }
    public Etudiant Etudiant { get; set; } = null!;

    // Relation : Une inscription appartient à une année scolaire
    [Required(ErrorMessage = "L'année scolaire est requise")]
    public int AnneeScolaireId { get; set; }
    public AnneeScolaire AnneeScolaire { get; set; } = null!;

    // Relation : Une inscription appartient à une classe
    [Required(ErrorMessage = "La classe est requise")]
    public int ClasseId { get; set; }
    public Classe Classe { get; set; } = null!;
}
