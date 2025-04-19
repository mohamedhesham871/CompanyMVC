using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PresntaionLayer.ViewModels.DepartmentViewModels
{
    public class CreateEditViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; } = null!;
        
        public string? Description { get; set; }
        
        public DateTime? CreatedDate { get; set; }
    }
}
