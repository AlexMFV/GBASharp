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

        [TestMethod] public void Test0x00() { TestOpcode(0x00, LoadTests("00")); }
        [TestMethod] public void Test0x01() { TestOpcode(0x01, LoadTests("01")); }
        [TestMethod] public void Test0x02() { TestOpcode(0x02, LoadTests("02")); }
        [TestMethod] public void Test0x03() { TestOpcode(0x03, LoadTests("03")); }
        [TestMethod] public void Test0x04() { TestOpcode(0x04, LoadTests("04")); }
        [TestMethod] public void Test0x05() { TestOpcode(0x05, LoadTests("05")); }
        [TestMethod] public void Test0x06() { TestOpcode(0x06, LoadTests("06")); }
        [TestMethod] public void Test0x07() { TestOpcode(0x07, LoadTests("07")); }
        [TestMethod] public void Test0x08() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x09() { TestOpcode(0x09, LoadTests("09")); }
        [TestMethod] public void Test0x0A() { TestOpcode(0x0A, LoadTests("0A")); }
        [TestMethod] public void Test0x0B() { TestOpcode(0x0B, LoadTests("0B")); }
        [TestMethod] public void Test0x0C() { TestOpcode(0x0C, LoadTests("0C")); }
        [TestMethod] public void Test0x0D() { TestOpcode(0x0D, LoadTests("0D")); }
        [TestMethod] public void Test0x0E() { TestOpcode(0x0E, LoadTests("0E")); }
        [TestMethod] public void Test0x0F() { TestOpcode(0x0F, LoadTests("0F")); }

        #endregion

        #region 1x

        [TestMethod] public void Test0x10() { TestOpcode(0x10, LoadTests("10")); }
        [TestMethod] public void Test0x11() { TestOpcode(0x11, LoadTests("11")); }
        [TestMethod] public void Test0x12() { TestOpcode(0x12, LoadTests("12")); }
        [TestMethod] public void Test0x13() { TestOpcode(0x13, LoadTests("13")); }
        [TestMethod] public void Test0x14() { TestOpcode(0x14, LoadTests("14")); }
        [TestMethod] public void Test0x15() { TestOpcode(0x15, LoadTests("15")); }
        [TestMethod] public void Test0x16() { TestOpcode(0x16, LoadTests("16")); }
        [TestMethod] public void Test0x17() { TestOpcode(0x17, LoadTests("17")); }
        [TestMethod] public void Test0x18() { TestOpcode(0x18, LoadTests("18")); }
        [TestMethod] public void Test0x19() { TestOpcode(0x19, LoadTests("19")); }
        [TestMethod] public void Test0x1A() { TestOpcode(0x1A, LoadTests("1A")); }
        [TestMethod] public void Test0x1B() { TestOpcode(0x1B, LoadTests("1B")); }
        [TestMethod] public void Test0x1C() { TestOpcode(0x1C, LoadTests("1C")); }
        [TestMethod] public void Test0x1D() { TestOpcode(0x1D, LoadTests("1D")); }
        [TestMethod] public void Test0x1E() { TestOpcode(0x1E, LoadTests("1E")); }
        [TestMethod] public void Test0x1F() { TestOpcode(0x1F, LoadTests("1F")); }

        #endregion

        #region 2x

        [TestMethod] public void Test0x20() { TestOpcode(0x20, LoadTests("20")); }
        [TestMethod] public void Test0x21() { TestOpcode(0x21, LoadTests("21")); }
        [TestMethod] public void Test0x22() { TestOpcode(0x22, LoadTests("22")); }
        [TestMethod] public void Test0x23() { TestOpcode(0x23, LoadTests("23")); }
        [TestMethod] public void Test0x24() { TestOpcode(0x24, LoadTests("24")); }
        [TestMethod] public void Test0x25() { TestOpcode(0x25, LoadTests("25")); }
        [TestMethod] public void Test0x26() { TestOpcode(0x26, LoadTests("26")); }
        [TestMethod] public void Test0x27() { TestOpcode(0x27, LoadTests("27")); }
        [TestMethod] public void Test0x28() { TestOpcode(0x28, LoadTests("28")); }
        [TestMethod] public void Test0x29() { TestOpcode(0x29, LoadTests("29")); }
        [TestMethod] public void Test0x2A() { TestOpcode(0x2A, LoadTests("2A")); }
        [TestMethod] public void Test0x2B() { TestOpcode(0x2B, LoadTests("2B")); }
        [TestMethod] public void Test0x2C() { TestOpcode(0x2C, LoadTests("2C")); }
        [TestMethod] public void Test0x2D() { TestOpcode(0x2D, LoadTests("2D")); }
        [TestMethod] public void Test0x2E() { TestOpcode(0x2E, LoadTests("2E")); }
        [TestMethod] public void Test0x2F() { TestOpcode(0x2F, LoadTests("2F")); }

        #endregion

        #region 3x

        [TestMethod] public void Test0x30() { TestOpcode(0x30, LoadTests("30")); }
        [TestMethod] public void Test0x31() { TestOpcode(0x31, LoadTests("31")); }
        [TestMethod] public void Test0x32() { TestOpcode(0x32, LoadTests("32")); }
        [TestMethod] public void Test0x33() { TestOpcode(0x33, LoadTests("33")); }
        [TestMethod] public void Test0x34() { TestOpcode(0x34, LoadTests("34")); }
        [TestMethod] public void Test0x35() { TestOpcode(0x35, LoadTests("35")); }
        [TestMethod] public void Test0x36() { TestOpcode(0x36, LoadTests("36")); }
        [TestMethod] public void Test0x37() { TestOpcode(0x37, LoadTests("37")); }
        [TestMethod] public void Test0x38() { TestOpcode(0x38, LoadTests("38")); }
        [TestMethod] public void Test0x39() { TestOpcode(0x39, LoadTests("39")); }
        [TestMethod] public void Test0x3A() { TestOpcode(0x3A, LoadTests("3A")); }
        [TestMethod] public void Test0x3B() { TestOpcode(0x3B, LoadTests("3B")); }
        [TestMethod] public void Test0x3C() { TestOpcode(0x3C, LoadTests("3C")); }
        [TestMethod] public void Test0x3D() { TestOpcode(0x3D, LoadTests("3D")); }
        [TestMethod] public void Test0x3E() { TestOpcode(0x3E, LoadTests("3E")); }
        [TestMethod] public void Test0x3F() { TestOpcode(0x3F, LoadTests("3F")); }

        #endregion

        #region 4x

        [TestMethod] public void Test0x40() { TestOpcode(0x40, LoadTests("40")); }
        [TestMethod] public void Test0x41() { TestOpcode(0x41, LoadTests("41")); }
        [TestMethod] public void Test0x42() { TestOpcode(0x42, LoadTests("42")); }
        [TestMethod] public void Test0x43() { TestOpcode(0x43, LoadTests("43")); }
        [TestMethod] public void Test0x44() { TestOpcode(0x44, LoadTests("44")); }
        [TestMethod] public void Test0x45() { TestOpcode(0x45, LoadTests("45")); }
        [TestMethod] public void Test0x46() { TestOpcode(0x46, LoadTests("46")); }
        [TestMethod] public void Test0x47() { TestOpcode(0x47, LoadTests("47")); }
        [TestMethod] public void Test0x48() { TestOpcode(0x48, LoadTests("48")); }
        [TestMethod] public void Test0x49() { TestOpcode(0x49, LoadTests("49")); }
        [TestMethod] public void Test0x4A() { TestOpcode(0x4A, LoadTests("4A")); }
        [TestMethod] public void Test0x4B() { TestOpcode(0x4B, LoadTests("4B")); }
        [TestMethod] public void Test0x4C() { TestOpcode(0x4C, LoadTests("4C")); }
        [TestMethod] public void Test0x4D() { TestOpcode(0x4D, LoadTests("4D")); }
        [TestMethod] public void Test0x4E() { TestOpcode(0x4E, LoadTests("4E")); }
        [TestMethod] public void Test0x4F() { TestOpcode(0x4F, LoadTests("4F")); }

        #endregion

        #region 5x

        [TestMethod] public void Test0x50() { TestOpcode(0x50, LoadTests("50")); }
        [TestMethod] public void Test0x51() { TestOpcode(0x51, LoadTests("51")); }
        [TestMethod] public void Test0x52() { TestOpcode(0x52, LoadTests("52")); }
        [TestMethod] public void Test0x53() { TestOpcode(0x53, LoadTests("53")); }
        [TestMethod] public void Test0x54() { TestOpcode(0x54, LoadTests("54")); }
        [TestMethod] public void Test0x55() { TestOpcode(0x55, LoadTests("55")); }
        [TestMethod] public void Test0x56() { TestOpcode(0x56, LoadTests("56")); }
        [TestMethod] public void Test0x57() { TestOpcode(0x57, LoadTests("57")); }
        [TestMethod] public void Test0x58() { TestOpcode(0x58, LoadTests("58")); }
        [TestMethod] public void Test0x59() { TestOpcode(0x59, LoadTests("59")); }
        [TestMethod] public void Test0x5A() { TestOpcode(0x5A, LoadTests("5A")); }
        [TestMethod] public void Test0x5B() { TestOpcode(0x5B, LoadTests("5B")); }
        [TestMethod] public void Test0x5C() { TestOpcode(0x5C, LoadTests("5C")); }
        [TestMethod] public void Test0x5D() { TestOpcode(0x5D, LoadTests("5D")); }
        [TestMethod] public void Test0x5E() { TestOpcode(0x5E, LoadTests("5E")); }
        [TestMethod] public void Test0x5F() { TestOpcode(0x5F, LoadTests("5F")); }

        #endregion

        #region 6x

        [TestMethod] public void Test0x60() { TestOpcode(0x60, LoadTests("60")); }
        [TestMethod] public void Test0x61() { TestOpcode(0x61, LoadTests("61")); }
        [TestMethod] public void Test0x62() { TestOpcode(0x62, LoadTests("62")); }
        [TestMethod] public void Test0x63() { TestOpcode(0x63, LoadTests("63")); }
        [TestMethod] public void Test0x64() { TestOpcode(0x64, LoadTests("64")); }
        [TestMethod] public void Test0x65() { TestOpcode(0x65, LoadTests("65")); }
        [TestMethod] public void Test0x66() { TestOpcode(0x66, LoadTests("66")); }
        [TestMethod] public void Test0x67() { TestOpcode(0x67, LoadTests("67")); }
        [TestMethod] public void Test0x68() { TestOpcode(0x68, LoadTests("68")); }
        [TestMethod] public void Test0x69() { TestOpcode(0x69, LoadTests("69")); }
        [TestMethod] public void Test0x6A() { TestOpcode(0x6A, LoadTests("6A")); }
        [TestMethod] public void Test0x6B() { TestOpcode(0x6B, LoadTests("6B")); }
        [TestMethod] public void Test0x6C() { TestOpcode(0x6C, LoadTests("6C")); }
        [TestMethod] public void Test0x6D() { TestOpcode(0x6D, LoadTests("6D")); }
        [TestMethod] public void Test0x6E() { TestOpcode(0x6E, LoadTests("6E")); }
        [TestMethod] public void Test0x6F() { TestOpcode(0x6F, LoadTests("6F")); }

        #endregion

        #region 7x

        [TestMethod] public void Test0x70() { TestOpcode(0x70, LoadTests("70")); }
        [TestMethod] public void Test0x71() { TestOpcode(0x71, LoadTests("71")); }
        [TestMethod] public void Test0x72() { TestOpcode(0x72, LoadTests("72")); }
        [TestMethod] public void Test0x73() { TestOpcode(0x73, LoadTests("73")); }
        [TestMethod] public void Test0x74() { TestOpcode(0x74, LoadTests("74")); }
        [TestMethod] public void Test0x75() { TestOpcode(0x75, LoadTests("75")); }
        [TestMethod] public void Test0x76() { Assert.Inconclusive(); }
        [TestMethod] public void Test0x77() { TestOpcode(0x77, LoadTests("77")); }
        [TestMethod] public void Test0x78() { TestOpcode(0x78, LoadTests("78")); }
        [TestMethod] public void Test0x79() { TestOpcode(0x79, LoadTests("79")); }
        [TestMethod] public void Test0x7A() { TestOpcode(0x7A, LoadTests("7A")); }
        [TestMethod] public void Test0x7B() { TestOpcode(0x7B, LoadTests("7B")); }
        [TestMethod] public void Test0x7C() { TestOpcode(0x7C, LoadTests("7C")); }
        [TestMethod] public void Test0x7D() { TestOpcode(0x7D, LoadTests("7D")); }
        [TestMethod] public void Test0x7E() { TestOpcode(0x7E, LoadTests("7E")); }
        [TestMethod] public void Test0x7F() { TestOpcode(0x7F, LoadTests("7F")); }

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
        [TestMethod] public void Test0xE2() { TestOpcode(0xE2, LoadTests("E2")); }
        [TestMethod] public void Test0xE3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xE8() { TestOpcode(0xE8, LoadTests("E8")); }
        [TestMethod] public void Test0xE9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEA() { TestOpcode(0xEA, LoadTests("EA")); }
        [TestMethod] public void Test0xEB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xED() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xEF() { Assert.Inconclusive(); }

        #endregion

        #region Fx

        [TestMethod] public void Test0xF0() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF1() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF2() { TestOpcode(0xF2, LoadTests("F2")); }
        [TestMethod] public void Test0xF3() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF4() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF5() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF6() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF7() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF8() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xF9() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFA() { TestOpcode(0xFA, LoadTests("FA")); }
        [TestMethod] public void Test0xFB() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFC() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFD() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFE() { Assert.Inconclusive(); }
        [TestMethod] public void Test0xFF() { Assert.Inconclusive(); }

        #endregion
    }
}