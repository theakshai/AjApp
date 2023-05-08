using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AjApp.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public string? UserId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("following")]
        public int? Following { get; set; }
        [Column("dob")]
        public DateTime? DOB { get; set; }
        [Column("country")]
        public string? Country { get; set; }
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}
