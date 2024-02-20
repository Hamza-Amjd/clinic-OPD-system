using System.ComponentModel.DataAnnotations;

namespace GlobalEntity
{
    public class Patient
    {
        public int PatientId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter your firstname."), MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter your lastname."), MaxLength(30)]
        public string LastName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:mm.dd.yyyy}")]
        [Required(ErrorMessage = "Please enter correct date of birth.")]
        public string DateOfBirth { get; set; } = null!;

        [Required(ErrorMessage = "Please enter mobile number.")]
        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-
    \d{7}$", ErrorMessage = "Mobile no is not valid.")]
        public  string ContactNo { get; set; }
    }
}
