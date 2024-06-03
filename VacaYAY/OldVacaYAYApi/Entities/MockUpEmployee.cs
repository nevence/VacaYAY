using Bogus;
using static OldVacaYAYApi.Entities.MockUpEnums;

namespace OldVacaYAYApi.Entities
{
    public class MockUpEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public int DaysOffNumber { get; set; }
        public MockUpLocation Location { get; set; }
        public MockUpLogin Login { get; set; }
        public MockUpPosition Position { get; set; }

        public static Faker<MockUpEmployee> GetEmployeeGenerator()
        {
            return new Faker<MockUpEmployee>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(e => e.IDNumber, f => f.Random.AlphaNumeric(6))
                .RuleFor(e => e.EmploymentStartDate, f => f.Date.Past(5))
                .RuleFor(e => e.EmploymentEndDate, f => f.Date.Future(2).OrNull(f, 0.3f))
                .RuleFor(e => e.DaysOffNumber, f => f.Random.Int(5, 30))
                .RuleFor(e => e.Location, f => new MockUpLocation
                {
                    Street = f.Address.StreetAddress(),
                    City = f.Address.City(),
                    Country = f.Address.Country()
                })
                .RuleFor(e => e.Login, f => new MockUpLogin
                {
                    UserName = f.Internet.Email(),
                    Password = "Password123!",
                    Role = f.PickRandom(new[] { "Employee", "HR" })
                })
                .RuleFor(e => e.Position, f => new MockUpPosition
                {
                    Name = f.PickRandom<PositionName>().ToString(),
                    Description = f.Lorem.Sentence()
                });
        }
    }
}