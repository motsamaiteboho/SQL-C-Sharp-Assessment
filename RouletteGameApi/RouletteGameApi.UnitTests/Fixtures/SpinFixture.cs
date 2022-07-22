using RouletteGameApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.UnitTests.Fixtures
{
    public static class SpinFixture
    {
        public static Spin Spin()
        {
            var winningnumber = (int)Random.Shared.Next(0, 37);
            var spin = new Spin()
            {
                Id = Guid.NewGuid(),
                WinningNumber = winningnumber,
            };
            return spin;
        }
    }
}
