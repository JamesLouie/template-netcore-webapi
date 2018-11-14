using System;
using template.Domain.ValueObjects;
using Xunit;

namespace template.test.unit.Tests.Domain
{
    public class EmailTests
    {
        [Fact]
        public void Constructor_StandardInput()
        {
            // Setup
            var standardInput = "test@test.com";

            // Test
            var email = new Email(standardInput);

            // Validate
            Assert.Equal("test", email.LocalName);
            Assert.Equal("test.com", email.DomainAddress);
            Assert.Equal(standardInput, email.CompleteEmailAddress);
        }

        [Fact]
        public void Constructor_DoesNotContainSymbol_ThrowsException()
        {
            // Setup
            var invalidInput = "testtest.com";

            // Test and Validate
            Assert.Throws<ArgumentException>(() => new Email(invalidInput));
        }
    }
}
