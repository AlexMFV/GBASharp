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
    }
}
