using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastrure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastrure.Repon
{
    internal class PeopleRepon : IPeople
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        public PeopleRepon(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
            _mapper = mapper;
        }
        //Hiển thị data
        public async Task<PeopleResponseListAll> GetAllPeopleAsync()
        {
            /*var peopleList = await appDbContext.People
                .Select(x => new PeopleUpdin
                {
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Place = x.Place,
                    Description = x.Description,
                })
                .ToListAsync();*/
            var peoples = await appDbContext.People.ToListAsync();
            //AutoMapper
            var peopleList = _mapper.Map<List<PeopleUpdin>>(peoples);

            return new PeopleResponseListAll(true, "Hiển thị thành công",peopleList);
        }

        //Tìm
        public async Task<PeopleResponseList> GetFindPeopleAsync(int id)
        {
            var p = await appDbContext.People.FindAsync(id);
            if (p is null)
            {
                return new PeopleResponseList(false, "Không có id");
            }
            return new PeopleResponseList(true, "Tìm thấy", p);
        }
        //Thêm Người
        public async Task<PeopleResponse> GetPeopleAsync(PeopleUpdin peopleUpdin)
        {
            /*thêm với AutoMapper _mapper.Map<AppPeople>(peopleUpdin) lấy dữ liệu từ mapper*/
            appDbContext.People.Add(_mapper.Map<AppPeople>(peopleUpdin));

            await appDbContext.SaveChangesAsync();
            return new PeopleResponse(true, "Thêm thành công");
        }

        //update
        public async Task<PeopleResponse> UpdatePeopleAsync(int id, PeopleUpdin peopleUpdin)
        {
            var p = await appDbContext.People.FindAsync(id);
            if (p is not null)
            {
                _mapper.Map(peopleUpdin,p);

                /* p.Name = peopleUpdin.Name;
                 p.FirstName = peopleUpdin.FirstName;
                 p.LastName = peopleUpdin.LastName;
                 p.Place = peopleUpdin.Place;
                 p.Description = peopleUpdin.Description;*/
                appDbContext.Update(p);
                await appDbContext.SaveChangesAsync();
                return new PeopleResponse(true, "Update thành công");
            }
            else
            {
                return new PeopleResponse(false, "Không có id");
            }
        }


        //Xóa người
        public async Task<PeopleResponseList> DeletePeopleAsync(int id)
        {
            var p = await appDbContext.People.FindAsync(id);
            if (p is null)
            {
                return new PeopleResponseList(false, "Không có id");
            }

            appDbContext.People.Remove(p);
            await appDbContext.SaveChangesAsync();
            return new PeopleResponseList(true, "Xóa thành công");
        }
    }
}
