using DTO.Base;

namespace DTO.Input.FromQuery.Parameters
{
    public class EmployeeParameter : RequestParameters
    {
        public uint MinAge { get; set; }

        public uint MaxAge { get; set; } = uint.MaxValue;

        public string? SearchTerm { get; set; }
    }
}
