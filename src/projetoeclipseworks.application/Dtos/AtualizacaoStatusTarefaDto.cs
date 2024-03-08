namespace projetoeclipseworks.Dtos
{
    public class AtualizacaoStatusTarefaDto
    {
        public bool Finalizada { get;  set; }
        public Guid UsuarioResponsavelId { get;  set; }
        public DateTime DataConclusao { get;  set; }
        public List<string> Comentarios { get; set; } = new List<string>();
    }
}
