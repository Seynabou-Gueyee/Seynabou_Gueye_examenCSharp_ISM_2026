using cSharp.Models;
using cSharp.Repositories;

namespace cSharp.Services.Impl;

public class ClasseService : IClasseService
{
    private readonly IClasseRepository _classeRepository;

    public ClasseService(IClasseRepository classeRepository)
    {
        _classeRepository = classeRepository;
    }

    public async Task<IEnumerable<Classe>> GetAllClassesAsync()
    {
        return await _classeRepository.GetAllAsync();
    }

    public async Task<Classe?> GetClasseByIdAsync(int id)
    {
        return await _classeRepository.GetByIdAsync(id);
    }

    public async Task<Classe?> GetClasseByCodeAsync(string code)
    {
        return await _classeRepository.GetByCodeAsync(code);
    }

    public async Task<Classe> CreateClasseAsync(Classe classe)
    {
        return await _classeRepository.AddAsync(classe);
    }

    public async Task UpdateClasseAsync(Classe classe)
    {
        await _classeRepository.UpdateAsync(classe);
    }

    public async Task DeleteClasseAsync(int id)
    {
        await _classeRepository.DeleteAsync(id);
    }

    public async Task<bool> ClasseExistsAsync(int id)
    {
        return await _classeRepository.ExistsAsync(id);
    }
}
