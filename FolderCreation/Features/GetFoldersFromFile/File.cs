using SharedKernel;

namespace FolderCreation.Features.GetFoldersFromFile;

public sealed record class File
{
    public string FileLocation { get; }

    private File(string fileLocation) { FileLocation = fileLocation; }

    public static Result<File> Create(Func<string, bool> doesFileExists, string? fileLocation)
    {
        ArgumentNullException.ThrowIfNull(doesFileExists);

        if (string.IsNullOrEmpty(fileLocation) || string.IsNullOrWhiteSpace(fileLocation))
            return Result<File>.Failed([new Error<FileErrorType>(FileErrorType.FileNameNotProvided)]);

        return doesFileExists(fileLocation) ? Result<File>.Succeed(new File(fileLocation)) : Result<File>.Failed([new Error<FileErrorType>(FileErrorType.FileDoesNotExists)]);
    }
}
