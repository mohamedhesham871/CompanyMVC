using System.Drawing;

namespace PresntaionLayer.ViewModels.DepartmentViewModels
{
    public class DepartmentViewModelEdit
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
        
        public string? Description { get; set; }
        
        public DateTime? CreatedDate { get; set; }
    }
}
