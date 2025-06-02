using System.ComponentModel.DataAnnotations;

namespace KYC.Models;


public class BankDetail
{
    public int BankDetailId { get; set; }
    public int MemberId { get; set; }

    [Required]
    public string BankName { get; set; } = null!;

    [Required]
    public string AccountNumber { get; set; } = null!;

    [Required]
    public string Branch { get; set; } = null!;
}

