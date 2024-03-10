using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Entidades
{
    public class Projeto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public int? Nivel { get; set; }

        public int? Status { get; set; }

        public ICollection<Tarefa>? Tarefas { get; set; } = new List<Tarefa>();
    }
}
