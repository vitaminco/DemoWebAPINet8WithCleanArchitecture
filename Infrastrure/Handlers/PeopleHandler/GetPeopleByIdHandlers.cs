

using Application.Features.PeopleFeatures.Queries;
using Domain.Entities;
using Infrastrure.Data;
using MediatR;

namespace Infrastrure.Handlers.PeopleHandler
{
    public class GetPeopleByIdHandlers : IRequestHandler<GetPeopleByIdQuery, AppPeople>
    {
        private readonly AppDbContext appDbContext;

        public GetPeopleByIdHandlers(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<AppPeople> Handle(GetPeopleByIdQuery request, CancellationToken cancellationToken)
           => await appDbContext.People.FindAsync(request.Id);

    }
}
