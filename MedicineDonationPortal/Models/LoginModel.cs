using System.ComponentModel.DataAnnotations;

namespace MedicineDonationPortal.Models
{
    public class LoginModel
    {
        [Required]
        [Key]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}
