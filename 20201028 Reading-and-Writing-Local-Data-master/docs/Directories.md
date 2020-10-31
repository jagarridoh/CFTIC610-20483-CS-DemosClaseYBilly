# Directory Class

## Manipulating Directories by using the Directory Class 
Name

Similar to the **File class**, the **Directory class**  provides static methods that enable you to interact with directories, without instantiating a directory-related object in your code.

The **CreateDirectory** method enables you to create a new directory on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryClass_CreateDirectory
```

The **Delete**  method enables you to delete a directory at a specific path.
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryClass_DeleteDirectory
```

The **Exists** method enables you to determine if a directory exists on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryClass_ExitsDirectory
```
The **GetDirectories**  method enables you to get a list of all subdirectories within a specific directory on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryClass_GetDirectories
```

The **GetFiles** method enables you to get a list of all the files within a specific directory on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryClass_GetFiles
```

# DirectoryInfo Class

## Manipulating Directories by using the DirectoryInfo Class
The **DirectoryInfo** class acts as an in-memory representation of a directory. Before you can access the properties and execute the methods that the DirectoryInfo class exposes, you must create an instance of the class. 

The **Create** method enables you to create a new directory on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_CreateDirectoryDirectoryInfo
```
The **Delete** method enables you to delete a directory at a specific path.
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_DeleteDirectoryDirectoryInfo
```
The **Exists** property enables you to determine if a directory exists on the file system. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_ExitsDirectoryDirectoryInfo
```

The **FullName** property enables you to get the full path to the directory. 
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_FullNameDirectoryInfo
```
The **GetDirectories** method enables you to get a list of all subdirectories within a specific directory on the file system.
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_GetDirectoriesDirectoryInfo
```
The **GetFiles** method enables you to get a list of all the files within a specific directory on the file system.
```cs --source-file ../src/UsingDirectories.cs --project ../src/File7.csproj --region Using_DirectoryInfoClass_GetFilesDirectoryInfo
```
