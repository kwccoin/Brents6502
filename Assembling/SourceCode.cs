using Assemble6502;
using Assemble6502._6502;
using System.Collections.Generic;
using System.IO;

namespace Brents6502.Assembling
{
    public class SourceCode
    {
        public List<string> Lines { get; private set; } = new List<string>();
        private InstructionLocater _locater = new InstructionLocater();
        private List<Instruction> _assemblyLines = new List<Instruction>();
        private List<Label> _labels = new List<Label>();
        private List<Define> _definitions = new List<Define>();

        public SourceCode(string filePath)
        {
            ReadFileLines(filePath);
            CleanUpSourceCode();
        }

        private void CleanUpSourceCode()
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                Lines[i] = Lines[i].Trim();
                Lines[i] = RemoveComment(Lines[i]);
                Lines[i] = ReplaceInLine(Lines[i], "  ", " ");
                Lines[i] = ReplaceInLine(Lines[i], ", ", ",");
                Lines[i] = ReplaceInLine(Lines[i], "( ", "(");
                Lines[i] = ReplaceInLine(Lines[i], " )", ")");
            }
        }

        private void ReadFileLines(string filePath)
        {
            string contents = File.ReadAllText(filePath);
            contents = contents.Replace("\r", "").Replace("\t", " ");
            Lines = new List<string>(contents.Split('\n'));
        }

        private string RemoveComment(string line)
        {
            int comment = line.IndexOf(';');
            if (comment >= 0)
                line = line.Remove(comment).Trim();
            return line;
        }

        private string ReplaceInLine(string line, string from, string to)
        {
            while (line.Contains(from))
            {
                line = line.Replace(from, to);
            }
            return line;
        }
    }
}
