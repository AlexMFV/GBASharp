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
            Raylib.InitWindow(600, 600, "GBASharp");
            Raylib.SetTargetFPS(60);
            Emulator.Setup();
            // Main game loop
            while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK);
                Raylib.DrawFPS(10, 10); //Draws the FPS counter
                Raylib.DrawText("Cycles per Frame: " + CycleManager.DEBUG_PREVIOUS_CYCLES, 10, 40, 20, new Color(255, 0, 0, 255)); //Draws the FPS counter
                Emulator.MainLoop();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}