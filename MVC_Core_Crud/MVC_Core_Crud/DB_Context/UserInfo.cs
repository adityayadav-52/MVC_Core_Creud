﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Core_Crud.DB_Context
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
