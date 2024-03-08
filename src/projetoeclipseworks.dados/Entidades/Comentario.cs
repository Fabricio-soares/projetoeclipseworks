using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Entidades
{
    public class Comentario
    {
        [Key]
        public Guid Id { get; set; }          

        public string Descricao { get; set; }

        public Guid IdTarefa { get; set;}
    }
}
