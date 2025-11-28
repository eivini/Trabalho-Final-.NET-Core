using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabalhoFinal.Application.Interfaces;
using TrabalhoFinal.Application.ViewModels;

namespace TrabalhoFinal.Web.Controllers;

public class MangasController : Controller
{
    private readonly IMangaService _mangaService;
    private readonly IEditoraService _editoraService;
    private readonly ILogger<MangasController> _logger;

    public MangasController(IMangaService mangaService, IEditoraService editoraService, ILogger<MangasController> logger)
    {
        _mangaService = mangaService;
        _editoraService = editoraService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var mangas = await _mangaService.ObterTodosAsync();
        return View(mangas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var manga = await _mangaService.ObterPorIdAsync(id);
        if (manga == null)
        {
            return NotFound();
        }
        return View(manga);
    }

    public async Task<IActionResult> Create()
    {
        await CarregarEditoras();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MangaViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _mangaService.CriarAsync(viewModel);
                TempData["Success"] = "Mangá criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar mangá");
                ModelState.AddModelError("", "Erro ao criar mangá. Tente novamente.");
            }
        }
        await CarregarEditoras();
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var manga = await _mangaService.ObterPorIdAsync(id);
        if (manga == null)
        {
            return NotFound();
        }
        await CarregarEditoras();
        return View(manga);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MangaViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _mangaService.AtualizarAsync(viewModel);
                TempData["Success"] = "Mangá atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar mangá");
                ModelState.AddModelError("", "Erro ao atualizar mangá. Tente novamente.");
            }
        }
        await CarregarEditoras();
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var manga = await _mangaService.ObterPorIdAsync(id);
        if (manga == null)
        {
            return NotFound();
        }
        return View(manga);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var result = await _mangaService.RemoverAsync(id);
            if (result)
            {
                TempData["Success"] = "Mangá removido com sucesso!";
            }
            else
            {
                TempData["Error"] = "Mangá não encontrado.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover mangá");
            TempData["Error"] = "Erro ao remover mangá.";
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Buscar(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            var todosMangas = await _mangaService.ObterTodosAsync();
            return Json(todosMangas);
        }

        var mangas = await _mangaService.BuscarAsync(termo);
        return Json(mangas);
    }

    private async Task CarregarEditoras()
    {
        var editoras = await _editoraService.ObterTodasAsync();
        ViewBag.Editoras = new SelectList(editoras, "Id", "Nome");
    }
}
