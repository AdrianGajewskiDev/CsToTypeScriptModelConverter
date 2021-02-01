# CsToTypeScriptModelConverter
## Convert C# Models, ViewModels and DTOs into their TypeScript equivalents.
Link: https://marketplace.visualstudio.com/items?itemName=AdrianDev.exr123

___

## Usage:

*Paste the CSharp class and click "Convert"*

![Paste Image](https://github.com/AdrianGajewski1/CsToTypeScriptModelConverter/blob/main/Converter.UI/Paste.PNG?raw=true)

## Result:
![Paste Image](https://github.com/AdrianGajewski1/CsToTypeScriptModelConverter/blob/main/Converter.UI/convert.PNG?raw=true)

___
# Using the CLI tool
### Description
This CLI tool allows to convert multiple code files and save them to specified directory without doing 
it one by one.

### Requirements:
 * Visual Studio 2019
 * Dotnet SDK
### Usage:
 * Clone the repository
 * Go to project root directory
 * Run: 
    ``` cmd
    dotnet build
    ```
 * Go to Converter.CLI\bin\Debug\netcoreapp3.1\win7-x64 and call
    ``` cmd
    dotnet ConverterCLI.dll f  --dir <path of files to convert> --out <your output directory> 
    ```