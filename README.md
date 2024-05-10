# Command Line Toolkit

The Command Line Toolkit provides a framework for easily creating CLI applications

## Getting Started

* Clone the repository to a solution
* Add `CLT` as a project reference

## Usage

### Parsing Command Line Input

Create a list of commands that will be used for parsing
```csharp
Command[] commands = new Command[] {
    new Command(action, "name", "argument format")
};
```

Use `ParseCommand` to determine which command should be run
```csharp
Command command = Parser.ParseCommand(commands, args);
```

Use `ParseArguments` to retrive a dictionary of needed arguments for `command`
```csharp
Dictionary<string, string> arguments = Parser.ParseArguments(command, args[1..]);
```

Run the `command` with the given `arguments`
```csharp
command.Action(arguments);
```

 
## Authors

 - [Michael Canudas](https://github.com/michaelcanudas)


## License

This project is licensed under the MIT License - see the `LICENSE` file for more details