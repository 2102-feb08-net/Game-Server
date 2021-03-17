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

            // act
            Weapon weapon = repo.GetWeapon(insertedWeapon.Id);

            // assert
            Assert.Equal(insertedWeapon.Id, weapon.Id);
            Assert.Equal(insertedWeapon.Name, weapon.Name);
            Assert.Equal(insertedWeapon.Damage, weapon.Damage);
            Assert.Equal(insertedWeapon.Description, weapon.Description);
            Assert.Equal(insertedWeapon.LevelRequirement, weapon.LevelRequirement);
        }
    }
}
