using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaceHosipital.Models
{
    [Table("Admin")]
    public class Admin
    {

        [Key]

        public int AdminId { get; set; }

        public string AName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        [ForeignKey("AdminTypes")]
        public int AdminTypeId { get; set; }
        public AdminType AdminTypes { get; set; }
    }
}
