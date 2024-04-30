using Newtonsoft.Json.Linq;
using System.Security.Principal;

namespace OpcodeTests
{
    [TestClass]
    public class RunOpcodeTesting
    {
        public void RunAll()
        {

        }

        public void TestOpcode(byte value, List<OpcodeTester> tests)
        {
            foreach (OpcodeTester test in tests)
            {
                CPU.SetCPUTesting(test.i_a, test.i_b, test.i_c, test.i_d, test.i_e, test.i_f, test.i_h, test.i_l, test.i_pc, test.i_sp, test.i_ram);
                CPU.ExecuteOpcode(value);
                bool result = CPU.CheckCPUTesting(test.f_a, test.f_b, test.f_c, test.f_d, test.f_e, test.f_f, test.f_h, test.f_l, test.f_pc, test.f_sp, test.f_ram);

                Assert.IsTrue(result, $"Failed Case @{test.name}");
            }
        }

        public List<OpcodeTester> LoadTests(string testNumber)
        {
            string fullPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "GBASharp\\GameboyCPUTests\\v2", testNumber + ".json");
            List<OpcodeTester> col = new List<OpcodeTester>();

            if (File.Exists(fullPath))
            {
                JArray arr = JArray.Parse(File.ReadAllText(fullPath));
                foreach (JObject obj in arr)
                {
                    OpcodeTester op = new OpcodeTester();
                    JObject initialVals = (JObject)obj.Property("initial").Value;
                    JObject finalVals = (JObject)obj.Property("final").Value;

                    op.name = obj.Property("name").Value.ToString();
                    op.i_a = (byte)initialVals.Property("a").Value;
                    op.i_b = (byte)initialVals.Property("b").Value;
                    op.i_c = (byte)initialVals.Property("c").Value;
                    op.i_d = (byte)initialVals.Property("d").Value;
                    op.i_e = (byte)initialVals.Property("e").Value;
                    op.i_f = (byte)initialVals.Property("f").Value;
                    op.i_h = (byte)initialVals.Property("h").Value;
                    op.i_l = (byte)initialVals.Property("l").Value;
                    op.i_pc = (ushort)initialVals.Property("pc").Value;
                    op.i_sp = (ushort)initialVals.Property("sp").Value;

                    op.i_ram = new List<List<ushort>>();
                    JArray initialArray = (JArray)initialVals.Property("ram").Value;

                    foreach(JArray arrObj in initialArray)
                    {
                        List<ushort> list = arrObj.ToObject<List<ushort>>();
                        op.i_ram.Add(list);
                    }

                    op.f_a = (byte)finalVals.Property("a").Value;
                    op.f_b = (byte)finalVals.Property("b").Value;
                    op.f_c = (byte)finalVals.Property("c").Value;
                    op.f_d = (byte)finalVals.Property("d").Value;
                    op.f_e = (byte)finalVals.Property("e").Value;
                    op.f_f = (byte)finalVals.Property("f").Value;
                    op.f_h = (byte)finalVals.Property("h").Value;
                    op.f_l = (byte)finalVals.Property("l").Value;
                    op.f_pc = (ushort)finalVals.Property("pc").Value;
                    op.f_sp = (ushort)finalVals.Property("sp").Value;

                    op.f_ram = new List<List<ushort>>();
                    JArray finalArray = (JArray)finalVals.Property("ram").Value;

                    foreach(JArray arrObj in finalArray)
                    {
                        List<ushort> list = arrObj.ToObject<List<ushort>>();
                        op.f_ram.Add(list);
                    }

                    col.Add(op);
                }
            }
            else
                throw new FileNotFoundException();

            return col;
        }

        #region 0x

        [TestMethod] public void Test0x00() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x01() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x02() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x03() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x04() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x05() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x06() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x07() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x08() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x09() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x0F() { Assert.Inconclusive(); }

        #endregion

        #region 1x

        [TestMethod] public void Test0x10() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x11() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x12() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x13() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x14() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x15() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x16() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x17() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x18() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x19() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x1F() { Assert.Inconclusive(); }

        #endregion

        #region 2x

        [TestMethod] public void Test0x20() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x21() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x22() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x23() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x24() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x25() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x26() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x27() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x28() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x29() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x2F() { Assert.Inconclusive(); }

        #endregion

        #region 3x

