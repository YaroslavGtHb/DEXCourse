using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DEXCource
{
    class LINQ
    {
        
    }
    public class Cat
    {
        public Cat(int id, string name, int age, bool isMale, double weight)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.isMale = isMale;
            this.weight = weight;
        }
        int id { get; }
        string name { get; set; }
        int age { get; set; }
        bool isMale { get; }
        double weight { get; set; }
    }
}
