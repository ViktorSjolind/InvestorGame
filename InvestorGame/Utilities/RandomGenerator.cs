using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.Utilities
{
    internal static class RandomGenerator
    {
        private static Random random;

        static RandomGenerator()
        {
            random = new Random();
        }

        public static int GetInteger(int min, int max)
        {
            return random.Next(min, max);
        }

    }
}
