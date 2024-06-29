
using Application.DTOs;
using MediatR;

namespace Application.Features.PeopleFeatures.Commands
{
    public class UpdatePeopleCommand: IRequest<PeopleResponse>
    {
        public PeopleUpdin? PeopleUpdin { get; set; }
        public int Id { get; set; }

    }
}
