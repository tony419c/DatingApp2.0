using CloudinaryDotNet.Actions;

namespace DatingApp2._0.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
