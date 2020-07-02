using System;
using System.Linq;

namespace Enigma
{
    public class Rotor
    {
        private readonly Random _rand = new Random(1);
        public static string Alphabets { get; set; } = new string(Enumerable.Range(32, 126 - 32).Select(i => (char)i).ToArray());
        public string RotorChars { get; set; }

        public Rotor()
        {
            RotorChars = new string(Alphabets.OrderBy(x => _rand.Next()).ToArray());
        }

        public void Shifting()
        {
            RotorChars = RotorChars.Substring(1, RotorChars.Length - 1) +
                         RotorChars.Substring(0, 1);
        }
    }
}