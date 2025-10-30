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

        static bool LCDC_bit0 = ((reg_LCDC & 0x1) == 0x1);
        static bool LCDC_bit1 = ((reg_LCDC >> 1 & 0x1) == 0x1);
        static bool LCDC_bit2 = ((reg_LCDC >> 2 & 0x1) == 0x1);
        static bool LCDC_bit3 = ((reg_LCDC >> 3 & 0x1) == 0x1);
        static bool LCDC_bit4 = ((reg_LCDC >> 4 & 0x1) == 0x1);
        static bool LCDC_bit5 = ((reg_LCDC >> 5 & 0x1) == 0x1);
        static bool LCDC_bit6 = ((reg_LCDC >> 6 & 0x1) == 0x1);
        static bool LCDC_bit7 = ((reg_LCDC >> 7 & 0x1) == 0x1);
        static bool LCDC_bit8 = ((reg_LCDC >> 8 & 0x1) == 0x1);

        static byte[] bg_framebuffer = new byte[256 * 256];
        static byte[] win_framebuffer = new byte[256 * 256];
        //static byte[] sprite_framebuffer = new byte[256 * 256];

        static double scanline_cycle = 0;
        static int scanline_pixel = 0;
        static double mode3_cycles = 0;
        static bool endMode3 = false;
        static bool startMode3 = true;
        public static int scanline = 0;
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

        private static void ProcessDot()
        {
            scanline_cycle++; // += cpuCycles;

            //Reached the end of the scanline (after HBlank)
            if (scanline_cycle >= 456)
            {
                endMode3 = false;
                startMode3 = true;
                scanline_cycle = 0;
                scanline++;

                if (scanline >= scanlineVBlank) //scanline_cycle? Doesn't make sense
                    scanline = 0;

                //Still need to understand where to put this (the boot will only advance if this is correct)
                CPU.memory[0xFF44] = (byte)scanline; //Write the scanline to the register

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
                    if (startMode3)
                    {
                        mode3_cycles = 0;
                        scanline_pixel = -1;
                        startMode3 = false;
                    }

                    mode3_cycles++;
                    scanline_pixel++;

                    //Processed all the pixels for the current scanline
                    if (scanline_pixel >= 160)
                    {
                        endMode3 = true;
                        return;
                    }

                    //Need to add a endMode3 = true (if mode3 already processed all pixels before 289 cycles passed)
                    Mode3();
                }
            }
        }

        public static void Process(double cpuCycles)
        {
            //Since the PPU runs at 4 times the speed of the CPU we need to run the PPU 4 times every CPU cycle
            for (int dotCycle = 0; dotCycle < cpuCycles * 4; dotCycle++)
                ProcessDot();
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

        public static void Mode3()
        {
            //TODO: Check if LCDC has background enabled

            //TODO: If LCDC bit 4 is 1 then we use:
            //$8000-$87ff (block 0) and $8800-$8fff (block 1)
            //Otherwise if LCDC bit 4 is 0 then we use
            //$8800-$8fff (block 0) and $9000-$97ff (block 1)

            //Compute global pixel in terms of the whole 256x256 pixel background
            int bgY = (scanline + (int)reg_SCY) % 256;
            int bgX = (scanline_pixel + (int)reg_SCX) % 256;

            int tileCol = bgX / 8; //Gets the index of the current 8x8 grid horizontal block
            int tileRow = bgY / 8; //Gets the index of the current 8x8 grid vertical block

            //Based on LCDC 3rd bit we read from different tile maps
            int tilemap_start = 0x0;
            int tilemap_end = 0x0;
            if (LCDC_bit3) //bit 3 is 1
            {
                //If lcdc bit 3 is 1 we can read the bg_tilemap from address 0x9800 to 0x9bff
                tilemap_start = 0x9800;
                tilemap_end = 0x9bff;
            }
            else
            {
                //Otherwise we read from 0x9c00 to 0x9fff
                tilemap_start = 0x9c00;
                tilemap_end = 0x9fff;
            }

            //Compute the ID of the tile to be read
            int tilemapIdx = tilemap_start + (tileRow * 32) + tileCol;
            int tileIdx = CPU.memory[tilemapIdx];

            //Based on LCDC bit 4 we either read from a signed value 0 to 255 or unsigned -128 to 127
            int startTileAddr = 0x0;
            if (LCDC_bit4)
            {
                //Unsigned from 0 to 255 tileId
                startTileAddr = 0x8000;
            }
            else
            {
                //Signed from -128 to 127 tileId
                startTileAddr = 0x9000;
            }

            int tileAddr = startTileAddr + tileIdx * 16;

            //Extract the information of the tile
            int tileRowY = bgY % 8;
            int rowAddr = tileAddr + tileRowY * 2;
            int lowByte = CPU.memory[rowAddr];
            int highByte = CPU.memory[rowAddr+1];

            //Compute the color of the pixel (In non color BG the pixel is either 00 - black, 01 - light grey, 10 - dark grey or 11 - white, this can be any set of colors)
            int bitIndex = 7 - (bgX % 8);
            int low = (lowByte >> bitIndex) & 1;
            int high = (highByte >> bitIndex) & 1;
            int colorID = (high << 1) | low;  // 0–3

            byte color = 0x0;

            switch (colorID)
            {
                case 0: color = 0x0; break;
                case 1: color = 0x1; break;
                case 2: color = 0x2; break;
                case 3: color = 0x3; break;
            }

            //Step 6 - Needs to be implemented, but can be skipped until bg scrolling is needed

            Screen.SetPixel(scanline, scanline_pixel, color);
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
