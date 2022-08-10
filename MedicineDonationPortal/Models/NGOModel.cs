using System.ComponentModel.DataAnnotations;

namespace MedicineDonationPortal.Models
{
    public class NGOModel
    {
        [Key]
        [Required]
        public int NGOId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Address { get; set; }
        public int MobileNumber { get; set; }

    }
}
