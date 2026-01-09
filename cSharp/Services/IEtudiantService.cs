using cSharp.Models;

namespace cSharp.Services;

public interface IEtudiantService
{
    Task<IEnumerable<Etudiant>> GetAllEtudiantsAsync();
    Task<Etudiant?> GetEtudiantByIdAsync(int id);
    Task<Etudiant?> GetEtudiantByMatriculeAsync(string matricule);
    Task<Etudiant> CreateEtudiantAsync(Etudiant etudiant);
    Task UpdateEtudiantAsync(Etudiant etudiant);
    Task DeleteEtudiantAsync(int id);
    Task<bool> EtudiantExistsAsync(int id);
    Task<bool> MatriculeExistsAsync(string matricule);
}
