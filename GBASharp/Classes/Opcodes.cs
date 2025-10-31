using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Opcodes
    {
        #region 0x (Done)

        public static void Code0x00() { OpcodeHelpers.NOP(); }
        public static void Code0x01() { OpcodeHelpers.LDxBC(); }
        public static void Code0x02() { OpcodeHelpers.LDmBC(); }
        public static void Code0x03() { OpcodeHelpers.INC(ref CPU.reg_bc); }
        public static void Code0x04() { OpcodeHelpers.INCxB(); }
        public static void Code0x05() { OpcodeHelpers.DECxB(); }
        public static void Code0x06() { OpcodeHelpers.LDxB(CPU.GetByteFromPC()); }
        public static void Code0x07() { OpcodeHelpers.RLCA(); }
        public static void Code0x08() { OpcodeHelpers.LDa16SP(); }
        public static void Code0x09() { OpcodeHelpers.ADDtoHL(CPU.BC_Register); }
        public static void Code0x0A() { OpcodeHelpers.LDxA(CPU.BC_Register); }
        public static void Code0x0B() { OpcodeHelpers.DECxBC(); }
        public static void Code0x0C() { OpcodeHelpers.INCxC(); }
        public static void Code0x0D() { OpcodeHelpers.DECxC(); }
        public static void Code0x0E() { OpcodeHelpers.LDxC(CPU.GetByteFromPC());  }
        public static void Code0x0F() { OpcodeHelpers.RRCA(); }

        #endregion

        #region 1x (Done)

        public static void Code0x10() { OpcodeHelpers.STOP(); }
        public static void Code0x11() { OpcodeHelpers.LDxDE(); }
        public static void Code0x12() { OpcodeHelpers.LDmDE(); }
        public static void Code0x13() { OpcodeHelpers.INC(ref CPU.reg_de); }
        public static void Code0x14() { OpcodeHelpers.INCxD(); }
        public static void Code0x15() { OpcodeHelpers.DECxD();}
        public static void Code0x16() { OpcodeHelpers.LDxD(CPU.GetByteFromPC()); }
        public static void Code0x17() { OpcodeHelpers.RLA(); }
        public static void Code0x18() { OpcodeHelpers.JR(); }
        public static void Code0x19() { OpcodeHelpers.ADDtoHL(CPU.DE_Register); }
        public static void Code0x1A() { OpcodeHelpers.LDxA(CPU.DE_Register); }
        public static void Code0x1B() { OpcodeHelpers.DECxDE(); }
        public static void Code0x1C() { OpcodeHelpers.INCxE(); }
        public static void Code0x1D() { OpcodeHelpers.DECxE();}
        public static void Code0x1E() { OpcodeHelpers.LDxE(CPU.GetByteFromPC()); }
        public static void Code0x1F() { OpcodeHelpers.RRA(); }

        #endregion

        #region 2x (Done)

        public static void Code0x20() { OpcodeHelpers.JR(CPU.Flag_Z, false); }
        public static void Code0x21() { OpcodeHelpers.LDxHL(); }
        public static void Code0x22() { OpcodeHelpers.LDmHLI(); }
        public static void Code0x23() { OpcodeHelpers.INC(ref CPU.reg_hl); }
        public static void Code0x24() { OpcodeHelpers.INCxH(); }
        public static void Code0x25() { OpcodeHelpers.DECxH();}
        public static void Code0x26() { OpcodeHelpers.LDxH(CPU.GetByteFromPC()); }
        public static void Code0x27() { OpcodeHelpers.DAA(); }
        public static void Code0x28() { OpcodeHelpers.JR(CPU.Flag_Z, true); }
        public static void Code0x29() { OpcodeHelpers.ADDtoHL(CPU.HL_Register); }
        public static void Code0x2A() { OpcodeHelpers.LDxA(CPU.HL_Register); CPU.HL_Register += 0x1; }
        public static void Code0x2B() { OpcodeHelpers.DECxHL(); }
        public static void Code0x2C() { OpcodeHelpers.INCxL(); }
        public static void Code0x2D() { OpcodeHelpers.DECxL();}
        public static void Code0x2E() { OpcodeHelpers.LDxL(CPU.GetByteFromPC()); }
        public static void Code0x2F() { OpcodeHelpers.CPL(); }

        #endregion

        #region 3x (Done)

        public static void Code0x30() { OpcodeHelpers.JR(CPU.Flag_C, false); }
        public static void Code0x31() { OpcodeHelpers.LDxSP(); }
        public static void Code0x32() { OpcodeHelpers.LDmHLD(); }
        public static void Code0x33() { OpcodeHelpers.INC(ref CPU.reg_sp); }
        public static void Code0x34() { OpcodeHelpers.INCxHL(); }
        public static void Code0x35() { OpcodeHelpers.DECmHL();}
        public static void Code0x36() { OpcodeHelpers.LDxHL(CPU.GetByteFromPC()); }
        public static void Code0x37() { OpcodeHelpers.SCF(); }
        public static void Code0x38() { OpcodeHelpers.JR(CPU.Flag_C, true); }
        public static void Code0x39() { OpcodeHelpers.ADDtoHL(CPU.reg_sp); }
        public static void Code0x3A() { OpcodeHelpers.LDxA(CPU.HL_Register); CPU.HL_Register -= 0x1; }
        public static void Code0x3B() { OpcodeHelpers.DECxSP(); }
        public static void Code0x3C() { OpcodeHelpers.INCxA(); }
        public static void Code0x3D() { OpcodeHelpers.DECxA();}
        public static void Code0x3E() { OpcodeHelpers.LDxA(CPU.GetByteFromPC()); }
        public static void Code0x3F() { OpcodeHelpers.CCF(); }

        #endregion

        #region 4x (Done)

        public static void Code0x40() { OpcodeHelpers.LDxB(CPU.B_Register); }
        public static void Code0x41() { OpcodeHelpers.LDxB(CPU.C_Register); }
        public static void Code0x42() { OpcodeHelpers.LDxB(CPU.D_Register); }
        public static void Code0x43() { OpcodeHelpers.LDxB(CPU.E_Register); }
        public static void Code0x44() { OpcodeHelpers.LDxB(CPU.H_Register); }
        public static void Code0x45() { OpcodeHelpers.LDxB(CPU.L_Register); }
        public static void Code0x46() { OpcodeHelpers.LDxB(CPU.HL_Register); }
        public static void Code0x47() { OpcodeHelpers.LDxB(CPU.A_Register); }
        public static void Code0x48() { OpcodeHelpers.LDxC(CPU.B_Register); }
        public static void Code0x49() { OpcodeHelpers.LDxC(CPU.C_Register); }
        public static void Code0x4A() { OpcodeHelpers.LDxC(CPU.D_Register); }
        public static void Code0x4B() { OpcodeHelpers.LDxC(CPU.E_Register); }
        public static void Code0x4C() { OpcodeHelpers.LDxC(CPU.H_Register); }
        public static void Code0x4D() { OpcodeHelpers.LDxC(CPU.L_Register); }
        public static void Code0x4E() { OpcodeHelpers.LDxC(CPU.HL_Register); }
        public static void Code0x4F() { OpcodeHelpers.LDxC(CPU.A_Register); }

        #endregion

        #region 5x (Done)

        public static void Code0x50() { OpcodeHelpers.LDxD(CPU.B_Register); }
        public static void Code0x51() { OpcodeHelpers.LDxD(CPU.C_Register); }
        public static void Code0x52() { OpcodeHelpers.LDxD(CPU.D_Register); }
        public static void Code0x53() { OpcodeHelpers.LDxD(CPU.E_Register); }
        public static void Code0x54() { OpcodeHelpers.LDxD(CPU.H_Register); }
        public static void Code0x55() { OpcodeHelpers.LDxD(CPU.L_Register); }
        public static void Code0x56() { OpcodeHelpers.LDxD(CPU.HL_Register); }
        public static void Code0x57() { OpcodeHelpers.LDxD(CPU.A_Register); }
        public static void Code0x58() { OpcodeHelpers.LDxE(CPU.B_Register); }
        public static void Code0x59() { OpcodeHelpers.LDxE(CPU.C_Register); }
        public static void Code0x5A() { OpcodeHelpers.LDxE(CPU.D_Register); }
        public static void Code0x5B() { OpcodeHelpers.LDxE(CPU.E_Register); }
        public static void Code0x5C() { OpcodeHelpers.LDxE(CPU.H_Register); }
        public static void Code0x5D() { OpcodeHelpers.LDxE(CPU.L_Register); }
        public static void Code0x5E() { OpcodeHelpers.LDxE(CPU.HL_Register); }
        public static void Code0x5F() { OpcodeHelpers.LDxE(CPU.A_Register); }

        #endregion

        #region 6x (Done)

        public static void Code0x60() { OpcodeHelpers.LDxH(CPU.B_Register); }
        public static void Code0x61() { OpcodeHelpers.LDxH(CPU.C_Register); }
        public static void Code0x62() { OpcodeHelpers.LDxH(CPU.D_Register); }
        public static void Code0x63() { OpcodeHelpers.LDxH(CPU.E_Register); }
        public static void Code0x64() { OpcodeHelpers.LDxH(CPU.H_Register); }
        public static void Code0x65() { OpcodeHelpers.LDxH(CPU.L_Register); }
        public static void Code0x66() { OpcodeHelpers.LDxH(CPU.HL_Register); }
        public static void Code0x67() { OpcodeHelpers.LDxH(CPU.A_Register); }
        public static void Code0x68() { OpcodeHelpers.LDxL(CPU.B_Register); }
        public static void Code0x69() { OpcodeHelpers.LDxL(CPU.C_Register); }
        public static void Code0x6A() { OpcodeHelpers.LDxL(CPU.D_Register); }
        public static void Code0x6B() { OpcodeHelpers.LDxL(CPU.E_Register); }
        public static void Code0x6C() { OpcodeHelpers.LDxL(CPU.H_Register); }
        public static void Code0x6D() { OpcodeHelpers.LDxL(CPU.L_Register); }
        public static void Code0x6E() { OpcodeHelpers.LDxL(CPU.HL_Register); }
        public static void Code0x6F() { OpcodeHelpers.LDxL(CPU.A_Register); }

        #endregion

        #region 7x (Missing HALT instruction)

        public static void Code0x70() { OpcodeHelpers.LDxHL(CPU.B_Register); }
        public static void Code0x71() { OpcodeHelpers.LDxHL(CPU.C_Register); }
        public static void Code0x72() { OpcodeHelpers.LDxHL(CPU.D_Register); }
        public static void Code0x73() { OpcodeHelpers.LDxHL(CPU.E_Register); }
        public static void Code0x74() { OpcodeHelpers.LDxHL(CPU.H_Register); }
        public static void Code0x75() { OpcodeHelpers.LDxHL(CPU.L_Register); }
        public static void Code0x76() { Console.Write("(Not Implemented)"); }
        public static void Code0x77() { OpcodeHelpers.LDxHL(CPU.A_Register); }
        public static void Code0x78() { OpcodeHelpers.LDxA(CPU.B_Register); }
        public static void Code0x79() { OpcodeHelpers.LDxA(CPU.C_Register); }
        public static void Code0x7A() { OpcodeHelpers.LDxA(CPU.D_Register); }
        public static void Code0x7B() { OpcodeHelpers.LDxA(CPU.E_Register); }
        public static void Code0x7C() { OpcodeHelpers.LDxA(CPU.H_Register); }
        public static void Code0x7D() { OpcodeHelpers.LDxA(CPU.L_Register); }
        public static void Code0x7E() { OpcodeHelpers.LDxA(CPU.HL_Register); }
        public static void Code0x7F() { OpcodeHelpers.LDxA(CPU.A_Register); }

        #endregion

        #region 8x (Done)

        public static void Code0x80() { OpcodeHelpers.ADD(CPU.B_Register); }
        public static void Code0x81() { OpcodeHelpers.ADD(CPU.C_Register); }
        public static void Code0x82() { OpcodeHelpers.ADD(CPU.D_Register); }
        public static void Code0x83() { OpcodeHelpers.ADD(CPU.E_Register); }
        public static void Code0x84() { OpcodeHelpers.ADD(CPU.H_Register); }
        public static void Code0x85() { OpcodeHelpers.ADD(CPU.L_Register); }
        public static void Code0x86() { OpcodeHelpers.ADDHL(CPU.HL_Register); }
        public static void Code0x87() { OpcodeHelpers.ADD(CPU.A_Register); }
        public static void Code0x88() { OpcodeHelpers.ADC(CPU.B_Register); }
        public static void Code0x89() { OpcodeHelpers.ADC(CPU.C_Register); }
        public static void Code0x8A() { OpcodeHelpers.ADC(CPU.D_Register); }
        public static void Code0x8B() { OpcodeHelpers.ADC(CPU.E_Register); }
        public static void Code0x8C() { OpcodeHelpers.ADC(CPU.H_Register); }
        public static void Code0x8D() { OpcodeHelpers.ADC(CPU.L_Register); }
        public static void Code0x8E() { OpcodeHelpers.ADCHL(CPU.HL_Register); }
        public static void Code0x8F() { OpcodeHelpers.ADC(CPU.A_Register); }

        #endregion

        #region 9x (Done)

        public static void Code0x90() { OpcodeHelpers.SUB(CPU.B_Register); }
        public static void Code0x91() { OpcodeHelpers.SUB(CPU.C_Register); }
        public static void Code0x92() { OpcodeHelpers.SUB(CPU.D_Register); }
        public static void Code0x93() { OpcodeHelpers.SUB(CPU.E_Register); }
        public static void Code0x94() { OpcodeHelpers.SUB(CPU.H_Register); }
        public static void Code0x95() { OpcodeHelpers.SUB(CPU.L_Register); }
        public static void Code0x96() { OpcodeHelpers.SUBHL(CPU.HL_Register); }
        public static void Code0x97() { OpcodeHelpers.SUB(CPU.A_Register); }
        public static void Code0x98() { OpcodeHelpers.SBC(CPU.B_Register); }
        public static void Code0x99() { OpcodeHelpers.SBC(CPU.C_Register); }
        public static void Code0x9A() { OpcodeHelpers.SBC(CPU.D_Register); }
        public static void Code0x9B() { OpcodeHelpers.SBC(CPU.E_Register); }
        public static void Code0x9C() { OpcodeHelpers.SBC(CPU.H_Register); }
        public static void Code0x9D() { OpcodeHelpers.SBC(CPU.L_Register); }
        public static void Code0x9E() { OpcodeHelpers.SBCHL(CPU.HL_Register); }
        public static void Code0x9F() { OpcodeHelpers.SBC(CPU.A_Register); }

        #endregion

        #region Ax (Done)

        public static void Code0xA0() { OpcodeHelpers.AND(CPU.B_Register); }
        public static void Code0xA1() { OpcodeHelpers.AND(CPU.C_Register); }
        public static void Code0xA2() { OpcodeHelpers.AND(CPU.D_Register); }
        public static void Code0xA3() { OpcodeHelpers.AND(CPU.E_Register); }
        public static void Code0xA4() { OpcodeHelpers.AND(CPU.H_Register); }
        public static void Code0xA5() { OpcodeHelpers.AND(CPU.L_Register); }
        public static void Code0xA6() { OpcodeHelpers.ANDHL(CPU.HL_Register); }
        public static void Code0xA7() { OpcodeHelpers.AND(CPU.A_Register); }
        public static void Code0xA8() { OpcodeHelpers.XOR(CPU.B_Register); }
        public static void Code0xA9() { OpcodeHelpers.XOR(CPU.C_Register); }
        public static void Code0xAA() { OpcodeHelpers.XOR(CPU.D_Register); }
        public static void Code0xAB() { OpcodeHelpers.XOR(CPU.E_Register); }
        public static void Code0xAC() { OpcodeHelpers.XOR(CPU.H_Register); }
        public static void Code0xAD() { OpcodeHelpers.XOR(CPU.L_Register); }
        public static void Code0xAE() { OpcodeHelpers.XORHL(CPU.HL_Register); }
        public static void Code0xAF() { OpcodeHelpers.XOR(CPU.A_Register); }

        #endregion

        #region Bx (Done)

        public static void Code0xB0() { OpcodeHelpers.OR(CPU.B_Register); }
        public static void Code0xB1() { OpcodeHelpers.OR(CPU.C_Register); }
        public static void Code0xB2() { OpcodeHelpers.OR(CPU.D_Register); }
        public static void Code0xB3() { OpcodeHelpers.OR(CPU.E_Register); }
        public static void Code0xB4() { OpcodeHelpers.OR(CPU.H_Register); }
        public static void Code0xB5() { OpcodeHelpers.OR(CPU.L_Register); }
        public static void Code0xB6() { OpcodeHelpers.ORHL(CPU.HL_Register); }
        public static void Code0xB7() { OpcodeHelpers.OR(CPU.A_Register); }
        public static void Code0xB8() { OpcodeHelpers.CP(CPU.B_Register); }
        public static void Code0xB9() { OpcodeHelpers.CP(CPU.C_Register); }
        public static void Code0xBA() { OpcodeHelpers.CP(CPU.D_Register); }
        public static void Code0xBB() { OpcodeHelpers.CP(CPU.E_Register); }
        public static void Code0xBC() { OpcodeHelpers.CP(CPU.H_Register); }
        public static void Code0xBD() { OpcodeHelpers.CP(CPU.L_Register); }
        public static void Code0xBE() { OpcodeHelpers.CPHL(CPU.HL_Register); }
        public static void Code0xBF() { OpcodeHelpers.CP(CPU.A_Register); }

        #endregion

        #region Cx

        public static void Code0xC0() { OpcodeHelpers.RET(CPU.Flag_Z == 0); }
        public static void Code0xC1() { OpcodeHelpers.POPxBC(); }
        public static void Code0xC2() { OpcodeHelpers.JPxNZ(); }
        public static void Code0xC3() { OpcodeHelpers.JP(); }
        public static void Code0xC4() { Console.Write("(Not Implemented)"); }
        public static void Code0xC5() { OpcodeHelpers.PUSH(CPU.B_Register, CPU.C_Register); }
        public static void Code0xC6() { Console.Write("(Not Implemented)"); }
        public static void Code0xC7() { Console.Write("(Not Implemented)"); }
        public static void Code0xC8() { OpcodeHelpers.RET(CPU.Flag_Z == 1); }
        public static void Code0xC9() { OpcodeHelpers.RET(); }
        public static void Code0xCA() { Console.Write("(Not Implemented)"); }
        public static void Code0xCB() { OpcodeHelpers.PREFIX(); }
        public static void Code0xCC() { Console.Write("(Not Implemented)"); }
        public static void Code0xCD() { OpcodeHelpers.CALL(); }
        public static void Code0xCE() { Console.Write("(Not Implemented)"); }
        public static void Code0xCF() { Console.Write("(Not Implemented)"); }

        #endregion

        #region Dx

        public static void Code0xD0() { OpcodeHelpers.RET(CPU.Flag_C == 0); }
        public static void Code0xD1() { OpcodeHelpers.POPxDE(); }
        public static void Code0xD2() { Console.Write("(Not Implemented)"); }
        public static void Code0xD3() { Console.Write("(Not Implemented)"); }
        public static void Code0xD4() { Console.Write("(Not Implemented)"); }
        public static void Code0xD5() { OpcodeHelpers.PUSH(CPU.D_Register, CPU.E_Register); }
        public static void Code0xD6() { OpcodeHelpers.SUB(CPU.GetByteFromPC()); }
        public static void Code0xD7() { Console.Write("(Not Implemented)"); }
        public static void Code0xD8() { OpcodeHelpers.RET(CPU.Flag_C == 1); }
        public static void Code0xD9() { Console.Write("(Not Implemented)"); }
        public static void Code0xDA() { Console.Write("(Not Implemented)"); }
        public static void Code0xDB() { Console.Write("(Not Implemented)"); }
        public static void Code0xDC() { Console.Write("(Not Implemented)"); }
        public static void Code0xDD() { Console.Write("(Not Implemented)"); }
        public static void Code0xDE() { OpcodeHelpers.SBC(CPU.GetByteFromPC()); }
        public static void Code0xDF() { Console.Write("(Not Implemented)"); }

        #endregion

        #region Ex

        public static void Code0xE0() { OpcodeHelpers.LDIO(CPU.GetByteFromPC(), CPU.A_Register); }
        public static void Code0xE1() { OpcodeHelpers.POPxHL(); }
        public static void Code0xE2() { OpcodeHelpers.LDIO(CPU.C_Register, CPU.A_Register); }
        public static void Code0xE3() { Console.Write("(Not Implemented)"); }
        public static void Code0xE4() { Console.Write("(Not Implemented)"); }
        public static void Code0xE5() { Console.Write("(Not Implemented)"); }
        public static void Code0xE6() { Console.Write("(Not Implemented)"); }
        public static void Code0xE7() { Console.Write("(Not Implemented)"); }
        public static void Code0xE8() { OpcodeHelpers.ADDSP(); }
        public static void Code0xE9() { OpcodeHelpers.JPxHL(); }
        public static void Code0xEA() { OpcodeHelpers.LD(CPU.GetWordFromPC(), CPU.A_Register); }
        public static void Code0xEB() { Console.Write("(Not Implemented)"); }
        public static void Code0xEC() { Console.Write("(Not Implemented)"); }
        public static void Code0xED() { Console.Write("(Not Implemented)"); }
        public static void Code0xEE() { Console.Write("(Not Implemented)"); }
        public static void Code0xEF() { Console.Write("(Not Implemented)"); }

        #endregion

        #region Fx

        public static void Code0xF0() { OpcodeHelpers.LDxA(CPU.memory[0xff00 + CPU.GetByteFromPC()]); }
        public static void Code0xF1() { OpcodeHelpers.POPxAF(); }
        public static void Code0xF2() { OpcodeHelpers.LDIOxA(CPU.C_Register); }
        public static void Code0xF3() { }
        public static void Code0xF4() { }
        public static void Code0xF5() { OpcodeHelpers.PUSHxAF(); }
        public static void Code0xF6() { }
        public static void Code0xF7() { }
        public static void Code0xF8() { }
        public static void Code0xF9() { OpcodeHelpers.LDxSP16(CPU.HL_Register); }
        public static void Code0xFA() { OpcodeHelpers.LDxA(CPU.memory[CPU.GetWordFromPC()]); }
        public static void Code0xFB() { }
        public static void Code0xFC() { }
        public static void Code0xFD() { }
        public static void Code0xFE() { OpcodeHelpers.CP(CPU.GetByteFromPC()); }
        public static void Code0xFF() { }

        #endregion
    }

    public static class OpcodeHelpers
    {

        //TODO: ALL THIS NEEDS TO BE CHANGED, THE FLAGS SHOULD NOT BE VARIABLES, BUT PART OF THE "AF" REGISTER(IN THIS CASE THE "f" PART)
        public static void SetFlagZ(ushort sum) { CPU.Flag_Z = (byte)sum == 0x0 ? (byte)0x1 : (byte)0x0; }
        public static void SetFlagZ(bool result) { CPU.Flag_Z = result ? (byte)0x1 : (byte)0x0; }
        public static void SetFlagN(bool result) { CPU.Flag_N = result ? (byte)0x1 : (byte)0x0; }
        public static void SetFlagH(byte value) { CPU.Flag_H = (byte)(value > 0xf ? 0x1 : 0x0); }
        public static void SetFlagH(ushort value) { CPU.Flag_H = (byte)(value > 0xfff ? 0x1 : 0x0); }
        public static void SetFlagH(bool result) { CPU.Flag_H = (byte)(result ? 0x1 : 0x0); }
        public static void SetFlagC(bool result) { CPU.Flag_C = result ? (byte)0x1 : (byte)0x0; }
        public static void InvertFlagC() { CPU.Flag_C = CPU.Flag_C == 0x1 ? (byte)0x0 : (byte)0x1; }

        public static void NOP() { /* No Operation */ }
        
        public static void STOP() { /* Low Power mode CPU */ }

        public static void ADC(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register + reg + CPU.Flag_C);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.A_Register & 0xf) + (reg & 0xf) + CPU.Flag_C)); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }

        public static void ADCHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register + CPU.memory[reg] + CPU.Flag_C);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.A_Register & 0xf) + (CPU.memory[reg] & 0xf) + CPU.Flag_C)); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }

        public static void ADD(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register + reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.A_Register & 0xf) + (reg & 0xf))); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void ADDSP()
        {
            byte reg = CPU.GetByteFromPC();
            sbyte signedVal = (sbyte)reg;
            short lowSP = (short)(CPU.reg_sp & 0xFF);
            short unsignedSum = (short)(lowSP + (reg & 0xFF));

            SetFlagZ(false);
            SetFlagN(false);
            SetFlagH((byte)((CPU.reg_sp & 0xf) + (reg & 0xf))); //Overflow from bit 3
            SetFlagC(unsignedSum > 0xff);   //Overflow from bit 7

            CPU.reg_sp = (ushort)(CPU.reg_sp + signedVal);
        }

        private static int signed(byte value)
        {
            if (value >= 0x80)
                return value - 0x100;
            return value;
        }

        public static void ADDHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register + CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH((byte)((CPU.A_Register & 0xf) + (CPU.memory[reg] & 0xf))); //Overflow from bit 3
            SetFlagC(sum > 0xff); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
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
            ushort sum = (ushort)(CPU.A_Register - reg - CPU.Flag_C);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.A_Register & 0xf) - (reg & 0xf) - CPU.Flag_C)); //Overflow from bit 3
            SetFlagC((reg + CPU.Flag_C) > CPU.A_Register); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void SBCHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register - CPU.memory[reg] - CPU.Flag_C);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.A_Register & 0xf) - (CPU.memory[reg] & 0xf) - CPU.Flag_C)); //Overflow from bit 3
            SetFlagC((CPU.memory[reg] + CPU.Flag_C) > CPU.A_Register); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void SUB(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register - reg);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.A_Register & 0xf) - (reg & 0xf))); //Overflow from bit 3
            SetFlagC(reg > CPU.A_Register); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void SUBHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register - CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.A_Register & 0xf) - (CPU.memory[reg] & 0xf))); //Overflow from bit 3
            SetFlagC(CPU.memory[reg] > CPU.A_Register); //Overflow from 7 bit (whole value)

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void AND(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register & reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(true); //Set 0x1
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void ANDHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register & CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(true); //Set 0x1
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void XOR(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register ^ reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void XORHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register ^ CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void OR(byte reg)
        {
            ushort sum = (ushort)(CPU.A_Register | reg);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        public static void ORHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register | CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(false);
            SetFlagH(false); //Set 0x0
            SetFlagC(false); //Set 0x0

            CPU.A_Register = (byte)(sum & 0xff);
        }

        //Old version
        //public static void CP(byte reg)
        //{
        //    ushort sum = (ushort)(CPU.A_Register - reg);
        //
        //    SetFlagZ(sum);
        //    SetFlagN(true);
        //    SetFlagH((byte)((CPU.A_Register & 0xf) - (reg & 0xf))); //Set if overflow from bit 3
        //    SetFlagC(reg > CPU.A_Register); //Set if overflow from 7 bit
        //}
        public static void CP(byte reg)
        {
            SetFlagZ(CPU.A_Register == reg);
            SetFlagN(true);
            SetFlagH((CPU.A_Register & 0xF) < (reg & 0xF));
            SetFlagC(CPU.A_Register < reg);
        }

        public static void CPHL(ushort reg)
        {
            ushort sum = (ushort)(CPU.A_Register - CPU.memory[reg]);

            SetFlagZ(sum);
            SetFlagN(true);
            SetFlagH((byte)((CPU.A_Register & 0xf) - (CPU.memory[reg] & 0xf))); //Set if overflow from bit 3
            SetFlagC(CPU.memory[reg] > CPU.A_Register); //Set if overflow from 7 bit
        }
        
        public static void LD(ushort address, byte value) { CPU.memory[address] = value; }

        public static void LDxSP16(ushort value) { CPU.reg_sp = value; }

        public static void LDIO(byte address, byte value) { CPU.memory[0xff00 + address] = value; }
        
        public static void LDIOxA(byte address) { CPU.A_Register = CPU.memory[0xff00 + address]; }

        public static void LDxA(byte value) { CPU.A_Register = value; }

        public static void LDxA(ushort value) { CPU.A_Register = CPU.memory[value]; }

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

        public static void LDmBC() { CPU.memory[CPU.BC_Register] = CPU.A_Register; }

        public static void LDmDE() { CPU.memory[CPU.DE_Register] = CPU.A_Register; }

        public static void LDmHLI() { CPU.memory[CPU.HL_Register] = CPU.A_Register; CPU.HL_Register += 0x1; } //Increment

        public static void LDmHLD() { CPU.memory[CPU.HL_Register] = CPU.A_Register; CPU.HL_Register -= 0x1; } //Decrement

        public static void LDmSP() { CPU.memory[CPU.reg_sp] = CPU.A_Register; }

        public static void LDa16SP()
        {
            ushort word = CPU.GetWordFromPC();
            CPU.memory[word] = (byte)(CPU.reg_sp & 0xff);
            CPU.memory[word + 1] = (byte)(CPU.reg_sp >> 8);
        }

        public static void LDH() {  }

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
            CPU.A_Register += 0x1;
            SetFlagZ(CPU.A_Register);
            SetFlagN(false);
            SetFlagH((CPU.A_Register & 0xf) == 0x0); //Set if overflow from bit 3)
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

        public static void DECmHL()
        {
            CPU.memory[CPU.HL_Register] -= 0x1;
            SetFlagZ(CPU.memory[CPU.HL_Register]);
            SetFlagN(true);
            SetFlagH((CPU.memory[CPU.HL_Register] & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void DECxHL() { CPU.HL_Register -= 0x1; }

        public static void DECxBC() { CPU.BC_Register -= 0x1; }

        public static void DECxDE() { CPU.DE_Register -= 0x1; }

        public static void DECxSP() { CPU.reg_sp -= 0x1; }

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
            CPU.A_Register -= 0x1;
            SetFlagZ(CPU.A_Register);
            SetFlagN(true);
            SetFlagH((CPU.A_Register & 0xf) == 0xf); //Set if borrow from bit 4)
        }

        public static void RLCA()
        {
            CPU.A_Register = RLC(CPU.A_Register);
            SetFlagZ(false);
            SetFlagN(false);
            SetFlagH(false);
        }

        public static void RRCA()
        {
            CPU.A_Register = RRC(CPU.A_Register);
            SetFlagZ(false);
            SetFlagN(false);
            SetFlagH(false);
        }

        public static byte RLC(byte reg, bool updateZ = false)
        {
            byte topMost = (byte)(reg >> 7 & 0x1);
            CPU.Flag_C = topMost;
            byte result = (byte)(reg << 1 | topMost);

            if (updateZ)
                SetFlagZ(result == 0);

            SetFlagH(false);
            SetFlagN(false);

            return result;
        }

        public static byte RRC(byte reg, bool updateZ = false)
        {
            byte bottomMost = (byte)(reg & 0x1);
            CPU.Flag_C = bottomMost;

            byte result = (byte)(bottomMost << 7 | reg >> 1);

            if (updateZ)
                SetFlagZ(result == 0);

            SetFlagH(false);
            SetFlagN(false);

            return result;
        }

        public static void RLA()
        {
            CPU.A_Register = RL(CPU.A_Register);
            SetFlagZ(false);
            SetFlagN(false);
            SetFlagH(false);
        }

        public static void RRA()
        {
            CPU.A_Register = RR(CPU.A_Register);
            SetFlagZ(false);
            SetFlagN(false);
            SetFlagH(false);
        }

        public static byte RL(byte reg, bool updateZ = false)
        {
            byte flag = CPU.Flag_C;
            byte topMost = (byte)(reg >> 7 & 0x1);
            CPU.Flag_C = topMost;

            byte result = (byte)(reg << 1 | flag);

            if (updateZ)
                SetFlagZ(result == 0);

            SetFlagH(false);
            SetFlagN(false);

            return result;
        }

        public static byte RR(byte reg, bool updateZ = false)
        {
            byte flag = CPU.Flag_C;
            byte bottomMost = (byte)(reg & 0x1);
            CPU.Flag_C = bottomMost;

            byte result = (byte)(flag << 7 | reg >> 1);

            if (updateZ)
                SetFlagZ(result == 0);

            SetFlagH(false);
            SetFlagN(false);

            return result;
        }

        public static void JR() { JR(0x0, ignore: true); }

        public static void JR(byte flag, bool expect = false, bool ignore = false)
        {
            byte immediate = CPU.GetByteFromPC();
            if (ignore || flag == (expect ? 0x1 : 0x0))
            {
                bool minus = immediate >= 0x80; //If less than 128

                //Should return a value from -128 to 127 (255)
                if (minus)
                    CPU.pc -= (byte)(0x80 - (immediate - 0x80));
                else
                    CPU.pc += (byte)(immediate);
            }
        }

        public static void DAA()
        {
            //We need to do BCD arithmetic, this mean we must treat the values as decimal and not hex
            //for example 0x66 means 66 and not 102
            //For this we can isolate the nibbles (one nibble is half a byte or 4 bits), each nibble is a decimal value
            //Hex is represented in the following, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, A, B, C, D, E, F
            //So when we have something higher than 9 we just add 6 meaning it will skip the letters, and we add 1 to the next nibble

            if(CPU.Flag_N == 0) //n == 0 (addition)
            {
                //Lower nibble has invalid BCD value or carry flag is enabled we add 0x06
                if((CPU.A_Register & 0x0f) > 0x9 || CPU.Flag_H == 0x1)
                    CPU.A_Register += 0x06;

                if (CPU.A_Register > 0x9F || CPU.Flag_C == 0x1)
                {
                    CPU.A_Register += 0x60;
                    SetFlagC(true);
                }
            }
            else //n == 1 (subtraction)
            {
                if (CPU.Flag_H == 0x1)
                    CPU.A_Register -= 0x06;

                if (CPU.Flag_C == 0x1)
                    CPU.A_Register -= 0x60;
            }

            SetFlagZ(CPU.A_Register == 0x0);
            SetFlagH(0x0); //Clear
        }

        public static void SCF()
        {
            SetFlagH(false);
            SetFlagN(false);
            SetFlagC(true);
        }

        public static void CPL()
        {
            CPU.A_Register = (byte)~CPU.A_Register;
            SetFlagN(true);
            SetFlagH(true);
        }

        public static void CCF()
        {
            SetFlagH(false);
            SetFlagN(false);
            InvertFlagC();
        }

        public static void POPxHL()
        {
            CPU.L_Register = (byte)(CPU.memory[CPU.reg_sp] & 0xff);
            CPU.reg_sp++;
            CPU.H_Register = (byte)(CPU.memory[CPU.reg_sp] & 0xff);
            CPU.reg_sp++;
            //CPU.HL_Register = (ushort)((CPU.memory[CPU.reg_sp] >> 4 & 0xff) + (CPU.memory[CPU.reg_sp] & 0xff));
            //CPU.reg_sp += 0x2;
        }

        public static void POPxBC()
        {
            CPU.B_Register = CPU.memory[CPU.reg_sp + 1];
            CPU.C_Register = CPU.memory[CPU.reg_sp];
            CPU.reg_sp += 0x2;
        }

        public static void POPxDE()
        {
            CPU.D_Register = CPU.memory[CPU.reg_sp + 1];
            CPU.E_Register = CPU.memory[CPU.reg_sp];
            CPU.reg_sp += 0x2;
        }

        public static void PUSH(byte high, byte low)
        {
            DECxSP();
            LD(CPU.reg_sp, high);
            DECxSP();
            LD(CPU.reg_sp, low);
        }

        public static void POPxAF()
        {
            CPU.A_Register = CPU.memory[CPU.reg_sp + 1];
            CPU.F_Register = CPU.memory[CPU.reg_sp];
            CPU.reg_sp += 0x2;
        }

        public static void PUSHxAF()
        {
            DECxSP();
            CPU.memory[CPU.reg_sp] = CPU.A_Register;
            DECxSP();
            CPU.memory[CPU.reg_sp] = CPU.F_Register;
        }

        public static void JPxHL()
        {
            CPU.pc = CPU.HL_Register;
        }

        public static void JP()
        {
            ushort word = CPU.GetWordFromPC();
            CPU.pc = word;
        }

        public static void JPxNZ()
        {
            ushort word = CPU.GetWordFromPC();
            if(CPU.Flag_Z == 0x0)
                CPU.pc = word;
        }

        public static void CALL()
        {
            ushort word = CPU.GetWordFromPC();
            CPU.reg_sp -= 0x1;
            CPU.memory[CPU.reg_sp] = (byte)(CPU.pc >> 8);
            CPU.reg_sp -= 0x1;
            CPU.memory[CPU.reg_sp] = (byte)(CPU.pc);
            CPU.pc = word;
        }

        public static void RET(bool condition)
        {
            if (condition)
                RET();
        }

        public static void RET()
        {
            CPU.pc = (ushort)((CPU.memory[CPU.reg_sp + 1] << 8) | CPU.memory[CPU.reg_sp]);
            CPU.reg_sp += 2;
        }

        public static void PREFIX()
        {
            //Executes another opcode at the PC memory address
            byte opAddr = CPU.GetByteFromPC();
            CPU.ExecuteCBOpcode(opAddr);
        }

        public static byte SLA(byte reg)
        {
            //The left bit if outside 16bits, check C flag
            SetFlagC((reg >> 7 & 0x1) == 0x1);

            //Clearn N and H flags
            SetFlagH(false);
            SetFlagN(false);

            //Shift reg 1 bit to left
            byte shifted = (byte)(reg << 1);

            //if reg == 0 then flag Z = 1, else 0
            SetFlagZ(shifted == 0x0);

            //return shifted reg?
            return shifted;
        }

        public static byte SRA(byte reg)
        {
            //Save right most bit and toggle C flag based on it
            SetFlagC((reg & 0x1) == 0x1);

            //Save left most bit
            byte leftmost = (byte)(reg >> 7 & 0x1); //0x1 or 0x0

            //shift all 1 to the right
            reg >>= 1;

            //if left most bit was 1, then we add 0x80 (1 in 8th bit in binary)
            if (leftmost == 0x1)
                reg += 0x80;

            //Clearn N and H flags
            SetFlagH(false);
            SetFlagN(false);
            SetFlagZ(reg == 0x0);

            return reg;
        }

        public static byte SWAP(byte reg)
        {
            //Split both lower and higher bits
            byte lowerBits = (byte)(reg & 0xf);
            byte higherBits = (byte)(reg >> 4 & 0xf);

            //Flip them
            byte result = (byte)(lowerBits << 4 | higherBits);

            //Reset the flags and set the Z flag if result is 0x0
            SetFlagH(false);
            SetFlagN(false);
            SetFlagC(false);
            SetFlagZ(result == 0x0);

            return result;
        }

        public static byte SRL(byte reg)
        {
            //Save right most bit and toggle C flag based on it
            SetFlagC((reg & 0x1) == 0x1);

            //Save left most bit
            byte leftmost = (byte)(reg >> 7 & 0x1); //0x1 or 0x0

            //shift all 1 to the right
            reg >>= 1;

            //Clearn N and H flags
            SetFlagH(false);
            SetFlagN(false);
            SetFlagZ(reg == 0x0);

            return reg;
        }
    }
}
