using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace MobilityWeb.Models
#nullable disable
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        
    }
}