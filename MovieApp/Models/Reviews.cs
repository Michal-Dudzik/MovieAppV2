using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Reviews
    {
        [Key] public int ReviewId { get; set; }
        [DisplayName("Choose a Movie")]
        public string? OwnerID { get; set; }
        public string MovieName { get; set; }
        [StringLength(1000)]
        [DisplayName("Review")]
        public string ReviewDescription { get; set; }
        [Range(1, 10, ErrorMessage = "Score movie from 1 to 10")]
        public int Score { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Date of the review")]
        public DateTime? ReviewDate { get; set; }

        public Reviews()
        {

        }
    }
}

