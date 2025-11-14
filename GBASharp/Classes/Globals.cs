using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Globals
    {
        public static bool DEBUG = true;
        public static bool SECOND_MONITOR = true;

        public static int SCREEN_WIDTH = 160;
        public static int SCREEN_HEIGHT = 144;
        public static int SCREEN_SCALE = 2;

        public static int SCREEN_DEBUG_WIDTH = SCREEN_WIDTH * 3;
        public static int SCREEN_DEBUG_HEIGHT = SCREEN_HEIGHT * 2;

        public static int EMULATOR_WIDTH = SCREEN_WIDTH * SCREEN_SCALE;
        public static int EMULATOR_HEIGHT = SCREEN_HEIGHT * SCREEN_SCALE;

        public static int REAL_SCREEN_WIDTH = (DEBUG ? SCREEN_DEBUG_WIDTH : SCREEN_WIDTH) * SCREEN_SCALE;
        public static int REAL_SCREEN_HEIGHT = (DEBUG ? SCREEN_DEBUG_HEIGHT : SCREEN_HEIGHT) * SCREEN_SCALE;

        public static int EMULATOR_OFFSET_X = Globals.DEBUG ? (Globals.REAL_SCREEN_WIDTH / 2) - (Globals.EMULATOR_WIDTH / 2) : 0;
        public static int EMULATOR_OFFSET_Y = Globals.DEBUG ? (Globals.REAL_SCREEN_HEIGHT / 2) - (Globals.EMULATOR_HEIGHT / 2) : 0;

        public static int PADDING_OFFSET = 10; //Padding size
        public static int SCALED_PADDING_OFFSET = (PADDING_OFFSET * Globals.SCREEN_SCALE); //Compute debug window padding size
        public static int DEBUG_RECTANGLE_WIDTH = Globals.EMULATOR_OFFSET_X - (SCALED_PADDING_OFFSET * 2); //Compute debug window size X
        public static int DEBUG_RECTANGLE_HEIGHT = Globals.REAL_SCREEN_HEIGHT - (SCALED_PADDING_OFFSET * 2); //Compute debug window size Y

        public static int FONT_SIZE = 16;
        public static int SCALED_FONT_SIZE = FONT_SIZE * SCREEN_SCALE;
    }
}
