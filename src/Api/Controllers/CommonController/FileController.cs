using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Configuration;
using ProductTracking.Core.Interfaces.CommonInterfaces;

namespace ProductTracking.Api.Controllers.CommonController;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly string _filePath;
    public FileController(IFileService fileService, IOptions<AppConfig> config)
    {
        _fileService = fileService;
        _filePath = config.Value.FilePath;
    }
    [Authorize]
    [HttpPost]
    public async Task<Response<string>> Upload(IFormFile file)
    {
        MemoryStream stream = new MemoryStream();
        await file.CopyToAsync(stream);
        var ext = Path.GetExtension(file.FileName);
        var filename = await _fileService.SaveFile(stream, _filePath, ext);
        return new Response<string>(filename);
    }

    [HttpGet("{filename}")]
    public async Task<IActionResult> Download(string filename)
    {
        // Stream stream = await {{__get_stream_based_on_id_here__}}
        var fileInfo = await _fileService.GetFile(filename, _filePath);

        if (fileInfo == null)
            return NotFound();

        FileStreamResult res = new FileStreamResult(fileInfo.Stream, fileInfo.MimeType)
        {
            FileDownloadName = "image.jpg"
        };
        return res;
    }
}
