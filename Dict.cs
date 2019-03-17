using System;
using System.IO;
using System.Text;

namespace TypingStudy
{
    class Dict
    {
        public string[] Words { get; private set; }

        public Dict() { }

        public Dict(string path)
        {
            AddWords(path);
        }

        public void AddWords(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Пустой путь к файлу!");
            else
                Words = File.ReadAllText(path, Encoding.Default).Split();
        }

        public string GetRandomWord()
        {
            return Words[new Random().Next(0, Words.Length)];
        }
    }
}
