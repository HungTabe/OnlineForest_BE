using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class TokenEarn
    {
        [Key] // Đánh dấu trường là khóa chính
        public int TokenEarnId { get; set; }

        [Required] // Yêu cầu trường này không thể để trống
        public int UserId { get; set; }

        [Range(0, int.MaxValue)] // Đảm bảo số token không âm
        public int Tokens { get; set; }

        [Required]
        public DateTime EarnedAt { get; set; }

        [Required]
        public string Reason { get; set; }

        // Khóa ngoại đến Tree
        public int TreeId { get; set; }
        public Tree Tree { get; set; }

    }
}
