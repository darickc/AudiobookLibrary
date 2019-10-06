using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Byui.AudiobookLibrary.ApplicationCore.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesInteractor : IRequestHandler<GetAudiobookFilesRequest, bool>
    {

        public GetAudiobookFilesInteractor()
        {
        }

        public async Task<bool> Handle(GetAudiobookFilesRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}