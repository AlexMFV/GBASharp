namespace GBASharp
{
    public static class RomLoader
    {
        public static void LoadRom(string filename)
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, "ROMs", filename);
            if (File.Exists(fullPath))
            {
                Cartridge.ROM = File.ReadAllBytes(fullPath);
            }
        }

        public static void LoadRom(string name, string path)
        {
            throw new NotImplementedException();
        }
    }
}
