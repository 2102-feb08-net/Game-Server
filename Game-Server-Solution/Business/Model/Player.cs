using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    /// <summary>
    /// Represents a player account.
    /// </summary>
    public class Player
    {
        private string _username;
        private string _password;

        /// <summary>
        /// Player's id.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id of the player's character.
        /// </summary>
        public int? CharacterId { get; set; }

        /// <summary>
        /// Player's username that is displayed to others. Can only be letters or digits and 5 <= length <= 15.
        /// If it is not, throws an ArgumentException.
        /// </summary>
        public string Username 
        { 
            get => _username;
            set 
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentException("Input size must be 5-25 for usernames");
                }
                else
                {
                    _username = value;
                }
            } 
        }

        /// <summary>
        /// Player's password for logging in. Can only be 5 < length < 15.
        /// If it is not, throws an ArgumentException.
        /// </summary>
        public string Password 
        { 
            get => _password; 
            set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException("Input size must be 5-15 for passwords");
                }
                else if (value.Any(Char.IsWhiteSpace))
                {
                    throw new ArgumentException("Passwords cannot contain spaces");
                }
                else
                {
                    _password = value;
                }
            }
        }


    }
}
