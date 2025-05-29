using System.ComponentModel.DataAnnotations;

namespace KYC.Dtos
{
    public record ProvinceDto
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

    }
}