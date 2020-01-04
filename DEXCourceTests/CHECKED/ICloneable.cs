using NUnit.Framework;

namespace DEXCource
{
    class ICloneable
    {
        [Test]
        public void ICloneableTest()
        {
            GalacticRepublicSolider solider = new GalacticRepublicSolider();
            solider.Name = "Solider";
            solider.Rang = 44;
            GalacticRepublicSolider SoliderClone = new GalacticRepublicSolider();
            SoliderClone = (GalacticRepublicSolider)solider.Clone();
            solider.Name = "MainSolider";
            solider.Rang = 88;
            Assert.AreNotEqual(solider.Name, SoliderClone.Name);
            Assert.AreNotEqual(solider.Rang, SoliderClone.Rang);
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
