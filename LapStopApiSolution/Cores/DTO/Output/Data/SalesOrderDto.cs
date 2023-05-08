using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class SalesOrderDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid SalesOrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int Total { get; set; }
    }
}
