using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? Names { get; set; }    
        public string? LastNames { get; set; }
        public string? IndentificationType { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? FullIdentification { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
