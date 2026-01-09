using Microsoft.EntityFrameworkCore;
using cSharp.Data;
using cSharp.Models;

namespace cSharp.Repositories.Impl;

public class InscriptionRepository : IInscriptionRepository
{
    private readonly ApplicationDbContext _context;

    public InscriptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inscription>> GetAllAsync()
    {
        return await _context.Inscriptions
            .Include(i => i.Etudiant)
            .Include(i => i.Classe)
            .Include(i => i.AnneeScolaire)
            .OrderByDescending(i => i.Date)
            .ToListAsync();
    }

    public async Task<Inscription?> GetByIdAsync(int id)
    {
        return await _context.Inscriptions
            .Include(i => i.Etudiant)
            .Include(i => i.Classe)
            .Include(i => i.AnneeScolaire)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Inscription>> GetByEtudiantIdAsync(int etudiantId)
    {
        return await _context.Inscriptions
            .Include(i => i.Classe)
            .Include(i => i.AnneeScolaire)
            .Where(i => i.EtudiantId == etudiantId)
            .OrderByDescending(i => i.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Inscription>> GetByClasseIdAsync(int classeId)
    {
        return await _context.Inscriptions
            .Include(i => i.Etudiant)
            .Include(i => i.AnneeScolaire)
            .Where(i => i.ClasseId == classeId)
            .OrderByDescending(i => i.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Inscription>> GetByAnneeScolaireIdAsync(int anneeScolaireId)
    {
        return await _context.Inscriptions
            .Include(i => i.Etudiant)
            .Include(i => i.Classe)
            .Where(i => i.AnneeScolaireId == anneeScolaireId)
            .OrderByDescending(i => i.Date)
            .ToListAsync();
    }

    public async Task<Inscription> AddAsync(Inscription inscription)
    {
        _context.Inscriptions.Add(inscription);
        await _context.SaveChangesAsync();
        return inscription;
    }

    public async Task UpdateAsync(Inscription inscription)
    {
        _context.Entry(inscription).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var inscription = await _context.Inscriptions.FindAsync(id);
        if (inscription != null)
        {
            _context.Inscriptions.Remove(inscription);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Inscriptions.AnyAsync(i => i.Id == id);
    }
}
