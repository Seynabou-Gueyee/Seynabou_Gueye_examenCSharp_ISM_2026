using cSharp.Models;
using cSharp.Repositories;

namespace cSharp.Services.Impl;

public class AnneeScolaireService : IAnneeScolaireService
{
    private readonly IAnneeScolaireRepository _anneeScolaireRepository;

    public AnneeScolaireService(IAnneeScolaireRepository anneeScolaireRepository)
    {
        _anneeScolaireRepository = anneeScolaireRepository;
    }

    public async Task<IEnumerable<AnneeScolaire>> GetAllAnnesScolairesAsync()
    {
        return await _anneeScolaireRepository.GetAllAsync();
    }

    public async Task<AnneeScolaire?> GetAnneeScolaireByIdAsync(int id)
    {
        return await _anneeScolaireRepository.GetByIdAsync(id);
    }

    public async Task<AnneeScolaire?> GetAnneeScolaireByCodeAsync(string code)
    {
        return await _anneeScolaireRepository.GetByCodeAsync(code);
    }

    public async Task<AnneeScolaire?> GetActiveAnneeScolaireAsync()
    {
        return await _anneeScolaireRepository.GetActiveAsync();
    }

    public async Task<AnneeScolaire> CreateAnneeScolaireAsync(AnneeScolaire anneeScolaire)
    {
        return await _anneeScolaireRepository.AddAsync(anneeScolaire);
    }

    public async Task UpdateAnneeScolaireAsync(AnneeScolaire anneeScolaire)
    {
        await _anneeScolaireRepository.UpdateAsync(anneeScolaire);
    }

    public async Task DeleteAnneeScolaireAsync(int id)
    {
        await _anneeScolaireRepository.DeleteAsync(id);
    }

    public async Task<bool> AnneeScolaireExistsAsync(int id)
    {
        return await _anneeScolaireRepository.ExistsAsync(id);
    }
}
