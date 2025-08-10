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

## Methodology
I have a abstract class `AbstractRobot` which can execute instructions, and a base robot that can sit or stand as a "least implementation" example.

I created a core robot used for the exercise.

I created a robot that extends the core with an additional instructions to demonostrate extensibility.

I previously had interfaces and external instructions but I didn't like that it exposed internal data.

## Considerations
In the corners of the map, it's possible for one robot to go off an edge in one direction, leaving a scent; and second robot going in the adjacent direction overriding the scent;
