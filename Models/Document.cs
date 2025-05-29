namespace KYC.Models;

public partial class KycFormModel
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int MemberId { get; set; }
        public required string DocumentType { get; set; }
        public required string DocumentNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public required string IssuedPlace { get; set; }
        public required string DocumentImagePath { get; set; }
    }
}
