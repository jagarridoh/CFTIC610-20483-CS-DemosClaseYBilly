using System;
using System.IO;
using static System.Console;
using System.Globalization;
using System.Threading;
namespace Files7
{
    public class UsingFiles
    {
        #region FileClass
        //Namespace System.IO
        //File Manipulation by using the File Class
        //Statics Methods, do not cache) recomended for single operation on a file.
        public int ReadAllText(string filePath, bool message = true) // Method reading content in memory
        {
            #region Using_files_read_all_text
            // Recomended using to small files, large files can result in an unresponsive UI in your apps.
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            string settings = File.ReadAllText(filePath);  // Reall All text 

            if (message)
                "Read All Text method".MakeItBold("Método de lectura:");

            WriteLine(settings);
            #endregion
            return 0;
        }

        public int ReadAllLines(string filePath, bool message = true) // Method reading content in memory
        {
            #region Using_files_ReadAllLines
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            string[] settingsLineByLine = File.ReadAllLines(filePath);

            if (message)
                "Read All Lines".MakeItBold("Método de lectura:");

            foreach (var sLine in settingsLineByLine)
            {
                WriteLine(sLine);
            }
            #endregion
            return 0;
        }

        public int ReadAllBytes(string filePath, bool message = true) // Method reading content in memory
        {
            #region Using_files_ReadAllBytes
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            byte[] rawSettings = File.ReadAllBytes(filePath);

            if (message)
                "Read All Bytes".MakeItBold("Método de lectura:");

            foreach (var sByte in rawSettings)
            {
                char c = (char)sByte;
                Write($" {sByte}-");
                c.MakeItBold();
            }
            #endregion
            return 0;
        }

        public int WriteAllText(string filePath)
        {
            #region Using_files_WriteAllText
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            string settings = "companyName=fourth coffee;";
            File.WriteAllText(filePath, settings);

            "Write All Text method".MakeItBold("\nMétodo de escritura:");
            ReadAllText(filePath, false);
            #endregion
            return 0;
        }

        public int WriteAllLines(string filePath)
        {
            #region Using_files_WriteAllLines
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\hosts.txt ";
            string[] hosts = { "86.120.1.203", "113.45.80.31", "168.195.23.29" };
            File.WriteAllLines(filePath, hosts);

            "Write All Lines".MakeItBold("\nMétodo de escritura:");
            ReadAllLines(filePath, false);
            #endregion
            return 0;
        }

        public int WriteAllBytes(string filePath)
        {
            #region Using_files_WriteAllBytes
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt ";
            byte[] rawSettings = {99,111,109,112,97,110,121,78,97,109,101,61,102,111,
                                117,114,116,104,32,99,111,102,102,101,101};
            File.WriteAllBytes(filePath, rawSettings);

            "Write All Text bytes".MakeItBold("\nMétodo de escritura:");
            ReadAllBytes(filePath, false);
            #endregion
            return 0;
        }

        public int AppendAllText(string filePath)
        {
            #region Using_files_AppendAllText
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            string settings = "\ncompanyContact= Dean Halstead";
            File.AppendAllText(filePath, settings);

            "Append All Text".MakeItBold("\n** Writing Method** :");
            ReadAllText(filePath, false);
            #endregion
            return 0;
        }

        public int AppendAllLines(string filePath)
        {
            #region Using_files_AppendAllLines
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\hosts.txt";
            string[] newHosts = {"97.11.1.195", "203.194.40.177"};
            File.AppendAllLines(filePath, newHosts);

            "Append All Lines".MakeItBold("\n** AppendAllLines Method** :");
            ReadAllText(filePath, false);
            #endregion
            return 0;
        }

        public int Copying(string sourceSettingsPath, string destinationSettingsPath)
        {
            #region Using_files_Copying
            if (sourceSettingsPath.IsEmpty())
                sourceSettingsPath = @".\fourthCoffee\settings.txt";
            if (destinationSettingsPath.IsEmpty())
                destinationSettingsPath = @".\fourthCoffee\Copy of settings.txt";
            bool overWrite = true; // System.IO.IOException if overwrite is false and file exits
            File.Copy(sourceSettingsPath, destinationSettingsPath, overWrite);

            "Fichero copiado".MakeItBold();
            $"Reading the Content of copy file:{destinationSettingsPath}".MakeItBold("\nUsing the Copy method of File Class:");
            ReadAllText(destinationSettingsPath, false);
            #endregion
            return 0;
        }

