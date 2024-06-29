

using Application.Features.PeopleFeatures.Queries;
using Domain.Entities;
using Infrastrure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastrure.Handlers.PeopleHandler
{
    public class GetPeopleListHandlers : IRequestHandler<GetAllPeopleQuery, List<AppPeople>>
    {
        private readonly AppDbContext appDbContext;

        public GetPeopleListHandlers(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //Hiển thị data
        public async Task<List<AppPeople>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        => await appDbContext.People.ToListAsync();
        
    }
}
