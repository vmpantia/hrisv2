using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRIS.Domain.Models.Dtos
{
    public class SaveContactDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContactType Type { get; set; }
        [Required]
        public bool IsPrimary { get; set; }
        [Required]
        public bool IsPersonal { get; set; }
    }
}
