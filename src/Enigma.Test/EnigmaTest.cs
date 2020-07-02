using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.Test
{
    [TestClass]
    public class EnigmaTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            var text = "test text";
            var cipher = new Enigma(3).Encrypt(text);
            var plainText = new Enigma(3).Encrypt(cipher);
            Assert.AreNotEqual(cipher, text);
            Assert.AreEqual(plainText, text);
        }
    }
}
