using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcodeTests
{
    public class OpcodeTester
    {
        public string name { get; set; }
        public byte i_a { get; set; }
        public byte i_b { get; set; }
        public byte i_c { get; set; }
        public byte i_d { get; set; }
        public byte i_e { get; set; }
        public byte i_f { get; set; }
        public byte i_h { get; set; }
        public byte i_l { get; set; }
        public ushort i_pc { get; set; }
        public ushort i_sp { get; set; }
        public List<List<ushort>> i_ram { get; set; }
        public byte f_a { get; set; }
        public byte f_b { get; set; }
        public byte f_c { get; set; }
        public byte f_d { get; set; }
        public byte f_e { get; set; }
        public byte f_f { get; set; }
        public byte f_h { get; set; }
        public byte f_l { get; set; }
        public ushort f_pc { get; set; }
        public ushort f_sp { get; set; }
        public List<List<ushort>> f_ram { get; set; }
    }
}
