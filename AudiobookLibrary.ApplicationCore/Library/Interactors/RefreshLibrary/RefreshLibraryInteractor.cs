using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Byui.AudiobookLibrary.ApplicationCore.Library.Interactors.RefreshLibrary
{
    public class RefreshLibraryInteractor : IRequestHandler<RefreshLibraryRequest, bool>
    {

        public RefreshLibraryInteractor()
        {
        }

        public async Task<bool> Handle(RefreshLibraryRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}