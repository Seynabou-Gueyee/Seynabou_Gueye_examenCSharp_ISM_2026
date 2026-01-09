using cSharp.Models;

namespace cSharp.Repositories;

public interface IInscriptionRepository
{
    Task<IEnumerable<Inscription>> GetAllAsync();
    Task<Inscription?> GetByIdAsync(int id);
    Task<IEnumerable<Inscription>> GetByEtudiantIdAsync(int etudiantId);
    Task<IEnumerable<Inscription>> GetByClasseIdAsync(int classeId);
    Task<IEnumerable<Inscription>> GetByAnneeScolaireIdAsync(int anneeScolaireId);
    Task<Inscription> AddAsync(Inscription inscription);
    Task UpdateAsync(Inscription inscription);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
