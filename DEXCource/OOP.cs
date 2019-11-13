using System;
using System.Collections.Generic;
using System.Text;

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
}
