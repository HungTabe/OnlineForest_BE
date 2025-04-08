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

        [Required]
        public int TreeCategoryId { get; set; }
        public TreeCategory TreeCategory { get; set; }

        public int? LandId { get; set; }  // Khóa ngoại đến Land, có thể null
        public Land Land { get; set; } // Mối quan hệ với Land

        public bool IsHarvest { get; set; }

        // Thêm TokenEarnId và mối quan hệ 1-1 với TokenEarn
        public int TokenEarnId { get; set; } // Khóa ngoại đến TokenEarn
        public TokenEarn TokenEarn { get; set; } // Liên kết đến TokenEarn

    }
}
