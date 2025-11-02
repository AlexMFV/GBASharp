using Raylib_CsLo;
using System.Timers;

namespace GBASharp
{
    public static class Emulator
    {
        public static CycleManager cpuManager;
        public static CycleManager ppuManager;
        public static bool stopped = false;
        public static bool runOnce = false;

        public static void Setup()
        {
            RomLoader.LoadBootRom("dmg_boot.bin");
            RomLoader.LoadRom("drmario.gb");
            CPU.BootSequence();
            PPU.InitRegisters();
            cpuManager = new CycleManager(CPU.ResetCycleCounter);
            ppuManager = new CycleManager(PPU.ResetCycleCounter);

            cpuManager.Start();
            ppuManager.Start();
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

            Screen.InitScreen();
            Random rand = new Random();
            double totalCycles = 70224;
            double currCycle = 0;
            double cpuCycles = 0;

            while (!Raylib.WindowShouldClose())
            {
                currCycle = 0;

                if (stopped && Raylib.IsKeyReleased(KeyboardKey.KEY_N))
                    runOnce = true;

                if (Raylib.IsKeyReleased(KeyboardKey.KEY_SPACE))
                    stopped = !stopped;

                if (!stopped || runOnce)
                {
                    //The emulator is not a bit slower, but it's still too fast
                    while (cpuManager.canProcess) //|| ppuManager.canProcess)
                    {
                        if (!CPU.halted)
                        {
                            //Process opcodes for the duration of one frame
                            CPU.Fetch();
                            CPU.Decode();
                            CPU.Execute();
                        }
                        else
                        {
                            if((CPU.IFRegister & CPU.IERegister) != 0) //If any of the interrupts are triggered
                            {
                                CPU.halted = false; //wake up CPU
                                if (CPU.IME)
                                    HandleInterrupt();
                            }
                        }

                        cpuCycles = CycleManager.CYCLES_OPCODE[CPU.opcode]; //Cycles used for the execution of the current instruction
                                                                            //currCycle += cpuCycles; //Total number of cycles

                        cpuManager.UpdateCycles(cpuCycles);
                        //ppuManager.UpdateCycles(cpuManager);

                        PPU.Process(cpuCycles);

                        if (runOnce)
                            runOnce = false;
                    }
                }

                if (CPU.bootFinished)
                {
                    CPU.bootFinished = false; //So that this does not run every time, we just need it to run once
                    CPU.UnmapBootRom();
                }

                //Update the screen
                Raylib.BeginDrawing();
                //DrawDebugWindow();
                //Raylib.ClearBackground(Raylib.BLACK);
                Screen.Render();
                if (stopped)
                {
                    Raylib.DrawText($"Stopped!", 10, 35, 20, new Raylib_CsLo.Color(255,0,0,255));
                    Raylib.DrawText($"RunOnce: {runOnce}", 10, 60, 20, new Raylib_CsLo.Color(255, 0, 0, 255));
                    Raylib.DrawText($"OPCODE: Ox{CPU.opcode:X2}", 10, 85, 20, new Raylib_CsLo.Color(255, 0, 0, 255));
                    Raylib.DrawText($"AF: {CPU.AF_Register:X4} BC: {CPU.BC_Register:X4} DE: {CPU.DE_Register:X4} HL: {CPU.HL_Register:X4}", 10, 110, 20, new Raylib_CsLo.Color(255, 0, 0, 255));
                }
                Raylib.DrawFPS(10, 10); //Draws the FPS counter
                //Raylib.DrawText("Cycles per Frame: " + cpuManager.DEBUG_PREVIOUS_CYCLES, 10, 40, 20, new Color(255, 0, 0, 255)); //Draws the FPS counter
                //Raylib.DrawText("Can Process: " + cpuManager.canProcess, 10, 70, 20, new Color(255, 0, 0, 255)); //Draws the FPS counter

                //Screen.ProcessScanline(PPU.scanline);
                Raylib.EndDrawing();
            }
        }

        private static void HandleInterrupt()
        {
            //For now do nothing, need to implement interrupt handling
            //Also the problem with Dr Mario is that MBC is not implemented (memory bank controller)
            return;
        }

        private static void DrawDebugWindow()
        {
            if (Globals.DEBUG)
            {
                Raylib.DrawRectangle(Globals.REAL_SCREEN_WIDTH / 2, 0, Globals.REAL_SCREEN_WIDTH / 2, Globals.REAL_SCREEN_HEIGHT, new Color(0,0,0,1));
            }
        }
    }
}
