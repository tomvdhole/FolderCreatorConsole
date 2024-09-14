using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.ShowDisplayStatus;

public static class ResultExtensionsForDisplayingStatus
{
    public static void ShowDisplayStatus(this Result<IReadOnlyList<ProcessedRow<Folder>>> result, Action<string> writer, Func<Folder, Func<Folder, Result>, Result> folderCreatorExecutor, Func<Folder, Result> folderCreator)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(folderCreatorExecutor);
        ArgumentNullException.ThrowIfNull(folderCreator);

        if (!result.IsSuccess)
            writer($"Error: {string.Join(", ", result.Errors)}");
        else
            foreach (var processedRow in result.Value!)
                if (processedRow.DoNotProcess)
                {
                    writer($"{processedRow.RowNumber} - OK - Folder not selected to be processed!");
                }
                else
                {
                    var resultFolder = processedRow.GetResultFolder();
                    if (resultFolder is null || !resultFolder.IsSuccess)
                    {
                        writer($"{processedRow.RowNumber} - NOT-OK - {(resultFolder is null ? string.Empty : string.Join(", ", resultFolder.Errors))}");
                    }
                    else
                    {
                        var resultCreatedFolder = folderCreatorExecutor(resultFolder.Value!, folderCreator);
                        if (!resultCreatedFolder.IsSuccess)
                            writer($"{processedRow.RowNumber} - NOT-OK - {(resultCreatedFolder is null ? string.Empty : string.Join(", ", resultCreatedFolder.Errors))}");
                        else
                            writer($"{processedRow.RowNumber} - OK - {resultFolder.Value!.Name}");
                    }
                }
    }
}
