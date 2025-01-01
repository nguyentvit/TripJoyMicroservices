namespace PostManagement.Application.Dtos
{
    public class CreatePostDto
    {
        public string Content { get; set; } = string.Empty;
        public List<IFormFile>? Images { get; set; } = null;
    }

}
