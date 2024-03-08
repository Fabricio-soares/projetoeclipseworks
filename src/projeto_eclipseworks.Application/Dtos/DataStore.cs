using projeto_eclipseworks.Dados.Entidades;

namespace projeto_eclipseworks.Application.Dtos
{
    public static class DataStore
    {
        public static List<Projeto> Projetos { get; } = new List<Projeto>();
        public static List<Tarefa> Tarefas { get; } = new List<Tarefa>();
    }
}
