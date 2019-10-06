using System.Collections.Generic;
using AudiobookLibrary.Core.Library.Domain;
using MediatR;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesRequest : IRequest<List<AudiobookFile>>
    {        
        public GetAudiobookFilesRequest()
        {
        }
    }
}