using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tarefas>> Get();
        Task<Tarefas> GetById(int id);
        void Create(Tarefas tarefas);
        void Delete(Tarefas tarefas);
        void Update(Tarefas tarefas);
        Task<bool> SaveChangeAsync();
    }
}
