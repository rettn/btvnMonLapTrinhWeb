using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace labSession7.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [
         Display(Name = "Ho va ten"),
         Required(ErrorMessage = "Ho ten khong duoc de trong"),
         MinLength(6, ErrorMessage = "Ho ten it nhat la 6 ki tu"),
         MaxLength(20, ErrorMessage = "Ho ten toi da la 20 ki tu")   
        ]
        public string FullName { get; set; }

        [
            Display(Name = "Dia chi email"),
            Required(ErrorMessage = "Dia chi email khong duoc de trong"),
            EmailAddress(ErrorMessage = "Dia chi email khong dung dinh dang"),
            DataType(DataType.EmailAddress)
        ]
        public string Email { get; set; }
        [Display(Name = "So dien thoai")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "VerifyPhone", controller:"Account")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[ -. ]?([0-9]{3})[ -. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không đung đinh dang")]

        public string Phone { get; set; }
      

        [Display(Name = "Dia chi thuong tru")]
        [Required(ErrorMessage = "Dia chi khong duoc de trong")]
        [StringLength(35, ErrorMessage = "Dia chi khong duoc vuot qua 35 ki tu")]
        public string Address { get; set; }

        [Display(Name = "Anh dai dien")]
        public string Avatar { get; set; }
        
        [Display(Name = " Ngay sinh")]
        [Required(ErrorMessage = "Ngay sinh khong duoc de trong")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        [Display(Name = "Gioi tinh")]
        public string Gender { get; set; }

        [Display(Name = "Mat khau")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Link fb ca nhan")]
        [Required(ErrorMessage ="Linh fb khong duoc de trong")]
        [Url(ErrorMessage = "Url phai dung dinh dang")]
        public string Facebook { get; set; }
    }
}
