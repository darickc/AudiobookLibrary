using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Configuration;
using AudiobookLibrary.Core.Library.Interactors;
using MediatR;

namespace AudiobookLibrary.Web.Conrollers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _settings;

        public DownloadController(IMediator mediator, AppSettings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Index(int id)
        {
            var book = await _mediator.Send(new GetAudiobookByIdRequest(id));
            var filename = book?.Filename;
            if (string.IsNullOrEmpty(filename))
            {
                return NotFound();
            }
            filename = _settings.Directory + WebUtility.UrlDecode(filename);
            // _logger.LogInformation($"Filename: {filename}");
            var file = new FileInfo(filename);
            if (!file.Exists)
            {
                return NotFound();
            }

            return File(file.OpenRead(), "audio/mp4a-latm", file.Name);
        }
    }
}
