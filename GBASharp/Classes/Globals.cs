using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Globals
    {
        public static bool DEBUG = false;

        public static int SCREEN_WIDTH = 160;
        public static int SCREEN_HEIGHT = 144;
        public static int SCREEN_SCALE = 2;

        public static int SCREEN_DEBUG_WIDTH = SCREEN_WIDTH * 2;
        public static int SCREEN_DEBUG_HEIGHT = SCREEN_HEIGHT;

        public static int REAL_SCREEN_WIDTH = (DEBUG ? SCREEN_DEBUG_WIDTH : SCREEN_WIDTH) * SCREEN_SCALE;
        public static int REAL_SCREEN_HEIGHT = (DEBUG ? SCREEN_DEBUG_HEIGHT : SCREEN_HEIGHT) * SCREEN_SCALE;
    }
}
