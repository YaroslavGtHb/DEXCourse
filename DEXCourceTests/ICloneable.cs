using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEXCource
{
    class ICloneable
    {
        [Test]
        public void ICloneableTest()
        {
            GalacticRepublicSolider Solider = new GalacticRepublicSolider();
            Solider.Name = "Solider";
            Solider.Rang = 44;
            GalacticRepublicSolider SoliderClone = new GalacticRepublicSolider();
            SoliderClone = (GalacticRepublicSolider)Solider.Clone();
            Solider.Name = "MainSolider";
            Solider.Rang = 88;
            Assert.AreNotEqual(Solider.Name, SoliderClone.Name);
        }
    }
    class GalacticRepublicSolider : ICloneable
    {
        public string Name { get; set; }
        public int Rang { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
