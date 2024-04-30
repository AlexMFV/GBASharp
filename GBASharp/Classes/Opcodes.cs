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

        #region 8x (Done)

        public static void Code0x80() { OpcodeHelpers.ADD(CPU.B_Register); }
        public static void Code0x81() { OpcodeHelpers.ADD(CPU.C_Register); }
        public static void Code0x82() { OpcodeHelpers.ADD(CPU.D_Register); }
        public static void Code0x83() { OpcodeHelpers.ADD(CPU.E_Register); }
        public static void Code0x84() { OpcodeHelpers.ADD(CPU.H_Register); }
        public static void Code0x85() { OpcodeHelpers.ADD(CPU.L_Register); }
        public static void Code0x86() { OpcodeHelpers.ADDHL(CPU.HL_Register); }
        public static void Code0x87() { OpcodeHelpers.ADD(CPU.reg_a); }
        public static void Code0x88() { OpcodeHelpers.ADC(CPU.B_Register); }
        public static void Code0x89() { OpcodeHelpers.ADC(CPU.C_Register); }
        public static void Code0x8A() { OpcodeHelpers.ADC(CPU.D_Register); }
        public static void Code0x8B() { OpcodeHelpers.ADC(CPU.E_Register); }
        public static void Code0x8C() { OpcodeHelpers.ADC(CPU.H_Register); }
        public static void Code0x8D() { OpcodeHelpers.ADC(CPU.L_Register); }
        public static void Code0x8E() { OpcodeHelpers.ADCHL(CPU.HL_Register); }
        public static void Code0x8F() { OpcodeHelpers.ADC(CPU.reg_a); }

        #endregion

        #region 9x (Done)

        public static void Code0x90() { OpcodeHelpers.SUB(CPU.B_Register); }
        public static void Code0x91() { OpcodeHelpers.SUB(CPU.C_Register); }
        public static void Code0x92() { OpcodeHelpers.SUB(CPU.D_Register); }
        public static void Code0x93() { OpcodeHelpers.SUB(CPU.E_Register); }
        public static void Code0x94() { OpcodeHelpers.SUB(CPU.H_Register); }
        public static void Code0x95() { OpcodeHelpers.SUB(CPU.L_Register); }
        public static void Code0x96() { OpcodeHelpers.SUBHL(CPU.HL_Register); }
        public static void Code0x97() { OpcodeHelpers.SUB(CPU.reg_a); }
        public static void Code0x98() { OpcodeHelpers.SBC(CPU.B_Register); }
        public static void Code0x99() { OpcodeHelpers.SBC(CPU.C_Register); }
        public static void Code0x9A() { OpcodeHelpers.SBC(CPU.D_Register); }
        public static void Code0x9B() { OpcodeHelpers.SBC(CPU.E_Register); }
        public static void Code0x9C() { OpcodeHelpers.SBC(CPU.H_Register); }
        public static void Code0x9D() { OpcodeHelpers.SBC(CPU.L_Register); }
        public static void Code0x9E() { OpcodeHelpers.SBCHL(CPU.HL_Register); }
        public static void Code0x9F() { OpcodeHelpers.SBC(CPU.reg_a); }

        #endregion

        #region Ax (Done)

        public static void Code0xA0() { OpcodeHelpers.AND(CPU.B_Register); }
        public static void Code0xA1() { OpcodeHelpers.AND(CPU.C_Register); }
        public static void Code0xA2() { OpcodeHelpers.AND(CPU.D_Register); }
        public static void Code0xA3() { OpcodeHelpers.AND(CPU.E_Register); }
        public static void Code0xA4() { OpcodeHelpers.AND(CPU.H_Register); }
        public static void Code0xA5() { OpcodeHelpers.AND(CPU.L_Register); }
        public static void Code0xA6() { OpcodeHelpers.ANDHL(CPU.HL_Register); }
        public static void Code0xA7() { OpcodeHelpers.AND(CPU.reg_a); }
        public static void Code0xA8() { OpcodeHelpers.XOR(CPU.B_Register); }
        public static void Code0xA9() { OpcodeHelpers.XOR(CPU.C_Register); }
        public static void Code0xAA() { OpcodeHelpers.XOR(CPU.D_Register); }
        public static void Code0xAB() { OpcodeHelpers.XOR(CPU.E_Register); }
        public static void Code0xAC() { OpcodeHelpers.XOR(CPU.H_Register); }
        public static void Code0xAD() { OpcodeHelpers.XOR(CPU.L_Register); }
        public static void Code0xAE() { OpcodeHelpers.XORHL(CPU.HL_Register); }
        public static void Code0xAF() { OpcodeHelpers.XOR(CPU.reg_a); }

        #endregion

        #region Bx (Done)

        public static void Code0xB0() { OpcodeHelpers.OR(CPU.B_Register); }
        public static void Code0xB1() { OpcodeHelpers.OR(CPU.C_Register); }
        public static void Code0xB2() { OpcodeHelpers.OR(CPU.D_Register); }
        public static void Code0xB3() { OpcodeHelpers.OR(CPU.E_Register); }
        public static void Code0xB4() { OpcodeHelpers.OR(CPU.H_Register); }
        public static void Code0xB5() { OpcodeHelpers.OR(CPU.L_Register); }
        public static void Code0xB6() { OpcodeHelpers.ORHL(CPU.HL_Register); }
        public static void Code0xB7() { OpcodeHelpers.OR(CPU.reg_a); }
        public static void Code0xB8() { OpcodeHelpers.CP(CPU.B_Register); }
        public static void Code0xB9() { OpcodeHelpers.CP(CPU.C_Register); }
        public static void Code0xBA() { OpcodeHelpers.CP(CPU.D_Register); }
        public static void Code0xBB() { OpcodeHelpers.CP(CPU.E_Register); }
        public static void Code0xBC() { OpcodeHelpers.CP(CPU.H_Register); }
        public static void Code0xBD() { OpcodeHelpers.CP(CPU.L_Register); }
        public static void Code0xBE() { OpcodeHelpers.CPHL(CPU.HL_Register); }
        public static void Code0xBF() { OpcodeHelpers.CP(CPU.reg_a); }

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
        public static void SetFlagZ(ushort sum) { CPU.flag_z = (byte)sum == 0x0 ? (byte)0x1 : (byte)0x0; }
        public static void SetFlagN(bool result) { CPU.flag_n = result ? (byte)0x1 : (byte)0x0; }
        public static void SetFlagH(byte value) { CPU.flag_h = (byte)(value > 0xf ? 0x1 : 0x0); }
        public static void SetFlagH(bool result) { CPU.flag_h = (byte)(result ? 0x1 : 0x0); }
        public static void SetFlagC(bool result) { CPU.flag_c = result ? (byte)0x1 : (byte)0x0; }

        public static void ADC(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a + reg + CPU.flag_c);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.reg_a & 0xf) + (reg & 0xf) + CPU.flag_c)); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }

        public static void ADCHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a + CPU.memory[reg] + CPU.flag_c);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.reg_a & 0xf) + (CPU.memory[reg] & 0xf) + CPU.flag_c)); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }

        public static void ADD(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a + reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.reg_a & 0xf) + (reg & 0xf))); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void ADDHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a + CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.reg_a & 0xf) + (CPU.memory[reg] & 0xf))); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void SBC(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a - reg - CPU.flag_c);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (reg & 0xf) - CPU.flag_c)); //Overflow from bit 3
            SetFlagC((reg + CPU.flag_c) > CPU.reg_a); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void SBCHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a - CPU.memory[reg] - CPU.flag_c);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (CPU.memory[reg] & 0xf) - CPU.flag_c)); //Overflow from bit 3
            SetFlagC((CPU.memory[reg] + CPU.flag_c) > CPU.reg_a); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void SUB(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a - reg);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (reg & 0xf))); //Overflow from bit 3
            SetFlagC(reg > CPU.reg_a); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void SUBHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a - CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (CPU.memory[reg] & 0xf))); //Overflow from bit 3
            SetFlagC(CPU.memory[reg] > CPU.reg_a); //Overflow from 7 bit (whole value)

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void AND(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a & reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(true); //Set 0x1
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void ANDHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a & CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(true); //Set 0x1
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void XOR(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a ^ reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void XORHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a ^ CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void OR(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a | reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void ORHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a | CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.reg_a = (byte)(sum & 0xff);
        }

        public static void CP(byte reg)
        {
            ushort sum = (ushort)(CPU.reg_a - reg);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (reg & 0xf))); //Set if overflow from bit 3
            SetFlagC(reg > CPU.reg_a); //Set if overflow from 7 bit
        }

        public static void CPHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.reg_a - CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.reg_a & 0xf) - (CPU.memory[reg] & 0xf))); //Set if overflow from bit 3
            SetFlagC(CPU.memory[reg] > CPU.reg_a); //Set if overflow from 7 bit
        }
    }
}
