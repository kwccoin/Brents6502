using System.Collections.Generic;

namespace Brents6502.Assembling.Repositories
{
    public class DefineRepository : IDefineRepository
    {
        private readonly Dictionary<string, string> _defines = new Dictionary<string, string>();

        public void AddDefine(string define, string value)
        {
            _defines.Add(define, value);
        }

        public bool TryGetPossibleDefine(IArgumentSymbol symbol, out KeyValuePair<string, string> pair)
        {
            foreach (var kv in _defines)
            {
                // TODO:  Should do what the label repository does here
                if (symbol.Source.Contains(kv.Key))
                {
                    pair = kv;
                    return true;
                }
            }
            pair = default;
            return false;
        }

        public bool TryGetValue(string define, out string value)
        {
            return _defines.TryGetValue(define, out value);
        }
    }
}
