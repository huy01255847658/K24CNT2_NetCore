using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HmhLesson09Annotation.Models.DataViewModels
{
    /// <summary>
    /// Data Annotation - Validation
    /// </summary>
    public class HmhMemberRegister
    {
        public int HmhMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập có độ dài trong khoảng 2 - 20 ký tự")]
        public string HmhUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string HmhPassword { get; set; }

        [DisplayName("Hòm Thư")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string HmhEmail { get; set; }

        [DisplayName("Số điện thoại")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string HmhPhoneNumber { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string HmhFullName { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime HmhBirthday { get; set; }
    }
}