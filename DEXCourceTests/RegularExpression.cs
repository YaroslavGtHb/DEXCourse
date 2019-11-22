using System.Text.RegularExpressions;
using NUnit.Framework;

namespace DEXCource
{
    internal class RegularExpression
    {
        [Test]
        public void RegularExpressionTest()
        {
            var RegExpString =
                "Это 1 совершенно 1 случайная 1000 фраза, 1000 в 1000 которой 1000 вставлены 1000000 и 1000000 и 1000000 и 1000000 числа 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 для проверки регексп выражений.";
            var one = new Regex(@"\s1\s");
            var oneThousand = new Regex(@"\s1000\s");
            var oneMillion = new Regex(@"\s1000000\s");
            var Float = new Regex(@"\s100.23\s");
            var oneMatches = one.Matches(RegExpString);
            var oneThousandMatches = oneThousand.Matches(RegExpString);
            var oneMillionMatches = oneMillion.Matches(RegExpString);
            var floatMatches = Float.Matches(RegExpString);
            Assert.IsTrue(oneMatches.Count == 2 && oneThousandMatches.Count == 4 && oneMillionMatches.Count == 4 &&
                          floatMatches.Count == 8);

            var spaceKeyString =
                "Это        совершенно    случайная  фраза  для  теста  обрезания  ненужных  пробелов.";
            var spaceTrimmer = new Regex(@"\s\s+");
            spaceKeyString = spaceTrimmer.Replace(spaceKeyString, " ");
            Assert.AreEqual(spaceKeyString, "Это совершенно случайная фраза для теста обрезания ненужных пробелов.");

            var internationalNumberString = "+373 77767852";
            var internalNumberString = "77767852";
            var internalCodeNumberString = " 0(777) 67852";
            var number = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){8,14}(\s*)?$");
            var internationalNumberMathes = number.Matches(internationalNumberString);
            var internalNumberMathes = number.Matches(internalNumberString);
            var internalCodeNumberMathes = number.Matches(internalCodeNumberString);
            Assert.IsTrue(internationalNumberMathes.Count == 1 && internalNumberMathes.Count == 1 &&
                          internalCodeNumberMathes.Count == 1);
        }
    }
}