using Microsoft.EntityFrameworkCore;
using cSharp.Models;

namespace cSharp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Etudiant> Etudiants { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
    public DbSet<Classe> Classes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Etudiant>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Matricule).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Matricule).IsUnique();
            entity.Property(e => e.Libelle).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Prenom).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);

            entity.HasOne(e => e.Classe)
                  .WithMany(c => c.Etudiants)
                  .HasForeignKey(e => e.ClasseId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Classe>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Libelle).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Code).IsRequired().HasMaxLength(20);
            entity.HasIndex(c => c.Code).IsUnique();
        });

        modelBuilder.Entity<AnneeScolaire>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Libelle).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Code).IsRequired().HasMaxLength(20);
            entity.HasIndex(a => a.Code).IsUnique();
            entity.Property(a => a.Statut).IsRequired();
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Date).IsRequired();
            entity.Property(i => i.Montant).IsRequired().HasColumnType("decimal(18,2)");

            entity.HasOne(i => i.Etudiant)
                  .WithMany(e => e.Inscriptions)
                  .HasForeignKey(i => i.EtudiantId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(i => i.AnneeScolaire)
                  .WithMany(a => a.Inscriptions)
                  .HasForeignKey(i => i.AnneeScolaireId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(i => i.Classe)
                  .WithMany(c => c.Inscriptions)
                  .HasForeignKey(i => i.ClasseId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}



git init 
git add .
git commit -m "premier commit" 
git branch -M main 
git remote add origin https://github.com/Seynabou-Gueyee/examenCSharp_L3_GLRS_Semestre1_2026.git
 git push -u origin main