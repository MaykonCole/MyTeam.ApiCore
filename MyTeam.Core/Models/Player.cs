using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Core.Models
{
   public class Player : Base
    {
        
        public string Nome { get; set; }
        public string Psn { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PerfilPlayer { get; set; }
        public bool PlayerAtivo { get; set; } = true;
        public string PosicaoP { get; set; }
        public string? PosicaoA { get; set; }
        public int? Numero { get; set; }
        public string? FotoURL { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
