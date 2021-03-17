using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class ItemRepositoryTests
    {
        [Fact]
        public void Get_GetsExistingWeapon()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();

            var insertedWeapon = new Weapon
            {
                Name = "AK-47",
                Damage = 3,
                Description = "Assault Weapon",
                LevelRequirement = 2
            };
            context.Weapons.Add(insertedWeapon);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            //// act
            Weapon weapon = repo.GetWeapon(insertedWeapon.Id);
            
            // assert
            Assert.Equal(insertedWeapon.Id, weapon.Id);
            Assert.Equal(insertedWeapon.Name, weapon.Name);
            Assert.Equal(insertedWeapon.Damage, weapon.Damage);
            Assert.Equal(insertedWeapon.Description, weapon.Description);
            Assert.Equal(insertedWeapon.LevelRequirement, weapon.LevelRequirement);
        }


        [Fact]
        public void Get_GetsExistingConsumable()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();

            var insertedConsumable = new Consumable
            {
                ItemName = "Super Strength Potion",
                Description = "Adds Significant Power",
                Duration = 60,
                Strength = 10,
                Type = "strength"
            };
            context.Consumables.Add(insertedConsumable);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            //// act
            Consumable potion = repo.GetConsumable(insertedConsumable.Id);

            // assert
            Assert.Equal(insertedConsumable.Id, potion.Id);
            Assert.Equal(insertedConsumable.ItemName, potion.ItemName);
            Assert.Equal(insertedConsumable.Duration, potion.Duration);
            Assert.Equal(insertedConsumable.Description, potion.Description);
            Assert.Equal(insertedConsumable.Type, potion.Type);
            Assert.Equal(insertedConsumable.Strength, potion.Strength);
        }

        [Fact]
        public void GetAllConsumables_GetsExistingConsumables()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();

            var insertedConsumable1 = new Consumable
            {
                ItemName = "Super Strength Potion",
                Description = "Adds Significant Power",
                Duration = 60,
                Strength = 10,
                Type = "strength"
            };
            var insertedConsumable2 = new Consumable
            {
                ItemName = "Super Health Potion",
                Description = "Adds Significant Health",
                Duration = 60,
                Strength = 10,
                Type = "health"
            };

            List <Consumable> entries = new();
            entries.Add(insertedConsumable1);
            entries.Add(insertedConsumable2);

            context.Consumables.Add(insertedConsumable1);
            context.Consumables.Add(insertedConsumable2);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            //// act
            List<Consumable> consumables = repo.GetAllConsumables()
                .OrderByDescending(c => c.Id)
                .Take(2).Reverse().ToList();

            // assert
            Assert.Equal(entries, consumables);
        }

        [Fact]
        public void GetAllWeapons_GetsExistingWeapons()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();

            var insertedWeapon1 = new Weapon
            {
                Name = "AK-47",
                Damage = 3,
                Description = "Assault Weapon",
                LevelRequirement = 2
            };
            var insertedWeapon2 = new Weapon
            {
                Name = "Bazooka",
                Damage = 10,
                Description = "Will destroy you",
                LevelRequirement = 5
            };

            List<Weapon> entries = new();
            entries.Add(insertedWeapon1);
            entries.Add(insertedWeapon2);

            context.Weapons.Add(insertedWeapon1);
            context.Weapons.Add(insertedWeapon2);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            //// act
            List<Weapon> weapons = repo.GetAllWeapons()
                .OrderByDescending(c => c.Id)
                .Take(2).Reverse().ToList();

            // assert
            Assert.Equal(entries, weapons);
        }
    }
}
