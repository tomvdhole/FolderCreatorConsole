namespace FolderCreation.Features.ShowOutputMessages;

public static class ShowOutputMessages
{
    public static void Execute(Action<string> writer, List<string> outputMessages)
    {
        ArgumentNullException.ThrowIfNull(writer, nameof(writer));
        ArgumentNullException.ThrowIfNull(outputMessages, nameof(outputMessages));

        foreach (var message in outputMessages) 
            writer(message);
    }
}
