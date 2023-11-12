using Bogus;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;

namespace HRIS.Infrastructure.DataAccess.Stubs
{
    public class StubData
    {
        public static Faker<Employee> FakerEmployee()
        {
            var gender = new string[] { "Male", "Female" };
            return new Faker<Employee>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.Number, faker => faker.Random.String(10))
                .RuleFor(prop => prop.FirstName, faker => faker.Name.FirstName())
                .RuleFor(prop => prop.MiddleName, faker => faker.Random.String(10))
                .RuleFor(prop => prop.LastName, faker => faker.Name.LastName())
                .RuleFor(prop => prop.Gender, faker => faker.Random.CollectionItem(gender))
                .RuleFor(prop => prop.BirthDate, faker => faker.Date.Past().Date)
                .RuleFor(prop => prop.Status, faker => faker.Random.Enum<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email())
                .Ignore(prop => prop.UpdatedAt)
                .Ignore(prop => prop.UpdatedBy)
                .Ignore(prop => prop.DeletedAt)
                .Ignore(prop => prop.DeletedBy);
        }
    }
}
