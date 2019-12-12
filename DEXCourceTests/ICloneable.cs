using NUnit.Framework;

namespace DEXCource
{
    internal class ICloneable
    {
        [Test]
        public void ICloneableTest()
        {
            var solider = new GalacticRepublicSolider();
            solider.Name = "Solider";
            solider.Rang = 44;
            var SoliderClone = new GalacticRepublicSolider();
            SoliderClone = (GalacticRepublicSolider) solider.Clone();
            solider.Name = "MainSolider";
            solider.Rang = 88;
            Assert.AreNotEqual(solider.Name, SoliderClone.Name);
            Assert.AreNotEqual(solider.Rang, SoliderClone.Rang);
        }
    }

    internal class GalacticRepublicSolider : ICloneable
    {
        public string Name { get; set; }
        public int Rang { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}