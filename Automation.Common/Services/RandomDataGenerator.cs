using System;
using Automation.Common.Models;
namespace PlaywrightAutomation.Utilities
{
    public static class RandomDataGenerator
    {
        private static readonly Random _random = new();

        public static UserModel GenerateRandomUser()
        {
            return new UserModel
            {
                FirstName = GetRandomFirstName(),
                LastName = GetRandomLastName(),
                Email = GetRandomEmail(),
                Password = "Test@123",
                Address = GetRandomAddress(),
                State = "Telangana",
                City = "Hyderabad",
                ZipCode = GetRandomZipCode(),
                Mobile = GetRandomMobileNumber()
            };
        }

        public static string GetRandomEmail()
            => $"test{Guid.NewGuid():N}@mail.com";

        public static string GetRandomFirstName()
        {
            string[] names = { "Sai", "Arjun", "David", "John", "Ravi" };
            return names[_random.Next(names.Length)];
        }

        public static string GetRandomLastName()
        {
            string[] names = { "Kumar", "Smith", "Reddy", "Brown", "Goud" };
            return names[_random.Next(names.Length)];
        }

        public static string GetRandomMobileNumber()
            => "9" + _random.Next(100000000, 999999999);

        public static string GetRandomAddress()
            => $"Street {_random.Next(1, 999)}, Hyderabad";

        public static string GetRandomZipCode()
            => _random.Next(100000, 999999).ToString();
    }
}
