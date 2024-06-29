

using Domain.Entities;

namespace Application.DTOs
{
    //Thông báo
    public record PeopleResponseList(bool Flag, string Message = null!, AppPeople Person = null!);
}
