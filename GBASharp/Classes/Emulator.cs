using GBASharp.Classes;
using Raylib_CsLo;
using System.Numerics;
using System.Timers;

namespace GBASharp
{
    public static class Emulator
    {
        public static CycleManager cpuManager;
        public static CycleManager ppuManager;
        public static bool stopped = false;
        public static int runXTimes = 0;
        public static List<ushort> pc_history = new List<ushort>();
        public static List<ushort> opcode_history = new List<ushort>();
        public static int histMaxIdx = 25;
        public static int maxHist = 256;
        public static Font debugFont;

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

            //Setup test
            if (Globals.DEBUG)
            {
                //Load BoldPixels
                unsafe
                {
                    debugFont = Raylib.LoadFontEx("Fonts/BoldPixels.ttf", Globals.SCALED_FONT_SIZE, null, 250);
                }
                Raylib.SetTextureFilter(debugFont.texture, TextureFilter.TEXTURE_FILTER_POINT);
            }
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
                    runXTimes = 1;

                if (stopped && Raylib.GetMouseWheelMove() > 0)
                    runXTimes = 512;

                if (stopped && Raylib.GetMouseWheelMove() < 0)
                    runXTimes = 5120;

                if (Raylib.IsKeyReleased(KeyboardKey.KEY_SPACE))
                    stopped = !stopped;

                if (!stopped || runXTimes > 0)
                {
                    //The emulator is not a bit slower, but it's still too fast
                    while ((cpuManager.canProcess && !stopped) || (stopped && runXTimes > 0)) //|| ppuManager.canProcess)
                    {
                        if (!CPU.halted)
                        {
                            //Process opcodes for the duration of one frame
                            CPU.Fetch();
                            CPU.Decode();
                            CPU.Execute();

                            if (Globals.DEBUG)
                            {
                                AddPCtoHistory();
                                AddOpcodeToHistory();
                            }
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

                        if (runXTimes > 0)
                            runXTimes--;
                    }
                }

                if (CPU.bootFinished)
                {
                    CPU.bootFinished = false; //So that this does not run every time, we just need it to run once
                    CPU.UnmapBootRom();
                }

                //Update the screen
                Raylib.BeginDrawing();

                DrawDebugWindow();
                
                Screen.Render();

                if (stopped)
                {
                    //TODO: When debugging enabled change the position of this to the middle of the screen, on the blank space
                    Raylib.DrawText($"Stopped!", 10, 35, 20, new Raylib_CsLo.Color(255,0,0,255));
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
                //Fill Background
                Screen.FillScreen(Raylib.PURPLE, true);

                //Left Debug bar for opcode
                Raylib.DrawRectangle(Globals.SCALED_PADDING_OFFSET, Globals.SCALED_PADDING_OFFSET, Globals.DEBUG_RECTANGLE_WIDTH, Globals.DEBUG_RECTANGLE_HEIGHT, Raylib.DARKPURPLE);

                //Right Debug bar for opcode
                Raylib.DrawRectangle(Globals.EMULATOR_OFFSET_X + Globals.EMULATOR_WIDTH + Globals.SCALED_PADDING_OFFSET, Globals.SCALED_PADDING_OFFSET, Globals.DEBUG_RECTANGLE_WIDTH, Globals.DEBUG_RECTANGLE_HEIGHT, Raylib.DARKPURPLE);

                List<string> pcoptexts = new List<string>();

                if (pc_history.Count < maxHist)
                {
                    for (int i = 0; i < histMaxIdx /*pc_history.Count*/; i++)
                    {
                        //Raylib.DrawText($"{pc_history[i]:X2} ({opcode_history[i]:X2})", Globals.SCALED_PADDING_OFFSET + (Globals.SCALED_PADDING_OFFSET / 2), (Globals.SCALED_PADDING_OFFSET * 2) + (i * Globals.SCALED_PADDING_OFFSET), Globals.SCALED_FONT_SIZE, Raylib.BLACK);
                        pcoptexts.Add($"{pc_history[i]:X4} ({opcode_history[i]:X2})");
                    }
                }
                else
                {
                    for (int i = pc_history.Count - histMaxIdx; i < pc_history.Count /*pc_history.Count*/; i++)
                    {
                        //Raylib.DrawText($"{pc_history[i]:X2} ({opcode_history[i]:X2})", Globals.SCALED_PADDING_OFFSET + (Globals.SCALED_PADDING_OFFSET / 2), (Globals.SCALED_PADDING_OFFSET * 2) + ((pc_history.Count - i - 1) * Globals.SCALED_PADDING_OFFSET), Globals.SCALED_FONT_SIZE, Raylib.BLACK);
                        pcoptexts.Add($"{pc_history[i]:X4} ({opcode_history[i]:X2})");
                    }
                }               

                //Draw on the left rectangle
                debugFont.DrawDebugTexts(pcoptexts, true);

                //Draw on the right rectangle
                debugFont.DrawDebugTexts(new string[]
                {
                    $"PC: {CPU.pc:X4}",
                    "",
                    $"SP: {CPU.reg_sp:X4}",
                    "",
                    $"IME: {(CPU.IME ? 1 : 0)}",
                    "",
                    $"Halted: {(CPU.halted ? 1 : 0)}",
                    "",
                    $"Opcode: {CPU.opcode:X2}",
                    "",
                    $"Cycles: {cpuManager.DEBUG_PREVIOUS_CYCLES}",
                    "",
                    $"AF: {CPU.AF_Register:X4}",
                    "",
                    $"BC: {CPU.BC_Register:X4}",
                    "",
                    $"DE: {CPU.DE_Register:X4}",
                    "",
                    $"HL: {CPU.HL_Register:X4}"
                }, false);
            }
        }

        private static void AddPCtoHistory()
        {
             //If list is still not filled
            //if (pc_history.Count < histMaxIdx)
            //    pc_history.Add(CPU.pc);
            //else
            //{
            //    pc_history.Add(CPU.pc); //Appends to end
            //    pc_history.RemoveAt(0); //Removes first in the list
            //}

            //If list is still not filled
            if (pc_history.Count < maxHist)
                pc_history.Add(CPU.pc);
            else
            {
                pc_history.Add(CPU.pc); //Appends to end
                pc_history.RemoveAt(0); //Removes first in the list
            }
        }

        private static void AddOpcodeToHistory()
        {
            //If list is still not filled
            if (opcode_history.Count < maxHist)
                opcode_history.Add(CPU.opcode);
            else
            {
                opcode_history.Add(CPU.opcode); //Appends to end
                opcode_history.RemoveAt(0); //Removes first in the list
            }
        }
    }
}
