using System.Text;
using NPOI.XSSF.UserModel;
using SharedKernel;
using FolderCreation.DomainSharedBetweenFeatures;

namespace FolderCreation.Features.GetFoldersFromFile;

public enum ProcessingErrorType
{
    ErrorDuringProcessing
}

public static class ExcelFolderRepository
{
    public static Result<IReadOnlyList<ProcessedRow<Folder>>> GetAllItems(Func<string, bool> isPathRooted, File pathToFolders)
    {
        ArgumentNullException.ThrowIfNull(isPathRooted);
        ArgumentNullException.ThrowIfNull(pathToFolders);

        try
        {
            var fileStream = new FileStream(pathToFolders.FileLocation, FileMode.Open, FileAccess.Read);
            var workbook = new XSSFWorkbook(fileStream);
            var sheet = workbook.GetSheetAt(0);

            var processedRows = new List<ProcessedRow<Folder>>();

            if (sheet != null)
            {
                var builder = new StringBuilder();
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row != null &&
                        row.GetCell(0) != null &&
                        row.GetCell(0).NumericCellValue != 0)
                    {
                        if (row.GetCell(1) != null && row.GetCell(1).StringCellValue.Trim() != string.Empty)
                        {
                            builder.Append(row.GetCell(1).StringCellValue.Trim());

                            if (row.GetCell(2) != null && row.GetCell(2).StringCellValue.Trim() != string.Empty)
                            {
                                builder.Append($"\\{row.GetCell(2).StringCellValue.Trim()}");

                                if (row.GetCell(3) != null && row.GetCell(3).StringCellValue.Trim() != string.Empty)
                                {
                                    builder.Append($"\\{row.GetCell(3).StringCellValue.Trim()}");

                                    if (row.GetCell(4) != null &&
                                        row.GetCell(4).StringCellValue.Trim() != string.Empty)
                                    {
                                        builder.Append($"\\{row.GetCell(4).StringCellValue.Trim()}");

                                        if (row.GetCell(5) != null &&
                                            row.GetCell(5).StringCellValue.Trim() != string.Empty)
                                        {
                                            builder.Append($"\\{row.GetCell(5).StringCellValue.Trim()}");

                                            if (row.GetCell(6) != null &&
                                                row.GetCell(6).StringCellValue.Trim() != string.Empty)
                                            {
                                                builder.Append($"\\{row.GetCell(6).StringCellValue.Trim()}");

                                                if (row.GetCell(7) != null &&
                                                    row.GetCell(7).StringCellValue.Trim() != string.Empty)
                                                {
                                                    builder.Append($"\\{row.GetCell(7).StringCellValue.Trim()}");

                                                    if (row.GetCell(8) != null &&
                                                        row.GetCell(8).StringCellValue.Trim() != string.Empty)
                                                    {
                                                        builder.Append(
                                                            $"\\{row.GetCell(8).StringCellValue.Trim()}");

                                                        if (row.GetCell(9) != null &&
                                                            row.GetCell(9).StringCellValue.Trim() != string.Empty)
                                                        {
                                                            builder.Append(
                                                                $"\\{row.GetCell(9).StringCellValue.Trim()}");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            processedRows.Add(new ProcessedRow<Folder>(i + 1, false, Folder.Create(isPathRooted, builder.ToString())));
                            // new ProcessedRow(i + 1, ...  --> row processing starts from line 2, first line is headerline
                            builder.Clear();
                        }
                    }

                    if (row != null &&
                        row.GetCell(0) != null &&
                        row.GetCell(0).NumericCellValue == 0)
                    {
                        processedRows.Add(new ProcessedRow<Folder>(i + 1, true, null));
                        // new ProcessedRow(i + 1, ...  --> row processing starts from line 2, first line is headerline
                        builder.Clear();
                    }
                }
            }

            return Result<IReadOnlyList<ProcessedRow<Folder>>>.Succeed(processedRows);

        }
        catch (IOException)
        {
            return Result<IReadOnlyList<ProcessedRow<Folder>>>.Failed([new Error<ProcessingErrorType>(ProcessingErrorType.ErrorDuringProcessing)]);
        }
        catch (Exception)
        {
            return Result<IReadOnlyList<ProcessedRow<Folder>>>.Failed([new Error<ProcessingErrorType>(ProcessingErrorType.ErrorDuringProcessing)]);
        }
    }
}
