using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DEXCource
{
    class RegularExpression
    {
        [Test]
        public void RegularExpressionTest()
        {
            string RegExpString =
                "Это 1 совершенно 1 случайная 1000 фраза, 1000 в 1000 которой 1000 вставлены 1000000 и 1000000 и 1000000 и 1000000 числа 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 и 100.23 для проверки регексп выражений.";
            Regex One = new Regex(@"\s1\s");
            Regex OneThousand = new Regex(@"\s1000\s");
            Regex OneMillion = new Regex(@"\s1000000\s");
            Regex Float = new Regex(@"\s100.23\s");
            MatchCollection OneMatches = One.Matches(RegExpString);
            MatchCollection OneThousandMatches = OneThousand.Matches(RegExpString);
            MatchCollection OneMillionMatches = OneMillion.Matches(RegExpString);
            MatchCollection FloatMatches = Float.Matches(RegExpString);
            Assert.IsTrue(OneMatches.Count == 2 && OneThousandMatches.Count == 4 && OneMillionMatches.Count == 4 && FloatMatches.Count == 8);

            string spaceKeyString = "Это        совершенно    случайная  фраза  для  теста  обрезания  ненужных  пробелов.";
            Regex spaceTrimmer = new Regex(@"\s\s+");
            spaceKeyString = spaceTrimmer.Replace(spaceKeyString, " ");
            Assert.AreEqual(spaceKeyString, "Это совершенно случайная фраза для теста обрезания ненужных пробелов.");

            string internationalNumberString = "+373 77767852";
            string internalNumberString = "77767852";
            string internalCodeNumberString = " 0(777) 67852";
            Regex Number = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){8,14}(\s*)?$");
            MatchCollection internationalNumberMathes = Number.Matches(internationalNumberString);
            MatchCollection internalNumberMathes = Number.Matches(internalNumberString);
            MatchCollection internalCodeNumberMathes = Number.Matches(internalCodeNumberString);
            Assert.IsTrue(internationalNumberMathes.Count == 1 && internationalNumberMathes.Count == 1 && internalCodeNumberMathes.Count == 1);
        }
    }
}
