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
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());
        }

        public static Faker<Contact> FakerContact(List<Guid> employeeIds)
        {
            return new Faker<Contact>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.EmployeeId, faker => faker.Random.CollectionItem(employeeIds))
                .RuleFor(prop => prop.Type, faker => faker.Random.Enum<ContactType>())
                .RuleFor(prop => prop.Value, (faker, val) => val.Type switch
                {
                    ContactType.Email => faker.Internet.Email(),
                    _ => faker.Phone.PhoneNumber(),

                })
                .RuleFor(prop => prop.IsPrimary, faker => faker.Random.Bool())
                .RuleFor(prop => prop.IsPersonal, faker => faker.Random.Bool())
                .RuleFor(prop => prop.Status, faker => faker.Random.Enum<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());
        }

        public static Faker<Address> FakerAddress(List<Guid> employeeIds)
        {
            return new Faker<Address>()
                .RuleFor(prop => prop.Id, faker => faker.Random.Guid())
                .RuleFor(prop => prop.EmployeeId, faker => faker.Random.CollectionItem(employeeIds))
                .RuleFor(prop => prop.Line1, faker => faker.Address.StreetAddress())
                .RuleFor(prop => prop.Line2, faker => faker.Address.StreetSuffix())
                .RuleFor(prop => prop.Barangay, faker => faker.Address.State())
                .RuleFor(prop => prop.City, faker => faker.Address.City())
                .RuleFor(prop => prop.Province, faker => faker.Address.State())
                .RuleFor(prop => prop.ZipCode, faker => faker.Address.ZipCode())
                .RuleFor(prop => prop.Country, faker => faker.Address.Country())
                .RuleFor(prop => prop.Type, faker => faker.Random.Enum<AddressType>())
                .RuleFor(prop => prop.Status, faker => faker.Random.Enum<CommonStatus>())
                .RuleFor(prop => prop.CreatedAt, faker => faker.Date.Future())
                .RuleFor(prop => prop.CreatedBy, faker => faker.Internet.Email());
        }
    }
}
