using Brents6502.Assembling.Repositories;
using System.Text.RegularExpressions;

namespace Brents6502.Assembling.LineAnalysis
{
    public class LabelLineAnalyzer : ILineAnalyzer
    {
        private static readonly Regex _regex = new Regex(@"^[a-zA-Z0-9_]+:$");
        private readonly ILabelRepository _labelRepository;

        public LabelLineAnalyzer(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public void HandleLine(string line)
        {
            _labelRepository.CreateLabel(line.Substring(0, line.Length - 1));
        }

        public bool ShouldHandle(string line)
        {
            return _regex.IsMatch(line);
        }
    }
}
