using System.Collections.Generic;

namespace Brents6502.Assembling.Repositories
{
    public interface ILabelRepository
    {
        void CreateLabel(string labelName);
        void SetAddress(string labelName, ushort address);
        bool TryGetValue(string labelName, out ushort value);
        bool TryGetPossibleLabel(IArgumentSymbol symbol, out KeyValuePair<string, ushort> pair);
    }
}
