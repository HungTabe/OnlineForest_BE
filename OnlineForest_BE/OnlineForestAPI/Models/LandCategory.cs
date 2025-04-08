using System.ComponentModel.DataAnnotations;

namespace OnlineForestAPI.Models
{
    public class LandCategory
    {
        [Key]
        public int LandCategoryId { get; set; }

        [StringLength(100)]
        public string? Name { get; set; } // Tên loại đất (ví dụ: "Agricultural", "Residential")

        [Range(1, int.MaxValue)]
        public int? MaxSlots { get; set; } // Số lượng slot tối đa cho loại đất này

        [Range(1, int.MaxValue)]
        public int? LandPrice { get; set; } // Số lượng money tối đa cho việc mua loại đất này

        // Một LandCategory có thể có nhiều Land
        public List<Land> Lands { get; set; } = new List<Land>();
    }
}
