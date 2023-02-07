using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Core.Common;
public class FileStreamInfo
{
    public Stream Stream { get; set; }
    public string MimeType { get; set; }
    public FileStreamInfo(Stream stream, string mimeType)
    {
        Stream = stream;
        MimeType = mimeType;
    }
}
