using System;
using static System.Console;
namespace Files7
{
    class Program
    {
        static int Main(
             string region = null,
             string session = null,
             string package = null,
             string project = null,
             string[] args = null)
        {
            bool exits = false;
            string directoryName = default;
            string extension = default;
            long size = default;
            string fullName = default;
            return region switch
            {
                "Using_files_read_all_text" => new UsingFiles().ReadAllText(""),
                "Using_files_ReadAllLines" => new UsingFiles().ReadAllLines(""),
                "Using_files_ReadAllBytes" => new UsingFiles().ReadAllBytes(""),
                "Using_files_WriteAllText" => new UsingFiles().WriteAllText(""),
                "Using_files_WriteAllLines" => new UsingFiles().WriteAllLines(""),
                "Using_files_WriteAllBytes" => new UsingFiles().WriteAllBytes(""),
                "Using_files_AppendAllText" => new UsingFiles().AppendAllText(""),
                "Using_files_AppendAllLines" => new UsingFiles().AppendAllLines(""),
                "Using_files_Copying" => new UsingFiles().Copying("", ""),
                "Using_files_Deleting" => new UsingFiles().Deleting(""),
                "Using_files_ExitsFile" => new UsingFiles().ExitsFile("", out exits),
                "Using_files_InfoCreationTime" => new UsingFiles().InfoCreationTime(""),
                "Using_filesInfo_CopyingUsingFileInfo" => new UsingFiles().CopyingUsingFileInfo("", ""),
                "Using_filesInfo_DeletingFileUsingFileInfo" => new UsingFiles().DeletingFileUsingFileInfo(""),
                "Using_filesInfo_NameOfDirectoryUsingFileInfo" => new UsingFiles().NameOfDirectoryUsingFileInfo("", out directoryName),
                "Using_filesInfo_ExitsFileUsingFileInfo" => new UsingFiles().ExitsFileUsingFileInfo("", out exits),
                "Using_filesInfo_GetExtensionFileUsingFileInfo" => new UsingFiles().GetExtensionFileUsingFileInfo("", out extension),
                "Using_filesInfo_GetLengthFileUsingFileInfo" => new UsingFiles().GetLengthFileUsingFileInfo("", out size),
                "Using_DirectoryClass_CreateDirectory" => new UsingDirectories().CreateDirectory(""),
                "Using_DirectoryClass_DeleteDirectory" => new UsingDirectories().DeleteDirectory(""),
                "Using_DirectoryClass_ExitsDirectory" => new UsingDirectories().ExitsDirectory("", out exits),
                "Using_DirectoryClass_GetDirectories" => new UsingDirectories().GetDirectories(""),
                "Using_DirectoryClass_GetFiles" => new UsingDirectories().GetFiles(""),
                "Using_DirectoryInfoClass_CreateDirectoryDirectoryInfo" => new UsingDirectories().CreateDirectoryDirectoryInfo(""),
                "Using_DirectoryInfoClass_DeleteDirectoryDirectoryInfo" => new UsingDirectories().DeleteDirectoryDirectoryInfo(""),
                "Using_DirectoryInfoClass_ExitsDirectoryDirectoryInfo" => new UsingDirectories().ExitsDirectoryDirectoryInfo("", out exits),
                "Using_DirectoryInfoClass_FullNameDirectoryInfo" => new UsingDirectories().FullNameDirectoryInfo("", out fullName),
                "Using_DirectoryInfoClass_GetDirectoriesDirectoryInfo" => new UsingDirectories().GetDirectoriesDirectoryInfo(""),
                "Using_DirectoryInfoClass_GetFilesDirectoryInfo" => new UsingDirectories().GetFilesDirectoryInfo(""),
                "UsingPath_UsingATemporaryDirectory" => new UsingPath().UsingATemporaryDirectory(""),
                "UsingPath_UsingHasExtension" => new UsingPath().UsingHasExtension(""),
                "UsingPath_UsingGetExtension" => new UsingPath().UsingGetExtension(""),
                "UsingPath_UsingGetTempFileName" => new UsingPath().UsingGetTempFileName(),
                null => RunAll(),
                _ => MissingTag(region),
            };

        }
        private static int MissingTag(string tag, bool region = true)
        {
            WriteLine($"No code snippet configured for {(region ? "region" : "session")}: {tag}");
            return 1;
        }
        private static int RunAll()
        {
            // 1- 5
            new UsingFiles().ReadAllText("");
            return 0;
        }
    }
}
