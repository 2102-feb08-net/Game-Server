using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.IntegrationTests
{
    public class ItemRepositoryTests
    {
        private Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Description = "Assault Weapon",
                Damage = 3,
                AttackSpeed = 5,
                LevelRequirement = 2,
                Rarity = "rare"
            };
        }
        private Consumable CreateConsumable(string name)
        {
            return new Consumable
            {
                ItemName = name,
                Description = "awesome consumable",
                Duration = 10,
                Strength = 5,
                Type = "healing"
            };
        }

        [Fact]
        public void GetWeapon_Gets1ExistingWeaponById()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedWeapon = CreateWeapon("AK-47");
            context.Weapons.Add(insertedWeapon);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            // act
            Business.Model.Weapon weapon = repo.GetWeapon(insertedWeapon.Id);

            // assert
            Assert.Equal(insertedWeapon.Id, weapon.Id);
            Assert.Equal(insertedWeapon.Name, weapon.Name);
            Assert.Equal(insertedWeapon.Description, weapon.Description);
            Assert.Equal(insertedWeapon.Damage, weapon.Damage);
            Assert.Equal(insertedWeapon.AttackSpeed, weapon.AttackSpeed);
            Assert.Equal(insertedWeapon.LevelRequirement, weapon.LevelRequirement);
            Assert.Equal(insertedWeapon.Rarity, weapon.Rarity);
        }

        [Fact]
        public void GetAllWeapons_GetsAllWeapons()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedWeapon1 = CreateWeapon("AK-47");
            var insertedWeapon2 = CreateWeapon("Katana");
            context.Weapons.Add(insertedWeapon1);
            context.Weapons.Add(insertedWeapon2);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            // act
            List<Business.Model.Weapon> weapon = repo.GetAllWeapons().ToList();

            // assert
            Assert.Equal(insertedWeapon1.Id, weapon[0].Id);
            Assert.Equal(insertedWeapon1.Name, weapon[0].Name);
            Assert.Equal(insertedWeapon1.Description, weapon[0].Description);
            Assert.Equal(insertedWeapon1.Damage, weapon[0].Damage);
            Assert.Equal(insertedWeapon1.AttackSpeed, weapon[0].AttackSpeed);
            Assert.Equal(insertedWeapon1.LevelRequirement, weapon[0].LevelRequirement);
            Assert.Equal(insertedWeapon1.Rarity, weapon[0].Rarity);
            Assert.Equal(insertedWeapon2.Id, weapon[1].Id);
            Assert.Equal(insertedWeapon2.Name, weapon[1].Name);
        }

        [Fact]
        public void GetConsumable_Gets1ConsumableById()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedConsumable = CreateConsumable("Health Potion");
            context.Consumables.Add(insertedConsumable);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            // act
            Business.Model.Consumable consumable = repo.GetConsumable(insertedConsumable.Id);

            // assert
            Assert.Equal(insertedConsumable.Id, consumable.Id);
            Assert.Equal(insertedConsumable.ItemName, consumable.ItemName);
            Assert.Equal(insertedConsumable.Description, consumable.Description);
            Assert.Equal(insertedConsumable.Duration, consumable.Duration);
            Assert.Equal(insertedConsumable.Strength, consumable.Strength);
            Assert.Equal(insertedConsumable.Type, consumable.Type);
        }

        [Fact]
        public void GetAllConsumables_GetsAllConsumables()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedConsumable1 = CreateConsumable("Health Potion");
            var insertedConsumable2 = CreateConsumable("Mana Potion");
            context.Consumables.Add(insertedConsumable1);
            context.Consumables.Add(insertedConsumable2);
            context.SaveChanges();
            var repo = new ItemRepository(context);

            // act
            List<Business.Model.Consumable> consumable = repo.GetAllConsumables().ToList();

            // assert
            Assert.Equal(insertedConsumable1.Id, consumable[0].Id);
            Assert.Equal(insertedConsumable1.ItemName, consumable[0].ItemName);
            Assert.Equal(insertedConsumable1.Description, consumable[0].Description);
            Assert.Equal(insertedConsumable1.Duration, consumable[0].Duration);
            Assert.Equal(insertedConsumable1.Strength, consumable[0].Strength);
            Assert.Equal(insertedConsumable1.Type, consumable[0].Type);
            Assert.Equal(insertedConsumable2.Id, consumable[1].Id);
            Assert.Equal(insertedConsumable2.ItemName, consumable[1].ItemName);
        }
    }
}