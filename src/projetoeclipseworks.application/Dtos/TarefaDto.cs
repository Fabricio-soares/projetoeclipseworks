
using projetoeclipseworks.Application.Util;

namespace projetoeclipseworks.Dtos
{
    public class TarefaDto
    {
        public Guid ProjetoId { get;  set; }
        public string Nome { get;  set; }
        public Enums.NivelPrioridade Nivel { get;  set; }
        public Guid UsuarioResponsavelId { get;  set; }
        public DateTime DataConclusao { get;  set; }
    }
}
