# robot-rover

A console app solution for the Developer Programming Problem by Red Badger. This project includes the console app and unit test library.

The project reads a text file of instructions, will print the results to the console as well as generates a file of results `output.txt`.

The input file must follow the specification indicated in the project definition or an error message will be written to the console with the issue encountered.

## Installation
You can build the app using Visual Studio or use `dotnet build` in the console.

You can also run the app using `dotnet run --project robot-rover`

## Usage
The app expects a file path as an argument.

Example:
```bash
./robot-rover input.txt
```
You can also run the app using `dotnet`. Please the input file in the same directory as the solution (.sln file) then run `dotnet run --project robot-rover filename.txt`.

This will generate a file `output.txt` with the final position of the robots from the input. The output will also be written to the console.

The example input file is already available, so to quickly see that the app works using `dotnet run --project robot-rover input-example.txt`

## Methodology
I have a abstract class `AbstractRobot` which can execute instructions, and a base robot that can sit or stand as a "least implementation" example.

I created a `CoreRobot` class as the robot used for the exercise.

I created a `MoveBackRobot` class, another robot that extends the core with an additional instructions to demonostrate extensibility.

I previously had interfaces and external instructions but I didn't like that it exposed internal data, and this seemed a simple solution.

## Considerations
In the corners of the map, it's possible for one robot to go off an edge in one direction, leaving a scent; and second robot going in the adjacent direction overriding the scent.

I ran out of time to properly test the input file processing and hardening the process against a dirty input file.

I probably could also have come up with more unit tests given more time.
