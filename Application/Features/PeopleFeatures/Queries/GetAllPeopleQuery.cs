using MediatR;
using Domain.Entities;

namespace Application.Features.PeopleFeatures.Queries
{
    public class GetAllPeopleQuery : IRequest<List<AppPeople>> {}
}
