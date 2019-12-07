using System.Collections.Generic;

namespace Brents6502.Assembling.Repositories
{
    public interface IDefineRepository
    {
        void AddDefine(string define, string value);
        bool TryGetValue(string define, out string value);
        bool TryGetPossibleDefine(IArgumentSymbol symbol, out KeyValuePair<string, string> pair);
    }
}
