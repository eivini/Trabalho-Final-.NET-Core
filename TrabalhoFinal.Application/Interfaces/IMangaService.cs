using TrabalhoFinal.Application.ViewModels;

namespace TrabalhoFinal.Application.Interfaces;

public interface IMangaService
{
    Task<IEnumerable<MangaViewModel>> ObterTodosAsync();
    Task<MangaViewModel?> ObterPorIdAsync(int id);
    Task<MangaViewModel> CriarAsync(MangaViewModel viewModel);
    Task<MangaViewModel> AtualizarAsync(MangaViewModel viewModel);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<MangaViewModel>> BuscarAsync(string termo);
    Task<IEnumerable<MangaViewModel>> ObterPorEditoraAsync(int editoraId);
}
