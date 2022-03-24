# RestInFSharp
This project was generated using ASP.NET Core Version 6.0.3
##Instalation
- In order to run this project you will need to install .NET version 6.0 to use the CLI commands. In this [link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) you will find the installer for each OS.
- After this clone the repo locally and set your MongoDB credentials in the PlanetController.fs file in lines 23, 26 and 29.
- Now you can run the project from CLI with the command:
```
dotnet run
```
##URIs
######GET URI
https://localhost:7235/Planet
######GET by ID URI
https://localhost:7235/Planet/{id}
######POST
https://localhost:7235/Planet
This method must send with a body
######PUT by ID URI
https://localhost:7235/Planet/{id}
This method must send with a body
######DELETE by ID URI
https://localhost:7235/Planet

Note: The port could change according your PC
