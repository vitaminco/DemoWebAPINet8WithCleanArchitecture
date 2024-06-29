

using Application.DTOs;
using Application.Features.PeopleFeatures.Commands;
using AutoMapper;
using Infrastrure.Data;
using MediatR;

namespace Infrastrure.Handlers.PeopleHandler
{
    public class DeletePeopleHandlers : IRequestHandler<DeletePeopleCommand, PeopleResponse>
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper _mapper;

        public DeletePeopleHandlers(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<PeopleResponse> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
        {
            var p = await appDbContext.People.FindAsync(request.Id);
            if (p is null)
            {
                return new PeopleResponse(false, "Không có id");
            }

            appDbContext.People.Remove(p);
            await appDbContext.SaveChangesAsync(cancellationToken);
            return new PeopleResponse(true, "Xóa thành công");
        }
    }
}
