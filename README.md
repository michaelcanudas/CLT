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

### Creating an Argument Template

Every space-separated phrase is considered a component of the template
```csharp
"component1 component2 component3"
```

Named Components are used to assign a given argument a name
```csharp
// The first argument will have key "wow"
"wow so cool"
```

Optional Components are used for flags, and end with a `?`
```csharp
// Running the command with "[arg1] [arg2]" and "[arg1] [arg2] -three" works
"one two -three?"
```

For example:
```csharp
Command command = new Command(Example, "example", "one two -three? four");

// input = ["this is great"]
Dictionary<string, string> arguments = Parser.ParseArguments(command, input);

// arguments["one"] == "this"
// arguments["two"] == "is"
// arguments["-three"] == "false"
// arguments["four"] == "great"
```

 
## Authors

 - [Michael Canudas](https://github.com/michaelcanudas)


## License

This project is licensed under the MIT License - see the `LICENSE` file for more details
