using Serializable8;
using System;


namespace Serializable08
{
    class Program
    {
        static void Main()
        {
            //new UsingCustomSerializableType().MakeBinarySerializable();
            //new UsingCustomSerializableType().MakeBinaryDeSerializable();
            //new UsingCustomSerializableType().MakdeSoapSerializable();
            //new UsingCustomSerializableType().MakeSoapDeSerializable();
            //new UsingCustomSerializableType().MakeJsonSerializable();
            //new UsingCustomSerializableType().MakeJsonDeSerializable();


            //new UsingNewtonJson().MakeSerializableWithNewtonJson();
            //new UsingNewtonJson().MakeDeSerializableWithNewtonJson();

            //new UsingNewtonJson().MakeSerializewithJsonSerializer();
            //new UsingNewtonJson().MakeDeSerializewithJsonSerializer();

            //new UsingIniFormaterCustomClass().MakeSerializableIniFormaterCustomClass();
            new UsingIniFormaterCustomClass().MakeDesSerializableIniFormaterCustomClass();
        }
    }
}
