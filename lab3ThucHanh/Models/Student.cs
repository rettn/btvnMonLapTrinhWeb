using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab3ThucHanh.Models
{
    public class Student
    {
        [DisplayName("Mã sinh viên")]
        public int Id { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DisplayName("Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }

        [DisplayName("Hệ đào tạo")]
        public bool IsRegular { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải trong khoảng từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // --- THÊM TRƯỜNG ĐIỂM (SCORE) ---
        [DisplayName("Điểm trung bình")]
        [Required(ErrorMessage = "Điểm số bắt buộc phải nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải là số thực từ 0.0 đến 10.0")]
        public double Score { get; set; }
    }
}