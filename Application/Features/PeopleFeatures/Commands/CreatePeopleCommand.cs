
using Application.DTOs;

using MediatR;

namespace Application.Features.PeopleFeatures.Commands
{
    //PeopleResponse là nằm ở DTOs
    public class CreatePeopleCommand() : IRequest<PeopleResponse>
    {
        public PeopleUpdin?  PeopleUpdin { get; set; }
    }

}
