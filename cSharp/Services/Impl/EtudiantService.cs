using cSharp.Models;
using cSharp.Repositories;

namespace cSharp.Services.Impl;

public class EtudiantService : IEtudiantService
{
    private readonly IEtudiantRepository _etudiantRepository;

    public EtudiantService(IEtudiantRepository etudiantRepository)
    {
        _etudiantRepository = etudiantRepository;
    }

    public async Task<IEnumerable<Etudiant>> GetAllEtudiantsAsync()
    {
        return await _etudiantRepository.GetAllAsync();
    }

    public async Task<Etudiant?> GetEtudiantByIdAsync(int id)
    {
        return await _etudiantRepository.GetByIdAsync(id);
    }

    public async Task<Etudiant?> GetEtudiantByMatriculeAsync(string matricule)
    {
        return await _etudiantRepository.GetByMatriculeAsync(matricule);
    }

    public async Task<Etudiant> CreateEtudiantAsync(Etudiant etudiant)
    {
        return await _etudiantRepository.AddAsync(etudiant);
    }

    public async Task UpdateEtudiantAsync(Etudiant etudiant)
    {
        await _etudiantRepository.UpdateAsync(etudiant);
    }

    public async Task DeleteEtudiantAsync(int id)
    {
        await _etudiantRepository.DeleteAsync(id);
    }

    public async Task<bool> EtudiantExistsAsync(int id)
    {
        return await _etudiantRepository.ExistsAsync(id);
    }

    public async Task<bool> MatriculeExistsAsync(string matricule)
    {
        return await _etudiantRepository.MatriculeExistsAsync(matricule);
    }
}
