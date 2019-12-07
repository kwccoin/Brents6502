using Brents6502.Assembling;
using System.Collections.Generic;
using System.IO;

namespace Brents6502
{
    class Program
    {
        private static void Main(string[] args)
        {
            string sourceFile = args[0];
            SourceCode code = new SourceCode();
            List<byte> byteCode = code.ProcessCode(sourceFile);

            string outFileName = Path.GetFileName(sourceFile);
            int extensionPos = outFileName.LastIndexOf('.');
            if (extensionPos >= 0)
                outFileName = outFileName.Substring(0, extensionPos);
            File.WriteAllBytes(outFileName + ".prg", byteCode.ToArray());
        }
    }
}
