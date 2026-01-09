using cSharp.Models;

namespace cSharp.Services;

public interface IInscriptionService
{
    Task<IEnumerable<Inscription>> GetAllInscriptionsAsync();
    Task<Inscription?> GetInscriptionByIdAsync(int id);
    Task<IEnumerable<Inscription>> GetInscriptionsByEtudiantAsync(int etudiantId);
    Task<IEnumerable<Inscription>> GetInscriptionsByClasseAsync(int classeId);
    Task<IEnumerable<Inscription>> GetInscriptionsByAnneeScolaireAsync(int anneeScolaireId);
    Task<Inscription> CreateInscriptionAsync(Inscription inscription);
    Task UpdateInscriptionAsync(Inscription inscription);
    Task DeleteInscriptionAsync(int id);
    Task<bool> InscriptionExistsAsync(int id);
}
