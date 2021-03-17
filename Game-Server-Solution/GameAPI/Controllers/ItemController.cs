using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.repositories;
using DataAccess;


namespace GameAPI.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        private readonly IConsumableService _consumableService;

        public ItemController(IItemRepository itemRepository, IConsumableService consumableService)
        {
            _itemRepository = itemRepository;
            _consumableService = consumableService;
        }

        [HttpGet("/api/weapons")]
        public IEnumerable<Weapon> GetAllWeapons()
        {
            return _itemRepository.GetAllWeapons();
        }

        [HttpGet("/api/weapons/{id}")]
        public Weapon GetWeapon(int id)
        {
            return _itemRepository.GetWeapon(id);
        }

        [HttpGet("/api/consumables")]
        IEnumerable<Consumable> GetAllConsumables()
        {
            return _itemRepository.GetAllConsumables();
        }

        [HttpGet("/api/consumables/{id}")]
        public Consumable GetConsumable(int id)
        {
            return _itemRepository.GetConsumable(id);
        }

        [HttpGet("/api/consumables/random")]
        public Consumable GetRandomConsumable()
        {
            return _consumableService.GetRandomConsumable();
        }
    }
}
