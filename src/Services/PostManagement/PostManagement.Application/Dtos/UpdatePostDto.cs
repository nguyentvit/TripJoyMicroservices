namespace PostManagement.Application.Dtos
{
    public class UpdatePostDto
    {
        public string Content { get; set; } = string.Empty;
        public List<IFormFile>? Images { get; set; } = null;
    }
}
