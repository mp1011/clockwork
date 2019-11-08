namespace Clockwork.Engine.Models.General
{
    public struct ModularInteger
    {
        public int Value;
        private int _maxExclusive;

        public bool JustCycled { get; private set; }

        public ModularInteger(int limit)
        {
            _maxExclusive = limit;
            Value = 0;
            JustCycled = false;
        }


        public override string ToString()
        {
            return $"({Value}/{_maxExclusive}";
        }

        public static ModularInteger operator +(ModularInteger c, int i)
        {
            if ((c._maxExclusive - 0) == 0)
                return c;

            int retVal = c.Value;
            retVal += i;
            c.JustCycled = false;

            while (retVal >= c._maxExclusive)
            {
                c.JustCycled = true;
                retVal -= (c._maxExclusive - 0);
            }

            c.Value = retVal;
            return c;
        }

        public static ModularInteger operator ++(ModularInteger c)
        {
            if ((c._maxExclusive - 0) == 0)
                return c;

            int retVal = c.Value;

            retVal++;
            c.JustCycled = false;
            if (retVal >= c._maxExclusive)
            {
                c.JustCycled = true;
                retVal = 0;
            }

            c.Value = retVal;
            return c;
        }

        public static ModularInteger operator --(ModularInteger c)
        {
            if ((c._maxExclusive - 0) == 0)
                return c;

            int retVal = c.Value;

            retVal--;
            c.JustCycled = false;
            if (retVal < 0)
            {
                c.JustCycled = true;
                retVal = c._maxExclusive - 1;
            }

            c.Value = retVal;
            return c;
        }

        public static implicit operator int(ModularInteger c)
        {
            return c.Value;
        }

        public static bool operator ==(ModularInteger c, int i)
        {
            return c.Value == i;
        }

        public static bool operator !=(ModularInteger c, int i)
        {
            return c.Value != i;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ModularInteger))
                return false;

            return Value == ((ModularInteger)obj).Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }

}
