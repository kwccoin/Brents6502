using Brents6502.Instructions;

namespace Brents6502.Assembling
{
    public interface IArgumentSymbol : ISymbol
    {
        InstructionType GetArgType();
    }
}
