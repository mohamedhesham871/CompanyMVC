using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapnyMVCBussinesLogic.Dto.DepartmentDtos
{
    public class DepartmentDetailsDto
    {

        public int DeptId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Lastupdate { get; set; }


        public int? LastUpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
