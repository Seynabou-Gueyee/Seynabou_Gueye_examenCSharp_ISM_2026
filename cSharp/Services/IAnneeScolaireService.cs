using cSharp.Models;

namespace cSharp.Services;

public interface IAnneeScolaireService
{
    Task<IEnumerable<AnneeScolaire>> GetAllAnnesScolairesAsync();
    Task<AnneeScolaire?> GetAnneeScolaireByIdAsync(int id);
    Task<AnneeScolaire?> GetAnneeScolaireByCodeAsync(string code);
    Task<AnneeScolaire?> GetActiveAnneeScolaireAsync();
    Task<AnneeScolaire> CreateAnneeScolaireAsync(AnneeScolaire anneeScolaire);
    Task UpdateAnneeScolaireAsync(AnneeScolaire anneeScolaire);
    Task DeleteAnneeScolaireAsync(int id);
    Task<bool> AnneeScolaireExistsAsync(int id);
}
