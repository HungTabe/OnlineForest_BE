using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class TreeCategory
    {
        [Key]
        public int TreeCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int? TreePrice { get; set; } // Số lượng money tối đa cho việc mua loại đất này

        [Range(1, int.MaxValue)] // Đảm bảo GrowthTime phải lớn hơn 0
        public int GrowthTime { get; set; }

        // Một TreeCategory có thể có nhiều Tree
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
