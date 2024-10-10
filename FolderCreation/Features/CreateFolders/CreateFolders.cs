using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.CreateFolders;

public class CreateFolders
{
    private readonly Func<Folder, Result> _createMethod;
    public CreateFolders(Func<Folder, Result> createMethod)
       => _createMethod = createMethod ?? throw new ArgumentNullException(nameof(createMethod));
    public Result Execute(Folder folder)
        => _createMethod(folder);
}
