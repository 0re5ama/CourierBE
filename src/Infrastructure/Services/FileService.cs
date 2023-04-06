using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Common;
using ProductTracking.Core.Interfaces.CommonInterfaces;

namespace ProductTracking.Infrastructure.Services;
public class FileService : IFileService
{

    public async Task<string> SaveFile(MemoryStream stream, string filepath, string ext)
    {
        try
        {
            Directory.CreateDirectory(filepath);
            string filename = Guid.NewGuid().ToString() + ext;
            var path = Path.Combine(filepath, filename);
            stream.Position = 0;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
            }
            return filename;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<FileStreamInfo> GetFile(string filename, string filepath)
    {
        string path = Path.Combine(filepath, filename);
        Stream stream = File.OpenRead(path);
        string mimeType = "image/jpg";
        return new FileStreamInfo(stream, mimeType);
    }
}
