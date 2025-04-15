﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapnyMVCBussinesLogic.Dto
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
