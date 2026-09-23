using System.ComponentModel.DataAnnotations;

namespace HmhLesson09Lab.Models
{
    public class HmhCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [MinLength(2, ErrorMessage = "Tên danh mục ít nhất 2 ký tự")]
        [MaxLength(100, ErrorMessage = "Tên danh mục tối đa 100 ký tự")]
        public string Name { get; set; } = string.Empty;
    }
}
