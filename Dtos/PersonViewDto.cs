using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class PersonViewDto
    {
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? IndentificationType { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
