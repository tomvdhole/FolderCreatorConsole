using FolderCreation.DomainSharedBetweenFeatures;
using SharedKernel;

namespace FolderCreation.Features.GetFoldersFromFile;

public static class GetFoldersFromFile
{
    public static Result<IReadOnlyList<ProcessedRow<Folder>>> Execute(Func<string, bool> doesFileExists, Func<string, bool> isPathRooted, string? location)
    {
        ArgumentNullException.ThrowIfNull(doesFileExists, nameof(doesFileExists));
        ArgumentNullException.ThrowIfNull(isPathRooted, nameof(isPathRooted));

        return File.Create(doesFileExists, location)
                   .Map(file => ExcelFolderRepository.GetAllItems(isPathRooted, file!));
    }
}
