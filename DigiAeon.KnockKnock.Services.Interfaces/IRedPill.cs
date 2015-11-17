namespace DigiAeon.KnockKnock.Services.Interfaces
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    /// <summary>
    /// The triangle type.
    /// </summary>
    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType
    {
        /// <summary>
        /// The error.
        /// </summary>
        [EnumMember]
        Error = 0,

        /// <summary>
        /// The equilateral.
        /// </summary>
        [EnumMember]
        Equilateral = 1,

        /// <summary>
        /// The isosceles.
        /// </summary>
        [EnumMember]
        Isosceles = 2,

        /// <summary>
        /// The scalene.
        /// </summary>
        [EnumMember]
        Scalene = 3,
    }

    /// <summary>
    /// The RedPill interface.
    /// </summary>
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        /// <summary>
        /// The what is your token.
        /// </summary>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        [OperationContract]
        Guid WhatIsYourToken();

        /// <summary>
        /// The fibonacci number.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

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
        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        /// <summary>
        /// The reverse words.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);
    }
}
