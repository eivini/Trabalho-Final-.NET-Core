using Mapster;
using TrabalhoFinal.Application.Interfaces;
using TrabalhoFinal.Application.ViewModels;
using TrabalhoFinal.Domain.Entities;
using TrabalhoFinal.Infrastructure.Repositories;

namespace TrabalhoFinal.Infrastructure.Services;

public class EditoraService : IEditoraService
{
    private readonly IEditoraRepository _repository;

    public EditoraService(IEditoraRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EditoraViewModel>> ObterTodasAsync()
    {
        var editoras = await _repository.ObterTodasAsync();
        return editoras.Adapt<IEnumerable<EditoraViewModel>>();
    }

    public async Task<EditoraViewModel?> ObterPorIdAsync(int id)
    {
        var editora = await _repository.ObterPorIdAsync(id);
        return editora?.Adapt<EditoraViewModel>();
    }

    public async Task<EditoraViewModel> CriarAsync(EditoraViewModel viewModel)
    {
        // Normalizar URL: adicionar https:// se não tiver protocolo
        if (!string.IsNullOrEmpty(viewModel.Site) && 
            !viewModel.Site.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && 
            !viewModel.Site.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            viewModel.Site = "https://" + viewModel.Site;
        }
        
        var editora = viewModel.Adapt<Editora>();
        editora.DataCriacao = DateTime.Now;
        
        var resultado = await _repository.AdicionarAsync(editora);
        return resultado.Adapt<EditoraViewModel>();
    }

    public async Task<EditoraViewModel> AtualizarAsync(EditoraViewModel viewModel)
    {
        // Normalizar URL: adicionar https:// se não tiver protocolo
        if (!string.IsNullOrEmpty(viewModel.Site) && 
            !viewModel.Site.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && 
            !viewModel.Site.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            viewModel.Site = "https://" + viewModel.Site;
        }
        
        var editora = viewModel.Adapt<Editora>();
        var resultado = await _repository.AtualizarAsync(editora);
        return resultado.Adapt<EditoraViewModel>();
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await _repository.RemoverAsync(id);
    }

    public async Task<IEnumerable<EditoraViewModel>> BuscarAsync(string termo)
    {
        var editoras = await _repository.BuscarAsync(termo);
        return editoras.Adapt<IEnumerable<EditoraViewModel>>();
    }
}
