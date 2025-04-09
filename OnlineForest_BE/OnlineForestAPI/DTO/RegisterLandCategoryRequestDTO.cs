namespace OnlineForestAPI.DTO
{
    public class RegisterLandCategoryRequestDTO
    {
        public int UserId { get; set; }
        public int MaxSlots { get; set; }
        public int LandPrice { get; set; }
        public string LandCategoryName { get; set; }
    }
}
