using FolderCreation.DomainSharedBetweenFeatures;
using SharedKernel;

namespace FolderCreation.Features.CreateFolders;

public static class ResultExtensions
{
    public static List<string> AddFoldersToWorkspace(this Result<IReadOnlyList<ProcessedRow<Folder>>> result, Func<Folder, Result> folderCreator)
    {
        ArgumentNullException.ThrowIfNull(folderCreator);

        var outputMessages = new List<string>();

        if (!result.IsSuccess)
            outputMessages.Add($"{result.Errors.MakeErrorsUserFriendly()}");
        else
            foreach (var processedRow in result.Value!)
                if (processedRow.DoNotProcess)
                {
                    outputMessages.Add($"{processedRow.RowNumber} - OK - Folder not selected to be processed!");
                }
                else
                {
                    var resultFolder = processedRow.GetResultFolder();
                    if (!resultFolder!.IsSuccess)
                    {
                        outputMessages.Add($"{processedRow.RowNumber} - NOT-OK - {resultFolder.Errors.MakeErrorsUserFriendly()}");
                    }
                    else 
                    { 
                        var resultCreatedFolder = folderCreator(resultFolder.Value!);
                        if (!resultCreatedFolder.IsSuccess)
                            outputMessages.Add($"{processedRow.RowNumber} - NOT-OK - {resultCreatedFolder.Errors.MakeErrorsUserFriendly()}");
                        else
                            outputMessages.Add($"{processedRow.RowNumber} - OK - {processedRow.GetResultFolder()!.Value!.Name}");
                    }
                }

        return outputMessages;
    }
}
