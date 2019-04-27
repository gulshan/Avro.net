To build this project, .NET Core SDK (minimum version 3.0, currently preview) should be installed in the machine. The SDK can be found at https://get.dot.net .

The project can be opened and run with "Visual Studio 2019" or "Visual Studio Code" with C# extension.

It can also be build from command line with the following command-
```cmd
dotnet build
```

To run the project from command line, at first ensure the current directory contains `data.json` file. Then use this command-
```cmd
dotnet run --project SimplePadCore
```
If project is run from Visual studio or VS Code, the IDE/editor will use the `data.json` from the build directory. So, no manual copying is needed.