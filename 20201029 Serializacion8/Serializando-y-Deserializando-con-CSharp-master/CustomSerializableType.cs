using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
//using System.Xml.Serialization;
using System.IO;
using static System.Console;
using Newtonsoft.Json.Serialization;

namespace Serializable08
{
    //Create a serializable type
    [Serializable] //2 - Decorate the class with the Serializable attribute provided in the System namespace.
    public class ServiceConfiguration : ISerializable // 3 - Implement the ISerializable interface provided in the System.Runtime.Serialization namespace
    {

        [NonSerialized] // Instructing the serializer to ignore private fields by decorating them with the NonSerialized attribute
        private Guid _internalId;
        //5 - Define the public members that you want to serialize. 
        //[NonSerialized]
        //private string configName;
        public string ConfigName { get; set; }
        //[field:NonSerialized]
        public string DatabaseHostName { get; set; }
        //[field:NonSerialized]
        public string ApplicationDataPath { get; set; }

        //1 - Define a default constructor
        public ServiceConfiguration()
        {
        }
        //4 - Define a deserialization constructor, which accepts SerializationInfo and StreamingContext objects as parameters
        public ServiceConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.ConfigName 
            = info.GetValue("ConfigName", typeof(string)).ToString();
            this.DatabaseHostName
            = info.GetValue("DatabaseHostName", typeof(string)).ToString();
            this.ApplicationDataPath
            = info.GetValue("ApplicationDataPath", typeof(string)).ToString();
            _internalId = Guid.NewGuid();

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConfigName", this.ConfigName);
            info.AddValue("DatabaseHostName", this.DatabaseHostName);
            info.AddValue("ApplicationDataPath", this.ApplicationDataPath);
        }

    }

    public class UsingCustomSerializableType
    {
        public void MakeBinarySerializable()
        {
            //1-Create the object you want to serialize.
            ServiceConfiguration config = new ServiceConfiguration();
            config.ApplicationDataPath = @"C:\Users\usuario\CFTIC\CFTIC610-20483-CS-DemosClaseYBilly\20201029 Serializacion8\Serializando-y-Deserializando-con-CSharp-master";
            config.ConfigName = "Binary Format";
            config.DatabaseHostName = "LocalHost";
            //2-Create the formatter you want to use to serialize the object.
            IFormatter formatter = new BinaryFormatter();
            //3-Create the stream that the serialized data will be buffered to.
            FileStream buffer = File.Create(@".\fourthcoffee\config1.txt");
            //4-Invoke the Serialize method.
            formatter.Serialize(buffer, config);
            //5-Close the stream.
            buffer.Close();
        }

        public void MakeBinaryDeSerializable()
        {
            //1-Create the formatter you want to use to serialize the object.
            IFormatter formatter = new BinaryFormatter();
            //2-Create the stream that the serialized data will be buffered too.
            FileStream buffer = File.OpenRead(@".\fourthcoffee\config1.txt");
            //3-Invoke the Deserialize method.
            ServiceConfiguration config = formatter.Deserialize(buffer) as ServiceConfiguration;
            WriteLine(config.ApplicationDataPath);
            WriteLine(config.ConfigName);
            WriteLine(config.DatabaseHostName);
            //4-Close the stream.
            buffer.Close();
            Console.ReadLine();
        }

        public void MakdeSoapSerializable()
        {
            // Create the object you want to serialize.
            ServiceConfiguration config = new ServiceConfiguration();
            config.ApplicationDataPath = @"c:\Program File";
            config.ConfigName = "XML Format";
            config.DatabaseHostName = "LocalHost";
            // Create the formatter you want to use to serialize the object.
            IFormatter formatter = new SoapFormatter();
            // Create the stream that the serialized data will be buffered too.
            FileStream buffer = File.Create(@".\fourthcoffee\config.xml");
            // Invoke the Serialize method.
            formatter.Serialize(buffer, config);
            // Close the stream.
            buffer.Close();
        }

        public void MakeSoapDeSerializable()
        {
            //1-Create the formatter you want to use to serialize the object.
            IFormatter formatter = new SoapFormatter();
            //2-Create the stream that the serialized data will be buffered too.
            FileStream buffer = File.OpenRead(@".\fourthcoffee\config.xml");
            //3-Invoke the Deserialize method.
            ServiceConfiguration config = formatter.Deserialize(buffer) as ServiceConfiguration;
            WriteLine(config.ApplicationDataPath);
            WriteLine(config.ConfigName);
            WriteLine(config.DatabaseHostName);
            //4-Close the stream.
            buffer.Close();
            Console.ReadLine();
        }

        public void MakeJsonSerializable()
        {
            // Create the object you want to serialize.
            ServiceConfiguration config = new ServiceConfiguration();
            config.ApplicationDataPath = @"c:\Program File";
            config.ConfigName = "Json Format";
            config.DatabaseHostName = "LocalHost";
            // Create a DataContractJsonSerializer object that you will use to serialize the object to JSON.
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(config.GetType());
            // Create the stream that the serialized data will be buffered too.
            FileStream buffer = File.Create(@".\fourthcoffee\config.json");
            // Invoke the WriteObject method.
            jsonSerializer.WriteObject(buffer, config);
            // Close the stream.
            buffer.Close();
        }

        public void MakeJsonDeSerializable()
        {
            // Create a DataContractJsonSerializer object that you will use to
            // deserialize the JSON.
            DataContractJsonSerializer jsonSerializer
             = new DataContractJsonSerializer(typeof(ServiceConfiguration));
            // Create a stream that will read the serialized data.
            FileStream buffer = File.OpenRead(@".\fourthcoffee\config.json");
            // Invoke the ReadObject method.
            ServiceConfiguration config = jsonSerializer.ReadObject(buffer) as ServiceConfiguration;
            WriteLine(config.ApplicationDataPath);
            WriteLine(config.ConfigName);
            WriteLine(config.DatabaseHostName);
            // Close the stream.
            buffer.Close();
            Console.ReadLine();
        }

    }
}