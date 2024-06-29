

using Application.DTOs;

namespace Application.Contracts
{
    public interface IPeople
    {
        //Gọi các DTOs để thực hiện
        //HIển thị all data
        Task<PeopleResponseListAll> GetAllPeopleAsync();
        //data tìm theo id
        Task<PeopleResponseList> GetFindPeopleAsync(int id);
        //Thêm data
        Task<PeopleResponse> GetPeopleAsync(PeopleUpdin peopleUpdin);
        //update 
        Task<PeopleResponse> UpdatePeopleAsync(int id, PeopleUpdin peopleUpdin);
        //Xóa
        Task<PeopleResponseList> DeletePeopleAsync(int id);
    }
}
