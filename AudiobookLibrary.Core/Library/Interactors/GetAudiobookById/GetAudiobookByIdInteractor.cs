using System.Threading;
using System.Threading.Tasks;
using AudiobookLibrary.Core.Library.Domain;
using AudiobookLibrary.Core.Persistance;
using MediatR;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookById
{
    public class GetAudiobookByIdInteractor : IRequestHandler<GetAudiobookByIdRequest, AudiobookFile>
    {
        private readonly AudioLibraryContext _ctx;
        public GetAudiobookByIdInteractor(AudioLibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AudiobookFile> Handle(GetAudiobookByIdRequest request, CancellationToken token)
        {
            var book = await _ctx.AudiobookFiles.FindAsync(request.Id);
            return book;
        }
    }
}