using System;
using System.IO;
using static System.Console;

namespace Streams
{
    class UsingBinaryReader
    {
        public void MakingBinaryReader()
        {
            // Source file path.
            string sourceFilePath = @".\fourthcoffee\applicationdata\settings.txt ";
            // Create a FileStream object so that you can interact with the file
            // system.
            FileStream sourceFile = new FileStream(
             sourceFilePath, // Pass in the source file path.
             FileMode.Open, // Open an existing file.
             FileAccess.Read);// Read an existing file.
                              // Create a BinaryWriter object passing in the FileStream object.
            BinaryReader reader = new BinaryReader(sourceFile);
                int position = 0;
            // Store the length of the stream.
            int length = (int)reader.BaseStream.Length;
            // Create an array to store each byte from the file.
            byte[] dataCollection = new byte[length];
            int returnedByte;
            while ((returnedByte = reader.Read()) != -1)
            {
                // Set the value at the next index.
                dataCollection[position] = (byte)returnedByte;
                Write($"{returnedByte},");
                // Advance our position variable.
                position += sizeof(byte);
            }
            // Close the streams to release any file handles.
            reader.Close();
            sourceFile.Close();
            Console.ReadLine();
        }

        public void MakingBinaryWriter()
        {
            string destinationFilePath = @".\fourthcoffee\applicationdata\settings.txt";
            // Collection of bytes.
            byte[] dataCollection = { 1, 4, 6, 7, 12, 33, 26, 98, 82, 101 };
            // Create a FileStream object so that you can interact with the file
            // system.
            FileStream destFile = new FileStream(
             destinationFilePath, // Pass in the destination path.
             FileMode.Create, // Always create new file.
             FileAccess.Write); // Only perform writing.
                                // Create a BinaryWriter object passing in the FileStream object.
            BinaryWriter writer = new BinaryWriter(destFile);
            // Write each byte to stream.
            foreach (byte data in dataCollection)
            {
                writer.Write(data);
            }
            // Close both streams to flush the data to the file.
            writer.Close();
            destFile.Close();
            Console.ReadLine();
        }

    }
}
