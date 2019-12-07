using System.Text.RegularExpressions;

namespace Brents6502.Assembling
{
    public class SymbolParser
    {
        private static readonly Regex _validComma = new Regex(@"^\(?\$?[a-zA-Z0-9]+\)?,[xXyY]\)?$");

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
            if (lineSrc.Contains(","))
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
