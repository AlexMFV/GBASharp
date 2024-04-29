using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Opcodes
    {
        #region 0x

        public static void Code0x00() { }
        public static void Code0x01() { }
        public static void Code0x02() { }
        public static void Code0x03() { }
        public static void Code0x04() { }
        public static void Code0x05() { }
        public static void Code0x06() { }
        public static void Code0x07() { }
        public static void Code0x08() { }
        public static void Code0x09() { }
        public static void Code0x0A() { }
        public static void Code0x0B() { }
        public static void Code0x0C() { }
        public static void Code0x0D() { }
        public static void Code0x0E() { }
        public static void Code0x0F() { }

        #endregion

        #region 1x

        public static void Code0x10() { }
        public static void Code0x11() { }
        public static void Code0x12() { }
        public static void Code0x13() { }
        public static void Code0x14() { }
        public static void Code0x15() { }
        public static void Code0x16() { }
        public static void Code0x17() { }
        public static void Code0x18() { }
        public static void Code0x19() { }
        public static void Code0x1A() { }
        public static void Code0x1B() { }
        public static void Code0x1C() { }
        public static void Code0x1D() { }
        public static void Code0x1E() { }
        public static void Code0x1F() { }

        #endregion

        #region 2x

        public static void Code0x20() { }
        public static void Code0x21() { }
        public static void Code0x22() { }
        public static void Code0x23() { }
        public static void Code0x24() { }
        public static void Code0x25() { }
        public static void Code0x26() { }
        public static void Code0x27() { }
        public static void Code0x28() { }
        public static void Code0x29() { }
        public static void Code0x2A() { }
        public static void Code0x2B() { }
        public static void Code0x2C() { }
        public static void Code0x2D() { }
        public static void Code0x2E() { }
        public static void Code0x2F() { }

        #endregion

        #region 3x

        public static void Code0x30() { }
        public static void Code0x31() { }
        public static void Code0x32() { }
        public static void Code0x33() { }
        public static void Code0x34() { }
        public static void Code0x35() { }
        public static void Code0x36() { }
        public static void Code0x37() { }
        public static void Code0x38() { }
        public static void Code0x39() { }
        public static void Code0x3A() { }
        public static void Code0x3B() { }
        public static void Code0x3C() { }
        public static void Code0x3D() { }
        public static void Code0x3E() { }
        public static void Code0x3F() { }

        #endregion

        #region 4x

        public static void Code0x40() { }
        public static void Code0x41() { }
        public static void Code0x42() { }
        public static void Code0x43() { }
        public static void Code0x44() { }
        public static void Code0x45() { }
        public static void Code0x46() { }
        public static void Code0x47() { }
        public static void Code0x48() { }
        public static void Code0x49() { }
        public static void Code0x4A() { }
        public static void Code0x4B() { }
        public static void Code0x4C() { }
        public static void Code0x4D() { }
        public static void Code0x4E() { }
        public static void Code0x4F() { }

        #endregion

        #region 5x

        public static void Code0x50() { }
        public static void Code0x51() { }
        public static void Code0x52() { }
        public static void Code0x53() { }
        public static void Code0x54() { }
        public static void Code0x55() { }
        public static void Code0x56() { }
        public static void Code0x57() { }
        public static void Code0x58() { }
        public static void Code0x59() { }
        public static void Code0x5A() { }
        public static void Code0x5B() { }
        public static void Code0x5C() { }
        public static void Code0x5D() { }
        public static void Code0x5E() { }
        public static void Code0x5F() { }

        #endregion

        #region 6x

        public static void Code0x60() { }
        public static void Code0x61() { }
        public static void Code0x62() { }
        public static void Code0x63() { }
        public static void Code0x64() { }
        public static void Code0x65() { }
        public static void Code0x66() { }
        public static void Code0x67() { }
        public static void Code0x68() { }
        public static void Code0x69() { }
        public static void Code0x6A() { }
        public static void Code0x6B() { }
        public static void Code0x6C() { }
        public static void Code0x6D() { }
        public static void Code0x6E() { }
        public static void Code0x6F() { }

        #endregion

        #region 7x

        public static void Code0x70() { }
        public static void Code0x71() { }
        public static void Code0x72() { }
        public static void Code0x73() { }
        public static void Code0x74() { }
        public static void Code0x75() { }
        public static void Code0x76() { }
        public static void Code0x77() { }
        public static void Code0x78() { }
        public static void Code0x79() { }
        public static void Code0x7A() { }
        public static void Code0x7B() { }
        public static void Code0x7C() { }
        public static void Code0x7D() { }
        public static void Code0x7E() { }
        public static void Code0x7F() { }

        #endregion

        #region 8x

        public static void Code0x80() { }
        public static void Code0x81() { }
        public static void Code0x82() { }
        public static void Code0x83() { }
        public static void Code0x84() { }
        public static void Code0x85() { }
        public static void Code0x86() { }
        public static void Code0x87() { }
        public static void Code0x88() { OpcodeHelpers.ADC(CPU.B_Register); }
        public static void Code0x89() { OpcodeHelpers.ADC(CPU.C_Register); }
        public static void Code0x8A() { OpcodeHelpers.ADC(CPU.D_Register); }
        public static void Code0x8B() { OpcodeHelpers.ADC(CPU.E_Register); }
        public static void Code0x8C() { OpcodeHelpers.ADC(CPU.H_Register); }
        public static void Code0x8D() { OpcodeHelpers.ADC(CPU.L_Register); }
        public static void Code0x8E() { OpcodeHelpers.ADCHL(CPU.HL_Register); }
        public static void Code0x8F() { OpcodeHelpers.ADC(CPU.reg_a); }

        #endregion

        #region 9x

        public static void Code0x90() { }
        public static void Code0x91() { }
        public static void Code0x92() { }
        public static void Code0x93() { }
        public static void Code0x94() { }
        public static void Code0x95() { }
        public static void Code0x96() { }
        public static void Code0x97() { }
        public static void Code0x98() { }
        public static void Code0x99() { }
        public static void Code0x9A() { }
        public static void Code0x9B() { }
        public static void Code0x9C() { }
        public static void Code0x9D() { }
        public static void Code0x9E() { }
        public static void Code0x9F() { }

        #endregion

        #region Ax

        public static void Code0xA0() { }
        public static void Code0xA1() { }
        public static void Code0xA2() { }
        public static void Code0xA3() { }
        public static void Code0xA4() { }
        public static void Code0xA5() { }
        public static void Code0xA6() { }
        public static void Code0xA7() { }
        public static void Code0xA8() { }
        public static void Code0xA9() { }
        public static void Code0xAA() { }
        public static void Code0xAB() { }
        public static void Code0xAC() { }
        public static void Code0xAD() { }
        public static void Code0xAE() { }
        public static void Code0xAF() { }

        #endregion

        #region Bx

        public static void Code0xB0() { }
        public static void Code0xB1() { }
        public static void Code0xB2() { }
        public static void Code0xB3() { }
        public static void Code0xB4() { }
        public static void Code0xB5() { }
        public static void Code0xB6() { }
        public static void Code0xB7() { }
        public static void Code0xB8() { }
        public static void Code0xB9() { }
        public static void Code0xBA() { }
        public static void Code0xBB() { }
        public static void Code0xBC() { }
        public static void Code0xBD() { }
        public static void Code0xBE() { }
        public static void Code0xBF() { }

        #endregion

        #region Cx

        public static void Code0xC0() { }
        public static void Code0xC1() { }
        public static void Code0xC2() { }
        public static void Code0xC3() { }
        public static void Code0xC4() { }
        public static void Code0xC5() { }
        public static void Code0xC6() { }
        public static void Code0xC7() { }
        public static void Code0xC8() { }
        public static void Code0xC9() { }
        public static void Code0xCA() { }
        public static void Code0xCB() { }
        public static void Code0xCC() { }
        public static void Code0xCD() { }
        public static void Code0xCE() { }
        public static void Code0xCF() { }

        #endregion

        #region Dx

        public static void Code0xD0() { }
        public static void Code0xD1() { }
        public static void Code0xD2() { }
        public static void Code0xD3() { }
        public static void Code0xD4() { }
        public static void Code0xD5() { }
        public static void Code0xD6() { }
        public static void Code0xD7() { }
        public static void Code0xD8() { }
        public static void Code0xD9() { }
        public static void Code0xDA() { }
        public static void Code0xDB() { }
        public static void Code0xDC() { }
        public static void Code0xDD() { }
        public static void Code0xDE() { }
        public static void Code0xDF() { }

        #endregion

        #region Ex

        public static void Code0xE0() { }
        public static void Code0xE1() { }
        public static void Code0xE2() { }
        public static void Code0xE3() { }
        public static void Code0xE4() { }
        public static void Code0xE5() { }
        public static void Code0xE6() { }
        public static void Code0xE7() { }
        public static void Code0xE8() { }
        public static void Code0xE9() { }
        public static void Code0xEA() { }
        public static void Code0xEB() { }
        public static void Code0xEC() { }
        public static void Code0xED() { }
        public static void Code0xEE() { }
        public static void Code0xEF() { }

        #endregion

        #region Fx

        public static void Code0xF0() { }
        public static void Code0xF1() { }
        public static void Code0xF2() { }
        public static void Code0xF3() { }
        public static void Code0xF4() { }
        public static void Code0xF5() { }
        public static void Code0xF6() { }
        public static void Code0xF7() { }
        public static void Code0xF8() { }
        public static void Code0xF9() { }
        public static void Code0xFA() { }
        public static void Code0xFB() { }
        public static void Code0xFC() { }
        public static void Code0xFD() { }
        public static void Code0xFE() { }
        public static void Code0xFF() { }

        #endregion
    }

    public static class OpcodeHelpers
    {
        public static void ADC(byte reg)
        {
            byte regA = CPU.reg_a;
            ushort sum = (ushort)(regA + reg + CPU.flag_c);

            if ((byte)sum == 0x0)
                CPU.flag_z = 0x1;
            else
                CPU.flag_z = 0x0;

            CPU.flag_n = 0x0;

            byte finalResult = (byte)((regA & 0xf) + (reg & 0xf) + CPU.flag_c);

            CPU.flag_h = (byte)(finalResult > 0xf ? 0x1 : 0x0);
            
            if(sum > 0xff) //Overflow from 7 bit (whole value)
                CPU.flag_c = 0x1;
            else
                CPU.flag_c = 0x0;

            CPU.reg_a = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }

        public static void ADCHL(ushort reg)
        {
            byte regA = CPU.reg_a;
            ushort sum = (ushort)(regA + CPU.memory[reg] + CPU.flag_c);

            if ((byte)sum == 0x0)
                CPU.flag_z = 0x1;
            else
                CPU.flag_z = 0x0;

            CPU.flag_n = 0x0;

            byte finalResult = (byte)((regA & 0xf) + (CPU.memory[reg] & 0xf) + CPU.flag_c);

            CPU.flag_h = (byte)(finalResult > 0xf ? 0x1 : 0x0);

            if (sum > 0xff) //Overflow from 7 bit (whole value)
                CPU.flag_c = 0x1;
            else
                CPU.flag_c = 0x0;

            CPU.reg_a = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }
    }
}
