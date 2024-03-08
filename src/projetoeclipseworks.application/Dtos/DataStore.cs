using projetoeclipseworks.Dados.Entidades;

namespace projetoeclipseworks.Application.Dtos
{
    public static class DataStore
    {
        public static List<Projeto> Projetos { get; } = new List<Projeto>();
        public static List<Tarefa> Tarefas { get; } = new List<Tarefa>();
    }
}
