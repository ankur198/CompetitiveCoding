using System;
using System.Linq;

namespace SavingTheUniverse
{
    class CaseSenario
    {
        public int ShieldStrength { get; private set; }
        public char[] Program { get; set; }
        public int SwapCount { get; private set; }

        public int ProgramStrength { get { return _computeProgramStrength(); } }

        public CaseSenario(string inputString)
        {
            var x = inputString.Split(' ');
            ShieldStrength = int.Parse(x[0]);
            Program = x[1].ToCharArray();
        }

        public override string ToString()
        {
            Optimize();

            if (ProgramStrength > ShieldStrength)
            {
                return "IMPOSSIBLE";
            }
            else
            {
                return SwapCount.ToString();
            }
        }

        private int _computeProgramStrength()
        {
            int strength = 1;
            int damage = 0;

            foreach (var instruction in Program)
            {
                switch (instruction)
                {
                    case 'S':
                        damage += strength;
                        break;

                    case 'C':
                        strength *= 2;
                        break;

                    default:
                        break;
                }
            }

            return damage;
        }

        bool _swappable = true;
        internal void Optimize()
        {
            while (ProgramStrength > ShieldStrength && _swappable)
            {
                _swappable = Swap();
            }
        }

        private bool Swap()
        {
            var program = new string(Program);
            var index = program.LastIndexOf("CS");

            if (index >= 0)
            {
                SwapCount++;
                Program[index] = 'S';
                Program[index + 1] = 'C';
                return true;
            }
            return false;
        }
    }
}
