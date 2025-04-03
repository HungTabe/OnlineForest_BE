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

        [Required] // Yêu cầu trường này không thể để trống
        public DateTime EarnedAt { get; set; }

        [Required] // Yêu cầu trường này không thể để trống
        public string Reason { get; set; }

    }
}
