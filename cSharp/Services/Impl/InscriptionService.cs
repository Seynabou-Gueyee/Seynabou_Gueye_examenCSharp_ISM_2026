using cSharp.Models;
using cSharp.Repositories;

namespace cSharp.Services.Impl;

public class InscriptionService : IInscriptionService
{
    private readonly IInscriptionRepository _inscriptionRepository;

    public InscriptionService(IInscriptionRepository inscriptionRepository)
    {
        _inscriptionRepository = inscriptionRepository;
    }

    public async Task<IEnumerable<Inscription>> GetAllInscriptionsAsync()
    {
        return await _inscriptionRepository.GetAllAsync();
    }

    public async Task<Inscription?> GetInscriptionByIdAsync(int id)
    {
        return await _inscriptionRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Inscription>> GetInscriptionsByEtudiantAsync(int etudiantId)
    {
        return await _inscriptionRepository.GetByEtudiantIdAsync(etudiantId);
    }

    public async Task<IEnumerable<Inscription>> GetInscriptionsByClasseAsync(int classeId)
    {
        return await _inscriptionRepository.GetByClasseIdAsync(classeId);
    }

    public async Task<IEnumerable<Inscription>> GetInscriptionsByAnneeScolaireAsync(int anneeScolaireId)
    {
        return await _inscriptionRepository.GetByAnneeScolaireIdAsync(anneeScolaireId);
    }

    public async Task<Inscription> CreateInscriptionAsync(Inscription inscription)
    {
        inscription.Date = DateTime.Now;
        return await _inscriptionRepository.AddAsync(inscription);
    }

    public async Task UpdateInscriptionAsync(Inscription inscription)
    {
        await _inscriptionRepository.UpdateAsync(inscription);
    }

    public async Task DeleteInscriptionAsync(int id)
    {
        await _inscriptionRepository.DeleteAsync(id);
    }

    public async Task<bool> InscriptionExistsAsync(int id)
    {
        return await _inscriptionRepository.ExistsAsync(id);
    }
}
