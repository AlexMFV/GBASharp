using GBASharp;
using Raylib_CsLo;
using System.Timers;

namespace GBASharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitializeEmulator();
        }

        static void InitializeEmulator()
        {
            //Initialize the window and main settings
            Raylib.InitWindow(Globals.REAL_SCREEN_WIDTH, Globals.REAL_SCREEN_HEIGHT, "GBASharp");
            Raylib.SetTargetFPS(60);
            Emulator.Setup();
            
            // Main game loop
            Emulator.MainLoop();

            Raylib.CloseWindow();
        }
    }
}