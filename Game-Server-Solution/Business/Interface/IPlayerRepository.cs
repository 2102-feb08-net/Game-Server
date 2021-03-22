using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    /// <summary>
    /// Interface for player repository
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Creates the player with the given username and password in the database.
        /// Creates a Character for that player with the given chararcter name.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>The Player that was created</returns>
        Player CreatePlayer(Player player, string characterName);

        /// <summary>
        /// Gets the player from the database with the given username and password.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>A Player</returns>
        Player GetPlayer(Player player);

        /// <summary>
        /// Gets all the kill stats of the player
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>IEnumerable of KillStat</returns>
        IEnumerable<KillStat> GetKillStats(int playerId);

        /// <summary>
        /// Updates the KillStat of the player that killed the mob specified by mobId.
        /// If the KillStat doesn't exist, creates it on the database
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="mobId"></param>
        void UpdateKillStat(int playerId, int mobId);

        /// <summary>
        /// Gets the character stats of the player specified by playerId
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>A character</returns>
        Character GetCharacterStats(int playerId);

        /// <summary>
        /// Updates the character stats of the specified character on the database
        /// </summary>
        /// <param name="character"></param>
        void UpdateCharacterStats(Character character);

        /// <summary>
        /// Persists the changes onto the database
        /// </summary>
        void Save();
    }
}
