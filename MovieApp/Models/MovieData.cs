using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class MovieData
    {
        [Key] public int MovieId { get; set; }
        [StringLength(100)]
        [DisplayName("Title")]
        public string MovieName { get; set; }
        [DisplayName("Director")]
        public string MovieDirector { get; set; }
        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }

        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Poster")]
        public IFormFile ImageFile { get; set; }

        public MovieData()
        {

        }
    }
}
