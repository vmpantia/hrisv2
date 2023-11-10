namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public interface IConfigRepository
    {
        TValue GetValue<TValue>(string section, string key);
    }
}