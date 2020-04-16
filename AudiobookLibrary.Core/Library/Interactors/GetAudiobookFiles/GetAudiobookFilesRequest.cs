using System.Collections.Generic;
using AudiobookLibrary.Shared.Models;
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