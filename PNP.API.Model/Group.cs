using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNP.API.Model
{
    public class Group
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Moderator")]
        public string ModeratorId { get; set; }
        public Person Moderator { get; set; }

        public virtual ICollection<Person> Members { get; set; }
    }
}
