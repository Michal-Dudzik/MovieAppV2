using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class PersonalCollection
    {
        [Key] public int CollectionId { get; set; }
        public string? OwnerID { get; set; }
        [DisplayName("Choose a Movie")]
        public string SelectMovieName { get; set; }
        [Range(1, 10, ErrorMessage = "Score movie from 1 to 10")]
        public int Score { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("When did you watch it?")]
        public DateTime? WatchDate { get; set; }

        public PersonalCollection()
        {

        }
    }
}

