using Assemble6502.Instructions;
using System;
using System.Text.RegularExpressions;

namespace Assemble6502
{
    public class Arg
    {
        private static readonly Regex _literal = new Regex(@"^#(\d{1,3}|\$[\dA-F]{1,2})$");
        private static readonly Regex _indirectY = new Regex(@"^\(\$[\dA-F]{1,2}\),Y$");
        private static readonly Regex _indirectX = new Regex(@"^\(\$([\dA-F]{1,2}|[\dA-F]{4}),X\)$");
        private static readonly Regex _indirect = new Regex(@"^\(\$[\dA-F]{4}\)$");
        private static readonly Regex _addressX = new Regex(@"^\$[\dA-F]{4},X$");
        private static readonly Regex _addressY = new Regex(@"^\$[\dA-F]{4},Y$");
        private static readonly Regex _address = new Regex(@"^\$[\dA-F]{4}$");
        private static readonly Regex _zeroPage = new Regex(@"^\$[\dA-F]{1,2}$");
        private static readonly Regex _zeroPageX = new Regex(@"^\$[\dA-F]{1,2},X$");
        private static readonly Regex _zeroPageY = new Regex(@"^\$[\dA-F]{1,2},Y$");

        public string Source { get; private set; }
        public InstructionType Type { get; private set; }

        public Arg(string source)
        {
            ChangeSource(source);
        }

        public void ChangeSource(string newSource)
        {
            if (newSource.StartsWith("#>") || newSource.StartsWith("#<"))
            {
                if (_literal.IsMatch(newSource.Remove(1, 1)))
                    newSource = $"#{newSource.Remove(0, 2)}";
                else if (_address.IsMatch(newSource.Remove(0, 2)))
                {
                    if (newSource.StartsWith("#>"))
                        newSource = $"#{newSource.Substring(2, 3)}";
                    else if (newSource.StartsWith("#<"))
                        newSource = $"#${newSource.Substring(5, 2)}";
                }
            }

            Source = newSource;
            Type = GetArgType(Source);
        }

        private InstructionType GetArgType(string arg)
        {
            arg = arg.ToUpper();
            if (_literal.IsMatch(arg) || arg.StartsWith("#<") || arg.StartsWith("#>"))
                return InstructionType.Literal;
            else if (_indirectY.IsMatch(arg))
                return InstructionType.IndirectY;
            else if (_indirectX.IsMatch(arg))
                return InstructionType.IndirectX;
            else if (_indirect.IsMatch(arg))
                return InstructionType.Indirect;
            else if (_addressX.IsMatch(arg))
                return InstructionType.AddressX;
            else if (_addressY.IsMatch(arg))
                return InstructionType.AddressY;
            else if (_address.IsMatch(arg))
                return InstructionType.Address;
            else if (_zeroPage.IsMatch(arg))
                return InstructionType.ZeroPage;
            else if (_zeroPageX.IsMatch(arg))
                return InstructionType.ZeroPageX;
            else if (_zeroPageY.IsMatch(arg))
                return InstructionType.ZeroPageX;
            else if (arg == "A")
                return InstructionType.Accumulator;
            return InstructionType.Address;
        }

        public byte[] GetBytes()
        {
            string upperArg = Source.ToUpper();

            if (Type == InstructionType.ZeroPage)
                return new byte[1] { Convert.ToByte(upperArg.Remove(0, 1), 16) };
            else if (Type == InstructionType.ZeroPageX)
                return new byte[1] { Convert.ToByte(upperArg.Remove(0, 1).Remove(2), 16) };
            else if (Type == InstructionType.Literal)
            {
                if (upperArg.Contains("$"))
                    return new byte[1] { Convert.ToByte(upperArg.Remove(0, 2), 16) };
                else
                {
                    int val = Convert.ToInt32(upperArg.Remove(0, 1));
                    if (val > byte.MaxValue)
                        throw new ArgumentException();
                    return new byte[1] { (byte)val };
                }
            }
            else if (Type == InstructionType.Address)
                return BitConverter.GetBytes(Convert.ToUInt16(upperArg.Remove(0, 1), 16));
            else if (Type == InstructionType.Address
                || Type == InstructionType.AddressX
                || Type == InstructionType.AddressY)
            {
                return BitConverter.GetBytes(Convert.ToUInt16(upperArg.Remove(0, 1).Remove(4), 16));
            }
            else if (Type == InstructionType.IndirectX || Type == InstructionType.IndirectY)
                return new byte[1] { Convert.ToByte(upperArg.Remove(0, 2).Remove(2), 16) };

            throw new ArgumentException();
        }
    }
}
