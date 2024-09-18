namespace TouristAttraction.API.Models
{
    public class Location
    {
        public string HouseName { get; set; } = default!; // Số nhà
        public string StreetName { get; set; } = default!; // Tên đường
        public string Ward { get; set; } = default!; // Phường/Xã
        public string District { get; set; } = default!; // Quận/Huyện
        public string CityOrProvice { get; set; } = default!; // Tỉnh/Thành phố
        public double Latitude { get; set; } // Vĩ độ
        public double Longitude { get; set; } // Kinh độ
    }
}
