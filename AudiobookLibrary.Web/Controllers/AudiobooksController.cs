using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Confguration;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookById;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using AudiobookLibrary.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AudiobookLibrary.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class AudiobooksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _settings;
        private readonly ILogger<AudiobooksController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="settings"></param>
        /// <param name="logger"></param>
        public AudiobooksController(IMediator mediator, AppSettings settings, ILogger<AudiobooksController> logger)
        {
            _mediator = mediator;
            _settings = settings;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Series>>> Get()
        {
            var files = await _mediator.Send(new GetAudiobookFilesRequest());
            return Ok(files);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> Post()
        {
            await _mediator.Send(new RefreshLibraryRequest());
            return Ok();
        }

        [HttpGet("cover/{id:int}")]
        public async Task<ActionResult> Cover(int id)
        {
            var book = await _mediator.Send(new GetAudiobookByIdRequest(id));
            if (string.IsNullOrEmpty(book?.Image))
            {
                return NotFound();
            }

            var image = book.Image.Replace("data:image/png;base64,", "");
            var data = Convert.FromBase64String(image);
            return File(data, "image/png");
        }

        [HttpGet("download/{id:int}")]
        public async Task<ActionResult> Download(int id)
        {
            var book = await _mediator.Send(new GetAudiobookByIdRequest(id));
            var filename = book?.Filename;
            if (string.IsNullOrEmpty(filename))
            {
                return NotFound();
            }
            filename = _settings.Directory + WebUtility.UrlDecode(filename);
            _logger.LogInformation($"Filename: {filename}");
            var file = new FileInfo(filename);
            if (!file.Exists)
            {
                return NotFound();
            }

            return File(file.OpenRead(), "audio/mp4a-latm", file.Name);
        }
    }
}