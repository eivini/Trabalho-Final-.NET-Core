using Mapster;
using TrabalhoFinal.Application.Interfaces;
using TrabalhoFinal.Application.ViewModels;
using TrabalhoFinal.Domain.Entities;
using TrabalhoFinal.Infrastructure.Repositories;

namespace TrabalhoFinal.Infrastructure.Services;

public class MangaService : IMangaService
{
    private readonly IMangaRepository _repository;

    public MangaService(IMangaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MangaViewModel>> ObterTodosAsync()
    {
        var mangas = await _repository.ObterTodosAsync();
        return mangas.Adapt<IEnumerable<MangaViewModel>>();
    }

    public async Task<MangaViewModel?> ObterPorIdAsync(int id)
    {
        var manga = await _repository.ObterPorIdAsync(id);
        return manga?.Adapt<MangaViewModel>();
    }

    public async Task<MangaViewModel> CriarAsync(MangaViewModel viewModel)
    {
        var manga = viewModel.Adapt<Manga>();
        manga.DataCriacao = DateTime.Now;
        
        var resultado = await _repository.AdicionarAsync(manga);
        return resultado.Adapt<MangaViewModel>();
    }

    public async Task<MangaViewModel> AtualizarAsync(MangaViewModel viewModel)
    {
        var manga = viewModel.Adapt<Manga>();
        var resultado = await _repository.AtualizarAsync(manga);
        return resultado.Adapt<MangaViewModel>();
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _repository.RemoverAsync(id);
    }

    public async Task<IEnumerable<MangaViewModel>> BuscarAsync(string termo)
    {
        var mangas = await _repository.BuscarAsync(termo);
        return mangas.Adapt<IEnumerable<MangaViewModel>>();
    }

    public async Task<IEnumerable<MangaViewModel>> ObterPorEditoraAsync(int editoraId)
    {
        var mangas = await _repository.ObterPorEditoraAsync(editoraId);
        return mangas.Adapt<IEnumerable<MangaViewModel>>();
    }
}
