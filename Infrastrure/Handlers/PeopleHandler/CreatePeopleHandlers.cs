

using Application.DTOs;
using Application.Features.PeopleFeatures.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastrure.Data;

using MediatR;

namespace Infrastrure.Handlers.PeopleHandler
{
    public class CreatePeopleHandlers : IRequestHandler<CreatePeopleCommand, PeopleResponse>
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper _mapper;

        public CreatePeopleHandlers(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<PeopleResponse> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            /*thêm với AutoMapper _mapper.Map<AppPeople>(peopleUpdin) lấy dữ liệu từ mapper*/
            appDbContext.People.Add(_mapper.Map<AppPeople>(request.PeopleUpdin));

            await appDbContext.SaveChangesAsync(cancellationToken);
            return new PeopleResponse(true, "Thêm thành công");
        }
    }
}
