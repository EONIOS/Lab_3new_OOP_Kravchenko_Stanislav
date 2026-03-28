using System;

namespace Lab3new_OOP_Kravchenko
{
    public abstract class Pair
    {
        protected int first;
        protected int second;

        public Pair(int f, int s) { first = f; second = s; }

        public abstract Pair Add(Pair other);
        public abstract Pair Subtract(Pair other);
        public abstract Pair Multiply(Pair other);
        public abstract Pair Divide(Pair other);
        public abstract override string ToString();
    }

    public class Money : Pair
    {
        public Money(int h, int k) : base(h, k) { Normalize(); }
        private void Normalize()
        {
            first += second / 100; second %= 100;
            if (second < 0) { first--; second += 100; }
        }
        public override Pair Add(Pair other) => new Money(first + ((Money)other).first, second + ((Money)other).second);
        public override Pair Subtract(Pair other) => new Money(first - ((Money)other).first, second - ((Money)other).second);
        public override Pair Multiply(Pair other)
        {
            long t1 = first * 100 + second;
            long t2 = ((Money)other).first * 100 + ((Money)other).second;
            long res = (t1 * t2) / 100;
            return new Money((int)(res / 100), (int)(res % 100));
        }
        public override Pair Divide(Pair other)
        {
            long t1 = first * 100 + second;
            long t2 = ((Money)other).first * 100 + ((Money)other).second;
            if (t2 == 0) throw new DivideByZeroException();
            long res = (t1 * 100) / t2;
            return new Money((int)(res / 100), (int)(res % 100));
        }
        public override string ToString() => $"{first} грн, {second:D2} коп.";
    }

    public class Fraction : Pair
    {
        public Fraction(int i, int f) : base(i, f) { }
        private double ToDouble() => first + (second / 100.0);
        private static Fraction FromDouble(double v) => new Fraction((int)v, (int)(Math.Round(Math.Abs(v - (int)v) * 100)));
        public override Pair Add(Pair other) => FromDouble(ToDouble() + ((Fraction)other).ToDouble());
        public override Pair Subtract(Pair other) => FromDouble(ToDouble() - ((Fraction)other).ToDouble());
        public override Pair Multiply(Pair other) => FromDouble(ToDouble() * ((Fraction)other).ToDouble());
        public override Pair Divide(Pair other)
        {
            double d2 = ((Fraction)other).ToDouble();
            if (d2 == 0) throw new DivideByZeroException();
            return FromDouble(ToDouble() / d2);
        }
        public override string ToString() => ToDouble().ToString("F2");
    }
}
