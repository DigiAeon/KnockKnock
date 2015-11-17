namespace DigiAeon.KnockKnock.Services
{
    using System;
    using System.ServiceModel;

    using DigiAeon.Core;
    using DigiAeon.Core.Enums;
    using DigiAeon.KnockKnock.Services.Interfaces;

    /// <summary>
    /// The red pill.
    /// </summary>
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {
        /// <summary>
        /// The my token.
        /// </summary>
        private readonly Guid _myToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedPill"/> class.
        /// </summary>
        /// <param name="myToken">
        /// The my token.
        /// </param>
        public RedPill(Guid myToken)
        {
            this._myToken = myToken;
        }

        /// <summary>
        /// The what is your token.
        /// </summary>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public Guid WhatIsYourToken()
        {
            return this._myToken;
        }

        /// <summary>
        /// The fibonacci number.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        /// <exception cref="FaultException{T}">
        /// In case of ArgumentOutOfRangeException, it will be wrapped inside FaultException.
        /// </exception>
        public long FibonacciNumber(long n)
        {
            try
            {
                if (n < -92)
                {
                    throw new ArgumentOutOfRangeException("n", "Fib(<92) will cause a 64-bit integer overflow.");
                }

                if (n > 92)
                {
                    throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
                }

                return n.GetNthFibonacciNumber();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new FaultException<ArgumentOutOfRangeException>(ex, ex.Message);
            }
        }

        /// <summary>
        /// The what shape is this.
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
        /// The <see cref="TriangleType"/>.
        /// </returns>
        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            var shapeType = ShapeHelper.GetTriangleType(a, b, c);

            switch (shapeType)
            {
                case ShapeType.EquilateralTriangle:
                    return TriangleType.Equilateral;

                case ShapeType.IsoscelesTriangle:
                    return TriangleType.Isosceles;

                case ShapeType.ScaleneTriangle:
                    return TriangleType.Scalene;

                default:
                    return TriangleType.Error;
            }
        }

        /// <summary>
        /// The reverse words.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="FaultException{T}">
        /// In case of ArgumentNullException, it will be wrapped inside FaultException.
        /// </exception>
        public string ReverseWords(string s)
        {
            try
            {
                if (s == null)
                {
                    throw new ArgumentNullException("s", "Value cannot be null.");
                }

                return s.ReverseWords();
            }
            catch (ArgumentNullException ex)
            {
                throw new FaultException<ArgumentNullException>(ex, ex.Message);
            }
        }
    }
}
