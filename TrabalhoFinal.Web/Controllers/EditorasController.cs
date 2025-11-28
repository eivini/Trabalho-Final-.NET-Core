using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal.Application.Interfaces;
using TrabalhoFinal.Application.ViewModels;

namespace TrabalhoFinal.Web.Controllers;

public class EditorasController : Controller
{
    private readonly IEditoraService _editoraService;
    private readonly ILogger<EditorasController> _logger;

    public EditorasController(IEditoraService editoraService, ILogger<EditorasController> logger)
    {
        _editoraService = editoraService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var editoras = await _editoraService.ObterTodasAsync();
        return View(editoras);
    }

    public async Task<IActionResult> Details(int id)
    {
        var editora = await _editoraService.ObterPorIdAsync(id);
        if (editora == null)
        {
            return NotFound();
        }
        return View(editora);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EditoraViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _editoraService.CriarAsync(viewModel);
                TempData["Success"] = "Editora criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar editora");
                ModelState.AddModelError("", "Erro ao criar editora. Tente novamente.");
            }
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var editora = await _editoraService.ObterPorIdAsync(id);
        if (editora == null)
        {
            return NotFound();
        }
        return View(editora);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditoraViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _editoraService.AtualizarAsync(viewModel);
                TempData["Success"] = "Editora atualizada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar editora");
                ModelState.AddModelError("", "Erro ao atualizar editora. Tente novamente.");
            }
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var editora = await _editoraService.ObterPorIdAsync(id);
        if (editora == null)
        {
            return NotFound();
        }
        return View(editora);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var result = await _editoraService.RemoverAsync(id);
            if (result)
            {
                TempData["Success"] = "Editora removida com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Editora não encontrada.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover editora");
            TempData["Error"] = "Não é possível remover uma editora que possui mangás cadastrados.";
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Buscar(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            var todasEditoras = await _editoraService.ObterTodasAsync();
            return Json(todasEditoras);
        }

        var editoras = await _editoraService.BuscarAsync(termo);
        return Json(editoras);
    }
}
