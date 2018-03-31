using System;
using Microsoft.SPOT;

namespace RSP125.Trigo
{
    public static class TrigoFunc
    {


        private const double sq2p1 = 2.414213562373095048802e0F;
        private const double sq2m1 = .414213562373095048802e0F;
        private const double m_pi = 3.14159265;
        private const double pio4 = .785398163397448309615e0F;
        private const double pio2 = 1.570796326794896619231e0F;
        private const double atan_p4 = .161536412982230228262e2F;
        private const double atan_p3 = .26842548195503973794141e3F;
        private const double atan_p2 = .11530293515404850115428136e4F;
        private const double atan_p1 = .178040631643319697105464587e4F;
        private const double atan_p0 = .89678597403663861959987488e3F;
        private const double atan_q4 = .5895697050844462222791e2F;
        private const double atan_q3 = .536265374031215315104235e3F;
        private const double atan_q2 = .16667838148816337184521798e4F;
        private const double atan_q1 = .207933497444540981287275926e4F;
        private const double atan_q0 = .89678597403663861962481162e3F;

        ///
        /// Returns the square root of a specified number
        ///
        /// <param name="x" />A positive real number
        /// The square root of x
        public static float Sqrt(float x)
        {
            //cut off any special case
            if (x <= 0.0f)
                return 0.0f;

            //here is a kind of base-10 logarithm
            //so that the argument will fall between
            //1 and 100, where the convergence is fast
            float exp = 1.0f;

            while (x < 1.0f)
            {
                x *= 100.0f;
                exp *= 0.1f;
            }

            while (x > 100.0f)
            {
                x *= 0.01f;
                exp *= 10.0f;
            }

            //choose the best starting point
            //upon the actual argument value
            float prev;

            if (x > 10f)
            {
                //decade (10..100)
                prev = 5.51f;
            }
            else if (x == 1.0f)
            {
                //avoid useless iterations
                return x * exp;
            }
            else
            {
                //decade (1..10)
                prev = 1.741f;
            }

            //apply the Newton-Rhapson method
            //just for three times
            prev = 0.5f * (prev + x / prev);
            prev = 0.5f * (prev + x / prev);
            prev = 0.5f * (prev + x / prev);

            //adjust the result multiplying for
            //the base being cut off before
            return prev * exp;
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="y">The y coordinate of a point</param>
        /// <param name="x">The x coordinate of a point</param>
        /// <returns>The arctangent of x/y</returns>
        public static double Atan2(double y, double x)
        {

            if ((x + y) == x)
            {
                if ((x == 0F) & (y == 0F)) return 0F;

                if (x >= 0.0F)
                    return pio2;
                else
                    return (-pio2);
            }
            else if (y < 0.0F)
            {
                if (x >= 0.0F)
                    return ((pio2 * 2) - Atans((-x) / y));
                else
                    return (((-pio2) * 2) + Atans(x / y));

            }
            else if (x > 0.0F)
            {
                return (Atans(x / y));
            }
            else
            {
                return (-Atans((-x) / y));
            }
        }

        public static double Atans(double x)
        {
            if (x < sq2m1)
                return (Atanx(x));
            else if (x > sq2p1)
                return (pio2 - Atanx(1.0F / x));
            else
                return (pio4 + Atanx((x - 1.0F) / (x + 1.0F)));
        }

        public static double Atanx(double x)
        {
            double argsq;
            double value;

            argsq = x * x;
            value = ((((atan_p4 * argsq + atan_p3) * argsq + atan_p2) * argsq + atan_p1) * argsq + atan_p0);
            value = value / (((((argsq + atan_q4) * argsq + atan_q3) * argsq + atan_q2) * argsq + atan_q1) * argsq + atan_q0);
            return (value * x);
        }
        public static double dist(double a, double b)
        {
            return Sqrt((float)((a * a) + (b * b)));
        }

        public static double get_y_rotation(double x, double y, double z)
        {
            double radians;
            radians = Atan2(x, dist(y, z));
            return (radians * (180.0 / m_pi));
        }

        public static double get_x_rotation(double x, double y, double z)
        {
            double radians;
            radians = Atan2(y, dist(x, z));
            return (radians * (180.0 / m_pi));
        }
    }
}
