using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Entidades
{
    public class HistoricoAlteracao
    {
        public Guid Id { get; set; }
        public Guid TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Alteracao { get; set; }
    }
}
