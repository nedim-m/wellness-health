﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.User
{
    public class UserSearchObj : BaseSearchObject
    {
        public string Role { get; set; } = string.Empty;
        public string? SearchName { get; set; }

        public string? Prisutan { get; set; }


    }
}
