using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBASharp
{
    public static class Opcodes
    {
        public static void Code0x86()
        {
            //Not implemented
        }

        public static void Code0x88()
        {
            OpcodeHelpers.ADC(CPU.B_Register);
        }

        public static void Code0x89()
        {
            OpcodeHelpers.ADC(CPU.C_Register);
        }

        public static void Code0x8A()
        {
            OpcodeHelpers.ADC(CPU.D_Register);
        }

        public static void Code0x8B()
        {
            OpcodeHelpers.ADC(CPU.E_Register);
        }

        public static void Code0x8C()
        {
            OpcodeHelpers.ADC(CPU.H_Register);
        }

        public static void Code0x8D()
        {
            OpcodeHelpers.ADC(CPU.L_Register);
        }

        public static void Code0x8E()
        {
            //Not Implemented
        }

        public static void Code0x8F()
        {
            OpcodeHelpers.ADC(CPU.reg_a);
        }
    }

    public static class OpcodeHelpers
    {
        public static void ADC(byte reg)
        {
            byte regA = CPU.reg_a;
            ushort sum = (ushort)(regA + reg + CPU.flag_c);

            if ((byte)sum == 0x0)
                CPU.flag_z = 0x1;
            else
                CPU.flag_z = 0x0;

            CPU.flag_n = 0x0;

            byte finalResult = (byte)((regA & 0xf) + (reg & 0xf) + CPU.flag_c);

            CPU.flag_h = (byte)(finalResult > 0xf ? 0x1 : 0x0);
            
            if(sum > 0xff) //Overflow from 7 bit (whole value)
                CPU.flag_c = 0x1;
            else
                CPU.flag_c = 0x0;

            CPU.reg_a = (byte)(sum & 0xff); //Since we are converting from a ushort to a byte we only want the first byte
        }
    }
}
