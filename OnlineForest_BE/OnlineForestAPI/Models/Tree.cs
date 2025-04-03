using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class Tree
    {
        [Key] // Đánh dấu trường là khóa chính
        public int TreeId { get; set; }

        [Required] // Yêu cầu trường này không thể để trống
        [StringLength(100)] // Giới hạn độ dài tối đa của trường
        public string Name { get; set; }

        [Required] // Yêu cầu trường này không thể để trống
        [StringLength(50)] // Giới hạn độ dài tối đa của trường
        public string Type { get; set; }

        [Range(1, int.MaxValue)] // Đảm bảo GrowthTime phải lớn hơn 0
        public int GrowthTime { get; set; }

        public bool IsHarvest { get; set; }

    }
}
