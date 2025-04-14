﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Model
{
    public class Department : BaseClass
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string? Description { get; set; }
    }
}