        [TestMethod] public void Test0x30() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x31() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x32() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x33() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x34() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x35() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x36() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x37() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x38() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x39() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x3F() { Assert.Inconclusive(); }

        #endregion

        #region 4x

        [TestMethod] public void Test0x40() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x41() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x42() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x43() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x44() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x45() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x46() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x47() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x48() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x49() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x4F() { Assert.Inconclusive(); }

        #endregion

        #region 5x

        [TestMethod] public void Test0x50() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x51() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x52() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x53() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x54() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x55() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x56() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x57() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x58() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x59() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x5F() { Assert.Inconclusive(); }

        #endregion

        #region 6x

        [TestMethod] public void Test0x60() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x61() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x62() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x63() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x64() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x65() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x66() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x67() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x68() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x69() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x6F() { Assert.Inconclusive(); }

        #endregion

        #region 7x

        [TestMethod] public void Test0x70() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x71() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x72() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x73() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x74() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x75() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x76() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x77() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x78() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x79() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7A() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7B() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7C() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7D() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7E() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x7F() { Assert.Inconclusive(); }

        #endregion

        #region 8x

        [TestMethod] public void Test0x80() { TestOpcode(0x80, LoadTests("80")); }
        [TestMethod] public void Test0x81() { TestOpcode(0x81, LoadTests("81")); }
        [TestMethod] public void Test0x82() { TestOpcode(0x82, LoadTests("82")); }
        [TestMethod] public void Test0x83() { TestOpcode(0x83, LoadTests("83")); }
        [TestMethod] public void Test0x84() { TestOpcode(0x84, LoadTests("84")); }
        [TestMethod] public void Test0x85() { TestOpcode(0x85, LoadTests("85")); }
        [TestMethod] public void Test0x86() { TestOpcode(0x86, LoadTests("86")); }
        [TestMethod] public void Test0x87() { TestOpcode(0x87, LoadTests("87")); }
        [TestMethod] public void Test0x88() { TestOpcode(0x88, LoadTests("88")); }
        [TestMethod] public void Test0x89() { TestOpcode(0x89, LoadTests("89")); }
        [TestMethod] public void Test0x8A() { TestOpcode(0x8A, LoadTests("8A")); }
        [TestMethod] public void Test0x8B() { TestOpcode(0x8B, LoadTests("8B")); }
        [TestMethod] public void Test0x8C() { TestOpcode(0x8C, LoadTests("8C")); }
        [TestMethod] public void Test0x8D() { TestOpcode(0x8D, LoadTests("8D")); }
        [TestMethod] public void Test0x8E() { TestOpcode(0x8E, LoadTests("8E")); }
        [TestMethod] public void Test0x8F() { TestOpcode(0x8F, LoadTests("8F")); }

        #endregion

        #region 9x

        [TestMethod] public void Test0x90() { TestOpcode(0x90, LoadTests("90")); }
        [TestMethod] public void Test0x91() { TestOpcode(0x91, LoadTests("91")); }
        [TestMethod] public void Test0x92() { TestOpcode(0x92, LoadTests("92")); }
        [TestMethod] public void Test0x93() { TestOpcode(0x93, LoadTests("93")); }
        [TestMethod] public void Test0x94() { TestOpcode(0x94, LoadTests("94")); }
        [TestMethod] public void Test0x95() { TestOpcode(0x95, LoadTests("95")); }
        [TestMethod] public void Test0x96() { TestOpcode(0x96, LoadTests("96")); }
        [TestMethod] public void Test0x97() { TestOpcode(0x97, LoadTests("97")); }
        [TestMethod] public void Test0x98() { TestOpcode(0x98, LoadTests("98")); }
        [TestMethod] public void Test0x99() { TestOpcode(0x99, LoadTests("99")); }
        [TestMethod] public void Test0x9A() { TestOpcode(0x9A, LoadTests("9A")); }
        [TestMethod] public void Test0x9B() { TestOpcode(0x9B, LoadTests("9B")); }
        [TestMethod] public void Test0x9C() { TestOpcode(0x9C, LoadTests("9C")); }
        [TestMethod] public void Test0x9D() { TestOpcode(0x9D, LoadTests("9D")); }
        [TestMethod] public void Test0x9E() { TestOpcode(0x9E, LoadTests("9E")); }
        [TestMethod] public void Test0x9F() { TestOpcode(0x9F, LoadTests("9F")); }

