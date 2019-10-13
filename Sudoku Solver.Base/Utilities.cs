using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public static class Utilities
    {
        static Random random = new Random(); 
    
        public static int GenerateRandomInteger(int min = 1, int max = 9)
        {
            return random.Next(min,max);
        }
    }
}
