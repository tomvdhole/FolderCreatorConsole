using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.GetFoldersFromFile;

public static class GetFoldersFromFile
{
    public static Result<IReadOnlyList<ProcessedRow<Folder>>> Execute(string? pathToFileWithFolders, Func<string, bool> doesFileExists)
    {
        ArgumentNullException.ThrowIfNull(doesFileExists);

        Result<IReadOnlyList<ProcessedRow<Folder>>> result = File.Create(pathToFileWithFolders, doesFileExists)
                                                                 .Map(file => new ExcelFolderRepository().GetAllItems(file!));

        return result;
    }
}





