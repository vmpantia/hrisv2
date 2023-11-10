using Microsoft.EntityFrameworkCore;

namespace HRIS.Domain.Models.Entities
{
    [PrimaryKey(nameof(Section), nameof(Key))]
    public class Config
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
