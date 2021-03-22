using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using Business.Model;

namespace GameAPI.Controllers
{
    /// <summary>
    /// This controller handles requests for loading and updating player/character data
    /// </summary>
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        /// <summary>
        /// Constructor to set up the player repository
        /// </summary>
        /// <param name="playerRepository"></param>
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// Gets a Player that matches the username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>A Player</returns>
        [HttpGet("api/player/{username}/{password}/login")]
        public IActionResult GetPlayer(string username, string password)
        {
            return Ok(_playerRepository.GetPlayer(username, password));
        }

        /// <summary>
        /// Creates a player with the given username and password and creates a character with the given character name.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="characterName"></param>
        /// <returns>201Created response</returns>
        [HttpPost("api/player/{player}/{characterName}/register")]
        public IActionResult CreatePlayer(Player player, string characterName)
        {
            return CreatedAtAction(nameof(CreatePlayer), _playerRepository.CreatePlayer(player, characterName));
        }

        /// <summary>
        /// Gets a list of all the monsters the player has killed and their quantaties.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>IEnumerable of mob kills of player</returns>
        [HttpGet("api/player/{playerid}/kill-stat")]
        public IEnumerable<KillStat> GetKillStats(int playerId)
        {
            return _playerRepository.GetKillStats(playerId);
        }

        /// <summary>
        /// Updates the kill stat of the player that killed the specific mob.
        /// If it is the first time killing the mob, adds the data to the database instead.
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="mobId"></param>
        [HttpPut("api/player/{playerid}/kill-stat/{mobId}")]
        public void UpdateKillStat(int playerId, int mobId)
        {
            _playerRepository.UpdateKillStat(playerId, mobId);
            _playerRepository.Save();
        }

        /// <summary>
        /// Gets the player's character and its stats. (exp, attack, strength, defense, mana).
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>The character of the player</returns>
        [HttpGet("api/player/{playerId}/character-stats")]
        public Character GetCharacterStats(int playerId)
        {
            return _playerRepository.GetCharacterStats(playerId);
        }

        /// <summary>
        /// Updates the stats of the character. (exp, attack, strength, defense, mana).
        /// </summary>
        /// <param name="character"></param>
        [HttpPut("api/character/{character}/character-stats")]
        public void UpdateCharacterStats(Character character)
        {
            _playerRepository.UpdateCharacterStats(character);
            _playerRepository.Save();
        }
    }
}
