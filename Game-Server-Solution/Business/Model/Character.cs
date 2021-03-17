using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    /// <summary>
    /// Represents a character of a player.
    /// </summary>
    public class Character
    {
        private string _characterName;
        private int? _exp;
        private int? _health;
        private double? _attack;
        private double? _defense;
        private int? _mana;

        /// <summary>
        /// The character's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Character's name. Must be letters and digits only and 3 <= length <= 10.
        /// Throws an ArgumentException when constraints not met.
        /// </summary>
        public string CharacterName 
        { 
            get => _characterName;
            set
            {
                if (!value.All(Char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Can only input English letters and numbers for character names");
                }
                else if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Input size must be 3-10 for usernames");
                }
                else
                {
                    _characterName = value;
                }
            } 
        }

        /// <summary>
        /// The amount of experience points that the character has.
        /// Throws an ArgumentException when trying to set this to a value < 0.
        /// </summary>
        public int? Exp
        {
            get => _exp;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set character exp < 0");
                }
                else
                {
                    _exp = value;
                }
            }
        }

        /// <summary>
        /// The maximum health the character has.
        /// Throws an ArgumentException when trying to set this to a value < 0.
        /// </summary>
        public int? Health
        {
            get => _health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set character health < 0");
                }
                else
                {
                    _health = value;
                }
            }
        }

        /// <summary>
        /// How much damage the character can do.
        /// Throws an ArgumentException when trying to set this to a value < 0.
        /// </summary>
        public double? Attack
        {
            get => _attack;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set character attack < 0");
                }
                else
                {
                    _attack = value;
                }
            }
        }

        /// <summary>
        /// How much damage the character can absorb.
        /// Throws an ArgumentException when trying to set this to a value < 0.
        /// </summary>
        public double? Defense
        {
            get => _defense;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set character defense < 0");
                }
                else
                {
                    _defense = value;
                }
            }
        }

        /// <summary>
        /// How much mana the character has.
        /// Throws an ArgumentException when trying to set this to a value < 0.
        /// </summary>
        public int? Mana
        {
            get => _mana;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set character mana < 0");
                }
                else
                {
                    _mana = value;
                }
            }
        }


    }
}
