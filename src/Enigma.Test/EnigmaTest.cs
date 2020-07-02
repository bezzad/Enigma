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
            var password = "test password";
            var cipher = new Enigma(password.Length).Encrypt(text, password);
            var plainText = new Enigma(password.Length).Encrypt(cipher, password);
            Assert.AreNotEqual(cipher, text);
            Assert.AreEqual(plainText, text);
        }
    }
}
