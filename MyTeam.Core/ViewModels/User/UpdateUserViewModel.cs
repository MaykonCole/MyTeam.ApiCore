﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Core.ViewModels.User
{
   public class UpdateUserViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool ResponsavelTime { get; set; }
    }
}
