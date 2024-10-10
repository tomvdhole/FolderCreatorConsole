using FolderCreation.Features.GetFoldersFromFile;
using FolderCreation.Features.CreateFolders;
using FolderCreation.Features.ShowDisplayStatus;

Console.WriteLine("Welcome to FolderCreator!");
Console.WriteLine("*************************");
Console.WriteLine();
Console.WriteLine("Lets get started! Pls enter the location where your file is stored.");
var location = Console.ReadLine();
Console.WriteLine();
Console.WriteLine();

GetFoldersFromFile.Retrieve(location, System.IO.File.Exists)
                  .ShowDisplayStatus(Console.WriteLine, 
                                     FolderCreator.Create);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Thank you for using FolderCreator!");


