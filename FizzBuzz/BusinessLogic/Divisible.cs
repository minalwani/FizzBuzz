using FizzBuzz.Interfaces;

namespace FizzBuzz.BusinessLogic
{
    public class Divisible : IDivisible
    {
        public bool IsDivisible(int i, int divVal)
        {
            if (i % divVal == 0)
                return true;
            else
                return false;
        }
    }
}
