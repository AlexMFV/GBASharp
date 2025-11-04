using Raylib_CsLo;
using System.Drawing;

namespace GBASharp
{
    public static class Screen
    {
        public static byte[] framebuffer = new byte[Globals.SCREEN_WIDTH * Globals.SCREEN_HEIGHT * 3];          //Used for Background screen
        public static byte[] framebufferAlpha = new byte[Globals.SCREEN_WIDTH * Globals.SCREEN_HEIGHT * 4];    //Used for alpha screens (Window and Sprite screen)
        public static byte[] pixelBuffer = new byte[Globals.SCREEN_WIDTH * Globals.SCREEN_HEIGHT];

        public static int pixelScaleX = Globals.EMULATOR_WIDTH / Globals.SCREEN_WIDTH;
        public static int pixelScaleY = Globals.EMULATOR_HEIGHT / Globals.SCREEN_HEIGHT;

        private static int currentScanline = 0;
        private static int maxScanlines = 156; //Total number of scanlines
        private static int vblankIdx = 144; //From which scanline does the vBlank start
        private static int hblankIdx = 160; //From which pixel does the hBlank start

        public static void InitScreen()
        {
            for(int i = 0; i < pixelBuffer.Length; i++)
                pixelBuffer[i] = 0x0;

            for (int i = 0; i < framebuffer.Length; i++)
                framebuffer[i] = 0x0;

            for (int i = 0; i < framebufferAlpha.Length; i++)
                framebufferAlpha[i] = 0x0;
        }

        public static void SetPixel(int scanline, int col, byte value)
        {
            int pixel = (scanline * Globals.SCREEN_WIDTH) + col;
            //00 - transparent
            //01 - color 1
            //10 - color 2
            //11 - color 3
            pixelBuffer[pixel] = value;
        }

        public static void FillScreen(Raylib_CsLo.Color color, bool background = true)
        {
            Raylib.ClearBackground(color);

            //for (int y = 0; y < Globals.SCREEN_HEIGHT; y++)
            //{
            //    for (int x = 0; x < Globals.SCREEN_WIDTH; x++)
            //    {
            //        if (background)
            //        {
            //            int idxRef = (y * Globals.SCREEN_HEIGHT + x) * 3;   //Calculate the pixel
            //            framebuffer[idxRef] = color.R;                      //Fill Red
            //            framebuffer[idxRef + 1] = color.G;                  //Fill green
            //            framebuffer[idxRef + 2] = color.B;                  //Fill Blue
            //        }
            //        else
            //        {
            //            int idxRef = (y * Globals.SCREEN_HEIGHT + x) * 4;   //Calculate the pixel
            //            framebufferAlpha[idxRef] = color.R;                 //Fill Red
            //            framebufferAlpha[idxRef + 1] = color.G;             //Fill green
            //            framebufferAlpha[idxRef + 2] = color.B;             //Fill Blue
            //            framebufferAlpha[idxRef + 3] = color.A;             //Fill Alpha
            //        }
            //    }
            //}
        }

        public static void Render()
        {
            for (int pix = 0; pix < pixelBuffer.Length; pix++)
            {
                for (int scaledX = 0; scaledX < pixelScaleX; scaledX++)
                {
                    for (int scaledY = 0; scaledY < pixelScaleY; scaledY++)
                    {
                        int pixelX = (pix % Globals.SCREEN_WIDTH) * pixelScaleX + scaledX;
                        int pixelY = (pix / Globals.SCREEN_WIDTH) * pixelScaleY + scaledY;

                        //00 - transparent
                        //01 - color 1
                        //10 - color 2
                        //11 - color 3
                        switch (pixelBuffer[pix])
                        {
                            case 0x0: Raylib.DrawPixel(pixelX + Globals.EMULATOR_OFFSET_X, pixelY + Globals.EMULATOR_OFFSET_Y, new Raylib_CsLo.Color(155, 188, 15, 255)); break;
                            case 0x1: Raylib.DrawPixel(pixelX + Globals.EMULATOR_OFFSET_X, pixelY + Globals.EMULATOR_OFFSET_Y, new Raylib_CsLo.Color(139, 172, 15, 255)); break;
                            case 0x2: Raylib.DrawPixel(pixelX + Globals.EMULATOR_OFFSET_X, pixelY + Globals.EMULATOR_OFFSET_Y, new Raylib_CsLo.Color(48, 98, 48, 255)); break;
                            case 0x3: Raylib.DrawPixel(pixelX + Globals.EMULATOR_OFFSET_X, pixelY + Globals.EMULATOR_OFFSET_Y, new Raylib_CsLo.Color(15, 56, 15, 255)); break;
                        }
                    }
                }
            }
        }

        public static void ProcessScanline(int scanline)
        {
            //for(int i = 0; i < 160; i++)
            //    SetPixel(scanline, i, );
        }
    }
}
