﻿using System;
using System.Diagnostics;

namespace IronAHK.Rusty
{
    partial class Core
    {
        // TODO: organise Math.cs

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="n">Any number.</param>
        /// <returns>The magnitude of <paramref name="n"/>.</returns>
        public static decimal Abs(decimal n)
        {
            return Math.Abs(n);
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="n">A number representing a cosine, where -1 ≤ <paramref name="n"/> ≤ 1.</param>
        /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π.</returns>
        public static double ACos(double n)
        {
            return Math.Acos(n);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="n">A number representing a sine, where -1 ≤ <paramref name="n"/> ≤ 1.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        public static double ASin(double n)
        {
            return Math.Asin(n);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="n">A number representing a tangent.</param>
        /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
        public static double ATan(double n)
        {
            return Math.Atan(n);
        }

        /// <summary>
        /// Returns the smallest integer greater than or equal to the specified decimal number.
        /// </summary>
        /// <param name="n">A number.</param>
        /// <returns>The smallest integer greater than or equal to <paramref name="n"/>.</returns>
        public static decimal Ceil(decimal n)
        {
            return Math.Ceiling(n);
        }

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <param name="n">An angle, measured in radians.</param>
        /// <returns>The cosine of <paramref name="n"/>.</returns>
        public static double Cos(double n)
        {
            return Math.Cos(n);
        }

        /// <summary>
        /// Add a value to a variable using numeric or date-time arithmetic.
        /// </summary>
        /// <param name="var">A variable.</param>
        /// <param name="value">A number.</param>
        /// <param name="units">
        /// To use date arithmetic specify one of the following words:
        /// <c>seconds</c> (<c>s</c>), <c>minutes</c> (<c>m</c>), <c>hours</c> (<c>h</c>), <c>days</c> (<c>d</c>), <c>months</c> or <c>years</c> (<c>y</c>).
        /// If this parameter is blank the functions performs a numeric addition.
        /// </param>
        public static void EnvAdd(ref double var, double value, string units = null)
        {
            if (string.IsNullOrEmpty(units))
            {
                var += value;
                return;
            }

            var time = ToDateTime(((int)var).ToString());

            switch (units.ToLowerInvariant())
            {
                case Keyword_Seconds:
                case "s":
                    time = time.AddSeconds(value);
                    break;

                case Keyword_Minutes:
                case "m":
                    time = time.AddMinutes(value);
                    break;

                case Keyword_Hours:
                case "h":
                    time = time.AddHours(value);
                    break;

                case Keyword_Days:
                case "d":
                    time = time.AddDays(value);
                    break;

                case Keyword_Months:
                case "mn":
                    time = time.AddMonths((int)value);
                    break;

                case Keyword_Years:
                case "y":
                    time = time.AddYears((int)value);
                    break;
            }

            var = FromTime(time);
        }

        /// <summary>
        /// See <see cref="EnvAdd"/>.
        /// </summary>
        /// <param name="var">A variable.</param>
        /// <param name="value">A value.</param>
        /// <param name="units">A numeric unit.</param>
        [Obsolete, Conditional("LEGACY")]
        public static void EnvSub(ref double var, double value, string units = null)
        {
            EnvAdd(ref var, -value, units);
        }

        /// <summary>
        /// Returns <c>e</c> raised to the specified power.
        /// </summary>
        /// <param name="n">A number specifying a power.</param>
        /// <returns>The number <c>e</c> raised to the power <paramref name="n"/>.</returns>
        public static double Exp(double n)
        {
            return Math.Exp(n);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified decimal number.
        /// </summary>
        /// <param name="n">A number.</param>
        /// <returns>The largest integer less than or equal to <paramref name="n"/>.</returns>
        public static decimal Floor(decimal n)
        {
            return Math.Floor(n);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="n">A number whose logarithm is to be found.</param>
        /// <returns>The natural logarithm of <paramref name="n"/>.</returns>
        public static double Ln(double n)
        {
            return Math.Log(n);
        }

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        /// <param name="n">A number whose logarithm is to be found.</param>
        /// <param name="b">The base of the logarithm. If unspecified this is <c>10</c>.</param>
        /// <returns>The logarithm of <paramref name="n"/> to base <paramref name="b"/>.</returns>
        public static double Log(double n, double b = 10)
        {
            return b == 10 ? Math.Log10(n) : Math.Log(n, b);
        }

        /// <summary>
        /// Returns the remainder after dividing two numbers.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The remainder after dividing <paramref name="dividend"/> by <paramref name="divisor"/>.</returns>
        public static decimal Mod(decimal dividend, decimal divisor)
        {
            return divisor == 0 ? 0 : dividend % divisor;
        }

        /// <summary>
        /// Generates a pseudo-random number.
        /// </summary>
        /// <param name="OutputVar">The name of the variable in which to store the result. The format of stored floating point numbers is determined by SetFormat.</param>
        /// <param name="Min">The smallest number that can be generated, which can be negative or floating point. If omitted, the smallest number will be 0. The lowest allowed value is -2147483648 for integers, but floating point numbers have no restrictions.</param>
        /// <param name="Max">The largest number that can be generated, which can be negative or floating point. If omitted, the largest number will be 2147483647 (which is also the largest allowed integer value -- but floating point numbers have no restrictions).</param>
        public static void Random(out double OutputVar, double Min, double Max)
        {
            var r = new Random();
            double x = Math.IEEERemainder(Min, 1), y = Math.IEEERemainder(Max, 1), z = r.Next((int)Min, (int)Max);

            if (x != 0 || y != 0)
                z += (r.NextDouble() % Math.Abs(y - x)) + x;

            OutputVar = z;
        }

        /// <summary>
        /// If N is omitted or 0, Number is rounded to the nearest integer. If N is positive number, Number is rounded to N decimal places. If N is negative, Number is rounded by N digits to the left of the decimal point. For example, Round(345, -1) is 350 and Round (345, -2) is 300. Unlike Transform Round, the result has no .000 suffix whenever N is omitted or less than 1. In v1.0.44.01+, a value of N greater than zero displays exactly N decimal places rather than obeying SetFormat. To avoid this, perform another math operation on Round()'s return value; for example: Round(3.333, 1)+0.
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Places"></param>
        /// <returns></returns>
        public static decimal Round(decimal Number, decimal Places)
        {
            return Math.Round(Number, (int)Places);
        }

        /// <summary>
        /// Returns the trigonometric sine Number. Number must be expressed in radians.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static decimal Sin(decimal Number)
        {
            return (decimal)Math.Sin((double)Number);
        }

        /// <summary>
        /// Returns the square root of Number. The result is formatted as floating point. If Number is negative, the function yields a blank result (empty string).
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static decimal Sqrt(decimal Number)
        {
            return (decimal)Math.Sqrt((double)Number);
        }

        /// <summary>
        /// Returns the trigonometric tangent of Number. Number must be expressed in radians.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static decimal Tan(decimal Number)
        {
            return (decimal)Math.Tan((double)Number);
        }
    }
}