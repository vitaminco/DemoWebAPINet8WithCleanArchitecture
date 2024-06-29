

using Domain.Entities;

namespace Application.DTOs
{
    //Thông báo
    public record PeopleResponseListAll(bool Flag, string Message = null!, List<PeopleUpdin> People = null!);
}
