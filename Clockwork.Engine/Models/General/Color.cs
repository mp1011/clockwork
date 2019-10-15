namespace Clockwork.Engine.Models.General
{
    public class Color
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"R={R},G={G},B={B}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Color c)
                return c.R == R && c.G == G && c.B == B;
            else
                return false;      
        }

        public override int GetHashCode()
        {
            return R * 100000 + G * 1000 + B;
        }
    }
}
