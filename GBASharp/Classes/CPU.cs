using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class CPU
    {
        //CPU Memory Map
        public static byte[] memory = new byte[0xFFFF]; //64KiB Memory

        //Registers
        public static byte reg_a = 0x0; //Accumulator & Flags

        //Note the reg_af has been replaced with reg_a and the flags have been split up into different variables

        //Lower 8 bits of the "reg_af" have the following flags
        //Bit 7 - Zero Flag (z)
        //Bit 6 - Subtraction Flag (n)
        //Bit 5 - Half Carry Flag (h)
        //Bit 4 - Carry Flag (c)

        public static byte flag_z = 0x0;
        public static byte flag_n = 0x0;
        public static byte flag_h = 0x0;
        public static byte flag_c = 0x0;

        static ushort reg_bc = 0x0; //BC
        static ushort reg_de = 0x0; //DE
        static ushort reg_hl = 0x0; //HL
        public static ushort reg_sp = 0x0; //Stack Pointer
        public static ushort pc = 0x0;     //Program Counter

        public static ushort opcode = 0x0;

        //Helpers opcode (DXY0)
        public static byte op_Prefix = 0x0;
        public static byte op_X = 0x0;
        public static byte op_Y = 0x0;
        public static byte op_N = 0x0;

        public static ushort BC_Register { get { return reg_bc; } set { reg_bc = value; } }
        public static byte B_Register { get { return (byte)(reg_bc >> 8 & 0xff); } set { reg_bc = (ushort)((reg_bc >> 8 & 0xff) << 8 | value); } }
        public static byte C_Register { get { return (byte)(reg_bc & 0xff); } set { reg_bc = (ushort)(value << 8 | reg_bc & 0xff); } }

        public static ushort DE_Register { get { return reg_de; } set { reg_de = value; } }
        public static byte D_Register { get { return (byte)(reg_de >> 8 & 0xff); } set { reg_de = (ushort)((reg_de >> 8 & 0xff) << 8 | value); } }
        public static byte E_Register { get { return (byte)(reg_de & 0xff); } set { reg_de = (ushort)(value << 8 | reg_de & 0xff); } }

        public static ushort HL_Register { get { return reg_hl; } set { reg_hl = value; } }
        public static byte H_Register { get { return (byte)(reg_hl >> 8 & 0xff); } set { reg_hl = (ushort)((reg_hl >> 8 & 0xff) << 8 | value); } }
        public static byte L_Register { get { return (byte)(reg_hl & 0xff); } set { reg_hl = (ushort)(value << 8 | reg_hl & 0xff); } }

        //Memory Breakdown
        //0000 - 3FFF / 16 KiB ROM bank 00              || From cartridge, usually a fixed bank
        //4000 - 7FFF / 16 KiB ROM Bank 01–NN           || From cartridge, switchable bank via mapper(if any)
        //8000 - 9FFF / 8 KiB Video RAM(VRAM)           || In CGB mode, switchable bank 0 / 1
        //A000 - BFFF / 8 KiB External RAM              || From cartridge, switchable bank if any
        //C000 - CFFF / 4 KiB Work RAM(WRAM)
        //D000 - DFFF / 4 KiB Work RAM(WRAM)            || In CGB mode, switchable bank 1–7
        //E000 - FDFF / Echo RAM(mirror of C000–DDFF)   || Nintendo says use of this area is prohibited.
        //FE00 - FE9F / Object attribute memory(OAM)
        //FEA0 - FEFF / Not Usable                      || Nintendo says use of this area is prohibited.
        //FF00 - FF7F / I / O Registers
        //FF80 - FFFE / High RAM(HRAM)
        //FFFF - FFFF / Interrupt Enable register(IE)

        #region Testing

        public static void SetCPUTesting(byte a, byte b, byte c, byte d, byte e, byte f, byte h, byte l, ushort _pc, ushort sp, List<List<ushort>> replaceMemory)
        {
            reg_a = a;

            flag_z = (byte)(f >> 7 & 0x1);
            flag_n = (byte)(f >> 6 & 0x1);
            flag_h = (byte)(f >> 5 & 0x1);
            flag_c = (byte)(f >> 4 & 0x1);

            reg_bc = (ushort)(b << 8 | c);
            reg_de = (ushort)(d << 8 | e);
            reg_hl = (ushort)(h << 8 | l);
            reg_sp = sp;
            pc = _pc;

            foreach(List<ushort> r in replaceMemory)
                memory[r[0]] = (byte)r[1];
        }

        public static bool CheckCPUTesting(byte a, byte b, byte c, byte d, byte e, byte f, byte h, byte l, ushort _pc, ushort sp, List<List<ushort>> checkMemory)
        {
            if(reg_a != a)
                return false;

            byte evalZ = (byte)(f >> 7 & 0x1);
            byte evalN = (byte)(f >> 6 & 0x1);
            byte evalH = (byte)(f >> 5 & 0x1);
            byte evalC = (byte)(f >> 4 & 0x1);

            if (evalZ != flag_z)
                return false;

            if (evalN != flag_n)
                return false;

            if (evalH != flag_h)
                return false;

            if (evalC != flag_c)
                return false;

            if (reg_bc != (ushort)(b << 8 | c))
                return false;

            if (reg_de != (ushort)(d << 8 | e))
                return false;

            if (reg_hl != (ushort)(h << 8 | l))
                return false;

            if (reg_sp != sp)
                return false;

            if (pc != _pc)
                return false;

            foreach (List<ushort> r in checkMemory)
                if (memory[r[0]] != (byte)r[1])
                    return false;

            return true;
        }

        public static void ExecuteOpcode(byte opcode)
        {
            switch (opcode)
            {
                case 0x88: Opcodes.Code0x88(); break;
                case 0x89: Opcodes.Code0x89(); break;
                case 0x8A: Opcodes.Code0x8A(); break;
                case 0x8B: Opcodes.Code0x8B(); break;
                case 0x8C: Opcodes.Code0x8C(); break;
                case 0x8D: Opcodes.Code0x8D(); break;
                case 0x8E: Opcodes.Code0x8E(); break;
                case 0x8F: Opcodes.Code0x8F(); break;
                default: break;
            }

            pc += 0x1;
        }

        #endregion

        public static void BootSequence()
        {
            //Clear and Load Rom
            ClearMemory();
            LoadRomToMemory();
        }

        public static void ClearMemory()
        {
            for (int i = 0; i < memory.Length; i++)
                memory[i] = 0x0;
        }

        static void LoadRomToMemory()
        {
            //The rom itself only loads the first 32KiB
            for (int i = 0x0; i <= 0x7FFF; i++)
                memory[pc + i] = Cartridge.ROM[i];
        }

        public static void Fetch()
        {
            //opcode = (ushort)((memory[pc] << 0x8) | (memory[pc + 0x1]));
            //pc += 0x1; //Jumps the program counter to the next instruction
        }

        public static void Decode()
        {
            //op_Prefix = (byte)(opcode >> 12 & 0xf);
            //op_X = (byte)(opcode >> 8 & 0xf);
            //op_Y = (byte)(opcode >> 4 & 0xf);
            //op_N = (byte)(opcode & 0xf);
        }

        public static void Execute()
        {

        }
    }
}
