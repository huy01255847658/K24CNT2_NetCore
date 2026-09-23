using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson09Lab.Models
{
    public class HmhProduct
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Ảnh sản phẩm")]
        public string? Image { get; set; }

        [NotMapped]
        [Display(Name = "Chọn ảnh sản phẩm")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh sản phẩm")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Giá gốc (VNĐ)")]
        [Required(ErrorMessage = "Giá gốc không được để trống")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá gốc phải ít nhất là 100.000 VNĐ")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi (VNĐ)")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        [Remote(action: "VerifySalePrice", controller: "HmhProduct",
            AdditionalFields = "Price",
            ErrorMessage = "Giá khuyến mãi phải nhỏ hơn giá gốc ít nhất 10%")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        [RegularExpression(
            @"^(?!.*(die|admin|fack|fuck|shit|bitch))[\s\S]*$",
            ErrorMessage = "Mô tả chứa từ ngữ không phù hợp (die, admin, fack, ...)")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục sản phẩm")]
        [Remote(action: "VerifyCategoryId", controller: "HmhProduct",
            ErrorMessage = "Danh mục không hợp lệ, vui lòng chọn lại")]
        public int CategoryId { get; set; }
    }
}
