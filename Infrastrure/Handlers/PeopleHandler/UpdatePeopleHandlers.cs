

using Application.DTOs;
using Application.Features.PeopleFeatures.Commands;
using AutoMapper;
using Infrastrure.Data;
using MediatR;

namespace Infrastrure.Handlers.PeopleHandler
{
    public class UpdatePeopleHandlers : IRequestHandler<UpdatePeopleCommand, PeopleResponse>
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper _mapper;

        public UpdatePeopleHandlers(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<PeopleResponse> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            var p = await appDbContext.People.FindAsync(request.Id);
            if (p is not null)
            {
                _mapper.Map(request.PeopleUpdin, p);
                appDbContext.Update(p);
                await appDbContext.SaveChangesAsync(cancellationToken);
                return new PeopleResponse(true, "Update thành công");
            }
            else
            {
                return new PeopleResponse(false, "Không có id");
            }
        }
    }
}
