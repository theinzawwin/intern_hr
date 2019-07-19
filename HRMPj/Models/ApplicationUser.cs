﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
