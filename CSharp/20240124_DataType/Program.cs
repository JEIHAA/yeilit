// See https://aka.ms/new-console-template for more information
using System.Formats.Asn1;
internal class Program
{
    public static void Main(string[] args)
    {
        //자료형(DataType)
        //Primary Data Type
        //Value Type
        //Reference Type
        //Pointer Type
        byte byteType = 10;
        System.Console.WriteLine("byteType : ", byteType, sizeof(byte));
        sbyte sbyteType = 10;
        System.Console.WriteLine("sbyteType : {0} / {1} Byte", sbyteType, sizeof(sbyte));
        char cbyteType = 'A';
        System.Console.WriteLine("charType : {0} / {1} Byte", cbyteType, sizeof(char));
        short shortType = -110;
        System.Console.WriteLine("shortType : {0} / {1} Byte", shortType, sizeof(short));
        ushort ushortType = 100;
        System.Console.WriteLine("ushortType : {0} / {1} Byte", ushortType, sizeof(ushort));
        int intType = -1000;
        System.Console.WriteLine("intType : {0} / {1} Byte", intType, sizeof(int));
        uint uintType = 1000;
        System.Console.WriteLine("uintType : {0} / {1} Byte", uintType, sizeof(uint));
        long longType = -12345;
        System.Console.WriteLine("longType : {0} / {1} Byte", longType, sizeof(long));
        long ulongType = 12345;
        System.Console.WriteLine("UlongType : {0} / {1} Byte", ulongType, sizeof(ulong));
        decimal deciamlType = 12345;
        System.Console.WriteLine("decimalType : {0} / {1} Byte", deciamlType, sizeof(decimal));
        bool boolType = true;
        System.Console.WriteLine("boolType : {0} / {1} Byte", boolType, sizeof(bool));
        //float floatType = 3.14f;
        //float floatType = 3f;
        float floatType = 3.14f;
        System.Console.WriteLine("floatType : {0} / {1} Byte", floatType, sizeof(float));
        double doubleType = 3.14;
        System.Console.WriteLine("DoubleType : {0} / {1} Byte", doubleType, sizeof(double));
        //[Reference Type]
        //상속 [Inheritance]
        object objectType = null;
        string stringType = null;
        var varType = 0;
    }
}