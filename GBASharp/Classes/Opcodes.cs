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

        public static void Code0x00() { OpcodeHelpers.NOP(); }
        public static void Code0x01() { OpcodeHelpers.LDxBC(); }
        public static void Code0x02() { OpcodeHelpers.LDmBC(); }
        public static void Code0x03() { OpcodeHelpers.INC(ref CPU.reg_bc); }
        public static void Code0x04() { OpcodeHelpers.INCxB(); }
        public static void Code0x05() { OpcodeHelpers.DECxB(); }
        public static void Code0x06() { }
        public static void Code0x07() { }
        public static void Code0x08() { }
        public static void Code0x09() { OpcodeHelpers.ADDtoHL(CPU.BC_Register); }
        public static void Code0x0A() { }
        public static void Code0x0B() { }
        public static void Code0x0C() { OpcodeHelpers.INCxC(); }
        public static void Code0x0D() { OpcodeHelpers.DECxC(); }
        public static void Code0x0E() { }
        public static void Code0x0F() { }

        #endregion

        #region 1x

        public static void Code0x10() { }
        public static void Code0x11() { OpcodeHelpers.LDxDE(); }
        public static void Code0x12() { OpcodeHelpers.LDmDE(); }
        public static void Code0x13() { OpcodeHelpers.INC(ref CPU.reg_de); }
        public static void Code0x14() { OpcodeHelpers.INCxD(); }
        public static void Code0x15() { OpcodeHelpers.DECxD();}
        public static void Code0x16() { }
        public static void Code0x17() { }
        public static void Code0x18() { }
        public static void Code0x19() { OpcodeHelpers.ADDtoHL(CPU.DE_Register); }
        public static void Code0x1A() { }
        public static void Code0x1B() { }
        public static void Code0x1C() { OpcodeHelpers.INCxE(); }
        public static void Code0x1D() { OpcodeHelpers.DECxE();}
        public static void Code0x1E() { }
        public static void Code0x1F() { }

        #endregion

        #region 2x

        public static void Code0x20() { }
        public static void Code0x21() { OpcodeHelpers.LDxHL(); }
        public static void Code0x22() { OpcodeHelpers.LDmHLI(); }
        public static void Code0x23() { OpcodeHelpers.INC(ref CPU.reg_hl); }
        public static void Code0x24() { OpcodeHelpers.INCxH(); }
        public static void Code0x25() { OpcodeHelpers.DECxH();}
        public static void Code0x26() { }
        public static void Code0x27() { }
        public static void Code0x28() { }
        public static void Code0x29() { OpcodeHelpers.ADDtoHL(CPU.HL_Register); }
        public static void Code0x2A() { }
        public static void Code0x2B() { }
        public static void Code0x2C() { OpcodeHelpers.INCxL(); }
        public static void Code0x2D() { OpcodeHelpers.DECxL();}
        public static void Code0x2E() { }
        public static void Code0x2F() { }

        #endregion

        #region 3x

        public static void Code0x30() { }
        public static void Code0x31() { OpcodeHelpers.LDxSP(); }
        public static void Code0x32() { OpcodeHelpers.LDmHLD(); }
        public static void Code0x33() { OpcodeHelpers.INC(ref CPU.reg_sp); }
        public static void Code0x34() { OpcodeHelpers.INCxHL(); }
        public static void Code0x35() { OpcodeHelpers.DECxHL();}
        public static void Code0x36() { }
        public static void Code0x37() { }
        public static void Code0x38() { }
        public static void Code0x39() { OpcodeHelpers.ADDtoHL(CPU.reg_sp); }
        public static void Code0x3A() { }
        public static void Code0x3B() { }
        public static void Code0x3C() { OpcodeHelpers.INCxA(); }
        public static void Code0x3D() { OpcodeHelpers.DECxA();}
        public static void Code0x3E() { }
        public static void Code0x3F() { }

        #endregion

        #region 4x (Done)

        public static void Code0x40() { OpcodeHelpers.LDxB(CPU.B_Register); }
        public static void Code0x41() { OpcodeHelpers.LDxB(CPU.C_Register); }
        public static void Code0x42() { OpcodeHelpers.LDxB(CPU.D_Register); }
        public static void Code0x43() { OpcodeHelpers.LDxB(CPU.E_Register); }
        public static void Code0x44() { OpcodeHelpers.LDxB(CPU.H_Register); }
        public static void Code0x45() { OpcodeHelpers.LDxB(CPU.L_Register); }
        public static void Code0x46() { OpcodeHelpers.LDxB(CPU.HL_Register); }
        public static void Code0x47() { OpcodeHelpers.LDxB(CPU.reg_a); }
        public static void Code0x48() { OpcodeHelpers.LDxC(CPU.B_Register); }
        public static void Code0x49() { OpcodeHelpers.LDxC(CPU.C_Register); }
        public static void Code0x4A() { OpcodeHelpers.LDxC(CPU.D_Register); }
        public static void Code0x4B() { OpcodeHelpers.LDxC(CPU.E_Register); }
        public static void Code0x4C() { OpcodeHelpers.LDxC(CPU.H_Register); }
        public static void Code0x4D() { OpcodeHelpers.LDxC(CPU.L_Register); }
        public static void Code0x4E() { OpcodeHelpers.LDxC(CPU.HL_Register); }
        public static void Code0x4F() { OpcodeHelpers.LDxC(CPU.reg_a); }

        #endregion

        #region 5x (Done)

        public static void Code0x50() { OpcodeHelpers.LDxD(CPU.B_Register); }
        public static void Code0x51() { OpcodeHelpers.LDxD(CPU.C_Register); }
        public static void Code0x52() { OpcodeHelpers.LDxD(CPU.D_Register); }
        public static void Code0x53() { OpcodeHelpers.LDxD(CPU.E_Register); }
        public static void Code0x54() { OpcodeHelpers.LDxD(CPU.H_Register); }
        public static void Code0x55() { OpcodeHelpers.LDxD(CPU.L_Register); }
        public static void Code0x56() { OpcodeHelpers.LDxD(CPU.HL_Register); }
        public static void Code0x57() { OpcodeHelpers.LDxD(CPU.reg_a); }
        public static void Code0x58() { OpcodeHelpers.LDxE(CPU.B_Register); }
        public static void Code0x59() { OpcodeHelpers.LDxE(CPU.C_Register); }
        public static void Code0x5A() { OpcodeHelpers.LDxE(CPU.D_Register); }
        public static void Code0x5B() { OpcodeHelpers.LDxE(CPU.E_Register); }
        public static void Code0x5C() { OpcodeHelpers.LDxE(CPU.H_Register); }
        public static void Code0x5D() { OpcodeHelpers.LDxE(CPU.L_Register); }
        public static void Code0x5E() { OpcodeHelpers.LDxE(CPU.HL_Register); }
        public static void Code0x5F() { OpcodeHelpers.LDxE(CPU.reg_a); }

        #endregion

        #region 6x (Done)

        public static void Code0x60() { OpcodeHelpers.LDxH(CPU.B_Register); }
        public static void Code0x61() { OpcodeHelpers.LDxH(CPU.C_Register); }
        public static void Code0x62() { OpcodeHelpers.LDxH(CPU.D_Register); }
        public static void Code0x63() { OpcodeHelpers.LDxH(CPU.E_Register); }
        public static void Code0x64() { OpcodeHelpers.LDxH(CPU.H_Register); }
        public static void Code0x65() { OpcodeHelpers.LDxH(CPU.L_Register); }
        public static void Code0x66() { OpcodeHelpers.LDxH(CPU.HL_Register); }
        public static void Code0x67() { OpcodeHelpers.LDxH(CPU.reg_a); }
        public static void Code0x68() { OpcodeHelpers.LDxL(CPU.B_Register); }
        public static void Code0x69() { OpcodeHelpers.LDxL(CPU.C_Register); }
        public static void Code0x6A() { OpcodeHelpers.LDxL(CPU.D_Register); }
        public static void Code0x6B() { OpcodeHelpers.LDxL(CPU.E_Register); }
        public static void Code0x6C() { OpcodeHelpers.LDxL(CPU.H_Register); }
        public static void Code0x6D() { OpcodeHelpers.LDxL(CPU.L_Register); }
        public static void Code0x6E() { OpcodeHelpers.LDxL(CPU.HL_Register); }
        public static void Code0x6F() { OpcodeHelpers.LDxL(CPU.reg_a); }

        #endregion

        #region 7x (Missing HALT instruction)

        public static void Code0x70() { OpcodeHelpers.LDxHL(CPU.B_Register); }
        public static void Code0x71() { OpcodeHelpers.LDxHL(CPU.C_Register); }
        public static void Code0x72() { OpcodeHelpers.LDxHL(CPU.D_Register); }
        public static void Code0x73() { OpcodeHelpers.LDxHL(CPU.E_Register); }
        public static void Code0x74() { OpcodeHelpers.LDxHL(CPU.H_Register); }
        public static void Code0x75() { OpcodeHelpers.LDxHL(CPU.L_Register); }
        public static void Code0x76() { }
        public static void Code0x77() { OpcodeHelpers.LDxHL(CPU.reg_a); }
        public static void Code0x78() { OpcodeHelpers.LDxA(CPU.B_Register); }
        public static void Code0x79() { OpcodeHelpers.LDxA(CPU.C_Register); }
        public static void Code0x7A() { OpcodeHelpers.LDxA(CPU.D_Register); }
        public static void Code0x7B() { OpcodeHelpers.LDxA(CPU.E_Register); }
        public static void Code0x7C() { OpcodeHelpers.LDxA(CPU.H_Register); }
        public static void Code0x7D() { OpcodeHelpers.LDxA(CPU.L_Register); }
        public static void Code0x7E() { OpcodeHelpers.LDxA(CPU.HL_Register); }
        public static void Code0x7F() { OpcodeHelpers.LDxA(CPU.reg_a); }

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
        public static void SetFlagH(ushort value) { CPU.flag_h = (byte)(value > 0xfff ? 0x1 : 0x0); }
        public static void SetFlagH(bool result) { CPU.flag_h = (byte)(result ? 0x1 : 0x0); }
        public static void SetFlagC(bool result) { CPU.flag_c = result ? (byte)0x1 : (byte)0x0; }

        public static void NOP() { /* No Operation */ }

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

        public static void ADDtoHL(ushort reg)
        {
            int sum = (int)(CPU.HL_Register + reg);

            SetFlagN(false);
            SetFlagH((ushort)((CPU.HL_Register & 0xfff) + (reg & 0xfff))); //Overflow from bit 11
            SetFlagC(sum > 0xffff); //Overflow from 15 bit (whole value)

            CPU.HL_Register = (ushort)(sum);
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
        
        public static void LDxA(byte value) { CPU.reg_a = value; }

        public static void LDxA(ushort value) { CPU.reg_a = CPU.memory[value]; }

        public static void LDxB(byte value) { CPU.B_Register = value; }

        public static void LDxB(ushort value) { CPU.B_Register = CPU.memory[value]; }

        public static void LDxC(byte value) { CPU.C_Register = value; }

        public static void LDxC(ushort value) { CPU.C_Register = CPU.memory[value]; }

        public static void LDxD(byte value) { CPU.D_Register = value; }

        public static void LDxD(ushort value) { CPU.D_Register = CPU.memory[value]; }

        public static void LDxE(byte value) { CPU.E_Register = value; }

        public static void LDxE(ushort value) { CPU.E_Register = CPU.memory[value]; }

        public static void LDxH(byte value) { CPU.H_Register = value; }

        public static void LDxH(ushort value) { CPU.H_Register = CPU.memory[value]; }

        public static void LDxL(byte value) { CPU.L_Register = value; }

        public static void LDxL(ushort value) { CPU.L_Register = CPU.memory[value]; }

        public static void LDxHL(byte value) { CPU.memory[CPU.HL_Register] = value; }

        public static void LDxBC() { CPU.BC_Register = CPU.GetWordFromPC(); }

        public static void LDxDE() { CPU.DE_Register = CPU.GetWordFromPC(); }

        public static void LDxHL() { CPU.HL_Register = CPU.GetWordFromPC(); }

        public static void LDxSP() { CPU.reg_sp = CPU.GetWordFromPC(); }

        public static void LDmBC() { CPU.memory[CPU.BC_Register] = CPU.reg_a; }

        public static void LDmDE() { CPU.memory[CPU.DE_Register] = CPU.reg_a; }

        public static void LDmHLI() { CPU.memory[CPU.HL_Register] = CPU.reg_a; CPU.HL_Register += 0x1; } //Increment

        public static void LDmHLD() { CPU.memory[CPU.HL_Register] = CPU.reg_a; CPU.HL_Register -= 0x1; } //Decrement

        public static void LDmSP() { CPU.memory[CPU.reg_sp] = CPU.reg_a; }

        public static void INC(ref ushort reg) { reg += 0x1; }

        public static void INCxB()
        {
            CPU.B_Register += 0x1;
            SetFlagZ(CPU.B_Register);
            SetFlagN(false);
            SetFlagH((CPU.B_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxD()
        {
            CPU.D_Register += 0x1;
            SetFlagZ(CPU.D_Register);
            SetFlagN(false);
            SetFlagH((CPU.D_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxH()
        {
            CPU.H_Register += 0x1;
            SetFlagZ(CPU.H_Register);
            SetFlagN(false);
            SetFlagH((CPU.H_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxHL()
        {
            CPU.memory[CPU.HL_Register] += 0x1;
            SetFlagZ(CPU.memory[CPU.HL_Register]);
            SetFlagN(false);
            SetFlagH((CPU.memory[CPU.HL_Register] & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxC()
        {
            CPU.C_Register += 0x1;
            SetFlagZ(CPU.C_Register);
            SetFlagN(false);
            SetFlagH((CPU.C_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxE()
        {
            CPU.E_Register += 0x1;
            SetFlagZ(CPU.E_Register);
            SetFlagN(false);
            SetFlagH((CPU.E_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxL()
        {
            CPU.L_Register += 0x1;
            SetFlagZ(CPU.L_Register);
            SetFlagN(false);
            SetFlagH((CPU.L_Register & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void INCxA()
        {
            CPU.reg_a += 0x1;
            SetFlagZ(CPU.reg_a);
            SetFlagN(false);
            SetFlagH((CPU.reg_a & 0xf) == 0x0); //Set if overflow from bit 3)
        }

        public static void DECxB()
        {
            CPU.B_Register -= 0x1;
            SetFlagZ(CPU.B_Register);
            SetFlagN(true);
            SetFlagH((CPU.B_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxD()
        {
            CPU.D_Register -= 0x1;
            SetFlagZ(CPU.D_Register);
            SetFlagN(true);
            SetFlagH((CPU.D_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxH()
        {
            CPU.H_Register -= 0x1;
            SetFlagZ(CPU.H_Register);
            SetFlagN(true);
            SetFlagH((CPU.H_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxHL()
        {
            CPU.memory[CPU.HL_Register] -= 0x1;
            SetFlagZ(CPU.memory[CPU.HL_Register]);
            SetFlagN(true);
            SetFlagH((CPU.memory[CPU.HL_Register] & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxC()
        {
            CPU.C_Register -= 0x1;
            SetFlagZ(CPU.C_Register);
            SetFlagN(true);
            SetFlagH((CPU.C_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxE()
        {
            CPU.E_Register -= 0x1;
            SetFlagZ(CPU.E_Register);
            SetFlagN(true);
            SetFlagH((CPU.E_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxL()
        {
            CPU.L_Register -= 0x1;
            SetFlagZ(CPU.L_Register);
            SetFlagN(true);
            SetFlagH((CPU.L_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxA()
        {
            CPU.reg_a -= 0x1;
            SetFlagZ(CPU.reg_a);
            SetFlagN(true);
            SetFlagH((CPU.reg_a & 0xf) == 0xf); //Set if borrow from bit 4)
        }
    }
}
