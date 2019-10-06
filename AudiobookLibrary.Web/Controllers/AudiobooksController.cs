using System.Collections.Generic;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public AudiobooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AudiobookFile>>> Get()
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
    }
}