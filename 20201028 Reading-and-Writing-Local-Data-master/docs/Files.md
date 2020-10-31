
# File Class

##  Read and write data by using the File class. 
Namespace System.IO
Statics Methods, (do not cache) recommended for single operation on a file.

*The **File class** in the System.IO namespace exposes several static methods that you can use to perform transactional operations for direct reading and writing of files.* 

To Read data from file
1. Acquire the file handle.
2. Open a stream to the file.
3. Buffer the data from the file into memory.
4. Release the file handle so that it can be reused.          

### Reading Data from Files

The **ReadAllText** method enables you to read the contents of a file into a single string variable. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_read_all_text
```

The **ReadAllBytes**  method enables you to read the contents of a file as binary data and store the data in a byte array. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_ReadAllBytes
```

The **ReadAllLines** method enables you to read the contents of a file and store each line at a new index in a string array
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_ReadAllLines
```

### Writing Data to Files

The File class also provides methods that you can use to write different types of data to a file. For each of the different types of data you can write, the File class provides two methods:

- If the specified file does not exist, the **Write**xxx methods create a new file with the new data. If the file does exist, the **Write**xxx methods overwrite the existing file with the new data.
- If the specified file does not exist, the **Append**xxx methods also create a new file with the new data. However, if the file does exist, the new data is written to the end of the existing file.

The **WriteAllText** method enables you to write the contents of a string variable to a file. If the file
exists, its contents will be overwritten. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_WriteAllText
```

The **WriteAllBytes**  method enables you to write the contents of a byte array to a binary file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_WriteAllBytes
```
The **WriteAllLines** method enables you to write the contents of a string array to a file. Each entry in the string array represents a new line in the file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_WriteAllLines
```

The **AppendAllText** method enables you to write the contents of a string variable to the end of an existing file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_AppendAllText
```

The **AppendAllLines** method enables you to write the contents of a string array to the end of an existing file.
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_AppendAllLines
```

### Manipulating Files 
As well as reading from and writing to files,  applications typically require the ability to interact
with files stored on the file system. For example, your application may need to copy a file from the system directory to a temporary location before performing some further processing, or your application may need to read some metadata associated with the file, such as the file creation time. You can implement this type of functionality by using the File and FileInfo classes. 

### File Manipulation by using the File Class
The File class provides static methods that you can use to perform basic file manipulation. 

The **Copy** method enables you to copy an existing file to a different directory on the file system. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_Copying
```

The **Delete** method enables you to delete an existing file from the file system.
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_Deleting
```

The **Exists** method enables you to check whether a file exists on the file system. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_ExitsFile
```

The **GetCreationTime** method enables you to read the date time stamp that describes when a file was created, from the metadata associated with the file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_files_InfoCreationTime
```

# FileInfo Class

## File Manipulation by using the FileInfo class
The FileInfo class provides instance members that you can use to manipulate an existing file. In contrast to the File class that provides static methods for direct manipulation, the FileInfo class behaves like an inmemory representation of the physical file, exposing metadata associated with the file through properties, and exposing operations through methods. 

Namespace System.IO
File Manipulation by using the FileInfo class (Need to instanciate before using, cache info)
Rrecommended for performing multiple operations on the same file.

### File Manipulation by using the FileInfo Class

The **CopyTo** method enables you to copy an existing file to a different directory on the file system.
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_CopyingUsingFileInfo
```
The **Delete** method enables you to delete a file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_DeletingFileUsingFileInfo
```
The **DirectoryName**  property enables you to get the directory path to the file
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_NameOfDirectoryUsingFileInfo
```

The **Exists** method enables you to determine if the file exists within the file system. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_ExitsFileUsingFileInfo
```

The **Extension** property enables you to get the file extension of a file. 
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_GetExtensionFileUsingFileInfo
```

The **Length** property enables you to get the length of the file in bytes.
```cs --source-file ../src/UsingFiles.cs --project ../src/File7.csproj --region Using_filesInfo_GetLengthFileUsingFileInfo
```