using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
namespace Files7
{
    public class UsingDirectories
    {
        #region DirectoryClass
        //Manipulating Directories by using the Directory Class 
        public int CreateDirectory(string directoryPath, bool message = true)
        {
            #region Using_DirectoryClass_CreateDirectory
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            Directory.CreateDirectory(directoryPath);
            if (message)
                "CreateDirectory Method".MakeItBold($"Creando un directorio:{directoryPath}",false);
            #endregion 
            return 0;
        }

        public int DeleteDirectory(string directoryPath, bool message=true)
        {
            #region Using_DirectoryClass_DeleteDirectory
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            bool recursivelyDeleteSubContent = true; // System.IO.IOException if false and directory is not empty
            Directory.Delete(directoryPath, recursivelyDeleteSubContent);
            if (message)
                "DeleteDirectory Method".MakeItBold($"Borrando el directorio:{directoryPath}");
            #endregion
            return 0;
        }

        public int ExitsDirectory(string directoryPath, out bool exits)
        {
            #region Using_DirectoryClass_ExitsDirectory
            exits = default;
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            exits = Directory.Exists(directoryPath);
            #endregion
            return 0;
        }

        public int GetDirectories(string directoryPath)
        {
            #region Using_DirectoryClass_GetDirectories
            string[] getDirectories;
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            getDirectories = Directory.GetDirectories(directoryPath);

            foreach (var dir in getDirectories)
            {
                dir.MakeItBold();
            }
            #endregion
            return 0;
        }

        public int GetFiles(string directoryPath)
        {
            #region Using_DirectoryClass_GetFiles
            string[] getFiles;
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            getFiles = Directory.GetFiles(directoryPath);
            #endregion
            return 0;
        }
        #endregion

        #region DirectoryInfo
        //Namespace System.IO
        //Manipulating Directories by using the DirectoryInfo Class 
        //Act as an in-memory representation of a directory
        public int CreateDirectoryDirectoryInfo(string directoryPath, bool message = true)
        {
            #region Using_DirectoryInfoClass_CreateDirectoryDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            directory.Create();
            if (message)
                "Create Method of Directory Info Class".MakeItBold($"Creando el directorio:{directoryPath}\n", false);
            #endregion                
            return 0;
        }

        public int DeleteDirectoryDirectoryInfo(string directoryPath, bool message = true)
        {
            #region Using_DirectoryInfoClass_DeleteDirectoryDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            bool recursivelyDeleteSubContent = true; //System.IO.IOException if is false and directory no is empty
            directory.Delete(recursivelyDeleteSubContent);
            if (message)
                "Delete Method of Directory Info Class".MakeItBold($"Borrando el directorio:{directoryPath}\n", false);
            #endregion
            return 0;
        }

        public int ExitsDirectoryDirectoryInfo(string directoryPath, out bool exits)
        {
            #region Using_DirectoryInfoClass_ExitsDirectoryDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            exits = directory.Exists;
            #endregion
            return 0;
        }

        public int FullNameDirectoryInfo(string directoryPath, out string fullName)
        {
            #region Using_DirectoryInfoClass_FullNameDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            fullName = directory.FullName;
            #endregion
            return 0;
        }

        public int GetDirectoriesDirectoryInfo(string directoryPath)
        {
            #region Using_DirectoryInfoClass_GetDirectoriesDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            DirectoryInfo[] subDirectories = directory.GetDirectories();

            List<string> getDirectories = new List<string>();

            foreach (var dir in subDirectories)
            {
                getDirectories.Add(@$"{dir.Parent}-\{dir.Name}");

            }
            #endregion
            return 0;
        }

        public int GetFilesDirectoryInfo(string directoryPath)
        {
            #region Using_DirectoryInfoClass_GetFilesDirectoryInfo
            if (directoryPath.IsEmpty())
            {
                directoryPath = @".\fourthCoffee\tempData";
            }
            //Instantiating the DirectoryInfo Class 
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            FileInfo[] subDirectories = directory.GetFiles();

            List<string> getFiles = new List<string>();

            foreach (var file in subDirectories)
            {
                getFiles.Add(file.Name);

            }
            #endregion
            return 0;
        }
        #endregion

        public static void lecturaTeclado(string mensaje, out string lectura)
        {
            Write(mensaje);
            lectura = ReadLine();
        }
        public static void lecturaTeclado(string mensaje)
        {
            mensaje.MakeItBold();
            ReadKey();
        }
    }
}