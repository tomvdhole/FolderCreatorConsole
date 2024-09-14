using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.CreateFolders;

public static class CreateFolders
{
    public static Result Execute(Folder folder, Func<Folder, Result> createMethod)
    {
        ArgumentNullException.ThrowIfNull(folder);
        ArgumentNullException.ThrowIfNull(createMethod);

        return createMethod(folder);
    }
}
