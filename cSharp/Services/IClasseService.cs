using cSharp.Models;

namespace cSharp.Services;

public interface IClasseService
{
    Task<IEnumerable<Classe>> GetAllClassesAsync();
    Task<Classe?> GetClasseByIdAsync(int id);
    Task<Classe?> GetClasseByCodeAsync(string code);
    Task<Classe> CreateClasseAsync(Classe classe);
    Task UpdateClasseAsync(Classe classe);
    Task DeleteClasseAsync(int id);
    Task<bool> ClasseExistsAsync(int id);
}
