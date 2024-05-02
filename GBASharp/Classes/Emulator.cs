using Raylib_CsLo;

namespace GBASharp
{
    public static class Emulator
    {
        public static void Setup()
        {
            RomLoader.LoadBootRom("dmg_boot.bin");
            RomLoader.LoadRom("tetris.gb");
            CPU.BootSequence();
        }

        public static void MainLoop()
        {
            CPU.Fetch();
            CPU.Decode();
            CPU.Execute();
        }
    }
}
