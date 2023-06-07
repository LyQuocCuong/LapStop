using DTO.Bases;

namespace DTO.Input.FromQuery.RequestPrams
{
    public class EmployeeRequestParam : BasePOSRequestParam
    {
        public EmployeeRequestParam() 
        {
            this.OrderBy = "EmployeeCode";  //set DEFAULT field's Order
        }

        public uint MinAge { get; set; }

        public uint MaxAge { get; set; } = uint.MaxValue;

        public string? SearchTerm { get; set; }

        public string? ShapingProps { get; set; }
    }
}
