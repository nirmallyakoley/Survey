using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Survey.Models
{
    [Table("Survey")]
    public class SurveyBO
    {
        [Key]
        public string UserID { get; set; }

        [Required]       
        public string AWSProjectExperience { get; set; } 

        [MaxLength(500)]
        [Required(ErrorMessage = "The referal course should not be blank and within 500 characters")]
        public string  ReferalCourse { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "The training course should not be blank and within 500 characters")]
        public string  Training { get; set; }

        [Range(1,5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Hours must be within 3 digits")]
        public int Hours { get; set; }

        [Column("CreatedOn")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