        #endregion

        #region Ax

        [TestMethod] public void Test0xA0() { TestOpcode(0xA0, LoadTests("A0")); }
        [TestMethod] public void Test0xA1() { TestOpcode(0xA1, LoadTests("A1")); }
        [TestMethod] public void Test0xA2() { TestOpcode(0xA2, LoadTests("A2")); }
        [TestMethod] public void Test0xA3() { TestOpcode(0xA3, LoadTests("A3")); }
        [TestMethod] public void Test0xA4() { TestOpcode(0xA4, LoadTests("A4")); }
        [TestMethod] public void Test0xA5() { TestOpcode(0xA5, LoadTests("A5")); }
        [TestMethod] public void Test0xA6() { TestOpcode(0xA6, LoadTests("A6")); }
        [TestMethod] public void Test0xA7() { TestOpcode(0xA7, LoadTests("A7")); }
        [TestMethod] public void Test0xA8() { TestOpcode(0xA8, LoadTests("A8")); }
        [TestMethod] public void Test0xA9() { TestOpcode(0xA9, LoadTests("A9")); }
        [TestMethod] public void Test0xAA() { TestOpcode(0xAA, LoadTests("AA")); }
        [TestMethod] public void Test0xAB() { TestOpcode(0xAB, LoadTests("AB")); }
        [TestMethod] public void Test0xAC() { TestOpcode(0xAC, LoadTests("AC")); }
        [TestMethod] public void Test0xAD() { TestOpcode(0xAD, LoadTests("AD")); }
        [TestMethod] public void Test0xAE() { TestOpcode(0xAE, LoadTests("AE")); }
        [TestMethod] public void Test0xAF() { TestOpcode(0xAF, LoadTests("AF")); }

        #endregion

        #region Bx

        [TestMethod] public void Test0xB0() { TestOpcode(0xB0, LoadTests("B0")); }
        [TestMethod] public void Test0xB1() { TestOpcode(0xB1, LoadTests("B1")); }
        [TestMethod] public void Test0xB2() { TestOpcode(0xB2, LoadTests("B2")); }
        [TestMethod] public void Test0xB3() { TestOpcode(0xB3, LoadTests("B3")); }
        [TestMethod] public void Test0xB4() { TestOpcode(0xB4, LoadTests("B4")); }
        [TestMethod] public void Test0xB5() { TestOpcode(0xB5, LoadTests("B5")); }
        [TestMethod] public void Test0xB6() { TestOpcode(0xB6, LoadTests("B6")); }
        [TestMethod] public void Test0xB7() { TestOpcode(0xB7, LoadTests("B7")); }
        [TestMethod] public void Test0xB8() { TestOpcode(0xB8, LoadTests("B8")); }
        [TestMethod] public void Test0xB9() { TestOpcode(0xB9, LoadTests("B9")); }
        [TestMethod] public void Test0xBA() { TestOpcode(0xBA, LoadTests("BA")); }
        [TestMethod] public void Test0xBB() { TestOpcode(0xBB, LoadTests("BB")); }
        [TestMethod] public void Test0xBC() { TestOpcode(0xBC, LoadTests("BC")); }
        [TestMethod] public void Test0xBD() { TestOpcode(0xBD, LoadTests("BD")); }
        [TestMethod] public void Test0xBE() { TestOpcode(0xBE, LoadTests("BE")); }
        [TestMethod] public void Test0xBF() { TestOpcode(0xBF, LoadTests("BF")); }

        #endregion

        #region Cx

        [TestMethod] public void Test0xC0() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC1() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC2() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC8() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xC9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCA() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCD() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xCF() { Assert.Inconclusive(); }

        #endregion

        #region Dx

        [TestMethod] public void Test0xD0() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD1() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD2() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD8() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xD9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDA() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDD() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xDF() { Assert.Inconclusive(); }

        #endregion

        #region Ex

        [TestMethod] public void Test0xE0() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE1() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE2() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE8() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEA() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xED() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEF() { Assert.Inconclusive(); }

        #endregion

        #region Fx

        [TestMethod] public void Test0xF0() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF1() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF2() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF8() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFA() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFD() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFF() { Assert.Inconclusive(); }

        #endregion
    }
}