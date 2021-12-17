using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VigenereCipher;

namespace TestVigenereCipher
{
    [TestClass]
    public class VigenereCipherTest
    {
        [TestMethod]
        public void Encrypt_CorrectKeyAndText_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "кларнет";
            string expected = "Хлрь б Пюкьы дшхтц цобнрюё";

            string actual = VigenereCipher.VigenereСipherRus.Encrypt(text, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decrypt_CorrectKeyAndText_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "кларнет";
            string expected = "Афры ё Ёщхеы гэлнб яоатжщр";

            string actual = VigenereCipher.VigenereСipherRus.Decrypt(text, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Decrypt_IncorrectKeyAndCorrectText_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "cat";

            string actual = VigenereCipher.VigenereСipherRus.Decrypt(text, key);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Encrypt_IncorrectKeyAndCorrectText_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "cat";

            string actual = VigenereCipher.VigenereСipherRus.Encrypt(text, key);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Decrypt_EmptyText_Test()
        {
            string text = "";
            string key = "кларнет";
            string actual = VigenereCipher.VigenereСipherRus.Decrypt(text, key);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Encrypt_EmptyText_Test()
        {
            string text = "";
            string key = "кларнет";
            string actual = VigenereCipher.VigenereСipherRus.Encrypt(text, key);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Encrypt_EmptyKey_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "";
            string actual = VigenereCipher.VigenereСipherRus.Encrypt(text, key);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Decrypt_EmptyKey_Test()
        {
            string text = "Карл у Клары украл кораллы";
            string key = "";
            string actual = VigenereCipher.VigenereСipherRus.Decrypt(text, key);
        }
    }

}

