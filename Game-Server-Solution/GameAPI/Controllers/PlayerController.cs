using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Controllers
{
    /// <summary>
    /// This controller handles requests for loading and updating player/character data
    /// </summary>
    [ApiController]
    public class PlayerController : ControllerBase
    {
        //private readonly IPlayerRepository _playerRepository;

        ///// <summary>
        ///// Constructor to set up the player repository
        ///// </summary>
        ///// <param name="playerRepository"></param>
        //public PlayerController(IPlayerRepository playerRepository)
        //{
        //    _playerRepository = playerRepository;
        //}

        ///// <summary>
        ///// Gets a list of all the monsters the player has killed and their quantaties.
        ///// </summary>
        ///// <param name="playerId"></param>
        ///// <returns>IEnumerable of mob kills of player</returns>
        //[HttpGet("api/player/{playerid}/kill-stat")]
        //public IEnumerable<KillStat> GetKillStats(int playerId)
        //{
        //    return _playerRepository.GetKillStats(playerId);
        //}

        ///// <summary>
        ///// Updates the kill stat of the player that killed the specific mob.
        ///// </summary>
        ///// <param name="playerId"></param>
        ///// <param name="mobId"></param>
        //[HttpPut("api/player/{playerid}/kill-stat/{mobId}")]
        //public void UpdateKillStat(int playerId, int mobId)
        //{
        //    _playerRepository.UpdateKillStat(playerId, mobId);
        //    _playerRepository.Save();
        //}

        ///// <summary>
        ///// Gets all the player's characters and their stats. (exp, attack, strength, defense, mana).
        ///// </summary>
        ///// <param name="playerId"></param>
        ///// <returns>A List of characters that player has</returns>
        //[HttpGet("api/player/{playerId}/character-stats")]
        //public IEnumerable<Character> GetCharacterStats(int playerId)
        //{
        //    return _playerRepository.GetCharacterStats(playerId);
        //}

        ///// <summary>
        ///// Updates the stats of the character. (exp, attack, strength, defense, mana).
        ///// </summary>
        ///// <param name="character"></param>
        //[HttpPut("api/character/{character}/character-stats")]
        //public void UpdateCharacterStats(Character character)
        //{
        //    _playerRepository.UpdateCharacterStats(character);
        //    _playerRepository.Save();
        //}
    }
}
