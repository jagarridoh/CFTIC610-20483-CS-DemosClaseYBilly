using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using static System.Console;

namespace Serializable8
{
    class IniFormatter : IFormatter
    {
        static readonly char[] _delim = new char[] { '=' };
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public IniFormatter()
        {
            this.Context = new StreamingContext(StreamingContextStates.All);
        }
        public object Deserialize(Stream serializationStream)
        {
            StreamReader buffer = new StreamReader(serializationStream);
            // Get the type from the serialized data.
            Type typeToDeserialize = this.GetType(buffer);
            // Create default instance of object using type name.
            Object obj = FormatterServices.GetUninitializedObject(typeToDeserialize);
            // Get all the members for the type.
            MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), this.Context);
            // Create dictionary to store the variable names and any serialized data.
            Dictionary<string, object> serializedMemberData
            = new Dictionary<string, object>();
            // Read the serialized data, and extract the variable names
            // and values as strings.
            while (buffer.Peek() >= 0)
            {
                string line = buffer.ReadLine();
                string[] sarr = line.Split(_delim);
                // key = variable name, value = variable value.
                serializedMemberData.Add(
                sarr[0].Trim(), // Variable name.
                sarr[1].Trim()); // Variable value.
            }
            // Close the underlying stream.
            buffer.Close();
            // Create a list to store member values as their correct type.
            List<object> dataAsCorrectTypes = new List<object>();
            // For each of the members, get the serialized values as their correct type.
            for (int i = 0; i < members.Length; i++)
            {
                FieldInfo field = members[i] as FieldInfo;
                if (!serializedMemberData.ContainsKey(field.Name))
                    throw new SerializationException(field.Name);
                // Change the type of the value to the correct type
                // of the member.
                object valueAsCorrectType = Convert.ChangeType(
                serializedMemberData[field.Name],
                field.FieldType);
                dataAsCorrectTypes.Add(valueAsCorrectType);
            }
            // Populate the object with the deserialized values.
            return FormatterServices.PopulateObjectMembers(
            obj,
            members,
            dataAsCorrectTypes.ToArray());
        }
        public void Serialize(Stream serializationStream, object graph)
        {
            // Get all the fields that you want to serialize.
            MemberInfo[] allMembers = FormatterServices.GetSerializableMembers(graph.GetType(), this.Context);
            // Get the field data.
            object[] fieldData = FormatterServices.GetObjectData(graph, allMembers);
            // Create a buffer to write the serialized data too.
            StreamWriter sw = new StreamWriter(serializationStream);
            // Write the name of the class to the firstline.
            sw.WriteLine("@ClassName={0}", graph.GetType().FullName);
            // Iterate the field data.
            for (int i = 0; i < fieldData.Length; ++i)
            {
                sw.WriteLine("{0}={1}",
                allMembers[i].Name, // Member name.
                fieldData[i].ToString()); // Member value.
            }
            sw.Close();
        }
        private Type GetType(StreamReader buffer)
        {
            string firstLine = buffer.ReadLine();
            string[] sarr = firstLine.Split(_delim);
            string nameOfClass = sarr[1];
            return Type.GetType(nameOfClass);
        }
    }

    public class OtraIniFormater : IFormatter
    {
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            object eje = new object();
            return eje;
        }

        public void Serialize(Stream serializationStream, object graph)
        {

        }
    }

    public class UsingIniFormaterCustomClass
    {
        public void MakeSerializableIniFormaterCustomClass()
        {
            var config = new ConfigCustom
            {
                Name = "OwnFormater",
                Values = "OwnValue"
            };
            IniFormatter iniF = new IniFormatter();
            FileStream buffer = File.Create(@".\fourthcoffee\OwnSerializationFormater.own");
            iniF.Serialize(buffer, config);
            buffer.Close();
        }

        public void MakeDesSerializableIniFormaterCustomClass()
        {
            //1-Create the formatter you want to use to serialize the object.
            IniFormatter iniF = new IniFormatter();
            //2-Create the stream that the serialized data will be buffered too.
            FileStream buffer = File.OpenRead(@".\fourthcoffee\OwnSerializationFormater.own");
            //3-Invoke the Deserialize method.
            ConfigCustom config = iniF.Deserialize(buffer) as ConfigCustom;
            WriteLine(config.Name);
            WriteLine(config.Values);
            //4-Close the stream.
            buffer.Close();
            ReadLine();
        }

    }

    [Serializable]
    public class ConfigCustom : ISerializable
    {
        public string Name { get; set; }
        public string Values { get; set; }

        public ConfigCustom() {}

        public ConfigCustom(SerializationInfo info, StreamingContext ctxt)
        {
            this.Name = info.GetValue("Name", typeof(string)).ToString();
            this.Values = info.GetValue("Values", typeof(string)).ToString();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Values", this.Values);
        }

    }
}


