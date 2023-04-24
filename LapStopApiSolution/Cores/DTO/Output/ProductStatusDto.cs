using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Output
{
    public record ProductStatusDto
    (
        Guid Id,
        string? Name,
        string? Description,
        bool IsEnable,
        bool IsRemoved
    );
}
