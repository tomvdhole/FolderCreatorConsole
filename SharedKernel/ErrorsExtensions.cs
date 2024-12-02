using System.Collections.Immutable;
using System.Text;

namespace SharedKernel;

public static class ErrorsExtensions
{
    public static string MakeErrorsUserFriendly(this ImmutableList<IError> errors)
    {
        if (errors.IsEmpty)
            throw new InvalidOperationException("There are no errors generated!");

        var builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendLine("Errors:");
        foreach (IError error in errors)
            builder.AppendLine(ParseError(error?.ToString() ?? throw new ApplicationException("Error is not defined!")));

        return builder.ToString();
    }

    private static string ParseError(string error)
    {
        var builder = new StringBuilder(char.ToUpper(error[0]).ToString());
        for (var i = 1; i < error.Length; i++)
            if(char.IsUpper(error[i]))
                builder.Append($" {char.ToLower(error[i])}");
            else
                builder.Append(error[i]);

        return builder.Append('.').ToString();
    }
}
