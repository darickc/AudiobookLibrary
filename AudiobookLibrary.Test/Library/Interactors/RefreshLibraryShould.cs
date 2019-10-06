using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Interactors.RefreshLibrary;
using MediatR;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace AudiobookLibrary.Test.Library.Interactors
{
    public class RefreshLibraryShould : IClassFixture<TestFixture>
    {
        private readonly IMediator _mediator;

        public RefreshLibraryShould(TestFixture fixture)
        {
            _mediator = fixture.ServiceProvider.GetService<IMediator>();
        }

        [Fact]
        public async Task RefreshData()
        {
            await _mediator.Send(new RefreshLibraryRequest());
        }
    }
}