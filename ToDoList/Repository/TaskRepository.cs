using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListContext _context;
        public TaskRepository(ToDoListContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tarefas>> Get()
        {

            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefas> GetById(int id)
        {
            return await _context.Tarefas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public void Create(Tarefas tarefas)
        {
            _context.Add(tarefas);
        }

        public void Delete(Tarefas tarefas)
        {
            _context.Remove(tarefas);
        }

        public void Update(Tarefas tarefas)
        {
            _context.Update(tarefas);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
