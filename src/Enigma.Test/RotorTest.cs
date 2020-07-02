using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Test
{
    [TestClass]
    public class RotorTest
    {
        [TestMethod]
        public void Shifting()
        {
            var rotor = new Rotor();
            var chars = (string)rotor.RotorChars.Clone();
            foreach (var c in chars)
            {
                rotor.Shifting();
                Assert.AreEqual(c, rotor.RotorChars.LastOrDefault());
            }
        }

        [TestMethod]
        public void RotorConstructor()
        {
            var rotor = new Rotor();
            Assert.IsTrue(rotor.RotorChars.IndexOf("A", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("1", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("/", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("a", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("ش", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("s", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("0", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf(".", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("\\", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf(",", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("#", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("@", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(rotor.RotorChars.IndexOf("ء", StringComparison.Ordinal) >= 0);

            for (var i = 0; i < 100; i++)
            {
                Assert.AreNotEqual(new Rotor().RotorChars, new Rotor().RotorChars);
            }
        }
    }
}
