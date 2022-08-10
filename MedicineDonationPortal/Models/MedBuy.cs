using System.ComponentModel.DataAnnotations;

namespace MedicineDonationPortal.Models
{
    public class MedBuy
    {
        [Key]
        public int UserId {get; set;}
        public string UserName { get; set; }
        public string MedicineName { get; set; }
        public int MobileNumber { get; set; }
        
        
    }
}
