using Brents6502.Assembling.Repositories;
using System.Text.RegularExpressions;

namespace Brents6502.Assembling.LineAnalysis
{
    public class DefineLineAnalyzer : ILineAnalyzer
    {
        private static readonly Regex _regex = new Regex(@"^define\s[a-zA-Z0-9_]+\s\$?[a-fA-F0-9]{1,4}$");
        private IDefineRepository _definesRepo;

        public DefineLineAnalyzer(IDefineRepository defineRepository)
        {
            _definesRepo = defineRepository;
        }

        public void HandleLine(string line)
        {
            string[] parts = line.Split(' ');
            _definesRepo.AddDefine(parts[1], parts[2]);
        }

        public bool ShouldHandle(string line)
        {
            return _regex.IsMatch(line);
        }
    }
}
