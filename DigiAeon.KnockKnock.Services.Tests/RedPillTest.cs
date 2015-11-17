namespace DigiAeon.KnockKnock.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;

    using DigiAeon.Core.Test;

    using NUnit.Framework;

    using Assert = NUnit.Framework.Assert;

    /// <summary>
    /// The my pill test.
    /// </summary>
    [TestFixture]
    public class RedPillTest
    {
        #region -- Variables --

        /// <summary>
        /// The expected result check.
        /// </summary>
        private const string ExpectedResultCheck = "Expected result check";

        /// <summary>
        /// The red pill result check.
        /// </summary>
        private const string RedPillResultCheck = "Readify result check";

        /// <summary>
        /// The my token.
        /// </summary>
        private readonly Guid _myToken = new Guid("4ddac338-4cde-4b05-b893-5bbaaff1ee54");
        
        /// <summary>
        /// The red pill client.
        /// </summary>
        private ReadifyRedPill.RedPillClient _redPillClient;

        /// <summary>
        /// The _my pill client.
        /// </summary>
        private DigiAeonRedPill.RedPillClient _myPillClient;
        
        #endregion

        #region -- Properties --

        /// <summary>
        /// Gets or sets the red pill.
        /// </summary>
        private ReadifyRedPill.IRedPill RedPill { get; set; }
        
        /// <summary>
        /// Gets or sets the my red pill.
        /// </summary>
        private DigiAeonRedPill.IRedPill MyRedPill { get; set; }

        #endregion

        #region -- Init & Dispose --

        /// <summary>
        /// The initialization.
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            // Also checked with BasicHttpsBinding_IRedPill binding, just to make sure Readify hasn't added bug in code based on binding!
            this._redPillClient = new ReadifyRedPill.RedPillClient("BasicHttpBinding_IRedPill");
            this.RedPill = this._redPillClient;

            this._myPillClient = new DigiAeonRedPill.RedPillClient("BasicHttpBinding_IRedPill1");
            this.MyRedPill = this._myPillClient;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        [TestFixtureTearDown]
        public void Dispose()
        {
            if (this._redPillClient != null)
            {
                this._redPillClient.Close();
            }

            if (this._myPillClient != null)
            {
                this._myPillClient.Close();
            }
        }

        #endregion

        #region -- Knock Knock Token Use Case --

        /// <summary>
        /// The test what is your token.
        /// </summary>
        [Test]
        public void TestWhatIsYourToken()
        {
            Assert.AreEqual(this._myToken, this.MyRedPill.WhatIsYourToken());
        }

        #endregion

        #region -- Triangle Use Case --

        /// <summary>
        /// The triangle use case.
        /// </summary>
        public class TriangleUseCase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TriangleUseCase"/> class.
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
            /// <param name="expectedTriangleType">
            /// The expected triangle type.
            /// </param>
            public TriangleUseCase(int a, int b, int c, ReadifyRedPill.TriangleType expectedTriangleType)
            {
                this.A = a;
                this.B = b;
                this.C = c;
                this.ExpectedTriangleType = expectedTriangleType;
            }

            /// <summary>
            /// Gets the a.
            /// </summary>
            public int A { get; private set; }

            /// <summary>
            /// Gets the b.
            /// </summary>
            public int B { get; private set; }

            /// <summary>
            /// Gets the c.
            /// </summary>
            public int C { get; private set; }

            /// <summary>
            /// Gets the expected triangle type.
            /// </summary>
            public ReadifyRedPill.TriangleType ExpectedTriangleType { get; private set; }
        }
        
        /// <summary>
        /// Gets the triangle use cases.
        /// </summary>
        private IEnumerable<TestCaseData> TriangleUseCases
        {
            get
            {
                // GIVEN any side is zero or negative WHEN I get triangle type THEN it will return error
                foreach (var scenario in this.GetCartesianProduct(-1).Where(scenario => !(scenario.Item1 == 1 && scenario.Item2 == 1 && scenario.Item3 == 1)))
                {
                    yield return new TriangleUseCase(
                            scenario.Item1,
                            scenario.Item2,
                            scenario.Item3,
                            ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                }

                yield return new TriangleUseCase(int.MinValue, int.MinValue, int.MinValue, ReadifyRedPill.TriangleType.Error).ToTestCaseData();

                // GIVEN sum of two sides is equal to third one WHEN I get triangle type THEN it will return error
                yield return new TriangleUseCase(1, 2, 3, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(1, 3, 2, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(2, 1, 3, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(2, 3, 1, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(3, 1, 2, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(3, 2, 1, ReadifyRedPill.TriangleType.Error).ToTestCaseData();

                // GIVEN sum of two sides is greater than third one WHEN I get triangle type THEN it will return error
                yield return new TriangleUseCase(1, 2, 4, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(1, 4, 2, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(2, 1, 4, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(2, 4, 1, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(4, 1, 2, ReadifyRedPill.TriangleType.Error).ToTestCaseData();
                yield return new TriangleUseCase(4, 2, 1, ReadifyRedPill.TriangleType.Error).ToTestCaseData();

                // GIVEN all sides are equals and greater than zero WHEN I get triangle type THEN it will return equilateral
                yield return new TriangleUseCase(int.MaxValue, int.MaxValue, int.MaxValue, ReadifyRedPill.TriangleType.Equilateral).ToTestCaseData();

                // GIVEN only two sides are same and greater than zero WHEN I get triangle type THEN it will return isosceles
                yield return new TriangleUseCase(45, 25, 25, ReadifyRedPill.TriangleType.Isosceles).ToTestCaseData();
                yield return new TriangleUseCase(23, 5, 23, ReadifyRedPill.TriangleType.Isosceles).ToTestCaseData();
                yield return new TriangleUseCase(44, 87, 44, ReadifyRedPill.TriangleType.Isosceles).ToTestCaseData();

                // GIVEN all sides are different and greater than zero WHEN I get triangle type THEN it will return scalenes
                yield return new TriangleUseCase(200, 300, 400, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
                yield return new TriangleUseCase(300, 200, 400, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
                yield return new TriangleUseCase(300, 400, 200, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
                yield return new TriangleUseCase(300, 400, 200, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
                yield return new TriangleUseCase(400, 300, 200, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
                yield return new TriangleUseCase(400, 200, 300, ReadifyRedPill.TriangleType.Scalene).ToTestCaseData();
            }
        }
        
        /// <summary>
        /// The test triangle scenarios.
        /// </summary>
        /// <param name="scenario">
        /// The scenario.
        /// </param>
        [Test]
        [TestCaseSource("TriangleUseCases")]
        public void TestTriangleUseCases(TriangleUseCase scenario)
        {
            var myRedPill = (ReadifyRedPill.TriangleType)this.MyRedPill.WhatShapeIsThis(scenario.A, scenario.B, scenario.C);
            var redPill = this.RedPill.WhatShapeIsThis(scenario.A, scenario.B, scenario.C);

            Assert.AreEqual(scenario.ExpectedTriangleType, myRedPill, ExpectedResultCheck);
            Assert.AreEqual(scenario.ExpectedTriangleType, redPill, RedPillResultCheck);
        }

        /// <summary>
        /// The get cartesian product.
        /// </summary>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <returns>
        /// The <see cref="T:IEnumerable"/>.
        /// </returns>
        private IEnumerable<Tuple<int, int, int>> GetCartesianProduct(int start)
        {
            for (var a = start; a <= start + 2; a++)
            {
                for (var b = start; b <= start + 2; b++)
                {
                    for (var c = start; c <= start + 2; c++)
                    {
                        yield return new Tuple<int, int, int>(a, b, c);
                    }
                }
            }
        }

        #endregion

        #region -- Reverse Words Use Case --

        /// <summary>
        /// The reverse words use case.
        /// </summary>
        public class ReverseWordsUseCase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReverseWordsUseCase"/> class.
            /// </summary>
            /// <param name="input">
            /// The input.
            /// </param>
            /// <param name="expectedResult">
            /// The expected result.
            /// </param>
            public ReverseWordsUseCase(string input, string expectedResult)
            {
                this.Input = input;
                this.ExpectedOutput = expectedResult;
            }

            /// <summary>
            /// Gets the input.
            /// </summary>
            public string Input { get; private set; }

            /// <summary>
            /// Gets the expected output.
            /// </summary>
            public string ExpectedOutput { get; private set; }
        }

        /// <summary>
        /// Gets the reverse words use cases.
        /// </summary>
        private IEnumerable<TestCaseData> ReverseWordsUseCases
        {
            get
            {
                // GIVEN any separator or white space WHEN I perform reverse words operation THEN it will reverse words and concatenate with the separator or white space
                // Reference: https://msdn.microsoft.com/en-us/library/cta536cf(v=vs.110).aspx
                for (var c = Convert.ToInt32(char.MinValue); c <= Convert.ToInt32(char.MaxValue); c++)
                {
                    var chr = (char)c;

                    if (char.IsSeparator(chr) || char.IsWhiteSpace(chr))
                    {
                        yield return new ReverseWordsUseCase("Ab" + Convert.ToString(chr) + Convert.ToString(chr) + "cD", "bA" + Convert.ToString(chr) + Convert.ToString(chr) + "Dc")
                            .ToTestCaseData(string.Format(@"\u{0:X4} ({1})", (int)chr, char.GetUnicodeCategory(chr)));
                    }
                }

                // GIVEN the following character WHEN I perform reverse words operation THEN it will reverse words and concatenate with the character
                yield return new ReverseWordsUseCase("Ab\rcD", "bA\rDc").ToTestCaseData(@"\r");
                yield return new ReverseWordsUseCase("Ab\tcD", "bA\tDc").ToTestCaseData(@"\t");
                yield return new ReverseWordsUseCase("Ab\ncD", "bA\nDc").ToTestCaseData(@"\n");

                // GIVEN word followed by dash, newline and then by word WHEN I perform reverse words operation THEN it will not consider it as an continuation of word
                yield return new ReverseWordsUseCase("Ab-\ncD", "-bA\nDc").ToTestCaseData(@"Dash_Before_Newline_Doesnt_Mean_Continuation");
                
                // GIVEN string without any separator or white space WHEN I perform reverse words operation THEN it will reverse the string
                yield return new ReverseWordsUseCase(string.Empty, string.Empty).ToTestCaseData("Empty");

                yield return
                    new ReverseWordsUseCase(
                        @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@#$%^&*()_+-={}|[]\:"";'<>?,./",
                        @"/.,?><';"":\][|}{=-+_)(*&^%$#@!~9876543210ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfedcba").ToTestCaseData("Common_Keyboard_Characters");

                // GIVEN null string is passed WHEN I perform reverse words operation THEN it should throw fault exception
                yield return new ReverseWordsUseCase(null, null).ToTestCaseData("NULL");
            }
        }
        
        /// <summary>
        /// The test reverse words use cases.
        /// </summary>
        /// <param name="scenario">
        /// The scenario.
        /// </param>
        [Test]
        [TestCaseSource("ReverseWordsUseCases")]
        public void TestReverseWordsUseCases(ReverseWordsUseCase scenario)
        {
            if (scenario.Input == null)
            {
                FaultException<ArgumentNullException> redPill = null;
                FaultException<ArgumentNullException> myRedPill = null;

                try
                {
                    this.RedPill.ReverseWords(null);
                }
                catch (FaultException<ArgumentNullException> ex)
                {
                    redPill = ex;
                }

                try
                {
                    this.MyRedPill.ReverseWords(null);
                }
                catch (FaultException<ArgumentNullException> ex)
                {
                    myRedPill = ex;
                }

                if (redPill != null && myRedPill != null)
                {
                    Assert.AreEqual(redPill.Detail.ParamName, myRedPill.Detail.ParamName, RedPillResultCheck);
                    Assert.AreEqual(redPill.Detail.Message, myRedPill.Detail.Message, RedPillResultCheck);
                }
            }
            else
            {
                var redPill = this.RedPill.ReverseWords(scenario.Input);
                var myRedPill = this.MyRedPill.ReverseWords(scenario.Input);

                Assert.AreEqual(scenario.ExpectedOutput, myRedPill, ExpectedResultCheck);
                Assert.AreEqual(scenario.ExpectedOutput, redPill, RedPillResultCheck);
            }
        }

        /// <summary>
        /// The test reverse words use cases unhandled exception.
        /// </summary>
        [Test]
        public void TestReverseWordsUseCasesUnhandledException()
        {
            var input = new StringBuilder();
            for (var c = Convert.ToInt32(char.MinValue); c <= Convert.ToInt32(char.MaxValue); c++)
            {
                input.Append((char)c);
            }

            Assert.Throws(typeof(EncoderFallbackException), () => this.RedPill.ReverseWords(input.ToString()));
        }

        #endregion

        #region -- Fibonacci Number Use Case --

        /// <summary>
        /// Gets the fibonacci number use cases.
        /// </summary>
        private IEnumerable<int> FibonacciNumberUseCases
        {
            get
            {
                return Enumerable.Range(-93, 187);
            }
        }
        
        /// <summary>
        /// The test fibonacci number use cases.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        [Test]
        [TestCaseSource("FibonacciNumberUseCases")]
        public void TestFibonacciNumberUseCases(int n)
        {
            if (n == -93 || n == 93)
            {
                FaultException<ArgumentOutOfRangeException> redPill = null;
                FaultException<ArgumentOutOfRangeException> myRedPill = null;

                try
                {
                    this.RedPill.FibonacciNumber(n);
                }
                catch (FaultException<ArgumentOutOfRangeException> ex)
                {
                    redPill = ex;
                }

                try
                {
                    this.MyRedPill.FibonacciNumber(n);
                }
                catch (FaultException<ArgumentOutOfRangeException> ex)
                {
                    myRedPill = ex;
                }

                if (redPill != null && myRedPill != null)
                {
                    Assert.AreEqual(redPill.Detail.ParamName, myRedPill.Detail.ParamName, RedPillResultCheck);
                    Assert.AreEqual(redPill.Detail.Message, myRedPill.Detail.Message, RedPillResultCheck);
                }
            }
            else
            {
                Assert.AreEqual(this.RedPill.FibonacciNumber(n), this.MyRedPill.FibonacciNumber(n), RedPillResultCheck);
            }
        }

        #endregion
    }
}
