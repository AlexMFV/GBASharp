using Timer = System.Timers.Timer;

namespace GBASharp
{
    public class CycleManager
    {
        Timer cycleTimer;
        public double DEBUG_PREVIOUS_CYCLES;
        public double MAX_CYCLES_FRAME; //Previous cycle 68470, new 70224
        public double cycle;
        Action func;
        public bool canProcess;

        public CycleManager(Action executeFunction, int targetFPS = 60, int MAX_CYCLES = 70224)
        {
            canProcess = true;
            cycle = 0;
            DEBUG_PREVIOUS_CYCLES = 0;
            MAX_CYCLES_FRAME = MAX_CYCLES;
            func = executeFunction;
            double msPerFrame = 1000.0f / targetFPS;
            cycleTimer = new Timer( msPerFrame);
        }

        public static double[] CYCLES_OPCODE =
        {
          1,3,1,1,1,1,2,1,3,1,1,1,1,1,2,1,
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

        public double CYCLES_SCANLINE = 456; //There are 154 scanlines if we multiply it by the number of cycles we get 70224

        public void SetupTimer() { cycleTimer.Elapsed += CycleTimer_Elapsed; }

        public void UpdateCycles(double cycles)
        {
            this.cycle += cycles;
            //Maybe try to find a way to make this more efficient, like a trigger (?)
            if (canProcess && this.cycle >= MAX_CYCLES_FRAME)
                canProcess = false; //Stops processing until the next frame
        }

        public void UpdateCycles(CycleManager toSync)
        {
            this.cycle = toSync.cycle;
            UpdateCycles(0); //Refresh the canProcess flag
        }

        private void CycleTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            func.Invoke();
        }

        public void Start()
        {
            SetupTimer();
            cycleTimer.Start();
        }

        public void Stop() { cycleTimer.Stop(); }
    }
}
