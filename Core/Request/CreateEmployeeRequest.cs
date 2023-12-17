using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class CreateEmployeeRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public int CountryId { get; set; }
        public DateTime? DOB { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }
    }
}
