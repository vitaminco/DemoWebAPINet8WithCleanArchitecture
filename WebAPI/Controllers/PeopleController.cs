

using Application.DTOs;
using Application.Features.PeopleFeatures.Commands;
using Application.Features.PeopleFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //Lấy dữ liệu từ Ipeople
        
        private readonly IMediator mediator;

        public PeopleController( IMediator mediator)
        {
            
            this.mediator = mediator;
        }

        //Hiển thị dữ liệu
        [HttpGet("Data")]
        public async Task<ActionResult<PeopleResponse>> GetAllPeople() => Ok(await mediator.Send(new GetAllPeopleQuery()));
        /*        {
                    var result = await people.GetAllPeopleAsync();
                    return Ok(result);
                }*/
        //Tìm data
        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleResponse>> FindPeople(int id) 
            => Ok(await mediator.Send(new GetPeopleByIdQuery{Id = id}));
       /* {
            var result = await people.GetFindPeopleAsync(id);
            return Ok(result);
        }*/
        //Thêm người
        [HttpPost("Them")]
        public async Task<ActionResult<PeopleResponse>> AddPeople(PeopleUpdin peopleUpdin)
            =>Ok(await mediator.Send(new CreatePeopleCommand { PeopleUpdin = peopleUpdin }));
        /*{
            var result = await mediator.Send(new CreatePeopleCommand { PeopleUpdin = peopleUpdin });
            //Gọi trong PeopleReponse để thêm người
            *//*var result = await people.GetPeopleAsync(peopleUpdin);*//*
            return Ok(result);
        }*/
        //Sửa người
        [HttpPut("{id}")]
        public async Task<ActionResult<PeopleResponse>> UpdatePeople(int id, PeopleUpdin peopleUpdin)
            =>Ok(await mediator.Send(new UpdatePeopleCommand { Id = id,PeopleUpdin = peopleUpdin }));
        /*        {
                    //Gọi trong PeopleReponse để thêm người
                    var result = await people.UpdatePeopleAsync(id, peopleUpdin);
                    return Ok(result);
                }*/
        //Xóa người
        [HttpDelete("{id}")]
        public async Task<ActionResult<PeopleResponse>> DeletePeople(int id)
            => Ok(await mediator.Send(new DeletePeopleCommand { Id = id }));
       /* {
            //Gọi trong PeopleReponse để thêm người
            var result = await people.DeletePeopleAsync(id);
            return Ok(result);
        }*/
    }
}
