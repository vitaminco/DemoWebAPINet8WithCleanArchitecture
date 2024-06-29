using Domain.Entities;
using MediatR;


namespace Application.Features.PeopleFeatures.Queries
{
    public class GetPeopleByIdQuery : IRequest<AppPeople>
    {
        // lấy cái id để lấy id để update
        public int Id { get; set; }
    }
}
