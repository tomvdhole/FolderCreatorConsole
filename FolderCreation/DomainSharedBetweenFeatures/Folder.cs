using SharedKernel;

namespace FolderCreation.DomainSharedBetweenFeatures;

public sealed class Folder
{
    public string Name { get; }

    private Folder(string name) { Name = name; }

    public static Result<Folder> Create(Func<string, bool> isPathRooted, string name)
    {
        ArgumentNullException.ThrowIfNull(isPathRooted);

        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            return Result<Folder>.Failed([new Error<FolderErrorType>(FolderErrorType.FolderNameNotProvided)]);

        try
        {
            if (!isPathRooted(name))
                return Result<Folder>.Failed([new Error<FolderErrorType>(FolderErrorType.PathWithoutRoot)]);
            else
                return Result<Folder>.Succeed(new Folder(name));
        }
        catch (ArgumentException)
        {
            return Result<Folder>.Failed([new Error<FolderErrorType>(FolderErrorType.ErrorInPath)]);
        }
    }
}
