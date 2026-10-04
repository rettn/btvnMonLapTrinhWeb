using System.ComponentModel.DataAnnotations;

namespace baitapthemSession7.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm không được vượt quá 150 ký tự")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Ảnh sản phẩm không được để trống")]
        public string Image { get; set; } = "";

        [Range(100000, float.MaxValue,
            ErrorMessage = "Giá sản phẩm phải từ 100000 trở lên")]
        public float Price { get; set; }

        [Range(0, float.MaxValue,
            ErrorMessage = "Giá khuyến mãi không được âm")]
        public float SalePrice { get; set; }

        [StringLength(1500,
            ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}