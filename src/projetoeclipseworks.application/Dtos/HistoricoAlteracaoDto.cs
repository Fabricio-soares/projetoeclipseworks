namespace projetoeclipseworks.Application.Dtos
{
    public class HistoricoAlteracaoDto
    {
        public DateTime DataHora { get; set; }
        public string Usuario { get; set; }
        public string Acao { get; set; }
        public string Detalhes { get; set; }
    }
}
