using System;
using System.Runtime.InteropServices;

// StructLayout: clr会按照结构中占用空间最大的成员进行对齐（Align）
// 对于64位操作系统的对象而言，字段前会有同步块索引SyncBlockIndex和类型对象指针TypeHandle，不足8字节的会补齐。

// 对于class，默认是Auto布局，即使标记了Sequential也会进行优化调整。
// 对于struct，默认是Sequential布局，标记了Auto后会进行优化调整。


namespace StructLayoutTest
{
    /// <summary>
    /// class的默认布局方式，按定义顺序进行布局，
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    class PeopleAuto
    {
        public bool IsDog;
        public double Income;
        public bool IsCat;
    }

    /// <summary>
    /// struct的默认布局方式，按定义顺序进行布局，
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    class PeopleSequential
    {
        public bool IsDog;
        public double Income;
        public bool IsCat;
    }

    /// <summary>
    /// 如果FieldOffset标记错误会导致数据丢失或错误。
    /// 但如果标记准确，会节省内存
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    class PeopleExplicit
    {
        [FieldOffset(0)]
        public bool IsDog;

        [FieldOffset(0)]
        public double Income;

        [FieldOffset(0)]
        public bool IsCat;
    }


    /// <summary>
    /// class的默认布局方式，按定义顺序进行布局，
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    struct StrPeopleAuto
    {
        public bool IsDog;
        public double Income;
        public bool IsCat;
    }

    /// <summary>
    /// struct的默认布局方式，按定义顺序进行布局，
    /// Pack字段控制类型字段在内存中的对齐方式。 它会影响 LayoutKind.Sequential。
    /// 默认情况下，此值为0，指示当前平台的默认封装大小。
    /// Pack的值必须为0、1、2、4、8、16、32、64或128：
    /// 当前平台，Pack=0时与Pack=2相同，字段将在2字节边界对齐。
    /// 当Pack为16时，Struct里的最大字段是double为8bit，则对齐距离为8
    /// 
    /// 对于Struct，当Sequential里添加DateTime作为字段时，Sequential的布局会变成Auto布局
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    struct StrPeopleSequential
    {
        public bool IsDog;
        public double Income;
        public bool IsCat;
        public DateTime dt;
    }

    /// <summary>
    /// 如果FieldOffset标记错误会导致数据丢失或错误。
    /// 但如果标记准确，会节省内存
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    struct StrPeopleExplicit
    {
        [FieldOffset(0)]
        public bool IsDog;

        [FieldOffset(0)]
        public double Income;

        [FieldOffset(0)]
        public bool IsCat;
    }

    class StructLayoutProgram1
    {
        unsafe static void Main1(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadLine();
            /*
            // class
            PeopleAuto pa = new PeopleAuto();
            fixed (bool* p = &(pa.IsDog))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E988
            }
            fixed (double* p = &(pa.Income))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E980
            }
            fixed (bool* p = &(pa.IsCat))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E989
            }
            Console.WriteLine("End1");

            PeopleSequential ps = new PeopleSequential();
            fixed (bool* p = &(ps.IsDog))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9A8
            }
            fixed (double* p = &(ps.Income))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9A0
            }
            fixed (bool* p = &(ps.IsCat))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9A9
            }
            Console.WriteLine("End2");

            PeopleExplicit pe = new PeopleExplicit();
            fixed (bool* p = &(pe.IsDog))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9C0
            }
            fixed (double* p = &(pe.Income))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9C0
            }
            fixed (bool* p = &(pe.IsCat))
            {
                Console.WriteLine(string.Format("0x{0:X}", (long)p)); // 26CAE84E9C0
            }
            Console.WriteLine("End3 ----------------------------");
            */

            // struct
            Console.WriteLine(sizeof(StrPeopleAuto)); // 16
            Console.WriteLine(sizeof(StrPeopleSequential)); // 24
            Console.WriteLine(sizeof(StrPeopleExplicit)); // 8

            StrPeopleAuto strpa = new StrPeopleAuto();
            StrPeopleSequential strps = new StrPeopleSequential();
            StrPeopleExplicit strpe = new StrPeopleExplicit();

            Console.WriteLine(string.Format("0x{0:X} strpa", (long)&(strpa)));        // E84D57E570
            Console.WriteLine(string.Format("0x{0:X} strpa.IsDog", (long)&(strpa.IsDog)));  // E84D57E578
            Console.WriteLine(string.Format("0x{0:X} strpa.Income", (long)&(strpa.Income))); // E84D57E570
            Console.WriteLine(string.Format("0x{0:X} strpa.IsCat", (long)&(strpa.IsCat)));  // E84D57E579
            Console.WriteLine("End1");

            Console.WriteLine(string.Format("0x{0:X} strps", (long)&(strps)));        // E84D57E558
            Console.WriteLine(string.Format("0x{0:X} strps.IsDog", (long)&(strps.IsDog)));  // E84D57E558 -- Pack = 0时，占用了2字节
            Console.WriteLine(string.Format("0x{0:X} strps.Income", (long)&(strps.Income))); // E84D57E560
            Console.WriteLine(string.Format("0x{0:X} strps.IsCat", (long)&(strps.IsCat)));  // E84D57E568
            Console.WriteLine(string.Format("0x{0:X} strps.dt", (long)&(strps.dt)));  // E84D57E568
            Console.WriteLine("End2");

            Console.WriteLine(string.Format("0x{0:X} strpe", (long)&(strpe)));        // E84D57E550
            Console.WriteLine(string.Format("0x{0:X} strpe.IsDog", (long)&(strpe.IsDog)));  // E84D57E550
            Console.WriteLine(string.Format("0x{0:X} strpe.Income", (long)&(strpe.Income))); // E84D57E550
            Console.WriteLine(string.Format("0x{0:X} strpe.IsCat", (long)&(strpe.IsCat)));  // E84D57E550
            Console.WriteLine("End3 ----------------------------");
        }
    }

    struct Color
    {
        float r;
        float g;
        float b;
        float a;
    };

    [StructLayout(LayoutKind.Auto)]
    struct FrameInfo
    {
        public Color color;
        public bool isColorDirty;
        public float depth;
        public bool isDepthDirty;
    };

    class StructLayoutProgram
    {
        unsafe static void Main(string[] args)
        {
            Console.WriteLine(sizeof(FrameInfo)); // 

            FrameInfo frameInfo = new FrameInfo();

            Console.WriteLine(string.Format("0x{0:X} strpa", (long)&(frameInfo)));        // 
            Console.WriteLine(string.Format("0x{0:X} strpa.color", (long)&(frameInfo.color)));  // 
            Console.WriteLine(string.Format("0x{0:X} strpa.isColorDirty", (long)&(frameInfo.isColorDirty))); // 
            Console.WriteLine(string.Format("0x{0:X} strpa.depth", (long)&(frameInfo.depth)));  // 
            Console.WriteLine(string.Format("0x{0:X} strpa.isDepthDirty", (long)&(frameInfo.isDepthDirty)));  // 
            Console.WriteLine("End1");
        }
    }
}