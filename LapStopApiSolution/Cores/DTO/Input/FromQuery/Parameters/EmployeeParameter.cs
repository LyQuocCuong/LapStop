using DTO.Bases;

namespace DTO.Input.FromQuery.Parameters
{
    public class EmployeeParameter : BaseRequestParameters
    {
        public EmployeeParameter() 
        {
            this.OrderBy = "EmployeeCode";  //set DEFAULT field's Order
        }

        public uint MinAge { get; set; }

        public uint MaxAge { get; set; } = uint.MaxValue;

        public string? SearchTerm { get; set; }
    }
}
