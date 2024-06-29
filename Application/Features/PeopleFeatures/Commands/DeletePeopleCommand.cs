
using Application.DTOs;
using MediatR;

namespace Application.Features.PeopleFeatures.Commands
{
    public class DeletePeopleCommand:IRequest<PeopleResponse>
    {
        public int Id { get; set; }
    }
}
