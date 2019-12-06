using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assemble6502._6502
{
    public class Define : IAssemblyLine
    {
        private static readonly Regex _defineName = new Regex(@"^[a-zA-Z_]([a-zA-Z0-9_]+)$");
        private static readonly Regex _literal = new Regex(@"^(\d{1,3}|\$[\da-fA-F]{1,2})$");

        public string Source { get; private set; }
        public ushort Address => 0;
        public byte Size => 0;
        public int LineNumber { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public ushort AddressFrom { get; set; }

        public Define(string line, int lineNumber)
        {
            Source = line;
            LineNumber = lineNumber;
            string[] parts = Source.Split(' ');
            if (parts.Length == 1)
                throw new Exception($"The define on line {LineNumber} does not have a name");

            if (!_defineName.IsMatch(parts[1]))
                throw new Exception($"The name {parts[1]} is an invalid name for a define, it must start with [a-zA-z_] on line {LineNumber}");

            if (parts.Length == 2)
                throw new Exception($"The define on line {LineNumber} does not have a value");

            if (!_literal.IsMatch(parts[2]))
                throw new Exception($"Definitions need literals (numbers) between 0 and 255 or between $00 and $FF but got '{parts[2]}' on line {LineNumber}");

            Name = parts[1];
            Value = parts[2];
        }

        public List<byte> GetLineBytes()
        {
            return new List<byte>();
        }

        public bool FindAndReplace(Arg arg)
        {
            string newSource = null;
            if (arg.Source[0] == '#')
            {
                if (Name == arg.Source.Remove(0, 1))
                    newSource = $"#{Value}";
            }
            else if (arg.Source.Contains(Name))
            {
                if (arg.Source.Length > Name.Length)
                {
                    if (arg.Source[Name.Length] == ',')
                    {
                        newSource = Value + arg.Source.Remove(0, Name.Length);
                    }
                    else if (arg.Source.StartsWith($"({Name})"))
                    {
                        newSource = $"({Value}){arg.Source.Remove(0, Name.Length + 2)}";
                    }
                    else if (arg.Source.StartsWith($"({Name},"))
                    {
                        newSource = $"({Value}{arg.Source.Remove(0, Name.Length + 1)}";
                    }
                }
                else if (arg.Source.Length == Name.Length)
                    newSource = Value;
            }

            if (!string.IsNullOrEmpty(newSource))
            {
                arg.ChangeSource(newSource);
                return true;
            }
            return false;
        }
    }
}
