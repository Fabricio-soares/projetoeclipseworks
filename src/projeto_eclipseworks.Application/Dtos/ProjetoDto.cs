using static projeto_eclipseworks.Util.Enums;

namespace projeto_eclipseworks.Dtos
{
    public class ProjetoDto
    {
        public string Nome { get;  set; }
        public StatusProjeto Status { get; set; }
        public NivelPrioridade Nivel { get;  set; }
    }
}
