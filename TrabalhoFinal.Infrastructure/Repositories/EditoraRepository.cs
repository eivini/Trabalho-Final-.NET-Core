using Microsoft.EntityFrameworkCore;
using TrabalhoFinal.Domain.Entities;
using TrabalhoFinal.Infrastructure.Data;

namespace TrabalhoFinal.Infrastructure.Repositories;

public class EditoraRepository : IEditoraRepository
{
    private readonly AppDbContext _context;

    public EditoraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Editora>> ObterTodasAsync()
    {
        return await _context.Editoras
            .Include(e => e.Mangas)
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    public async Task<Editora?> ObterPorIdAsync(int id)
    {
        return await _context.Editoras
            .Include(e => e.Mangas)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Editora> AdicionarAsync(Editora editora)
    {
        await _context.Editoras.AddAsync(editora);
        await _context.SaveChangesAsync();
        return editora;
    }

    public async Task<Editora> AtualizarAsync(Editora editora)
    {
        _context.Editoras.Update(editora);
        await _context.SaveChangesAsync();
        return editora;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var editora = await ObterPorIdAsync(id);
        if (editora == null) return false;

        _context.Editoras.Remove(editora);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Editora>> BuscarAsync(string termo)
    {
        return await _context.Editoras
            .Include(e => e.Mangas)
            .Where(e => e.Nome.Contains(termo) || e.Pais.Contains(termo))
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }
}

public interface IEditoraRepository
{
    Task<IEnumerable<Editora>> ObterTodasAsync();
    Task<Editora?> ObterPorIdAsync(int id);
    Task<Editora> AdicionarAsync(Editora editora);
    Task<Editora> AtualizarAsync(Editora editora);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<Editora>> BuscarAsync(string termo);
}
