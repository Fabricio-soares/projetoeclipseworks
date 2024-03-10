using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Entidades
{
    public class Tarefa
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Nivel { get; set; }

        public bool Finalizada { get; set; }

        public Guid ProjetoId { get; set; }
        public Guid UsuarioResponsavelId { get; set; }
        public DateTime DataConclusao { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<HistoricoAlteracao> HistoricoAlteracoes { get; set; }
    }
}
