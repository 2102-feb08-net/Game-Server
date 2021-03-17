using Xunit;
using DataAccess;
using DataAccess.repositories;
using Moq;
using System;

namespace UnitTests
{
    public class ConsumableServiceTests
    {
        [Fact]
        public void Constructor_Accepts_Null()
        {
            var consumableService = new ConsumableService(null);
        }

        [Fact]
        public void GetRandomConsumable_GetsOneRandomConsumable()
        {
            // arrange
            var consumables = new[]
            {
                new Consumable {Id = 1, ItemName = "Strength Potion", Description = "Gives Strength points" , Duration = 60,
                Strength = 1.2, Type = "Strength"},
                new Consumable {Id = 2, ItemName = "Health Potion", Description = "Gives Health points" , Duration = 60,
                Strength = 5, Type = "Health"}
            };

            var mockRepo = new Mock<IItemRepository>();
            mockRepo.Setup(r => r.GetAllConsumables()).Returns(consumables).Verifiable();
            mockRepo.Setup(r => r.GetConsumable(It.IsAny<int>())).Verifiable();

            var consumableService = new ConsumableService(mockRepo.Object);

            // act
            consumableService.GetRandomConsumable();

            // assert
            Random gen = new Random();
            int randomId = gen.Next(consumables.Length);
            mockRepo.Verify(r => r.GetAllConsumables());
            mockRepo.Verify(r => r.GetConsumable(randomId));
            mockRepo.VerifyNoOtherCalls();
        }
    }
}
