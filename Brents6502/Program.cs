using Brents6502.Assembling;
using System;
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
            outFileName = outFileName + ".prg";
            File.WriteAllBytes(outFileName, byteCode.ToArray());
            Console.WriteLine($"Successfully created program file at {outFileName}. Program code is {byteCode.Count} bytes.");
        }
    }
}
