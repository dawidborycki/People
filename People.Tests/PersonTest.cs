using People.WebApp.Models;
using System.Text.RegularExpressions;

namespace People.Tests;

public class PersonTest
{
        public class PersonTests
    {        
        [Fact]
        public void VerifyEmail()
        {
            // Arrange
            const string email = "@borycki.com.pl";

            // Act
            var isValid = EmailCheck(email);

            // Assert
            Assert.Equal(isValid, Person.IsValidEmail(email));
        }

        [Theory]
        [InlineData("dawid@")]
        [InlineData("dawid@borycki.com.pl")]
        [InlineData("@borycki.com.pl")]
        [InlineData("@")]
        public void VerifyEmailDataDrivenTest(string email)
        {
            // Act
            var isValid = EmailCheck(email);

            // Assert
            Assert.Equal(isValid, Person.IsValidEmail(email));
        }

        [Theory]
        [InlineData(new object[] { "dawid@", false })]
        [InlineData(new object[] { "dawid@borycki.com.pl", true })]
        [InlineData(new object[] { "@borycki.com.pl", false })]
        [InlineData(new object[] { "@", false })]
        public void VerifyEmailDataDrivenTestTwoArgs(string email,
            bool expectedResult)
        {
            // Act
            var isValid = EmailCheck(email);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }        

        private bool EmailCheck(string email)
        {
            const string emailPattern =
                @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";

            return Regex.IsMatch(email, emailPattern);
        }
    }
}