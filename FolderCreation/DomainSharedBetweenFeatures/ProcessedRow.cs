using SharedKernel;

namespace FolderCreation.DomainSharedBetweenFeatures;

public class ProcessedRow<T>
{
    public int RowNumber { get; }
    public bool DoNotProcess { get; }

    private Result<T>? resultFolder;

    public void SetResultFolder(Result<T>? resultFolder)
        => this.resultFolder = resultFolder;

    public Result<T>? GetResultFolder()  //No use of property because, this can throw an InvalidOperationException
    {
        if (!DoNotProcess)
            return resultFolder;
        else
            throw new InvalidOperationException(nameof(GetResultFolder));
    }

    public ProcessedRow(int rowNumber, bool doNotProcess, Result<T>? resultFolder)
    {
        RowNumber = rowNumber;
        DoNotProcess = doNotProcess;
        SetResultFolder(resultFolder);
    }
}


