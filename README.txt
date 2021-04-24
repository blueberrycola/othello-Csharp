I made some slight adjustments to the structure of Othello in C#.

Driver.cs does not exist because I found a way to compact it into Main in Othello.cs
OuttaBounds() and CheckDirection() are used for cleaner code inside ValidMove() and PlaceDisc()
To make sure my code worked I ran the last 3 tests given for the other Othello inside main and checked output.
Input starts at 0 til size-1. The reason I did this is it makes quick testing of functions inside main easier.
All code was tested and compiled on Visual Studio 2019
