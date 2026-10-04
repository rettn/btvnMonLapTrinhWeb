using System.ComponentModel.DataAnnotations;

namespace baitapthemSession7.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150, ErrorMessage = "Tên danh mục không được vượt quá 150 ký tự")]
        public string Name { get; set; } = "";
    }
}