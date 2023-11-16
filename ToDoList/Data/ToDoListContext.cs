using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }
        public DbSet<Tarefas> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tarefas>().ToTable("tb_task");
            modelBuilder.Entity<Tarefas>().HasKey(p => p.Id);
            modelBuilder.Entity<Tarefas>().Property(p => p.Id).HasColumnName("id").IsRequired();
            modelBuilder.Entity<Tarefas>().Property(p => p.Description).HasColumnName("description").IsRequired();
            modelBuilder.Entity<Tarefas>().Property(p => p.Title).HasColumnName("title").IsRequired();
            modelBuilder.Entity<Tarefas>().Property(p => p.Status).HasColumnName("status").IsRequired();
        }
    }
}
