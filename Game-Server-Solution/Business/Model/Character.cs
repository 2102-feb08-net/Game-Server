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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }


    }
}
