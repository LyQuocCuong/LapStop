using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class CustomerAccount
    {
        public Guid CustomerId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
