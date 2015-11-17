namespace DigiAeon.Core
{
    using DigiAeon.Core.Enums;

    /// <summary>
    /// The shape helper.
    /// </summary>
    public static class ShapeHelper
    {
        /// <summary>
        /// The get triangle type.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="ShapeType"/>.
        /// </returns>
        public static ShapeType GetTriangleType(int a, int b, int c)
        {
            // side values cannot be negative or zero
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return ShapeType.Error;
            }

            // Because sum can exceeed int.MaxValue
            long sideA = a;
            long sideB = b;
            long sideC = c;

            // Sum of two sides must be greater than the third one, otherwise it would create triangle!
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                return ShapeType.Error;
            }

            if (a == b && a == c && b == c)
            {
                return ShapeType.EquilateralTriangle;
            }

            if ((a == b && a != c) || (a == c && a != b) || (b == c && b != a))
            {
                return ShapeType.IsoscelesTriangle;
            }

            return ShapeType.ScaleneTriangle;
        }
    }
}
