using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Core.Models
{
    public abstract class Base
    {
        [Key]
        public long Id { get; set; }

        public DateTime CriadoEm { get; set; }
        public long CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public long? AtualizadoPor { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public long? ExcluidoPor { get; set; }
        public bool Ativo { get; set; }
    }
}
