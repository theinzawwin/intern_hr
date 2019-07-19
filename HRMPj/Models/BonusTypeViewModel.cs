﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class BonusTypeViewModel
    {
        public long Id { get; set; }
        public string TypeName { get; set; }
        public int Amount { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
