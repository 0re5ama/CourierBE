using ProductTracking.Core.Common;

namespace ProductTracking.Core.Interfaces.CommonInterfaces;
public interface IFileService
{
    Task<string> SaveFile(MemoryStream stream, string filepath, string ext);
    Task<FileStreamInfo> GetFile(string filename, string filepath);
}
