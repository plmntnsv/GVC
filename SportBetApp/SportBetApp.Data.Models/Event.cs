using System;
using System.ComponentModel.DataAnnotations;

namespace SportBetApp.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        [DisplayFormat(DataFormatString ="0.00")]
        [Range(1, double.MaxValue, ErrorMessage ="Odd must be bigger than 1")]
        public double? OddsForFirstTeam { get; set; }

        [DisplayFormat(DataFormatString = "0.00")]
        [Range(1, double.MaxValue, ErrorMessage = "Odd must be bigger than 1")]
        public double? OddsForDraw { get; set; }

        [DisplayFormat(DataFormatString = "0.00")]
        [Range(1, double.MaxValue, ErrorMessage ="Odd must be bigger than 1")]
        public double? OddsForSecondTeam { get; set; }

        //[Required]
        //[DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MM/yyyy HH:mm}")]
        public DateTime StartDate { get; set; }
    }
}
