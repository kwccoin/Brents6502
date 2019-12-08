using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Brents6502.Assembling
{
    public class SymbolParser
    {
        private static readonly Regex _validComma = new Regex(@"^\(?\$?[a-zA-Z0-9]+\)?,[xXyY]\)?$");

        // TODO:  This mapping could be done by a configuration file or something
        private static readonly Dictionary<char, byte> _characterCoding = new Dictionary<char, byte>()
        {
            ['A'] = 1,
            ['a'] = 1,
            ['B'] = 2,
            ['b'] = 2,
            ['C'] = 3,
            ['c'] = 3,
            ['D'] = 4,
            ['d'] = 4,
            ['E'] = 5,
            ['e'] = 5,
            ['F'] = 6,
            ['f'] = 6,
            ['G'] = 7,
            ['g'] = 7,
            ['H'] = 8,
            ['h'] = 8,
            ['I'] = 9,
            ['i'] = 9,
            ['J'] = 10,
            ['j'] = 10,
            ['K'] = 11,
            ['k'] = 11,
            ['L'] = 12,
            ['l'] = 12,
            ['M'] = 13,
            ['m'] = 13,
            ['N'] = 14,
            ['n'] = 14,
            ['O'] = 15,
            ['o'] = 15,
            ['P'] = 16,
            ['p'] = 16,
            ['Q'] = 17,
            ['q'] = 17,
            ['R'] = 18,
            ['r'] = 18,
            ['S'] = 19,
            ['s'] = 19,
            ['T'] = 20,
            ['t'] = 20,
            ['U'] = 21,
            ['u'] = 21,
            ['V'] = 22,
            ['v'] = 22,
            ['W'] = 23,
            ['w'] = 23,
            ['X'] = 24,
            ['x'] = 24,
            ['Y'] = 25,
            ['y'] = 25,
            ['Z'] = 26,
            ['z'] = 26,
            [' '] = 32,
            ['!'] = 33,
            ['"'] = 34,
            ['#'] = 35,
            ['$'] = 36,
            ['%'] = 37,
            ['&'] = 38,
            ['\''] = 39,
            ['('] = 40,
            [')'] = 41,
            ['*'] = 42,
            ['+'] = 43,
            [','] = 44,
            ['-'] = 45,
            ['.'] = 46,
            ['/'] = 47,
            ['0'] = 48,
            ['1'] = 49,
            ['2'] = 50,
            ['3'] = 51,
            ['4'] = 52,
            ['5'] = 53,
            ['6'] = 54,
            ['7'] = 55,
            ['8'] = 56,
            ['9'] = 57,
            [':'] = 58,
            [';'] = 59,
            ['<'] = 60,
            ['='] = 61,
            ['>'] = 62,
            ['?'] = 63,
            ['@'] = 64
        };

        public Line ParseAssemblyLine(string lineSrc, int lineNumber)
        {
            return new Line
            {
                LineNumber = lineNumber,
                Instruction = CreateInstructionSymbol(lineSrc, lineNumber),
                Arguments = CreateArgumentSymbols(lineSrc, lineNumber),
                Source = lineSrc
            };
        }

        private static IInstructionSymbol CreateInstructionSymbol(string lineSrc, int lineNumber)
        {
            string src;
            int idx = lineSrc.IndexOf(' ');
            if (idx < 0)
                src = lineSrc;
            else
                src = lineSrc.Substring(0, idx);
            IInstructionSymbol instruction = new InstructionSymbol();
            instruction.SetSource(src);
            instruction.LineNumber = lineNumber;
            return instruction;
        }

        private static IArgumentSymbol[] CreateArgumentSymbols(string lineSrc, int lineNumber)
        {
            // TODO:  Possibly should abstract this out so that there
            // can be other types of argument construction techniques
            if (lineSrc.ToUpper().StartsWith("DCB `"))
            {
                string text = lineSrc.Substring(5, lineSrc.LastIndexOf('`') - 5);
                List<string> nums = new List<string>(text.Length);
                foreach (char t in text)
                {
                    if (!_characterCoding.TryGetValue(t, out byte v))
                        throw new Exception($"The character {t} is not supported in a string");
                    nums.Add($"${v.ToString("X2")}");
                }
                lineSrc = "DCB " + string.Join(' ', nums.ToArray());
            }
            else if (lineSrc.Contains(","))
            {
                int firstSpace = lineSrc.IndexOf(' ');
                if (!_validComma.IsMatch(lineSrc.Substring(firstSpace + 1)))
                    lineSrc = lineSrc.Replace(',', ' ');
            }
            string[] parts = lineSrc.Split(' ');
            if (parts.Length == 1)
                return new ArgumentSymbol[0];
            IArgumentSymbol[] symbols = new ArgumentSymbol[parts.Length - 1];
            for (int i = 1; i < parts.Length; i++)
            {
                IArgumentSymbol arg = new ArgumentSymbol();
                arg.SetSource(parts[i]);
                arg.LineNumber = lineNumber;
                symbols[i - 1] = arg;
            }
            return symbols;
        }
    }
}
