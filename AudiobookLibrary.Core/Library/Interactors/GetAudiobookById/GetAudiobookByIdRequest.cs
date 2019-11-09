using AudiobookLibrary.Core.Library.Domain;
using MediatR;

namespace AudiobookLibrary.Core.Library.Interactors.GetAudiobookById
{
    public class GetAudiobookByIdRequest : IRequest<AudiobookFile>
    {
        public int Id { get; }
        public GetAudiobookByIdRequest(int id)
        {
            Id = id;
        }
    }
}