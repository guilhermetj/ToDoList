using ToDoList.Models;

namespace ToDoList.Services.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<Tarefas>> Get();
        Task<Tarefas> GetById(int id);
        Task<bool> Create(TarefaCreateEdit tarefa);
        Task<bool> Update(int id, TarefaCreateEdit tarefa);
        Task<bool> Delete(int id);
    }
}
