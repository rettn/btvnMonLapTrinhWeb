using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace codeDemoSession7.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Ten Dang nhap")]
        [Required(ErrorMessage = "Ten dang nhap khong duoc de trong")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Do dai ten tu 3 - 20 ki tu" )]
        public string UserName { get; set; }

        [DisplayName("Ho va ten")]
        [Required(ErrorMessage = "Ho va ten khong duoc de trong")]
        public string FullName { get; set; }

        [DisplayName("Mat Khau")]
        [Required(ErrorMessage = "Hay nhap password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName ("Go lai mat khau")]
        [Required(ErrorMessage = "Mat khau khong khop")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Hom thu")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email khong duoc bo trong")]
        public string Email { get; set; }

        [DisplayName("Dien Thoai")]
        [RegularExpression(@"^0\d{9,12}$", ErrorMessage = "So dien thoai khong hop le")]
        public string Phone{ get; set; }

        [DisplayName("Ngay Sinh")]
        public DateTime BirthDay { get; set; }
    }
}
