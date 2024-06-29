

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PeopleUpdin
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string? Place { get; set; }
        public string? Description { get; set; }
    }
}
