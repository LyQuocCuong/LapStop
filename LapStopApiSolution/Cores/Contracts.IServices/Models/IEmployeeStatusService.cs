using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeStatusService
    {
        List<EmployeeStatusDto> GetAll();

        EmployeeStatusDto? GetOneById(Guid employeeStatusId);
    }
}
