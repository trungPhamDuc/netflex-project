namespace Netflex.Services;

public interface IStorageService
{
    Task<Uri> UploadFileAsync(string name, IFormFile file);
}