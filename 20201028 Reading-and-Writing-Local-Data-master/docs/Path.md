# Path Class

## Manipulating File and Directory Paths 
All files and all directories have a name, which when combined to point to a file in a directory, constitute a path. Different file systems can have different  conventions and rules for what constitutes a path. The .NET Framework  provides the **Path** class, which encapsulates a variety of file system utility functions that you can use to parse and construct valid file names, directory names, and paths within the Windows file system. 

NameSpace System.IO

###  Getting the Path to the Windows Temporary Directory 
A better way is to use the static GetTempPath method provided by the Path class to get the path to the current user’s Windows temporary directory. 
```cs --source-file ../src/UsingPath.cs --project ../src/File7.csproj --region UsingPath_UsingATemporaryDirectory

```

###  Using another Paths methods 

The **Path** class includes many other static methods that provide a good starting point for any custom I/O type functionality that your application may require.

The **HasExtension** method enables you to determine if the path your application is processing has anextension. 
```cs --source-file ../src/UsingPath.cs --project ../src/File7.csproj --region UsingPath_UsingHasExtension       

```

The **GetExtension** method enables you to get the extension from a file name. This method is particularly useful when you want to ascertain what type of file your application is processing. 
```cs --source-file ../src/UsingPath.cs --project ../src/File7.csproj --region UsingPath_UsingGetExtension       

```

The **GetTempFileName** enables you to create a new temp file in your local Windows temporary directory in a single transactional operation folder. This method then returns the absolute path to that file, ready for further processing. 
```cs --source-file ../src/UsingPath.cs --project ../src/File7.csproj --region UsingPath_UsingGetTempFileName       

```