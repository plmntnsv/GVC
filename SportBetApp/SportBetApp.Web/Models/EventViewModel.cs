using System;
using System.ComponentModel.DataAnnotations;

namespace SportBetApp.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "0.00")]
        [Range(1, double.MaxValue, ErrorMessage = "Odd for first team must be bigger than 1")]
        public double? OddsForFirstTeam { get; set; }

        [DisplayFormat(DataFormatString = "0.00")]
        [Range(1, double.MaxValue, ErrorMessage = "Odd for draw must be bigger than 1")]
        public double? OddsForDraw { get; set; }

        [DisplayFormat(DataFormatString = "0.00")]
        [Range(1, double.MaxValue, ErrorMessage = "Odd for second team must be bigger than 1")]
        public double? OddsForSecondTeam { get; set; }
        
        [Required(ErrorMessage ="Start date is required")]
        public DateTime StartDate { get; set; }
    }
}