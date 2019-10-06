using System.Collections.Generic;
using AudiobookLibrary.Core.Library.Models;
using MediatR;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesRequest : IRequest<List<Series>>
    {        
        public GetAudiobookFilesRequest()
        {
        }
    }
}