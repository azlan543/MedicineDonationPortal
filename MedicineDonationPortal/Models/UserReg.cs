using System.ComponentModel.DataAnnotations;

namespace MedicineDonationPortal.Models
{
    public class UserReg
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int ContactNumber { get; set; }
        public string Address { get; set; }
        

    }
}
