using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;

namespace WebApi.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column("UserName")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Registred { get; set; } = DateTime.Now;
        public int Age { get; set; }
    }
}
