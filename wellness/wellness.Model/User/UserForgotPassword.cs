using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.User
{
    public  class UserForgotPassword
    {
        public string UserName { get; set; } = null!;
     
        public string Email { get; set; } = null!;

        public bool Mobile { get; set; } = true;
    }
}
