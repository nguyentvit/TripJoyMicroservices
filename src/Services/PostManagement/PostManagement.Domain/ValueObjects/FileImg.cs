using Microsoft.AspNetCore.Http;

namespace PostManagement.Domain.ValueObjects
{
    public record FileImg
    {
        public IFormFile Value { get; }
        private FileImg(IFormFile value) => Value = value;
        public static FileImg Of(IFormFile value)
        {
            if (value == null)
                throw new ArgumentException("File cannot be null.", nameof(value));

            if (value.Length == 0)
                throw new ArgumentException("File cannot be empty.", nameof(value));

            return new FileImg(value);
        }

    }
}
