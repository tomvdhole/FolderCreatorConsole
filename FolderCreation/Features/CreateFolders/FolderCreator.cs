using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.CreateFolders;

public static class FolderCreator
{
    public static Result Create(Folder pathToFolder)
    {
        ArgumentNullException.ThrowIfNull(pathToFolder);

        try
        {
            Directory.CreateDirectory(pathToFolder.Name);
            return Result.Succeed();
        }
        catch (Exception)
        {
            return Result.Failed([new Error<CreationErrorType>(CreationErrorType.ErrorDuringCreation)]);
        }
    }
}