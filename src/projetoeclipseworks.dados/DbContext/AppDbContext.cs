using Microsoft.EntityFrameworkCore;
using projetoeclipseworks.Dados.Entidades;

namespace projetoeclipseworks.Dados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Projeto
            modelBuilder.Entity<Projeto>()
                .HasKey(p => p.Id); // Define a chave primária

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Nome)
                .IsRequired(); // Define a propriedade como obrigatória

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Nivel); // Configuração adicional para a propriedade Nivel

            // Configuração da entidade Tarefa
            modelBuilder.Entity<Tarefa>()
                .HasKey(t => t.Id); // Define a chave primária

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Nome)
                .IsRequired(); // Define a propriedade como obrigatória

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Finalizada); // Configuração adicional para a propriedade Finalizada

            // Configuração da entidade HistoricoAlteracao
            modelBuilder.Entity<HistoricoAlteracao>()
                .HasKey(h => h.Id); // Define a chave primária

            modelBuilder.Entity<HistoricoAlteracao>()
                .Property(h => h.DataAlteracao)
                .IsRequired(); // Define a propriedade como obrigatória

            modelBuilder.Entity<HistoricoAlteracao>()
                .Property(h => h.Alteracao)
                .IsRequired(); // Define a propriedade como obrigatória
        }
    }
}
