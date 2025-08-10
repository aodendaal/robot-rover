# robot-rover

A console app solution for the Developer Programming Problem by Red Badger. This project includes the console app and unit test library.

The project reads a file `input.txt` and generates a file `output.txt`.

The input file must follow the specification indicated in the project definition or it will be ignored.

## Installation
Use Visual Studio or `dotnet build` to build the project

## Usage
With the console app created, generate a file file named `input.txt` and run the console app.

```bash
./robot-rover
```
This will generate a file `output.txt` with the final position of the robots from the input.

## Considerations
I have a abstract class `AbstractRobot` which uses an instruction interface 'IInstructionProperties` which my core robot is built upon and can be extended to support new instruction and new robot properties without affecting default behavior.
