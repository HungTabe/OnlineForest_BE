using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class Land
    {
        [Key] // Đánh dấu trường là khóa chính
        public int LandId { get; set; }

        [Required] // Yêu cầu trường này không thể để trống
        public int UserId { get; set; }

        // Liên kết với bảng LandCategory (Mỗi Land thuộc một LandCategory)
        public int LandCategoryId { get; set; }
        public LandCategory LandCategory { get; set; }

        // Liên kết với bảng Tree (Một Land có thể chứa nhiều Tree)
        public List<Tree> Trees { get; set; } = new List<Tree>();

        [Required] // Yêu cầu trường này không thể để trống
        public DateTime LastPlanted { get; set; }
    }
}
