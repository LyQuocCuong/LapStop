using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeStatusService
    {
        IEnumerable<EmployeeStatusDto> GetAll();

        EmployeeStatusDto? GetOneById(Guid employeeStatusId);
    }
}
