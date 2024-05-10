namespace CLT.Parser;

/// <summary>
/// Parses command line inputs to be used for running commands
/// </summary>
public class Parser
{
    /// <summary>
    /// Parses a command line input and determines which command should be run
    /// </summary>
    /// <param name="commands">The commands that could be run</param>
    /// <param name="input">Command line input</param>
    /// <returns>The command from "commands" that should be run</returns>
    /// <exception cref="ArgumentNullException">No command line input</exception>
    /// <exception cref="ArgumentException">No matching command for command line input</exception>
    public static Command ParseCommand(Command[] commands, string[] input)
    {
        if (!input.Any())
            throw new ArgumentNullException("No arguments found");

        Command? command = commands.FirstOrDefault((c) => c.Name == input[0]);
        if (command is null)
            throw new ArgumentException($"No command '{input[0]}' found");

        return command;
    }

    /// <summary>
    /// Parses a command line input and genereates a dictionary of all arguments needed for "command"
    /// </summary>
    /// <param name="command">The command that needs its arguments parsed</param>
    /// <param name="input">Command line input</param>
    /// <returns>The organized argument list for "command"</returns>
    /// <exception cref="ArgumentException">Missing a required argument in command line input</exception>
    public static Dictionary<string, string> ParseArguments(Command command, string[] input)
    {
        if (command.Template == string.Empty)
            return new Dictionary<string, string>();

        Dictionary<string, string> arguments = new Dictionary<string, string>();

        int i = 0;
        string[] components = command.Template.Split();
        foreach (string component in components)
        {
            if (component.EndsWith("?"))
            {
                string key = component[0..(component.Length - 1)];

                if (i < input.Length)
                    if (input[i] == key)
                        arguments[input[i++]] = "true";
                    else
                        arguments[key] = "false";
                else
                    arguments[key] = "false";
            }
            else
            {
                if (i < input.Length)
                    if (!components.Contains(input[i] + "?"))
                        arguments[component] = input[i++];
                    else
                        throw new ArgumentException($"Missing argument '{component}'");
                else
                    throw new ArgumentException($"Missing argument '{component}'");
            }
        }

        return arguments;
    }
}