        public int Deleting(string filePath)
        {
            #region Using_files_Deleting
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            File.Delete(filePath);

            "Fichero borrado".MakeItBold("\nUsing the File Class, Delete Method:");
            #endregion
            return 0;
        }

        public int ExitsFile(string filePath, out bool exits)
        {
            #region Using_files_ExitsFile
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";

            exits = File.Exists(filePath);  // Need thread isole, becouse try to open file in exclusive mode
                                            // If does have sufficient permission to read, no exeption return false
            #endregion
            return 0;
        }

        public int InfoCreationTime(string filePath, CultureInfo culture = null)
        {
            #region Using_files_InfoCreationTime
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            if (culture == null)
                culture = new CultureInfo("es-Es");
            Thread.CurrentThread.CurrentCulture = culture;
            DateTime settingsCreatedOn = File.GetCreationTime(filePath);

            "\nUsing Info Creating Time".MakeItBold($"Fecha de creación del fichero:{filePath}\n", false);
            WriteLine(settingsCreatedOn.ToLongDateString());
            #endregion
            return 0;
        }
        #endregion

        #region FileInfoClass
        //Namespace System.IO
        //File Manipulation by using the FileInfo class (Need to instanciate before using, cache info)
        //recomended for performing multiple operations on the same file.
        public int CopyingUsingFileInfo(string sourceSettingsPath, string destinationSettingsPath)
        {
            #region Using_filesInfo_CopyingUsingFileInfo
            if (sourceSettingsPath.IsEmpty())
                sourceSettingsPath = @".\fourthCoffee\settings.txt";
            if (destinationSettingsPath.IsEmpty())
                destinationSettingsPath = @".\temp\settings.txt";
            bool overwrite = true; // System.IO.IOException if overwrite is false and file exits 

            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(sourceSettingsPath);
            settings.CopyTo(destinationSettingsPath, overwrite);

            "Fichero copiado".MakeItBold();
            $"Reading the Content of copy file:{destinationSettingsPath}".MakeItBold("\nUsing the FileInfo Class, Copy to Method:");
            ReadAllText(destinationSettingsPath, false);
            #endregion
            return 0;
        }

        public int DeletingFileUsingFileInfo(string filePath)
        {
            #region Using_filesInfo_DeletingFileUsingFileInfo
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";

            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(filePath);
            settings.Delete();

            "Fichero borrado".MakeItBold("\nUsing the FileInfo Class, Delete Method:");
            #endregion
            return 0;
        }

        public int NameOfDirectoryUsingFileInfo(string filePath, out string directoryName)
        {
            directoryName = default;
            #region Using_filesInfo_NameOfDirectoryUsingFileInfo
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(filePath);
            directoryName = settings.DirectoryName;
            #endregion
            return 0;
        }

        public int ExitsFileUsingFileInfo(string filePath, out bool exits)
        {
            exits = default;
            #region Using_filesInfo_ExitsFileUsingFileInfo
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(filePath);
            exits = settings.Exists;
            #endregion            
            return 0;
        }

        public int GetExtensionFileUsingFileInfo(string filePath, out string extension)
        {
            extension = default;
            #region Using_filesInfo_GetExtensionFileUsingFileInfo
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(filePath);
            extension = settings.Extension;
            #endregion            
            return 0;
        }

        public int GetLengthFileUsingFileInfo(string filePath, out long size)
        {
            size = default;
            #region Using_filesInfo_GetLengthFileUsingFileInfo
            if (filePath.IsEmpty())
                filePath = @".\fourthCoffee\settings.txt";
            //Instantiating the FileInfo Class
            FileInfo settings = new FileInfo(filePath);
            size = settings.Length;
            #endregion
            return 0;
        }
        #endregion
    }

    public static class ExtendString
    {
        public static bool IsEmpty(this string s) => s.Length == 0 ? true : false;

        public static void MakeItBold(this string s)
        {

            int currentColor = (int)ForegroundColor;
            ForegroundColor = System.ConsoleColor.Yellow;
            WriteLine(s);
            ForegroundColor = (ConsoleColor)currentColor;
        }

        public static void MakeItBold(this char c)
        {
            int currentColor = (int)ForegroundColor;
            ForegroundColor = System.ConsoleColor.Yellow;
            Write(c);
            ForegroundColor = (ConsoleColor)currentColor;
        }

        public static void MakeItBold(this string s, string message, bool after = true)
        {
            if (after)
            {
                Write(message);
                MakeItBold(s);
            }
            else
            {
                MakeItBold(s);
                Write(message);
            }

        }

    }
}