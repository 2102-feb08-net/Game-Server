using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UnitTests
{
    public class PlayerTest
    {
        private Player player;

        private void SetUp()
        {
            player = new();
        }

        [Theory]
        [InlineData("Hamza")]
        [InlineData("2453556")]
        [InlineData("Hamza213")]
        public void Username_ValidName_DoesNotThrowException(string username)
        {
            SetUp();

            player.Username = username;
        }

        [Theory]
        [InlineData("Butt")]
        [InlineData("1234567890123456")]
        [InlineData("Hamza Butt")]
        [InlineData("Hamza!@#")]
        public void Username_InvalidName_ThrowsException(string username)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => player.Username = username);
        }

        [Theory]
        [InlineData("Hamza")]
        [InlineData("2453556")]
        [InlineData("Hamza213!@")]
        public void Password_ValidName_DoesNotThrowException(string password)
        {
            SetUp();

            player.Password = password;
        }

        [Theory]
        [InlineData("Butt")]
        [InlineData("1234567890123456")]
        [InlineData("Hamza Butt")]
        public void Password_InvalidName_ThrowsException(string password)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => player.Password = password);
        }


    }
}
