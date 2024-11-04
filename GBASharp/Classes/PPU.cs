using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class PPU
    {
        const ushort add_LCDC = 0xFF40;
        const ushort add_STAT = 0xFF41;
        const ushort add_SCY = 0xFF42;
        const ushort add_SCX = 0xFF43;
        const ushort add_LY = 0xFF44;
        const ushort add_LYC = 0xFF45;
        const ushort add_BGP = 0xFF47;
        const ushort add_OBP0 = 0xFF48;
        const ushort add_OBP1 = 0xFF49;

        const ushort oam_start = 0xfe00;
        const ushort oam_end = 0xfe9f;

        static byte reg_LCDC; //0xFF40
        static byte reg_STAT; //0xFF41
        static byte reg_SCY; //0xFF42
        static byte reg_SCX; //0xFF43
        static byte reg_LY; //0xFF44
        static byte reg_LYC; //0xFF45
        static byte reg_BGP; //0xFF47
        static byte reg_OBP0; //0xFF48
        static byte reg_OBP1; //0xFF49

        static byte[] bg_framebuffer = new byte[256 * 256];
        static byte[] win_framebuffer = new byte[256 * 256];
        //static byte[] sprite_framebuffer = new byte[256 * 256];

        static double scanline_cycle = 0;
        static double scanline_pixel = 0;
        static double mode3_cycles = 0;
        static bool endMode3 = false;
        static bool startMode3 = true;
        static int scanline = 0;
        static int scanlineVBlank = 144;
        static int max_scanlines = 154;

        static List<Sprite> sprite_buffer = new List<Sprite>(); //Only a max num of 10 sprites can be loaded

        public static void ResetCycleCounter() { Emulator.ppuManager.cycle = 0; Emulator.ppuManager.canProcess = true; }

        public static void InitRegisters()
        {
            reg_LCDC = CPU.memory[add_LCDC];
            reg_STAT = CPU.memory[add_STAT];
            reg_SCX = CPU.memory[add_SCX];
            reg_SCY = CPU.memory[add_SCY];
            reg_LY = CPU.memory[add_LY];
            reg_LYC = CPU.memory[add_LYC];
            reg_BGP = CPU.memory[add_BGP];
            reg_OBP0 = CPU.memory[add_OBP0];
            reg_OBP1 = CPU.memory[add_OBP1];
        }

        public static void Process(double cpuCycles)
        {
            scanline_cycle += cpuCycles;

            //Reached the end of the scanline (after HBlank)
            if (scanline_cycle >= 456)
            {
                scanline_cycle = 0;
                scanline++;

                if (scanline_cycle > max_scanlines)
                    scanline = 0;

                return;
            }

            //VBlank Period, does nothing so we don't need this we can just skip
            //if (scanline > 144 && scanline <= max_scanlines)
            //    Mode1();

            if (scanline_cycle <= 80)
                Mode2();
            else
            {
                if (mode3_cycles <= 289 && !endMode3)
                {
                    //Runs only once it enters mode3, to reset all the counters
                    if(startMode3)
                    {
                        mode3_cycles = 0;
                        scanlinePixel = 0;
                        startMode3 = false;
                    }

                    mode3_cycles += cpuCycles;
                    //Need to add a endMode3 = true (if mode3 already processed all pixels before 289 cycles passed)
                    Mode3(cpuCycles);
                }
            }
        }

        public static void Mode2()
        {
            sprite_buffer.Clear(); //Buffer is per scanline

            //Goes through OAM
            for(ushort i = oam_start; i <= oam_end; i+=0x4)
            {
                //Checks the YPos of each sprite
                //If y pos is the same level as scanline, we save the current sprite in the buffer (if buffer is full we ignore)
                byte yPos = (byte)(CPU.memory[i] - 0x10);
                byte xPos = (byte)CPU.memory[i+0x1];
                byte tileIdx = (byte)CPU.memory[i+0x2];
                byte attrs = (byte)CPU.memory[i+0x3];

                byte sprt_sz = (byte)(reg_LCDC & 0x100); //0 = 8x8 | 1 = 8x16
                int size = sprt_sz == 0x0 ? 0x8 : 0x10; //8 or 16 pixels

                if(scanline >= yPos && scanline <= yPos + size)
                {
                    //Is present in current scanline
                    if (sprite_buffer.Count < 10)
                        sprite_buffer.Add(new Sprite(yPos, xPos, tileIdx, attrs));
                }
            }
        }

        public static void Mode3(double availableCycles)
        {
            //TODO: Check if LCDC has background enabled

            //TODO: If LCDC bit 4 is 1 then we use:
            //$8000-$87ff (block 0) and $8800-$8fff (block 1)
            //Otherwise if LCDC bit 4 is 0 then we use
            //$8800-$8fff (block 0) and $9000-$97ff (block 1)

            int pixelY = scanline + (int)reg_SCY;
            int pixelX = scanlinePixel + (int)reg_SCX;
        }

        public static void Mode0() { }

        public static void Mode1() { }

        public class Sprite
        {
            public byte yPos;
            public byte xPos;
            public byte tileIndex;
            public byte attributes;

            public Sprite(byte yPos, byte xPos, byte tileIndex, byte attributes)
            {
                this.yPos = yPos;
                this.xPos = xPos;
                this.tileIndex = tileIndex;
                this.attributes = attributes;
            }
        }
    }
}
