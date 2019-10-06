using System;
using MediatR;

namespace Byui.AudiobookLibrary.ApplicationCore.Library.Interactors.RefreshLibrary
{
    public class RefreshLibraryRequest : IRequest<bool>
    {        
        public RefreshLibraryRequest()
        {
        }
    }
}