using FolderCreation.DomainSharedBetweenFeatures;
using SharedKernel;

namespace FolderCreation.Features.CreateFolders;

public static class CreateFolders
{
    public static List<string> Execute(Func<Folder, Result> folderCreator, Result<IReadOnlyList<ProcessedRow<Folder>>> foldersFromFileResult)
    {
        ArgumentNullException.ThrowIfNull(folderCreator, nameof(folderCreator));
        ArgumentNullException.ThrowIfNull(foldersFromFileResult, nameof(foldersFromFileResult));

        return foldersFromFileResult.AddFoldersToWorkspace(folderCreator);
    }
}
