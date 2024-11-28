using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using BuildingBlocks.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BuildingBlocks.Services
{
    public class S3Service
        (IConfiguration configuration): IS3Service
    {
        public async Task<string> UploadFileAsync(IFormFile File)
        {
            if (File == null || File.Length <= 0)
                throw new ArgumentException("File is invalid");

            var awsOptions = configuration.GetSection("AWS");

            string bucketName = awsOptions["BucketName"]!;
            
            IAmazonS3 s3Client = new AmazonS3Client(
                awsOptions["AccessKey"],
                awsOptions["SecretKey"],
                RegionEndpoint.GetBySystemName(awsOptions["Region"]));

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
    }
}
