using System;
using System.Linq;

namespace Enigma
{
    public class Enigma
    {
        public Rotor[] Rotors { get; set; }

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


        public string Encrypt(string text, string password)
        {
            SetPassword(password);
            var result = "";
            var step = 1;
            foreach (var c in text)
            {
                result += Encrypt(c);
                WheelRotors(step++);
            }

            return result;
        }

        private char Encrypt(char ch)
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

        private void WheelRotors(int step)
        {
            for (var i = 0; i < Rotors.Length; i++)
            {
                if (step % (long)Math.Pow(Rotor.Alphabets.Length, i) == 0)
                    Rotors[i].Shifting();
            }
        }

        private void SetPassword(string pass)
        {
            // first state of rotors
            for (var p = 0; p < pass.Length; p++)
            {
                var passChar = pass[p];
                var shiftCount = Rotor.Alphabets.IndexOf(passChar) + 1;
                Rotors[p].Shifting(shiftCount);
            }
        }
    }
}