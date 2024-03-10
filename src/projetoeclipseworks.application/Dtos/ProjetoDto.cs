using static projetoeclipseworks.Application.Util.Enums;

namespace projetoeclipseworks.Dtos
{
    public class ProjetoDto
    {
        public string Nome { get;  set; }
        public StatusProjeto Status { get; set; }
        public NivelPrioridade Nivel { get;  set; }
    }
}
