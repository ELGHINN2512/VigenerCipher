using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    public static class VigenereСipherRus
    {
        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        static private string Vigenere(string text, string key, bool encrypting = true)
        {

            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                throw new Exception("Ошибка! Исходный текст не может быть пустым");

            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new Exception("Ошибка! Ключ не может быть пустым");

            if (!VigenereСipherRus.IsValidKey(key))
                throw new Exception("Ошибка! Невалидное значение ключа.\nКлюч должен содержать только буквы русского языка");

            string result = "";
            int keyIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                int letterIndex = alphabet.IndexOf(Char.ToLower(text[i]));
                int codeIndex = alphabet.IndexOf(Char.ToLower(key[keyIndex%key.Length]));

                if (letterIndex < 0)
                    result += text[i].ToString();
                else
                {
                    if (Char.IsUpper(text[i]))
                        result += Char.ToUpper(alphabet[(alphabet.Length + letterIndex +
                            ((encrypting ? 1 : -1) * codeIndex)) % alphabet.Length]).ToString();
                    else
                        result += Char.ToLower(alphabet[(alphabet.Length + letterIndex +
                            ((encrypting ? 1 : -1) * codeIndex)) % alphabet.Length]).ToString();
                    keyIndex++;
                }

            }
            return result;
        }

        //шифрование текста
        static public string Encrypt(string plainMessage, string password)
            => Vigenere(plainMessage, password);

        //дешифрование текста
        static public string Decrypt(string encryptedMessage, string password)
            => Vigenere(encryptedMessage, password, false);
        
        static bool IsValidKey(string key)
        {
            foreach (var item in key)
            {
                if (!alphabet.Contains(item))
                    return false;
            }
            return true;
        }
    }
}
