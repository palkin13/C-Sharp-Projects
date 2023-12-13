namespace FileProcessingAPI.Services
{
    public interface IManageImage
    {
        Task<string> UploadFile(IFormFile _iformfile);
        Task<(byte[], string , string)> DownloadFile(string fileName);
    }
}
