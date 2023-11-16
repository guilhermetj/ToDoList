using ToDoList.Helpers;
using ToDoList.Models;
using ToDoList.Repository;
using ToDoList.Services.Interface;

namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Tarefas>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Tarefas> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<bool> Create(TarefaCreateEdit tarefa)
        {
            Tarefas tarefaDatabase = new Tarefas
            {
                Description = tarefa.Description,
                Title = tarefa.Title,
                Status = tarefa.Status,
            };

            _repository.Create(tarefaDatabase);

            return await _repository.SaveChangeAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var tarefaDatabase = await _repository.GetById(id);

            if (tarefaDatabase == null)
            {
                throw new NotFoundException("Tarefa não encontrada");
            }

            _repository.Delete(tarefaDatabase);
            return await _repository.SaveChangeAsync();
        }

        public async Task<bool> Update(int id, TarefaCreateEdit tarefa)
        {
            Tarefas tarefaDatabase = await _repository.GetById(id);

            if (tarefaDatabase == null)
            {
                throw new NotFoundException("Tarefa não encontrada");
            }
            tarefaDatabase.Description = tarefa.Description;
            tarefaDatabase.Title = tarefa.Title;
            tarefa.Status = tarefa.Status;
            
            _repository.Update(tarefaDatabase);
            return await _repository.SaveChangeAsync();
        }
    }
}
