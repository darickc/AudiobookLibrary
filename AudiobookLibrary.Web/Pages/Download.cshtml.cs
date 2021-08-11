using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Configuration;
using AudiobookLibrary.Core.Library.Interactors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AudiobookLibrary.Web.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _settings;

        public DownloadModel(IMediator mediator, AppSettings settings)
        {
            _mediator = mediator;
            _settings = settings;
        }

        public async Task<ActionResult> OnGet(int id)
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
