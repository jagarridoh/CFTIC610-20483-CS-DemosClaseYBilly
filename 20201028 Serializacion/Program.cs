using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializador
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  new Program().MakeBinarySerializable();
              Console.WriteLine("serialización"); */
            new Program().MakeBinaryDesSerializable();

        }
        public void MakeBinarySerializable()
        {
            TipoSerializable tiposer = new TipoSerializable();
            tiposer.ApplicationDataPath = @"d:\";
            tiposer.ConfigName = "BinaryFormat";
            tiposer.DatabaseHostName = "localhost";

            IFormatter formater = new BinaryFormatter();
            FileStream stream = File.Create(@"D:\temp\serializados\binario.txt");
            formater.Serialize(stream, tiposer);
            stream.Close();
        }
        public void MakeBinaryDesSerializable() {
            IFormatter formater = new BinaryFormatter();
            FileStream stream = File.OpenRead(@"D:\temp\serializados\binario.txt");
            TipoSerializable tiposer = (TipoSerializable) formater.Deserialize(stream);
            Console.WriteLine($" {tiposer.ConfigName}    {tiposer.ApplicationDataPath}    {tiposer.DatabaseHostName}  ");
            stream.Close();
        }
    }




    [Serializable]
    public class TipoSerializable : ISerializable
    {
        [NonSerialized]
        private Guid _internalId;
      
        public string ConfigName { get; set; }
        public string DatabaseHostName { get; set; }
        public string ApplicationDataPath { get; set; }


        public TipoSerializable()
        {
        }

        public TipoSerializable(SerializationInfo info, StreamingContext ctxt)
        {
            _internalId =  Guid.NewGuid();
            this.ConfigName
           = info.GetValue("ConfigName", typeof(string)).ToString();
            this.DatabaseHostName
           = info.GetValue("DatabaseHostName", typeof(string)).ToString();
            this.ApplicationDataPath
               = info.GetValue("ApplicationDataPath", typeof(string)).ToString();
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
          
            info.AddValue("ConfigName", this.ConfigName);
            info.AddValue("DatabaseHostName", this.DatabaseHostName);
            info.AddValue("ApplicationDataPath", this.ApplicationDataPath);
        }
    }
}
