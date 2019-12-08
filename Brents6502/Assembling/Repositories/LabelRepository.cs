using System.Collections.Generic;

namespace Brents6502.Assembling.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly Dictionary<string, int> _labels = new Dictionary<string, int>();

        public void CreateLabel(string labelName)
        {
            _labels.Add(labelName, -1);
        }

        public void SetAddress(string labelName, ushort address)
        {
            _labels[labelName] = address;
        }

        public bool TryGetValue(string labelName, out ushort value)
        {
            if (_labels.TryGetValue(labelName, out var address))
            {
                if (address < 0)
                    throw new LabelAddressNotAssignedException(labelName);
                value = (ushort)address;
                return true;
            }
            value = 0;
            return false;
        }

        public bool TryGetPossibleLabel(IArgumentSymbol symbol, out KeyValuePair<string, ushort> pair)
        {
            return TryGetPossibleLabel(symbol.Source, out pair);
        }

        private bool TryGetPossibleLabel(string src, out KeyValuePair<string, ushort> pair)
        {
            if (_labels.TryGetValue(src, out int val))
            {
                pair = new KeyValuePair<string, ushort>(src, (ushort)val);
                return true;
            }
            if (src.StartsWith("#<") || src.StartsWith("#>"))
                return TryGetPossibleLabel(src.Substring(2), out pair);
            else if (src.Contains(','))
                return TryGetPossibleLabel(src.Substring(0, src.Length - 2), out pair);
            pair = default;
            return false;
        }
    }
}
