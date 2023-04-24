using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll(bool isTrackChanges);
        EmployeeDto? GetById(bool isTrackChanges, Guid id);
        bool IsValidEmployeeId(Guid id);
    }
}
