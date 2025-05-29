using System.ComponentModel.DataAnnotations;

namespace KYC.Models;

public partial class KycFormModel
{
    public class Nominee
    {
        public int NomineeId { get; set; }
        public int MemberId { get; set; }           // Foreign key to Member
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Relationship { get; set; } = null!;
        [Required]
        public string CitizenshipNumber { get; set; } = null!;
    }
}
