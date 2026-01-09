using cSharp.Models;

namespace cSharp.Repositories;

public interface IEtudiantRepository
{
    Task<IEnumerable<Etudiant>> GetAllAsync();
    Task<Etudiant?> GetByIdAsync(int id);
    Task<Etudiant?> GetByMatriculeAsync(string matricule);
    Task<Etudiant> AddAsync(Etudiant etudiant);
    Task UpdateAsync(Etudiant etudiant);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> MatriculeExistsAsync(string matricule);
}
