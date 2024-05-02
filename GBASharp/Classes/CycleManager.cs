using Timer = System.Timers.Timer;

namespace GBASharp
{
    public static class CycleManager
    {
        static Timer cycleTimer = new Timer(16.7);
        public static double DEBUG_PREVIOUS_CYCLES = 0;
        public static double MAX_CYCLES_FRAME = 68470;
        
        public static double[] CYCLES_OPCODE =
        { 1,3,1,1,1,1,2,1,3,1,1,1,1,1,2,1,
          2,3,1,1,1,1,2,1,2,1,1,1,1,1,2,1,
          2,3,1,1,1,1,2,1,2,1,1,1,1,1,2,1,
          2,3,1,1,1,1,2,1,2,1,1,1,1,1,2,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
          1,1,3,3,3,1,2,1,1,1,3,1,3,3,2,1,
          1,1,3,0,3,1,2,1,1,1,3,0,3,0,2,1,
          2,1,2,0,0,1,2,1,2,1,3,0,0,0,2,1,
          2,1,2,1,0,1,2,1,2,1,3,1,0,0,2,1
        };

        public static void SetupTimer() { cycleTimer.Elapsed += CycleTimer_Elapsed; }

        private static void CycleTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) { DEBUG_PREVIOUS_CYCLES = CPU.Cycles; CPU.ResetCycleCounter(); }

        public static void Start() { cycleTimer.Start(); }

        public static void Stop() { cycleTimer.Stop(); }
    }
}
