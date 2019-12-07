namespace Brents6502.Assembling.ArgumentParsing
{
    public interface IArgumentParser
    {
        byte[] GetBytes(IArgumentSymbol symbol);
        bool ShouldHandle(IArgumentSymbol symbol);
    }
}
