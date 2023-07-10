using DTO.Output.ApiResponses.Bases;

namespace DTO.Output.ApiResponses.ErrorNotFound
{
    public sealed class EmployeeNotFoundReponse : ApiNotFoundResponse
    {
        public EmployeeNotFoundReponse(Guid id)
            : base($"Employee with id: {id} is not found in DB")
        {
        }
    }
}
