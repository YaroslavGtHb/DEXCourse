using System;
using System.Runtime.Remoting;
using NUnit.Framework;

namespace DEXCource
{
    internal class OOP
    {
        private readonly Mathematician _alan = new Mathematician("AlanTuring", 288);
        private readonly Physicist _albert = new Physicist("AlbertEinste", 488);

        public static explicit operator OOP(ObjectHandle v)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void OOPTest()
        {
            _alan.Introduse();
            _alan.SaySomething();
            _albert.SaySomething();
            _albert.Introduse();
        }
    }

    public abstract class Scientist
    {
        protected Scientist(string Name, int Iq)
        {
            this.Name = Name;
            this.Iq = Iq;
        }

        private string Name { get; }
        private int Iq { get; }

        public virtual void Introduse()
        {
            Console.WriteLine("Привет, меня зовут {0} и мой IQ равен {1}", Name, Iq);
        }

        public virtual void SaySomething()
        {
            Console.WriteLine("Если оно зеленое или дергается – это биология." +
                              "Если воняет – это химия." +
                              "Если не работает – это физика." +
                              "Если непонятно – это математика." +
                              "Если это бессмысленно – это либо экономика, либо психология.");
        }

        public abstract void DoSomething();
    }

    public class Mathematician : Scientist
    {
        public Mathematician(string Name, int Io) : base(Name, Io)
        {
            this.Name = Name;
            Iq = Iq;
        }

        public string Name { get; }
        public int Iq { get; }

        public override void SaySomething()
        {
            Console.WriteLine("Математика это царица всех наук, физика есть лишь ее приложение.");
        }

        public override void DoSomething()
        {
            Console.WriteLine("Смотри, я знаю, что такое целые числа, проверь меня, введи что нибудь:");
            var number = GetStringAndParseToInt();
            Console.WriteLine("О, ты ввел число, давай теперь я возведу его в десятую степень: ");
            for (var i = 0; i <= 10; i++) number = IntMultiplication(number, number);
            Console.WriteLine(number);
            Console.WriteLine("А теперь, давай найдем середину: ");
            Console.WriteLine(IntDivision(number, 2));
        }

        protected virtual int GetStringAndParseToInt()
        {
            var stringForCheck = Console.ReadLine();
            int parsedInt;

            while (!int.TryParse(stringForCheck, out parsedInt))
            {
                Console.WriteLine("Это не целое число, попробуй еще раз.");
                stringForCheck = Console.ReadLine();
            }

            return parsedInt;
        }

        protected virtual int IntMultiplication(int FirstMultipler, int SecondMultipler)
        {
            return FirstMultipler * SecondMultipler;
        }

        protected virtual float IntDivision(int Divident, int Devider)
        {
            return Divident / Devider;
        }
    }

    public class Physicist : Mathematician
    {
        public Physicist(string Name, int Io) : base(Name, Io)
        {
            this.Name = Name;
            IQ = IQ;
        }

        public string Name { get; }
        public int IQ { get; }

        public override void SaySomething()
        {
            Console.WriteLine("Я физик и имею право на сохранение энергии.");
        }

        public override void DoSomething()
        {
            Console.WriteLine("Благодаря математике, физики могут вычислять нечто интересное.");
            Console.WriteLine("К примеру, скажи какое нибудь целое число:");
            var firstNumber = GetStringAndParseToInt();
            Console.WriteLine("А теперь еще одно:");
            var secondNumber = GetStringAndParseToInt();
            ShowOhmEquation(firstNumber, secondNumber);
        }

        private void ShowOhmEquation(int FirstNumber, int SecondNumber)
        {
            Console.WriteLine("Отлично, у нас есть два числа");
            Console.WriteLine("Если это напряжение и сопротивление, то сила тока будет равна: " +
                              IntDivision(FirstNumber, SecondNumber));
            Console.WriteLine("Если это напряжение и сила тока, сопротивление окажется: " +
                              IntDivision(FirstNumber, SecondNumber));
            Console.WriteLine(
                "Ну а если эити два часла предстиавляют собьой силу тока и сопротивление, то напряжение получится:" +
                IntMultiplication(FirstNumber, SecondNumber));
        }
    }
}