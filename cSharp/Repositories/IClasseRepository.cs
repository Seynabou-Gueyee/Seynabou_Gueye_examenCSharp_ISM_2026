using cSharp.Models;

namespace cSharp.Repositories;

public interface IClasseRepository
{
    Task<IEnumerable<Classe>> GetAllAsync();
    Task<Classe?> GetByIdAsync(int id);
    Task<Classe?> GetByCodeAsync(string code);
    Task<Classe> AddAsync(Classe classe);
    Task UpdateAsync(Classe classe);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
