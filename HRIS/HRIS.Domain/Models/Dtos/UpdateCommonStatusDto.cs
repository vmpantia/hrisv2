using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HRIS.Domain.Models.Dtos
{
    public class UpdateCommonStatusDto
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommonStatus NewStatus { get; set; }
    }
}
