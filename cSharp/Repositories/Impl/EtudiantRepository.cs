using Microsoft.EntityFrameworkCore;
using cSharp.Data;
using cSharp.Models;

namespace cSharp.Repositories.Impl;

public class EtudiantRepository : IEtudiantRepository
{
    private readonly ApplicationDbContext _context;

    public EtudiantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Etudiant>> GetAllAsync()
    {
        return await _context.Etudiants
            .Include(e => e.Classe)
            .Include(e => e.Inscriptions)
            .OrderBy(e => e.Nom)
            .ToListAsync();
    }

    public async Task<Etudiant?> GetByIdAsync(int id)
    {
        return await _context.Etudiants
            .Include(e => e.Classe)
            .Include(e => e.Inscriptions)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Etudiant?> GetByMatriculeAsync(string matricule)
    {
        return await _context.Etudiants
            .Include(e => e.Classe)
            .FirstOrDefaultAsync(e => e.Matricule == matricule);
    }

    public async Task<Etudiant> AddAsync(Etudiant etudiant)
    {
        _context.Etudiants.Add(etudiant);
        await _context.SaveChangesAsync();
        return etudiant;
    }

    public async Task UpdateAsync(Etudiant etudiant)
    {
        _context.Entry(etudiant).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var etudiant = await _context.Etudiants.FindAsync(id);
        if (etudiant != null)
        {
            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Etudiants.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> MatriculeExistsAsync(string matricule)
    {
        return await _context.Etudiants.AnyAsync(e => e.Matricule == matricule);
    }
}
