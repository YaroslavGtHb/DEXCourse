using System;

namespace DEXCource
{
    class OOP
    {
    }
    public abstract class Scientist
    {
        public Scientist(string Name, int IQ)
        {
            this.Name = Name;
            this.IQ = IQ;
        }
        private string Name { get; }
        private int IQ { get; }
        public virtual void Introduse()
        {
            Console.WriteLine("Привет, меня зовут {0} и мой IQ равен {1}", Name, IQ);
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
        public Mathematician(string Name, int IO) : base(Name, IO)
        {
            this.Name = Name;
            IQ = IQ;
        }
        public string Name { get; }
        public int IQ { get; }
        public override void SaySomething()
        {
            Console.WriteLine("Математика это царица всех наук, физика есть лишь ее приложение.");
        }
        public override void DoSomething()
        {
            
        }
        protected virtual int getStringAndParseToInt()
        {
            string stringForCheck = Console.ReadLine();
            int parsedInt;

            while (!Int32.TryParse(stringForCheck, out parsedInt))
            {
                Console.WriteLine("Подойдут только числа, попробуйте еще раз.");
                stringForCheck = Console.ReadLine();
            }
            return parsedInt;
        }
        protected virtual int intMultiplication(int FirstMultipler, int SecondMultipler)
        {
            return FirstMultipler * SecondMultipler;
        }
        protected virtual float intDivision (int Divident, int Devider)
        {
            return Divident / Devider;
        }

    }
    public class Physicist : Mathematician
    {
        public Physicist(string Name, int IO) : base(Name, IO)
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
            base.DoSomething();
        }
        private void showOhmEquation(int FirstNumber, int SecondNumber)
        {
            Console.WriteLine("Отлично, у нас есть два числа");
            Console.WriteLine("Если это напряжение и сопротивление, то сила тока будет равна: " + intDivision(FirstNumber, SecondNumber));
            Console.WriteLine("Если это напряжение и сила тока, сопротивление окажется: " + intDivision(FirstNumber, SecondNumber));
            Console.WriteLine("Ну а если эити два часла предстиавляют собьой силу тока и сопротивление, то напряжение получится:" + intMultiplication(FirstNumber, SecondNumber));
        }
    }
}
