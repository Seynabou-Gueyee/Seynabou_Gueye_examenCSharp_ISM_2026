using Microsoft.EntityFrameworkCore;
using cSharp.Data;
using cSharp.Models;

namespace cSharp.Repositories.Impl;

public class ClasseRepository : IClasseRepository
{
    private readonly ApplicationDbContext _context;

    public ClasseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Classe>> GetAllAsync()
    {
        return await _context.Classes
            .Include(c => c.Etudiants)
            .Include(c => c.Inscriptions)
            .OrderBy(c => c.Libelle)
            .ToListAsync();
    }

    public async Task<Classe?> GetByIdAsync(int id)
    {
        return await _context.Classes
            .Include(c => c.Etudiants)
            .Include(c => c.Inscriptions)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Classe?> GetByCodeAsync(string code)
    {
        return await _context.Classes
            .FirstOrDefaultAsync(c => c.Code == code);
    }

    public async Task<Classe> AddAsync(Classe classe)
    {
        _context.Classes.Add(classe);
        await _context.SaveChangesAsync();
        return classe;
    }

    public async Task UpdateAsync(Classe classe)
    {
        _context.Entry(classe).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var classe = await _context.Classes.FindAsync(id);
        if (classe != null)
        {
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Classes.AnyAsync(c => c.Id == id);
    }
}
