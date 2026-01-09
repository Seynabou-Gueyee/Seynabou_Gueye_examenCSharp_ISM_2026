using cSharp.Models;

namespace cSharp.Repositories;

public interface IAnneeScolaireRepository
{
    Task<IEnumerable<AnneeScolaire>> GetAllAsync();
    Task<AnneeScolaire?> GetByIdAsync(int id);
    Task<AnneeScolaire?> GetByCodeAsync(string code);
    Task<AnneeScolaire?> GetActiveAsync();
    Task<AnneeScolaire> AddAsync(AnneeScolaire anneeScolaire);
    Task UpdateAsync(AnneeScolaire anneeScolaire);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
