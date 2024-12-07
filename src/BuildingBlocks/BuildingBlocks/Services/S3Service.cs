using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BuildingBlocks.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BuildingBlocks.Services
{
    public class S3Service: IS3Service
    {
        private readonly string bucketName;
        private readonly IAmazonS3 s3Client;
        public S3Service(IConfiguration configuration)
        {
            var awsOptions = configuration.GetSection("AWS");
            bucketName = awsOptions["BucketName"]!;
            s3Client = new AmazonS3Client(
                awsOptions["AccessKey"],
                awsOptions["SecretKey"],
                RegionEndpoint.GetBySystemName(awsOptions["Region"]));
        }
        public async Task<string> UploadFileAsync(IFormFile File)
        {
            if (File == null || File.Length <= 0)
                throw new ArgumentException("File is invalid");

            var key = Guid.NewGuid() + Path.GetExtension(File.FileName);

            using var stream = File.OpenReadStream();
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                Key = key,
                BucketName = bucketName,
                ContentType = File.ContentType
            };

            var transferUtility = new TransferUtility(s3Client);
            await transferUtility.UploadAsync(uploadRequest);

            return $"https://{bucketName}.s3.amazonaws.com/{key}";
        }
        public async Task DeleteFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File key is invalid");

            string fileKey = filePath.Split("/")[filePath.Length - 1];

            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = fileKey
            };

            await s3Client.DeleteObjectAsync(deleteObjectRequest);
        }
    }
}
