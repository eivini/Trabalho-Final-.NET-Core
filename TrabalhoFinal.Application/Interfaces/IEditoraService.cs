using TrabalhoFinal.Application.ViewModels;

namespace TrabalhoFinal.Application.Interfaces;

public interface IEditoraService
{
    Task<IEnumerable<EditoraViewModel>> ObterTodasAsync();
    Task<EditoraViewModel?> ObterPorIdAsync(int id);
    Task<EditoraViewModel> CriarAsync(EditoraViewModel viewModel);
    Task<EditoraViewModel> AtualizarAsync(EditoraViewModel viewModel);
    Task<bool> RemoverAsync(int id);
    Task<IEnumerable<EditoraViewModel>> BuscarAsync(string termo);
}
