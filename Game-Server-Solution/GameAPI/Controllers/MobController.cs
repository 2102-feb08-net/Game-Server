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
    /// This controller handles saving and loading mobs and mob loot
    /// </summary>
    [ApiController]
    public class MobController : ControllerBase
    {
        //private readonly IMobRepository _mobRepository;

        /////////// <summary>
        /////////// Get mob repository.
        /////////// </summary>
        //public MobController(IMobRepository mobRepository)
        //{
        //   _mobRepository = mobRepository;
        //}

        ///// <summary>
        ///// Set and save mob stats to databse.
        ///// </summary>
        ////[HttpPost("api/admin/monster-creation")]
        ////public void RegisterMobStats(int mobID, , int health, int experience, float attack, float defense, float speed)
        ////{
        ////    _mobRepository.SetMobStats(mobID, health, experience, attack, defense, defense, speed);
        ////    _mobRepository.Save();
        ////}

        ///// <summary>
        ///// Set and save mob loot to database.
        ///// </summary>
        ////[HttpPost("api/admin/monster-loot")]
        ////public void RegisterMobLoot(int mobID, int lootID, int lootLineID, int weaponID, int quantity, decimal dropPercentage)
        ////{
        ////    _mobRepository.SetMonsterLoot(mobID, lootID, lootLineID, weaponID, quantity, dropPercentage);
        ////    _mobRepository.Save();
        ////}

        ///// <summary>
        ///// Get list of mobs with their stats and spawn location.
        ///// </summary>
        //[HttpGet("api/mobspawns")]
        //public IActionResult LoadMobs()
        //{
        //    return Ok(_mobRepository.GetMobspawns());
        //}
        ///// <summary>
        ///// Get Loot of Mob given a MobID.
        ///// </summary>
        ////[HttpGet("api/maze/mobloot")]
        ////public Loot LoadMobLoot(int mobID) 
        ////{
        ////    return _mobRepository.GetMobLoot(mobID);
        ////}
    }
}
