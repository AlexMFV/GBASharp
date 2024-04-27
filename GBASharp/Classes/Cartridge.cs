using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Cartridge
    {
        static byte[] rom = new byte[0xFFFF];

        public static byte[] ROM { get { return rom; } set { rom = value; } }
    }
}
