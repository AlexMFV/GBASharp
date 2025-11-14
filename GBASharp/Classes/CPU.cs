using Newtonsoft.Json.Linq;
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
        public static byte[] memory = new byte[0x10000]; //64KiB Memory
        public static byte[] bootROM = new byte[0x100]; //256b boot ROM

        //Lower 8 bits of the "reg_af" have the following flags
        //Bit 7 - Zero Flag (z)
        //Bit 6 - Subtraction Flag (n)
        //Bit 5 - Half Carry Flag (h)
        //Bit 4 - Carry Flag (c)

        //public static byte flag_z = 0x0;
        //public static byte flag_n = 0x0;
        //public static byte flag_h = 0x0;
        //public static byte flag_c = 0x0;

        //Registers
        public static ushort reg_af = 0x0; //Accumulator & Flags
        public static ushort reg_bc = 0x0; //BC
        public static ushort reg_de = 0x0; //DE
        public static ushort reg_hl = 0x0; //HL
        public static ushort reg_sp = 0x0; //Stack Pointer
        public static ushort pc = 0x0;     //Program Counter

        public static byte opcode = 0x0;
        public static bool IME = false;
        public static int IMEshouldExecute = 0;
        public static bool IMEchanged = false;
        public static bool bootFinished = false;
        public static bool halted = false;

        //Helpers opcode (DXY0)
        public static byte op_Prefix = 0x0;
        public static byte op_X = 0x0;
        public static byte op_Y = 0x0;
        public static byte op_N = 0x0;

        public static ushort ifAddress = 0xff0f;
        public static ushort ieAddress = 0xffff;

        public static ushort joypadAddress = 0xff00;

        public static byte IFRegister { get { return memory[ifAddress]; } set { memory[ifAddress] = value; } }
        public static byte IERegister { get { return memory[ieAddress]; } set { memory[ifAddress] = value; } }

        //public static bool CanProcess { get { return canProcess; } set { canProcess = value; } }
        //public static double Cycles { get { return cycles; } set { cycles = value; } }

        public static ushort BC_Register { get { return reg_bc; } set { reg_bc = value; } }
        public static byte B_Register { get { return GetHighByte(reg_bc); } set { reg_bc = SetHighByte(reg_bc, value); } }
        public static byte C_Register { get { return GetLowByte(reg_bc); } set { reg_bc = SetLowByte(reg_bc, value); } }

        public static ushort DE_Register { get { return reg_de; } set { reg_de = value; } }
        public static byte D_Register { get { return GetHighByte(reg_de); } set { reg_de = SetHighByte(reg_de, value); } }
        public static byte E_Register { get { return GetLowByte(reg_de); } set { reg_de = SetLowByte(reg_de, value); } }

        public static ushort HL_Register { get { return reg_hl; } set { reg_hl = value; } }
        public static byte H_Register { get { return GetHighByte(reg_hl); } set { reg_hl = SetHighByte(reg_hl, value); } }
        public static byte L_Register { get { return GetLowByte(reg_hl); } set { reg_hl = SetLowByte(reg_hl, value); } }


        public static ushort AF_Register { get { return reg_af; } set { reg_af = value; } }
        public static byte A_Register { get { return GetHighByte(reg_af); } set { reg_af = SetHighByte(reg_af, value); } }
        public static byte F_Register { get { return (byte)(GetLowByte(reg_af) & 0xF0); } set { reg_af = SetLowByte(reg_af, (byte)(value & 0xF0)); } }

        public static byte Flag_C { get { return (byte)(F_Register >> 4 & 0x1); } set { F_Register = (byte)((F_Register & 0xE0) | (value << 4)); } }
        public static byte Flag_H { get { return (byte)(F_Register >> 5 & 0x1); } set { F_Register = (byte)((F_Register & 0xD0) | (value << 5)); } }
        public static byte Flag_N { get { return (byte)(F_Register >> 6 & 0x1); } set { F_Register = (byte)((F_Register & 0xB0) | (value << 6)); } }
        public static byte Flag_Z { get { return (byte)(F_Register >> 7 & 0x1); } set { F_Register = (byte)((F_Register & 0x70) | (value << 7)); } }

        private static byte GetLowByte(ushort register) { return (byte)(register & 0xff); }
        private static byte GetHighByte(ushort register) { return (byte)(register >> 8 & 0xff); }
        private static ushort SetLowByte(ushort register, byte value) { return (ushort)((register >> 8 & 0xff) << 8 | value); }
        private static ushort SetHighByte(ushort register, byte value) { return (ushort)(value << 8 | register & 0xff); }

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
            A_Register = a;
            F_Register = f;
            //Flag_C = (byte)(f >> 4 & 0x1);
            //Flag_H = (byte)(f >> 5 & 0x1);
            //Flag_N = (byte)(f >> 6 & 0x1);
            //Flag_Z = (byte)(f >> 7 & 0x1);

            B_Register = b;
            C_Register = c;
            D_Register = d;
            E_Register = e;
            H_Register = h;
            L_Register = l;

            //reg_bc = (ushort)(b << 8 | c);
            //reg_de = (ushort)(d << 8 | e);
            //reg_hl = (ushort)(h << 8 | l);
            reg_sp = sp;
            pc = _pc;

            foreach(List<ushort> r in replaceMemory)
                memory[r[0]] = (byte)r[1];
        }

        public static bool CheckCPUTesting(byte a, byte b, byte c, byte d, byte e, byte f, byte h, byte l, ushort _pc, ushort sp, List<List<ushort>> checkMemory)
        {
            if(A_Register != a)
                return false;

            if (F_Register != f)
                return false;

            //byte evalZ = (byte)(f >> 7 & 0x1);
            //byte evalN = (byte)(f >> 6 & 0x1);
            //byte evalH = (byte)(f >> 5 & 0x1);
            //byte evalC = (byte)(f >> 4 & 0x1);
            //
            //if (evalZ != Flag_Z)
            //    return false;
            //
            //if (evalN != Flag_N)
            //    return false;
            //
            //if (evalH != Flag_H)
            //    return false;
            //
            //if (evalC != Flag_C)
            //    return false;

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

        #endregion

        public static void ResetCycleCounter() { Emulator.cpuManager.cycle = 0; Emulator.cpuManager.canProcess = true; }

        //public static void IncrementCycleCounter(byte opcode)
        //{
            
            //cycles += CycleManager.CYCLES_OPCODE[opcode];

            //THERE WILL PROBABLY BE A PROBLEM HERE.
            //LET'S SAY FOR EXAMPLE THAT WE ARE RUNNING CORRECTLY AND THE PROCESSING OF OPCODES IS ALWAYS FASTER THAT THE FRAME TIME.
            //THIS MEANS THAT EVERY FRAME THE OPCODE PROCESSING WILL ALWAYS WAIT SOME TIME BEFORE RESUMING THE NEXT OPCODES, BECAUSE
            //IT USED ALL THE CYCLES FOR THAT FRAME BEFORE THE FRAME ENDED.

            //BUT LET'S SAY THAT THE 70k+ CYCLES ARE NOT ATTAINABLE INSIDE A FRAME, THIS MEANS THAT SOME INSTRUCTIONS THAT SHOULD'VE BEEN 
            //PROCESSED IN THAT FRAME WILL BE PASSED TO THE NEXT FRAME. BUT THE WAY OUR CODE IS DONE WE ONLY REFRESH THE SCREEN USING RAYLIB
            //ONCE WE STOP THE OPCODE PROCESSING.

            //AND SINCE IN THIS SCENARIO WE NEVER FINISH THE OPCODES FIRST, THE CPU.CanProcess VARIABLE IS ALWAYS TRUE, MEANING THE WHILE LOOP
            //IS NEVER GOING TO STOP.

            //MAYBE IF WE INCLUDE THE OPCODE CYCLE INSIDE THE RAYLIB.BEGINDRAWING AND ENDDRAWING WE CAN PROCESS NEW DATA INSIDE THE WHILE LOOP

        //}

        public static ushort GetWordFromPC()
        {
            byte lower = GetByteFromPC();
            byte upper = GetByteFromPC();
            return (ushort)(upper << 8 | lower);
        }

        public static byte GetByteFromPC()
        {
            byte value = memory[pc];
            pc += 0x1;
            return value;
        }

        public static void BootSequence()
        {
            //Clear and Load ROMs
            ClearMemory();
            LoadRomToMemory();
            LoadBootROM();
        }

        public static void UnmapBootRom()
        {
            for(int i = 0x0; i < bootROM.Length-1; i++)
                memory[i] = Cartridge.ROM[i];
        }

        public static void ClearMemory()
        {
            for (int i = 0; i < memory.Length; i++)
                memory[i] = 0x0;
        }

        static void LoadBootROM()
        {
            // Boot ROM overlays the first 256 bytes
            for (int i = 0x0; i < bootROM.Length && i <= 0xFF; i++)
                memory[i] = bootROM[i];
        }

        static void LoadRomToMemory()
        {
            // Load ROM starting at 0x0000 (but boot ROM will overlay it temporarily)
            for (int i = 0x0; i < Cartridge.ROM.Length && i <= 0x7FFF; i++)
                memory[i] = Cartridge.ROM[i];
        }

        public static void Fetch()
        {
            if (pc >= memory.Length)
                pc = 0xFFFF-0x1;

            opcode = memory[pc];
            pc += 1;
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
            //ExecuteOpcode
            ExecuteOpcode(opcode);
        }

        public static void ExecuteCBOpcode(byte opcode)
        {
            int group = (opcode >> 6) & 0x03;
            int y = (opcode >> 3) & 0x07;
            int r = opcode & 0x07;

            switch (group)
            {
                case 0: HandleRotateShift(y, r); break;
                case 1: HandleBitTest(y, r); break;
                case 2: HandleBitReset(y, r); break;
                case 3: HandleBitSet(y, r); break;
            }
        }

        static byte ResolveRegister(int r)
        {
            switch (r)
            {
                case 0: return CPU.B_Register;
                case 1: return CPU.C_Register;
                case 2: return CPU.D_Register;
                case 3: return CPU.E_Register;
                case 4: return CPU.H_Register;
                case 5: return CPU.L_Register;
                case 7: return CPU.A_Register;
                default: return 0x0;
                    //throw new Exception("(HL) not handled here");
            }
        }

        static void SaveToRegister(int r, byte newValue)
        {
            switch (r)
            {
                case 0: CPU.B_Register = newValue; break;
                case 1: CPU.C_Register = newValue; break;
                case 2: CPU.D_Register = newValue; break;
                case 3: CPU.E_Register = newValue; break;
                case 4: CPU.H_Register = newValue; break;
                case 5: CPU.L_Register = newValue; break;
                case 7: CPU.A_Register = newValue; break;
                default: break;
                    //throw new Exception("(HL) not handled here");
            }
        }

        static void HandleRotateShift(int y, int r)
        {
            byte reg;

            //Necessary for the HL operation only
            if (r == 6)
            {
                ushort addr = CPU.HL_Register;
                reg = CPU.memory[addr];
            }
            else
                reg = ResolveRegister(r);

            byte newValue = 0x0;
            switch (y)
            {
                case 0: newValue = OpcodeHelpers.RLC(reg, true); break;
                case 1: newValue = OpcodeHelpers.RRC(reg, true); break;
                case 2: newValue = OpcodeHelpers.RL(reg, true); break;
                case 3: newValue = OpcodeHelpers.RR(reg, true); break;
                case 4: newValue = OpcodeHelpers.SLA(reg); break;
                case 5: newValue = OpcodeHelpers.SRA(reg); break;
                case 6: newValue = OpcodeHelpers.SWAP(reg); break;
                case 7: newValue = OpcodeHelpers.SRL(reg); break;
            }

            if (r != 6)
                SaveToRegister(r, newValue);
            else
                CPU.memory[CPU.HL_Register] = newValue;
        }

        static void HandleBitTest(int bit, int r)
        {
            if (r == 6)
                BIT(bit, CPU.memory[CPU.HL_Register]); // no write-back
            else
                BIT(bit, ResolveRegister(r));
        }

        static void HandleBitReset(int bit, int r)
        {
            if (r == 6)
            {
                byte val = CPU.memory[CPU.HL_Register];
                val = RES(bit, val);
                CPU.memory[CPU.HL_Register] = val;
            }
            else
            {
                byte val = RES(bit, ResolveRegister(r));
                SaveToRegister(r, val);
            }
        }

        static void HandleBitSet(int bit, int r)
        {
            if (r == 6)
            {
                ushort addr = CPU.HL_Register;
                byte val = CPU.memory[addr];
                val = SET(bit, val);
                CPU.memory[addr] = val;       // write back
            }
            else
            {
                byte val = SET(bit, ResolveRegister(r));
                SaveToRegister(r, val);
            }
        }

        static void BIT(int bit, byte reg)
        {
            CPU.Flag_Z = (byte)(((reg >> bit) & 1) == 0 ? 1 : 0);
            CPU.Flag_N = 0;
            CPU.Flag_H = 1;
        }

        static byte RES(int bit, byte reg)
        {
            return (byte)(reg & ~(1 << bit));
        }

        static byte SET(int bit, byte reg)
        {
            return (byte)(reg | (1 << bit));
        }

        public static void ExecuteOpcode(byte opcode)
        {
            //if (CPU.opcode != 0x0)
            //{
            //Console.WriteLine("");
            //Console.Write($"{CPU.pc:X8} - OPCODE: 0x{CPU.opcode:X2} (SP: {CPU.reg_sp:X2})");
            //}

            //if (CPU.pc == 0x0067)
            //    Console.WriteLine($"A={CPU.A_Register:X2}, LY={CPU.memory[0xFF44]}, FlagF={CPU.F_Register:X4}");

            switch (opcode)
            {
                #region 0x

                case 0x00: Opcodes.Code0x00(); break;
                case 0x01: Opcodes.Code0x01(); break;
                case 0x02: Opcodes.Code0x02(); break;
                case 0x03: Opcodes.Code0x03(); break;
                case 0x04: Opcodes.Code0x04(); break;
                case 0x05: Opcodes.Code0x05(); break;
                case 0x06: Opcodes.Code0x06(); break;
                case 0x07: Opcodes.Code0x07(); break;
                case 0x08: Opcodes.Code0x08(); break;
                case 0x09: Opcodes.Code0x09(); break;
                case 0x0A: Opcodes.Code0x0A(); break;
                case 0x0B: Opcodes.Code0x0B(); break;
                case 0x0C: Opcodes.Code0x0C(); break;
                case 0x0D: Opcodes.Code0x0D(); break;
                case 0x0E: Opcodes.Code0x0E(); break;
                case 0x0F: Opcodes.Code0x0F(); break;

                #endregion

                #region 1x

                case 0x10: Opcodes.Code0x10(); break;
                case 0x11: Opcodes.Code0x11(); break;
                case 0x12: Opcodes.Code0x12(); break;
                case 0x13: Opcodes.Code0x13(); break;
                case 0x14: Opcodes.Code0x14(); break;
                case 0x15: Opcodes.Code0x15(); break;
                case 0x16: Opcodes.Code0x16(); break;
                case 0x17: Opcodes.Code0x17(); break;
                case 0x18: Opcodes.Code0x18(); break;
                case 0x19: Opcodes.Code0x19(); break;
                case 0x1A: Opcodes.Code0x1A(); break;
                case 0x1B: Opcodes.Code0x1B(); break;
                case 0x1C: Opcodes.Code0x1C(); break;
                case 0x1D: Opcodes.Code0x1D(); break;
                case 0x1E: Opcodes.Code0x1E(); break;
                case 0x1F: Opcodes.Code0x1F(); break;

                #endregion

                #region 2x

                case 0x20: Opcodes.Code0x20(); break;
                case 0x21: Opcodes.Code0x21(); break;
                case 0x22: Opcodes.Code0x22(); break;
                case 0x23: Opcodes.Code0x23(); break;
                case 0x24: Opcodes.Code0x24(); break;
                case 0x25: Opcodes.Code0x25(); break;
                case 0x26: Opcodes.Code0x26(); break;
                case 0x27: Opcodes.Code0x27(); break;
                case 0x28: Opcodes.Code0x28(); break;
                case 0x29: Opcodes.Code0x29(); break;
                case 0x2A: Opcodes.Code0x2A(); break;
                case 0x2B: Opcodes.Code0x2B(); break;
                case 0x2C: Opcodes.Code0x2C(); break;
                case 0x2D: Opcodes.Code0x2D(); break;
                case 0x2E: Opcodes.Code0x2E(); break;
                case 0x2F: Opcodes.Code0x2F(); break;

                #endregion

                #region 3x

                case 0x30: Opcodes.Code0x30(); break;
                case 0x31: Opcodes.Code0x31(); break;
                case 0x32: Opcodes.Code0x32(); break;
                case 0x33: Opcodes.Code0x33(); break;
                case 0x34: Opcodes.Code0x34(); break;
                case 0x35: Opcodes.Code0x35(); break;
                case 0x36: Opcodes.Code0x36(); break;
                case 0x37: Opcodes.Code0x37(); break;
                case 0x38: Opcodes.Code0x38(); break;
                case 0x39: Opcodes.Code0x39(); break;
                case 0x3A: Opcodes.Code0x3A(); break;
                case 0x3B: Opcodes.Code0x3B(); break;
                case 0x3C: Opcodes.Code0x3C(); break;
                case 0x3D: Opcodes.Code0x3D(); break;
                case 0x3E: Opcodes.Code0x3E(); break;
                case 0x3F: Opcodes.Code0x3F(); break;

                #endregion

                #region 4x

                case 0x40: Opcodes.Code0x40(); break;
                case 0x41: Opcodes.Code0x41(); break;
                case 0x42: Opcodes.Code0x42(); break;
                case 0x43: Opcodes.Code0x43(); break;
                case 0x44: Opcodes.Code0x44(); break;
                case 0x45: Opcodes.Code0x45(); break;
                case 0x46: Opcodes.Code0x46(); break;
                case 0x47: Opcodes.Code0x47(); break;
                case 0x48: Opcodes.Code0x48(); break;
                case 0x49: Opcodes.Code0x49(); break;
                case 0x4A: Opcodes.Code0x4A(); break;
                case 0x4B: Opcodes.Code0x4B(); break;
                case 0x4C: Opcodes.Code0x4C(); break;
                case 0x4D: Opcodes.Code0x4D(); break;
                case 0x4E: Opcodes.Code0x4E(); break;
                case 0x4F: Opcodes.Code0x4F(); break;

                #endregion

                #region 5x

                case 0x50: Opcodes.Code0x50(); break;
                case 0x51: Opcodes.Code0x51(); break;
                case 0x52: Opcodes.Code0x52(); break;
                case 0x53: Opcodes.Code0x53(); break;
                case 0x54: Opcodes.Code0x54(); break;
                case 0x55: Opcodes.Code0x55(); break;
                case 0x56: Opcodes.Code0x56(); break;
                case 0x57: Opcodes.Code0x57(); break;
                case 0x58: Opcodes.Code0x58(); break;
                case 0x59: Opcodes.Code0x59(); break;
                case 0x5A: Opcodes.Code0x5A(); break;
                case 0x5B: Opcodes.Code0x5B(); break;
                case 0x5C: Opcodes.Code0x5C(); break;
                case 0x5D: Opcodes.Code0x5D(); break;
                case 0x5E: Opcodes.Code0x5E(); break;
                case 0x5F: Opcodes.Code0x5F(); break;

                #endregion

                #region 6x

                case 0x60: Opcodes.Code0x60(); break;
                case 0x61: Opcodes.Code0x61(); break;
                case 0x62: Opcodes.Code0x62(); break;
                case 0x63: Opcodes.Code0x63(); break;
                case 0x64: Opcodes.Code0x64(); break;
                case 0x65: Opcodes.Code0x65(); break;
                case 0x66: Opcodes.Code0x66(); break;
                case 0x67: Opcodes.Code0x67(); break;
                case 0x68: Opcodes.Code0x68(); break;
                case 0x69: Opcodes.Code0x69(); break;
                case 0x6A: Opcodes.Code0x6A(); break;
                case 0x6B: Opcodes.Code0x6B(); break;
                case 0x6C: Opcodes.Code0x6C(); break;
                case 0x6D: Opcodes.Code0x6D(); break;
                case 0x6E: Opcodes.Code0x6E(); break;
                case 0x6F: Opcodes.Code0x6F(); break;

                #endregion

                #region 7x

                case 0x70: Opcodes.Code0x70(); break;
                case 0x71: Opcodes.Code0x71(); break;
                case 0x72: Opcodes.Code0x72(); break;
                case 0x73: Opcodes.Code0x73(); break;
                case 0x74: Opcodes.Code0x74(); break;
                case 0x75: Opcodes.Code0x75(); break;
                case 0x76: Opcodes.Code0x76(); break;
                case 0x77: Opcodes.Code0x77(); break;
                case 0x78: Opcodes.Code0x78(); break;
                case 0x79: Opcodes.Code0x79(); break;
                case 0x7A: Opcodes.Code0x7A(); break;
                case 0x7B: Opcodes.Code0x7B(); break;
                case 0x7C: Opcodes.Code0x7C(); break;
                case 0x7D: Opcodes.Code0x7D(); break;
                case 0x7E: Opcodes.Code0x7E(); break;
                case 0x7F: Opcodes.Code0x7F(); break;

                #endregion

                #region 8x

                case 0x80: Opcodes.Code0x80(); break;
                case 0x81: Opcodes.Code0x81(); break;
                case 0x82: Opcodes.Code0x82(); break;
                case 0x83: Opcodes.Code0x83(); break;
                case 0x84: Opcodes.Code0x84(); break;
                case 0x85: Opcodes.Code0x85(); break;
                case 0x86: Opcodes.Code0x86(); break;
                case 0x87: Opcodes.Code0x87(); break;
                case 0x88: Opcodes.Code0x88(); break;
                case 0x89: Opcodes.Code0x89(); break;
                case 0x8A: Opcodes.Code0x8A(); break;
                case 0x8B: Opcodes.Code0x8B(); break;
                case 0x8C: Opcodes.Code0x8C(); break;
                case 0x8D: Opcodes.Code0x8D(); break;
                case 0x8E: Opcodes.Code0x8E(); break;
                case 0x8F: Opcodes.Code0x8F(); break;

                #endregion

                #region 9x

                case 0x90: Opcodes.Code0x90(); break;
                case 0x91: Opcodes.Code0x91(); break;
                case 0x92: Opcodes.Code0x92(); break;
                case 0x93: Opcodes.Code0x93(); break;
                case 0x94: Opcodes.Code0x94(); break;
                case 0x95: Opcodes.Code0x95(); break;
                case 0x96: Opcodes.Code0x96(); break;
                case 0x97: Opcodes.Code0x97(); break;
                case 0x98: Opcodes.Code0x98(); break;
                case 0x99: Opcodes.Code0x99(); break;
                case 0x9A: Opcodes.Code0x9A(); break;
                case 0x9B: Opcodes.Code0x9B(); break;
                case 0x9C: Opcodes.Code0x9C(); break;
                case 0x9D: Opcodes.Code0x9D(); break;
                case 0x9E: Opcodes.Code0x9E(); break;
                case 0x9F: Opcodes.Code0x9F(); break;

                #endregion

                #region Ax

                case 0xA0: Opcodes.Code0xA0(); break;
                case 0xA1: Opcodes.Code0xA1(); break;
                case 0xA2: Opcodes.Code0xA2(); break;
                case 0xA3: Opcodes.Code0xA3(); break;
                case 0xA4: Opcodes.Code0xA4(); break;
                case 0xA5: Opcodes.Code0xA5(); break;
                case 0xA6: Opcodes.Code0xA6(); break;
                case 0xA7: Opcodes.Code0xA7(); break;
                case 0xA8: Opcodes.Code0xA8(); break;
                case 0xA9: Opcodes.Code0xA9(); break;
                case 0xAA: Opcodes.Code0xAA(); break;
                case 0xAB: Opcodes.Code0xAB(); break;
                case 0xAC: Opcodes.Code0xAC(); break;
                case 0xAD: Opcodes.Code0xAD(); break;
                case 0xAE: Opcodes.Code0xAE(); break;
                case 0xAF: Opcodes.Code0xAF(); break;

                #endregion

                #region Bx

                case 0xB0: Opcodes.Code0xB0(); break;
                case 0xB1: Opcodes.Code0xB1(); break;
                case 0xB2: Opcodes.Code0xB2(); break;
                case 0xB3: Opcodes.Code0xB3(); break;
                case 0xB4: Opcodes.Code0xB4(); break;
                case 0xB5: Opcodes.Code0xB5(); break;
                case 0xB6: Opcodes.Code0xB6(); break;
                case 0xB7: Opcodes.Code0xB7(); break;
                case 0xB8: Opcodes.Code0xB8(); break;
                case 0xB9: Opcodes.Code0xB9(); break;
                case 0xBA: Opcodes.Code0xBA(); break;
                case 0xBB: Opcodes.Code0xBB(); break;
                case 0xBC: Opcodes.Code0xBC(); break;
                case 0xBD: Opcodes.Code0xBD(); break;
                case 0xBE: Opcodes.Code0xBE(); break;
                case 0xBF: Opcodes.Code0xBF(); break;

                #endregion

                #region Cx

                case 0xC0: Opcodes.Code0xC0(); break;
                case 0xC1: Opcodes.Code0xC1(); break;
                case 0xC2: Opcodes.Code0xC2(); break;
                case 0xC3: Opcodes.Code0xC3(); break;
                case 0xC4: Opcodes.Code0xC4(); break;
                case 0xC5: Opcodes.Code0xC5(); break;
                case 0xC6: Opcodes.Code0xC6(); break;
                case 0xC7: Opcodes.Code0xC7(); break;
                case 0xC8: Opcodes.Code0xC8(); break;
                case 0xC9: Opcodes.Code0xC9(); break;
                case 0xCA: Opcodes.Code0xCA(); break;
                case 0xCB: Opcodes.Code0xCB(); break;
                case 0xCC: Opcodes.Code0xCC(); break;
                case 0xCD: Opcodes.Code0xCD(); break;
                case 0xCE: Opcodes.Code0xCE(); break;
                case 0xCF: Opcodes.Code0xCF(); break;

                #endregion

                #region Dx

                case 0xD0: Opcodes.Code0xD0(); break;
                case 0xD1: Opcodes.Code0xD1(); break;
                case 0xD2: Opcodes.Code0xD2(); break;
                case 0xD3: Opcodes.Code0xD3(); break;
                case 0xD4: Opcodes.Code0xD4(); break;
                case 0xD5: Opcodes.Code0xD5(); break;
                case 0xD6: Opcodes.Code0xD6(); break;
                case 0xD7: Opcodes.Code0xD7(); break;
                case 0xD8: Opcodes.Code0xD8(); break;
                case 0xD9: Opcodes.Code0xD9(); break;
                case 0xDA: Opcodes.Code0xDA(); break;
                case 0xDB: Opcodes.Code0xDB(); break;
                case 0xDC: Opcodes.Code0xDC(); break;
                case 0xDD: Opcodes.Code0xDD(); break;
                case 0xDE: Opcodes.Code0xDE(); break;
                case 0xDF: Opcodes.Code0xDF(); break;

                #endregion

                #region Ex

                case 0xE0: Opcodes.Code0xE0(); break;
                case 0xE1: Opcodes.Code0xE1(); break;
                case 0xE2: Opcodes.Code0xE2(); break;
                case 0xE3: Opcodes.Code0xE3(); break;
                case 0xE4: Opcodes.Code0xE4(); break;
                case 0xE5: Opcodes.Code0xE5(); break;
                case 0xE6: Opcodes.Code0xE6(); break;
                case 0xE7: Opcodes.Code0xE7(); break;
                case 0xE8: Opcodes.Code0xE8(); break;
                case 0xE9: Opcodes.Code0xE9(); break;
                case 0xEA: Opcodes.Code0xEA(); break;
                case 0xEB: Opcodes.Code0xEB(); break;
                case 0xEC: Opcodes.Code0xEC(); break;
                case 0xED: Opcodes.Code0xED(); break;
                case 0xEE: Opcodes.Code0xEE(); break;
                case 0xEF: Opcodes.Code0xEF(); break;

                #endregion

                #region Fx

                case 0xF0: Opcodes.Code0xF0(); break;
                case 0xF1: Opcodes.Code0xF1(); break;
                case 0xF2: Opcodes.Code0xF2(); break;
                case 0xF3: Opcodes.Code0xF3(); break;
                case 0xF4: Opcodes.Code0xF4(); break;
                case 0xF5: Opcodes.Code0xF5(); break;
                case 0xF6: Opcodes.Code0xF6(); break;
                case 0xF7: Opcodes.Code0xF7(); break;
                case 0xF8: Opcodes.Code0xF8(); break;
                case 0xF9: Opcodes.Code0xF9(); break;
                case 0xFA: Opcodes.Code0xFA(); break;
                case 0xFB: Opcodes.Code0xFB(); break;
                case 0xFC: Opcodes.Code0xFC(); break;
                case 0xFD: Opcodes.Code0xFD(); break;
                case 0xFE: Opcodes.Code0xFE(); break;
                case 0xFF: Opcodes.Code0xFF(); break;

                #endregion

                default: break;
            }

            if (IMEchanged && IMEshouldExecute == 0)
            {
                IME = true;
                IMEchanged = false;
            }

            if (IMEchanged && IMEshouldExecute > 0)
                IMEshouldExecute--;

        }

        public static void HandleInterrupt()
        {
            CPU.IME = false; //Disable interrupts
            OpcodeHelpers.PCtoStack(); //Adds the PC to the stack
            int exec = GetLowestActiveBit();

            if (exec == -1)
                throw new Exception($"Error while processing Interrupt at PC:{pc} OP:{opcode}");

            switch (exec)
            {
                case 0: OpcodeHelpers.CALL(0x0040); break;
                case 1: OpcodeHelpers.CALL(0x0048); break;
                case 2: OpcodeHelpers.CALL(0x0050); break;
                case 3: OpcodeHelpers.CALL(0x0058); break;
                case 4: OpcodeHelpers.CALL(0x0060); break;
            }

            //For some reason this breaks and starts overriding the whole memory through stack pointer
            //(still need to evaluate if this is necessary after the instruction is called)
            //OpcodeHelpers.RETI();

            return;
        }

        public static int GetLowestActiveBit()
        {
            byte bitSum = (byte)(CPU.IFRegister & CPU.IERegister);

            //Bit 0 - VBlank
            if ((bitSum & 0x01) == 0x1)
            {
                IFRegister &= 0xFE;
                return 0;
            }

            //Bit 1 - LCD Stat
            if ((bitSum & 0x02) == 0x2)
            {
                IFRegister &= 0xFD;
                return 1;
            }

            //Bit 2 - Timer Overflow
            if ((bitSum & 0x04) == 0x4)
            {
                IFRegister &= 0xFB;
                return 2;
            }

            //Bit 3 - Serial Transfer
            if ((bitSum & 0x08) == 0x8)
            {
                IFRegister &= 0xF7;
                return 3;
            }

            //Bit 4 - Joypad Input
            if ((bitSum & 0x10) == 0x10)
            {
                IFRegister &= 0xEF;
                return 4;
            }

            return -1;
        }
    }
}
