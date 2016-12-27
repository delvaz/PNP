#region References

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace PNP.API.Model
{
    public class PrayerRequest
    {
        public PrayerRequest()
        {
            Groups = new HashSet<Group>();
        }

        private DateTime _createdOn = DateTime.MinValue;

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrayerRequestId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate
        {
            get { return _createdOn == DateTime.MinValue ? DateTime.Now : _createdOn; }
            set { _createdOn = value; }
        }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TargetDate { get; set; }

        [Required(ErrorMessage = "At least 1 group is required.")]
        [MinLength(1)]
        public virtual ICollection<Group> Groups { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CloseDate { get; set; }
    }
}