
using Microsoft.AspNetCore.Http;

namespace University.Application.Interfaces
{
    public interface IFileService 
    {
        ValueTask<string> UploadImageAsync(IFormFile file);
        ValueTask<bool> DeleteImageAsync(string file);
        ValueTask<byte[]> GetImageAsync(string path);
    }
}
