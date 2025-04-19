using MVCCompanyDataAccess.Model.Enums;
using MVCCompanyDataAccess.Model.Shaerd;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Model
{
    public class Empolyee:BaseClass
    {       
        public string Name { get; set; } = null!;
        
        public int Age { get; set; }
        
        public string? Address { get; set; } 
        
        public bool IsActive { get; set; }
        
        public decimal Salary { get; set; }
        
        public string ?Email { get; set; } 
        
        public string ?PhoneNumber { get; set; }
        
        public DateTime HiringDate { get; set; }
        
        public Gender Gender { get; set; }
        
        public EmployeeType EmployeeType { get; set; }

        #region Relation work  [one employee to one Department ]
        //fk
        public int? DepartmentId { set; get; } // make it later Required
        public Department? department { set; get; } // make it later Required 
        #endregion
    }

}
