using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Core.Models
{
    public class User : Base
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        //public int? PlayerId { get; set; }
        //public Player Player { get; set; }
        public bool ResponsavelTime { get; set; }
    }
}
