using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRIS.Domain.Models.Dtos
{
    public class SaveEmployeeDto
    {
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }

    public class ChangeCommonStatusDto
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommonStatus NewStatus { get; set; }
    }
}
