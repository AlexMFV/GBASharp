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
            PPU.InitRegisters();
            CycleManager.SetupTimer();
            CycleManager.Start();
        }

        public static void MainLoop()
        {
            //THIS MAIN LOOP SHOULD RUN ON A SEPARATE THREAD AT 4.1MHz
            //So, based on simple tests the CPU can handle 200 million plus operations per second
            //If we want to run the CPU at 4.1MHz, we need to run 4,100,000 operations per second
            //Since there is not timer to allow a function to run every x microseconds we can process everything necessary
            //This means that since the screen is updating 60 times per second, and in a millisecond we can process 4100 operations
            //This translates to around 68 470 cycles per frame
            //With this information we can make a thread run the calculations separately and every 16.7 milliseconds we can aim to achieve the 68k operations
            //We do this by, every opcode that is processed we increase a operation counter, based on the number of cycles the opcode takes
            //If the timer has not reached 16.7 milliseconds we stop the processing of opcodes
            //Once the timer elapses we reset the counter, so that the opcode processing can continue
            //PS: The screen will continue to update at 60 fps
            //Another Note: We can have an array containing the number of cycles each opcode takes, so that we can easily access it after the Opcode Switch

            while (CPU.CanProcess && !Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK);
                Raylib.DrawFPS(10, 10); //Draws the FPS counter
                Raylib.DrawText("Cycles per Frame: " + CycleManager.DEBUG_PREVIOUS_CYCLES, 10, 40, 20, new Color(255, 0, 0, 255)); //Draws the FPS counter

                for (int i = 0; i < 20; i++)
                {
                    for(int j = 0; j < 20; j++)
                    {
                        Raylib.DrawPixel(i, j, new Color(255, 0, 0, 255));
                    }
                }

                CPU.Fetch();
                CPU.Decode();
                CPU.Execute();

                Raylib.EndDrawing();
            }

        }
    }
}
