namespace OnlineForestAPI.DTO
{
    public class LandDTO
    {
        public int LandId { get; set; }
        public int UserId { get; set; }
        public string LandSpecificName { get; set; }
        public int LandCategoryId { get; set; }
        public DateTime LastPlanted { get; set; }
    }
}
