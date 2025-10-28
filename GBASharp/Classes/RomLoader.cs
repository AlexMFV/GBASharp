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
            else
            {
                throw new Exception("No ROM found in directory");
            }
        }

        public static void LoadBootRom(string filename)
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, "ROMs", filename);
            if (File.Exists(fullPath))
            {
                CPU.bootROM = File.ReadAllBytes(fullPath);
            }
            else
            {
                throw new Exception("No boot ROM found in directory");
            }
        }

        public static void LoadRom(string name, string path)
        {
            throw new NotImplementedException();
        }
    }
}
