using FolderCreation.Features.CreateFolders;
using FolderCreation.Features.GetFoldersFromFile;
using FolderCreation.Features.ShowOutputMessages;


Console.WriteLine("Welcome to FolderCreator!");
Console.WriteLine("*************************");
Console.WriteLine();
Console.WriteLine("Lets get started! Pls enter the location where your file is stored.");
var location = Console.ReadLine();
Console.WriteLine();
Console.WriteLine();

var foldersFromFileResult = GetFoldersFromFile.Execute(System.IO.File.Exists, Path.IsPathRooted, location);
var outputMessages = CreateFolders.Execute(FolderCreator.Create, foldersFromFileResult);
ShowOutputMessages.Execute(Console.WriteLine, outputMessages);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Thank you for using FolderCreator!");


