using System.ComponentModel.DataAnnotations;

namespace MedicineDonationPortal.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public float Price { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }
        public float Quantity { get; set; }

    }
}
