namespace CLT.Parser;

/// <summary>
/// A command
/// </summary>
public class Command
{
    public Action<Dictionary<string, string>> Action { get; set; }
    public string Name { get; set; }
    public string Template { get; set; }

    /// <summary>
    /// Creates a command
    /// </summary>
    /// <param name="action">The action that the command will run</param>
    /// <param name="name">The name of the command</param>
    /// <param name="template">The argument format of the command</param>
    public Command(Action<Dictionary<string, string>> action, string name, string template = "")
    {
        Action = action;
        Name = name;
        Template = template;
    }
}
