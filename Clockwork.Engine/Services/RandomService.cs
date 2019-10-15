namespace Clockwork.Engine.Services
{
    public static class RandomService
    {
        private static System.Random rng = new System.Random();

        public static int Range(int minInc, int maxExc)
        {
            return rng.Next(minInc, maxExc);
        }

        public static bool Chance(double odds)
        {
            var value = rng.NextDouble();
            return value <= odds;
        }
    }
}
