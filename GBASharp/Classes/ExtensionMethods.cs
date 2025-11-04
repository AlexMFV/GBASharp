using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp.Classes
{
    public static class RaylibTextExtensions
    {
        public static void DrawDebugTexts(this Font font, string[] texts, bool isLeftSide, Color color = new Color(), float fontSize = 0)
        {
            Raylib.SetTextureFilter(font.texture, TextureFilter.TEXTURE_FILTER_POINT);

            if (fontSize == 0)
                fontSize = Globals.SCALED_FONT_SIZE;

            //Default color
            if (color.Equals(new Color()))
                color = Raylib.BLACK;

            if(texts == null || texts.Length == 0)
                return;

            int x = isLeftSide ? (Globals.SCALED_PADDING_OFFSET * 2) : Globals.EMULATOR_OFFSET_X + Globals.EMULATOR_WIDTH + (Globals.SCALED_PADDING_OFFSET * 2);
            int y = Globals.SCALED_PADDING_OFFSET;

            // Uses your own global default font
            for (int i = 0; i < texts.Count(); i++)
                Raylib.DrawTextEx(font, texts[i], new Vector2(x, (y+y/2)+(y * i)) , fontSize, 0, color);
        }

        public static void DrawDebugTexts(this Font font, List<string> texts, bool isLeftSide, Color color = new Color(), float fontSize = 0)
        {
            DrawDebugTexts(font, texts.ToArray(), isLeftSide, color, fontSize);
        }
    }
}
