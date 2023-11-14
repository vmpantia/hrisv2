using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRIS.Domain.Models.Dtos
{
    public class SaveAddressDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        [Required]
        public string Barangay { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AddressType Type { get; set; }
    }
}
