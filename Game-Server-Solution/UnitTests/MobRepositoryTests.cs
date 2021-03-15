using System;
using Xunit;
using DataAccess;

namespace UnitTests
{
    public class MobRepositoryTests
    {
        [Fact]
        public void Test1()
        {
            MobRepository mobRepository = new MobRepository(context: Project2Context);
        }
    }
}
