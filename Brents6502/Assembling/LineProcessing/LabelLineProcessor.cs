using Brents6502.Assembling.Repositories;
using Brents6502.Assembling.Tokens;
using System.Collections.Generic;

namespace Brents6502.Assembling.LineProcessing
{
    public class LabelLineProcessor : ILineProcessor
    {
        private readonly ILabelRepository _labelRepository;
        private readonly List<ITokenReplacement> _replacements = new List<ITokenReplacement>();

        public LabelLineProcessor(ILabelRepository defineRepository)
        {
            _labelRepository = defineRepository;
            _replacements.Add(new TokenMatchReplacement());
            _replacements.Add(new TokenLiteralReplacement());
            _replacements.Add(new TokenIndirectReplacement());
            _replacements.Add(new TokenIndirectParenthesisReplacement());
            _replacements.Add(new TokenAbsoluteReplacement());
            _replacements.Add(new TokenHighLowByteReplacement());
        }

        public void ProcessLine(Line line)
        {
            for (int i = 0; i < line.Arguments.Length; i++)
            {
                if (_labelRepository.TryGetPossibleLabel(line.Arguments[i], out var pair))
                {
                    foreach (var r in _replacements)
                    {
                        r.Token = pair.Key;
                        r.Replacement = $"${pair.Value.ToString("X4")}";
                        r.ReplaceToken(line.Arguments[i]);
                    }
                }
            }
        }
    }
}
