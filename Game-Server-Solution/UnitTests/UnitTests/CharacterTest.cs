using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public class CharacterTest
    {
        private Character character;

        private void SetUp()
        {
            character = new();
        }


        [Theory]
        [InlineData("Hamza")]
        [InlineData("1234567")]
        [InlineData("Hamza213")]
        public void CharacterName_SetValidName_DoesNotThrowException(string name)
        {
            SetUp();

            character.CharacterName = name;
        }

        [Theory]
        [InlineData("Hi")]
        [InlineData("12345678901")]
        [InlineData("Hi Hi")]
        [InlineData("Hamza1!@")]
        public void CharacterName_SetInvalidName_ThrowsException(string name)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.CharacterName = name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10000)]
        public void Exp_SetValidNumber_DoesNotThrowException(int number)
        {
            SetUp();

            character.Exp = number;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Exp_SetInValidNumber_ThrowsException(int number)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.Exp = number);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10000)]
        public void Health_SetValidNumber_DoesNotThrowException(int number)
        {
            SetUp();

            character.Health = number;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Health_SetInValidNumber_ThrowsException(int number)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.Health = number);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10000)]
        public void Attack_SetValidNumber_DoesNotThrowException(int number)
        {
            SetUp();

            character.Attack = number;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Attack_SetInValidNumber_ThrowsException(int number)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.Attack = number);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10000)]
        public void Defense_SetValidNumber_DoesNotThrowException(int number)
        {
            SetUp();

            character.Defense = number;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Defense_SetInValidNumber_ThrowsException(int number)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.Defense = number);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10000)]
        public void Mana_SetValidNumber_DoesNotThrowException(int number)
        {
            SetUp();

            character.Mana = number;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Mana_SetInValidNumber_ThrowsException(int number)
        {
            SetUp();

            Assert.Throws<ArgumentException>(() => character.Mana = number);
        }

    }
}
