using Brents6502.Instructions;
using System.Text.RegularExpressions;

namespace Brents6502.Assembling
{
    public class ArgumentSymbol : IArgumentSymbol
    {
        public static Regex RegexLiteral = new Regex(@"^#\$?[a-fA-F0-9]{1,3}$");
        public static Regex RegexIndirectY = new Regex(@"^\(\$[a-fA-F0-9]{1,2}\),[yY]$");
        public static Regex RegexIndirectX = new Regex(@"^\(\$([a-fA-F0-9]{1,2}|[a-fA-F0-9]{4}),[xX]\)$");
        public static Regex RegexIndirect = new Regex(@"^\(\$[a-fA-F0-9]{4}\)$");
        public static Regex RegexAddressX = new Regex(@"^\$[a-fA-F0-9]{4},[xX]$");
        public static Regex RegexAddressY = new Regex(@"^\$[a-fA-F0-9]{4},[yY]$");
        public static Regex RegexAddress = new Regex(@"^\$[a-fA-F0-9]{4}$");
        public static Regex RegexZeroPage = new Regex(@"^\$[a-fA-F0-9]{1,2}$");
        public static Regex RegexZeroPageX = new Regex(@"^\$[a-fA-F0-9]{1,2},[xX]$");
        public static Regex RegexZeroPageY = new Regex(@"^\$[a-fA-F0-9]{1,2},[yY]$");

        public string Source { get; private set; }
        public int LineNumber { get; set; }
        public ushort Address { get; set; }

        public void SetSource(string source)
        {
            Source = source;
        }

        public InstructionType GetArgType()
        {
            string arg = Source.ToUpper();
            if (RegexLiteral.IsMatch(arg) || arg.StartsWith("#<") || arg.StartsWith("#>"))
                return InstructionType.Literal;
            else if (RegexIndirectY.IsMatch(arg))
                return InstructionType.IndirectY;
            else if (RegexIndirectX.IsMatch(arg))
                return InstructionType.IndirectX;
            else if (RegexIndirect.IsMatch(arg))
                return InstructionType.Indirect;
            else if (RegexAddressX.IsMatch(arg))
                return InstructionType.AddressX;
            else if (RegexAddressY.IsMatch(arg))
                return InstructionType.AddressY;
            else if (RegexAddress.IsMatch(arg))
                return InstructionType.Address;
            else if (RegexZeroPage.IsMatch(arg))
                return InstructionType.ZeroPage;
            else if (RegexZeroPageX.IsMatch(arg))
                return InstructionType.ZeroPageX;
            else if (RegexZeroPageY.IsMatch(arg))
                return InstructionType.ZeroPageX;
            else if (arg == "A")
                return InstructionType.Accumulator;
            return InstructionType.Address;
        }
    }
}
