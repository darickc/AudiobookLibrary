using System;
using MediatR;

namespace Byui.AudiobookLibrary.ApplicationCore.Library.Interactors.GetAudiobookFiles
{
    public class GetAudiobookFilesRequest : IRequest<bool>
    {        
        public GetAudiobookFilesRequest()
        {
        }
    }
}