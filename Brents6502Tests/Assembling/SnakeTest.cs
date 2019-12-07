using Brents6502.Assembling;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Brents6502Tests.Assembling
{
    [TestFixture]
    public class SnakeTest
    {
        [Test]
        public void BytesShouldBeSame()
        {
            string sourceFile = "../../../../Brents6502/Resources/snake.asm";
            SourceCode code = new SourceCode();
            List<byte> byteCode = code.ProcessCode(sourceFile);

            string n = Path.GetFileName(sourceFile);
            string p = Path.GetFullPath(sourceFile);
            string cmp = File.ReadAllText(p.Remove(p.Length - n.Length) + "snake-hex.txt");
            string[] cmpHex = cmp.Split(' ');
            List<byte> cmpByteCode = new List<byte>();
            foreach (string h in cmpHex)
                cmpByteCode.Add(Convert.ToByte(h, 16));
            for (int i = 0; i < byteCode.Count; i++)
                Assert.AreEqual(cmpByteCode[i], byteCode[i]);
            Assert.AreEqual(cmpByteCode.Count, byteCode.Count);
        }
    }
}
