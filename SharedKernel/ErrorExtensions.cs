using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel;

public static class ErrorExtensions
{
    public static string MakeErrorsUserFriendlyer(this string errors)
    {
        var builder = new StringBuilder();
        var splittedErrors = errors.Split(", ");
        
        foreach (var error in splittedErrors)
            builder.AppendLine($"Error: {AddSpaceWhenCaption(error)}");

        return builder.ToString();
    }

    private static string AddSpaceWhenCaption(string sentence)
    {
        StringBuilder sentenceWithSpaces = new();
        for(int i = 0; i < sentence.Length; i++)
            if (char.IsUpper(sentence[i]) && i == 0) //Begin of sentence
                sentenceWithSpaces.Append(sentence[i]);
            else if (char.IsUpper(sentence[i]) && i != 0)
                    sentenceWithSpaces.Append($" {char.ToLower(sentence[i])}");
                 else
                    sentenceWithSpaces.Append(char.ToLower(sentence[i]));

        return sentenceWithSpaces.ToString();
    }
}
