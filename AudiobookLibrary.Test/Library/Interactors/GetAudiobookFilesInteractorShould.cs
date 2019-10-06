using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AudiobookLibrary.Test.Library.Interactors
{
    public class GetAudiobookFilesInteractorShould : IClassFixture<TestFixture>
    {
        private readonly IMediator _mediator;

        public GetAudiobookFilesInteractorShould(TestFixture fixture)
        {
            _mediator = fixture.ServiceProvider.GetService<IMediator>();
        }

        [Fact]
        public async Task GetAudiobookFiles()
        {
            var files = await _mediator.Send(new GetAudiobookFilesRequest());
        }
    }
}