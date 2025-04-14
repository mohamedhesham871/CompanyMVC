using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Model
{
    public class BaseClass
    {

        public int Id { get; set; }//pk

        public int CreatedBy { get; set; }//User ID

        public DateTime? CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }//User ID

        public DateTime? LastModifiiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
