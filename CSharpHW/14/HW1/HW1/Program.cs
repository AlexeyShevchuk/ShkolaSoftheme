using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Lotoreya
    {
        private int[] _values;

        public int this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public int Length
        {
            get { return _values.Length; }
        }

        public Lotoreya()
        {
            _values = new int[0];
        }

        public Lotoreya(int length)
        {
            _values = new int[length];
            var rand = new Random();
            for (int i = 0; i < length; i++)
            {
                _values[i] = rand.Next(1, 9);
            }
        }

        public override string ToString()
        {
            var str = String.Empty;
            for (int i = 0; i < this.Length; i++)
            {
                str += " " + this[i];
            }
            return str;
        }

        public bool СompareValues(int[] values)
        {
            if (this.Length != values.Length)
            {
                return false;
            }

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != values[i])
                {
                    return false;
                }
            }
            return true;
        }
        public Lotoreya(int[] values)
        {
            _values = values;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lotoreya = new Lotoreya(6);
            var values = new int[6];
            var value = 0;
            var restart = false;
            do
            {
                Console.WriteLine("Input 6 values: ");
                Console.WriteLine("Lotoreya values for test: " + lotoreya.ToString());
                for (int i = 0; i < 6; i++)
                {
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Wrong input! Restart...");
                        restart = true;
                        break;
                    }
                    values[i] = value;
                }
                if (restart)
                {
                    continue;
                }
                if (lotoreya.СompareValues(values))
                {
                    Console.WriteLine("You win!");
                    restart = false;
                }
                else
                {
                    Console.WriteLine("You lose!");
                    restart = false;
                }
            }
            while (restart);
            Console.WriteLine(lotoreya.ToString());
            Console.ReadLine();
        }
     }
}
