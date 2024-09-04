using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaceHosipital.Models
{
    [Table("AdminType")]
    public class AdminType
    {
        [Key]
        public int AdminTypeId { get; set; }
        public string AdminTypeName { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
