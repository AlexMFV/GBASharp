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

            return col;
        }

        [TestMethod]
        public void Test0x88()
        {
            TestOpcode(0x88, LoadTests("88"));
        }

        [TestMethod]
        public void Test0x89()
        {
            TestOpcode(0x89, LoadTests("89"));
        }

        [TestMethod]
        public void Test0x8A()
        {
            TestOpcode(0x8A, LoadTests("8A"));
        }

        [TestMethod]
        public void Test0x8B()
        {
            TestOpcode(0x8B, LoadTests("8B"));
        }

        [TestMethod]
        public void Test0x8C()
        {
            TestOpcode(0x8C, LoadTests("8C"));
        }

        [TestMethod]
        public void Test0x8D()
        {
            TestOpcode(0x8D, LoadTests("8D"));
        }

        [TestMethod]
        public void Test0x8E()
        {
            TestOpcode(0x8E, LoadTests("8E"));
        }

        [TestMethod]
        public void Test0x8F()
        {
            TestOpcode(0x8F, LoadTests("8F"));
        }
    }
}