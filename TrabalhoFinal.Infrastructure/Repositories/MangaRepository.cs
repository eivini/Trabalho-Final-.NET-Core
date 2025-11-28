using Microsoft.EntityFrameworkCore;
using TrabalhoFinal.Domain.Entities;
using TrabalhoFinal.Infrastructure.Data;

namespace TrabalhoFinal.Infrastructure.Repositories;

public class MangaRepository : IMangaRepository
{
    private readonly AppDbContext _context;

    public MangaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Manga>> ObterTodosAsync()
    {
        return await _context.Mangas
            .Include(m => m.Editora)
            .OrderBy(m => m.Titulo)
            .ToListAsync();
    }

    public async Task<Manga?> ObterPorIdAsync(int id)
    {
        return await _context.Mangas
            .Include(m => m.Editora)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Manga> AdicionarAsync(Manga manga)
    {
        await _context.Mangas.AddAsync(manga);
        await _context.SaveChangesAsync();
        return manga;
    }

    public async Task<Manga> AtualizarAsync(Manga manga)
    {
        _context.Mangas.Update(manga);
        await _context.SaveChangesAsync();
        return manga;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var manga = await ObterPorIdAsync(id);
        if (manga == null) return false;

        _context.Mangas.Remove(manga);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Manga>> BuscarAsync(string termo)
    {
        return await _context.Mangas
            .Include(m => m.Editora)
            .Where(m => m.Titulo.Contains(termo) || 
                       m.Autor.Contains(termo) || 
                       m.Genero.Contains(termo))
            .OrderBy(m => m.Titulo)
            .ToListAsync();
    }

    public async Task<IEnumerable<Manga>> ObterPorEditoraAsync(int editoraId)
    {
        return await _context.Mangas
            .Include(m => m.Editora)
            .Where(m => m.EditoraId == editoraId)
            .OrderBy(m => m.Titulo)
            .ToListAsync();
    }
}

public interface IMangaRepository
{
    Task<IEnumerable<Manga>> ObterTodosAsync();
    Task<Manga?> ObterPorIdAsync(int id);
    Task<Manga> AdicionarAsync(Manga manga);
    Task<Manga> AtualizarAsync(Manga manga);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<Manga>> BuscarAsync(string termo);
    Task<IEnumerable<Manga>> ObterPorEditoraAsync(int editoraId);
}
