namespace TouristAttraction.API.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string UrlPath { get; set; } = default!;
        public string AltText { get; set; } = default!; // Văn bản thay thế
        public DateTime DateUpLoaded { get; set; }
        public string FileType { get; set; } = default!;
        public bool Display { get; set; }
    }
}
