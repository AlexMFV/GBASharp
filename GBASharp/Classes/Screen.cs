﻿namespace GBASharp
{
    public static class Screen
    {
        public static byte[] framebuffer = new byte[Globals.SCREEN_WIDTH * Globals.SCREEN_HEIGHT * 3];          //Used for Background screen
        public static byte[] framebufferAlpha = new byte[Globals.SCREEN_WIDTH * Globals.SCREEN_HEIGHT * 4];    //Used for alpha screens (Window and Sprite screen)

        private static int currentScanline = 0;
        private static int maxScanlines = 156; //Total number of scanlines
        private static int vblankIdx = 144; //From which scanline does the vBlank start
        private static int hblankIdx = 160; //From which pixel does the hBlank start

        public static void InitScreen()
        {
            for (int i = 0; i < framebuffer.Length; i++)
                framebuffer[i] = 0x0;

            for (int i = 0; i < framebufferAlpha.Length; i++)
                framebufferAlpha[i] = 0x0;
        }

        public static void FillScreen(System.Drawing.Color color, bool background = true)
        {
            for (int y = 0; y < Globals.SCREEN_HEIGHT; y++)
            {
                for (int x = 0; x < Globals.SCREEN_WIDTH; x++)
                {
                    if (background)
                    {
                        int idxRef = (y * Globals.SCREEN_HEIGHT + x) * 3;   //Calculate the pixel
                        framebuffer[idxRef] = color.R;                      //Fill Red
                        framebuffer[idxRef + 1] = color.G;                  //Fill green
                        framebuffer[idxRef + 2] = color.B;                  //Fill Blue
                    }
                    else
                    {
                        int idxRef = (y * Globals.SCREEN_HEIGHT + x) * 4;   //Calculate the pixel
                        framebufferAlpha[idxRef] = color.R;                 //Fill Red
                        framebufferAlpha[idxRef + 1] = color.G;             //Fill green
                        framebufferAlpha[idxRef + 2] = color.B;             //Fill Blue
                        framebufferAlpha[idxRef + 3] = color.A;             //Fill Alpha
                    }
                }
            }
        }

        public static void ProcessScanline()
        {

        }
    }
}
