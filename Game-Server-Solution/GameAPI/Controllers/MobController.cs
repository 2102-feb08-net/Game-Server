using Business.Interface;
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
        private readonly IMobRepository _mobRepository;

        /// <summary>
        /// Initialize the mobRepository.
        /// </summary>
        public MobController(IMobRepository mobRepository)
        {
           _mobRepository = mobRepository;
        }

        /// <summary>
        /// Gets a list of spawn locations for mobs
        /// </summary>
        /// <returns>IEnumarable of MobSpawn</returns>
        [HttpGet("api/mobspawns")]
        public IActionResult GetMobSpawns()
        {
            return Ok(_mobRepository.GetMobSpawns());
        }

        /// <summary>
        /// Gets all the mobs that will spawn in the game world
        /// </summary>
        /// <returns>IEnumerable of Mobs</returns>
        [HttpGet("api/mobs")]
        public IActionResult GetAllMobs()
        {
            return Ok(_mobRepository.GetAllMobs());
        }

        /// <summary>
        /// Gets the loot for killing a mob.
        /// </summary>
        /// <param name="mobId"></param>
        /// <returns>A Weapon</returns>
        [HttpGet("api/mobs/loot/{mobId}")]
        public IActionResult GetLoot(int mobId)
        {
            return Ok(_mobRepository.GetLoot(mobId));
        }
    }
}
