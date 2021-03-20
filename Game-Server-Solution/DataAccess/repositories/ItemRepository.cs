using Business.Interface;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Project2Context _context;

        public ItemRepository(Project2Context context)
        {
            _context = context;
        }

        public IEnumerable<Business.Model.Consumable> GetAllConsumables()
        {
            var consumables = _context.Consumables
                .Select(c => c);

            return consumables.Select(c => new Business.Model.Consumable
            {
                Id = c.Id,
                ItemName = c.ItemName,
                Description = c.Description,
                Duration = c.Duration,
                Strength = c.Strength,
                Type = c.Type
            });
        }

        public IEnumerable<Business.Model.Weapon> GetAllWeapons()
        {
            var weapons = _context.Weapons
                .Select(w => w);

            return weapons.Select(w => new Business.Model.Weapon
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Damage = w.Damage,
                AttackSpeed = w.AttackSpeed,
                LevelRequirement = w.LevelRequirement,
                Rarity = w.Rarity
            });
        }

        public Business.Model.Consumable GetConsumable(int id)
        {
            var consumable = _context.Consumables
                .First(c => c.Id == id);

            return new Business.Model.Consumable
            {
                Id = consumable.Id,
                ItemName = consumable.ItemName,
                Description = consumable.Description,
                Duration = consumable.Duration,
                Strength = consumable.Strength,
                Type = consumable.Type
            };
        }

        public Business.Model.Weapon GetWeapon(int id)
        {
            var weapon = _context.Weapons
                .First(w => w.Id == id);

            return new Business.Model.Weapon
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Description = weapon.Description,
                Damage = weapon.Damage,
                AttackSpeed = weapon.AttackSpeed,
                LevelRequirement = weapon.LevelRequirement,
                Rarity = weapon.Rarity
            };
        }
    }
}
