using System;
using System.IO;
using static System.Console;
namespace Files7
{
    class UsingPath
    {
        public int UsingATemporaryDirectory(string tempDirectoryPath)
        {
            #region UsingPath_UsingATemporaryDirectory
            if (tempDirectoryPath.IsEmpty())
                // avoid many assumptions, including whether your application has the necessary
                // privileges to perform I/O at the root of the specific drive
                tempDirectoryPath = Path.GetTempPath(); //getting path of current user's Windows temporary directory
            tempDirectoryPath.MakeItBold("Directorio temporal en:");
            #endregion
            return 0;
        }

        public int UsingHasExtension(string filePath)
        {
            #region UsingPath_UsingHasExtension         
            if (filePath.IsEmpty())
                filePath = @$"{System.Environment.CurrentDirectory}\temp\settings.txt";
            WriteLine(filePath);
            //Return bool
            Path.HasExtension(filePath);
            #endregion
            return 0;
        }

        public int UsingGetExtension(string filePath)
        {
            #region UsingPath_UsingGetExtension            
            if (filePath.IsEmpty())
                filePath = @$"{System.Environment.CurrentDirectory}\temp\settings.txt";
            WriteLine(filePath);
            WriteLine(Path.GetExtension(filePath));
            #endregion
            return 0;
        }

        public int UsingGetTempFileName()
        {
            #region UsingPath_UsingGetTempFileName  
            string tempPath = Path.GetTempFileName();
            WriteLine(tempPath);
            new UsingFiles().AppendAllLines(tempPath);
            #endregion
            return 0;
        }

    }
}