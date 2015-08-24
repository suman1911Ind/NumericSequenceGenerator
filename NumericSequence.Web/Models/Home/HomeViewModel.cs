using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NumericSequence.Web.Models.Home
{
    public class HomeViewModel
    {
        [Required]
        [Display(Name = "Upper bound")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}.")]
        public int? UpperBound { get; set; }

        public List<SequenceViewModel> Sequences { get; set; } 
    }
}