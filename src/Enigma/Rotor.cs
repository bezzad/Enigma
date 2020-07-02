using System;
using System.Linq;

namespace Enigma
{
    public class Rotor
    {
        private Random Rand { get; }
        public static string Alphabets { get; set; } = new string(Enumerable.Range(32, 126 - 32).Select(i => (char)i).ToArray()) + "";
        public string RotorChars { get; set; }

        public Rotor(int seed = 1)
        {
            Rand = new Random(seed);
            RotorChars = new string(Alphabets.OrderBy(x => Rand.Next()).ToArray());
        }

        public void Shifting(int count = 1)
        {
            count = count % RotorChars.Length;
            RotorChars = RotorChars.Substring(count, RotorChars.Length - count) +
                         RotorChars.Substring(0, count);
        }
    }
}