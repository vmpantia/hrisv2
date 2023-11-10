using AutoMapper;
using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Database;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class ConfigRepository : BaseRepository<Config>, IConfigRepository
    {
        public ConfigRepository(HRISDbContext context, IMapper mapper) : base(context, mapper) { }

        public TValue GetValue<TValue>(string section, string key)
        {
            var result = _table.FirstOrDefault(data => data.Section == section && data.Key == key)?.Value;

            if (result == null)
                return default(TValue);

            return (TValue)Convert.ChangeType(result, typeof(TValue));
        }
    }
}
