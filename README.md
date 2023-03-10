# Text Adventure - Into The Light

This is a little project to help me consolidate my C# skills.  

I focused on writing neat high-quality code using OOP.

This is a console application. It uses C# (.NET 6.0 framework) and NUnit for testing.

## How to Play
1. Download this repository (or alternatively just download the "Into The Light" folder).
2. Change directory into the downloaded folder and then to the "Into The Light" folder.
3. Run `TextAdventure.exe`. Alternatively run `dotnet TextAdventure.dll`.
4. Play!

This is a Text Adventure in the tradition of the great 1970s Adventure games like Zork or The Hitchhiker's Guide to the Galaxy.   
You have to navigate the world by typing commands into the console.  
Traditionally they are commands like `Go to ...`, `Look around` or `Open ...`, but part of the fun is to try to work out the correct commands to get to progress in the game. If you type in an unkown command the game will tell you.

I built this adventure to be simple to edit and to write new levels and other text adventures easily. All you need to do is write a CSV file with a bunch of headings like level and action descriptions and the program will make it into a working text adventure.  
Here is an example of the CSV file:
![csv-screenshot](./csv-screenshot.jpg)

I created an overview of my classes with Excalidraw to help me keep an overview of the different variables and methods and how everything links together.

![classes-overview](./classes-overview.png)