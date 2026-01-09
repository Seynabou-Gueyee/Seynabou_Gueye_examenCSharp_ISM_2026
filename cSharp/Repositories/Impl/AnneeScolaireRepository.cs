using Microsoft.EntityFrameworkCore;
using cSharp.Data;
using cSharp.Models;

namespace cSharp.Repositories.Impl;

public class AnneeScolaireRepository : IAnneeScolaireRepository
{
    private readonly ApplicationDbContext _context;

    public AnneeScolaireRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AnneeScolaire>> GetAllAsync()
    {
        return await _context.AnneeScolaires
            .Include(a => a.Inscriptions)
            .OrderByDescending(a => a.Code)
            .ToListAsync();
    }

    public async Task<AnneeScolaire?> GetByIdAsync(int id)
    {
        return await _context.AnneeScolaires
            .Include(a => a.Inscriptions)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<AnneeScolaire?> GetByCodeAsync(string code)
    {
        return await _context.AnneeScolaires
            .FirstOrDefaultAsync(a => a.Code == code);
    }

    public async Task<AnneeScolaire?> GetActiveAsync()
    {
        return await _context.AnneeScolaires
            .FirstOrDefaultAsync(a => a.Statut == Statut.ENCOURS);
    }

    public async Task<AnneeScolaire> AddAsync(AnneeScolaire anneeScolaire)
    {
        _context.AnneeScolaires.Add(anneeScolaire);
        await _context.SaveChangesAsync();
        return anneeScolaire;
    }

    public async Task UpdateAsync(AnneeScolaire anneeScolaire)
    {
        _context.Entry(anneeScolaire).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var anneeScolaire = await _context.AnneeScolaires.FindAsync(id);
        if (anneeScolaire != null)
        {
            _context.AnneeScolaires.Remove(anneeScolaire);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.AnneeScolaires.AnyAsync(a => a.Id == id);
    }
}
