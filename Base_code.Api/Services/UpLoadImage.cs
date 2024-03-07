using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace Base_code.Api.Services
{
    public class UpLoadImage
    {
        private readonly Cloudinary _cloudinary;
        public UpLoadImage(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        public string ImageUpload(IFormFile? image)
        {
            if (image != null && image.Length > 0)
            {
                using (var stream = image.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(image.FileName, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill"),
                    };

                    try
                    {
                        var uploadResult = _cloudinary.Upload(uploadParams);
                        return uploadResult.SecureUrl.ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi tải lên hình ảnh: {ex.Message}");
                    }
                }
            }

            return null;
        }
        public void DeleteImage(string imageUrl)
        {
            var data = GetPublicIdFromUrl(imageUrl);

            var deletionParams = new DeletionParams(data)
            {
                Invalidate = true
            };

            try
            {
                var result = _cloudinary.Destroy(deletionParams);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting image: {ex.Message}");
            }
        }

        private string GetPublicIdFromUrl(string imageUrl)
        {
            var publicId = imageUrl.Split('/').Last().Split('.').First();
            return publicId;
        }
    }
}
