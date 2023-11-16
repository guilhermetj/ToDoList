using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repository;
using ToDoList.Services.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Tarefas> tarefas = await _service.Get();

            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Tarefas tarefa = await _service.GetById(id);

            return tarefa != null ? Ok(tarefa) : NotFound("Tarefa não encontrada");
        }
        [HttpPost]
        public async Task<IActionResult> Create(TarefaCreateEdit request)
        {
            return await _service.Create(request) ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TarefaCreateEdit request)
        {
            return await _service.Update(id, request) ? Ok("Editado com sucesso") : BadRequest("Error ao editar");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.Delete(id) ? Ok("Deletado com sucesso") : BadRequest("Error ao deletar");
        }
    }
}
