using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Confguration;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using AudiobookLibrary.Core.Library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public AudiobooksController(IMediator mediator, AppSettings settings)
        {
            _mediator = mediator;
            _settings = settings;
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

        [HttpGet("download/{filename}")]
        public ActionResult Download(string filename)
        {
            filename = _settings.Directory + filename;
            var file = new FileInfo(filename);
            if (!file.Exists)
            {
                return NotFound();
            }

            return File(file.OpenRead(), "audio/mp4a-latm", file.Name);
        }
    }
}