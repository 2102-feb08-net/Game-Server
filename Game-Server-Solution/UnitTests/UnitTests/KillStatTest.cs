using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UnitTests
{
    public class KillStatTest
    {
        private KillStat killStat;

        private void SetUp()
        {
            killStat = new();
        }

        [Fact]
        public void UpdateQuantity_IncrementsQuantityBy1()
        {
            SetUp();

            killStat.UpdateQuantity();
            Assert.Equal(1, killStat.Quantity);
            killStat.UpdateQuantity();
            Assert.Equal(2, killStat.Quantity);
        }


    }
}
