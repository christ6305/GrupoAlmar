using Microsoft.AspNetCore.Mvc;
using APPTareasPendientes.Models;
using APPTareasPendientes.Services;

public class TareaController : Controller
{
    private readonly TareaService _tareaService;

    public TareaController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    // Acción para mostrar la vista principal con la lista de tareas
    public async Task<IActionResult> Index()
    {
        var tareas = await _tareaService.GetAllAsync();
        return View(tareas);
    }

    // Acción para mostrar el modal de creación
    [HttpGet]
    public IActionResult Create()
    {
        return PartialView("_EditarTareaModal", new TareaModel());
    }

    // Acción para mostrar el modal de edición
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var tarea = await _tareaService.GetByIdAsync(id);
        if (tarea == null)
        {
            return NotFound();
        }
        return PartialView("_EditarTareaModal", tarea);
    }

    // Acción para manejar el envío del formulario de actualización o creación
    [HttpPost]
    public async Task<IActionResult> Update(TareaModel tarea)
    {
        if (tarea != null)
        {
            if (tarea.Id == 0)
            {
                await _tareaService.CreateAsync(tarea);
            }
            else
            {
                await _tareaService.UpdateAsync(tarea);
            }
            return RedirectToAction(nameof(Index));
        }
        return PartialView("_EditarTareaModal", tarea);
    }

    // Acción para manejar la eliminación de una tarea
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _tareaService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
