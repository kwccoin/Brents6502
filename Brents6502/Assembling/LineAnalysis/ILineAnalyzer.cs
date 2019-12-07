namespace Brents6502.Assembling.LineAnalysis
{
    public interface ILineAnalyzer
    {
        bool ShouldHandle(string line);
        void HandleLine(string line);
    }
}
