using BlazorShop.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorShop.Service;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<string> UploadFile(IBrowserFile file)
    {
        FileInfo fileInfo = new FileInfo(file.Name);
        var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
        var folderDirectory = $"{_webHostEnvironment.WebRootPath}/assets/product";
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }

        var filePath = Path.Combine(folderDirectory, fileName);

        await using FileStream fs = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);

        var fullPath = $"/assets/product/{fileName}";
        return fullPath;
    }

    public bool DeleteFile(string filePath)
    {
        if (File.Exists(_webHostEnvironment.WebRootPath + filePath))
        {
            File.Delete(_webHostEnvironment.WebRootPath + filePath);
            return true;
        }

        return false;
    }
    
}