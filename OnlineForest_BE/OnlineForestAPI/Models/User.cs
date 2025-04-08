using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)] // Giới hạn độ dài tối đa của trường
        public string? Username { get; set; }

        [StringLength(100)] // Giới hạn độ dài tối đa của trường
        public string? Password { get; set; }

        [StringLength(100)] // Giới hạn độ dài tối đa của trường
        public string? Email { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastLogin { get; set; }

        // Liên kết với bảng Land (Một User có nhiều Land)
        public List<Land> Lands { get; set; } = new List<Land>();

        // Liên kết với bảng TokenEarn (Một User có thể có nhiều TokenEarn)
        public List<TokenEarn> TokenEarnings { get; set; } = new List<TokenEarn>();

        [Range(0, int.MaxValue)] // Đảm bảo giá trị TotalTokenEarn không âm
        public int? TotalTokenEarn { get; set; }
    }
}
