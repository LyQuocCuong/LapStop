using Common.Models.Links;
using DTO.Bases;

namespace DTO.Output.Data
{
    public sealed class CustomerDto : BaseOutputDto
    {
        public CustomerDto() 
        {
            Links = new List<LinkItemModel>();
        }

        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public List<LinkItemModel> Links { get; set; }
    }
}
