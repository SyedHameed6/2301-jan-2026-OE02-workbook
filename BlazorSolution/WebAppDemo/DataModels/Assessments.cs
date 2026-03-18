using System.ComponentModel.DataAnnotations;

namespace WebAppDemo.DataModels
{
    public class Assessments
    {
        [Required(ErrorMessage ="Assessment Name is required. Can not be empty.")]
        [StringLength(15, ErrorMessage ="Assessment Name is limited to 15 characters.")]
        public string Name { get; set; }
        [Range(0, 100, ErrorMessage ="Assessment weight must be between 0 and 100.")]
        public int Weight { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Assessment mark must be greater than 0.")]
        public int Mark {  get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Assessment maximum mark must be greater than 0.")]
        public int MaxMark { get; set; }

        //read-only calculated field
        //computed value for display only
        //ternary operator 
        //  condition: MaxMark == 0
        //  true value: 0
        //  false value: ((decimal)Mark / (decimal)MaxMark)* (decimal)Weight
        public decimal WeightedMark => MaxMark == 0 ? 0 : ((decimal)Mark / (decimal)MaxMark) * Weight;
    }
}
