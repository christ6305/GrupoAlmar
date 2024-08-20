using APITareasPendientes.Models;
using APITareasPendientes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APITareasPendientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaModel>>> GetTareas()
        {
            var tareas = await _tareaRepository.GetAllAsync();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaModel>> GetTarea(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<TareaModel>> PostTarea(TareaModel tareaModel)
        {
            await _tareaRepository.AddAsync(tareaModel);
            return CreatedAtAction(nameof(GetTarea), new { id = tareaModel.Id }, tareaModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, TareaModel tareaModel)
        {
            if (id != tareaModel.Id)
            {
                return BadRequest();
            }

            var existeTarea = await _tareaRepository.GetByIdAsync(id);
            if (existeTarea == null)
            {
                return NotFound();
            }

            existeTarea.Id = tareaModel.Id;
            existeTarea.Titulo = tareaModel.Titulo;
            existeTarea.Descripcion = tareaModel.Descripcion;
            existeTarea.FechaVencimiento = tareaModel.FechaVencimiento;
            existeTarea.Completada = tareaModel.Completada;

            await _tareaRepository.UpdateAsync(existeTarea);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            if (!await _tareaRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _tareaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
