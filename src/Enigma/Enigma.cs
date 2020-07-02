using System;
using System.Linq;

namespace Enigma
{
    public class Enigma
    {
        public Rotor[] Rotors { get; set; }
        private int Step { get; set; } = 1;

        public Enigma(int passwordLength, params Rotor[] rotors)
        {
            if (rotors.Length != passwordLength)
            {
                Rotors = new Rotor[passwordLength];
                for (var i = 0; i < passwordLength; i++)
                {
                    Rotors[i] = new Rotor();
                }
            }
            else
            {
                Rotors = rotors;
            }
        }


        public string Encrypt(string text)
        {
            var result = "";
            foreach (var c in text)
            {
                result += Encrypt(c);
                WheelRotors();
            }

            return result;
        }

        public char Encrypt(char ch)
        {
            var result = ch;

            // to rotors
            foreach (var rotor in Rotors)
            {
                result = rotor.RotorChars[Rotor.Alphabets.IndexOf(result)];
            }

            // to reflector (reverse alphabets: a-->z  , b-->y, c-->x)
            result = Rotor.Alphabets[Rotor.Alphabets.Length - Rotor.Alphabets.IndexOf(result) - 1];

            // back to rotors
            foreach (var rotor in Rotors.Reverse())
            {
                result = Rotor.Alphabets[rotor.RotorChars.IndexOf(result)];
            }

            return result;
        }

        private void WheelRotors()
        {
            for (var i = 0; i < Rotors.Length; i++)
            {
                if (Step % (long)Math.Pow(Rotor.Alphabets.Length, i) == 0)
                    Rotors[i].Shifting();
            }

            Step++;
        }
    }
}