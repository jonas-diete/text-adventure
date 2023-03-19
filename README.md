# Text Adventure - Into The Light

This is a project that helped me consolidate my C# skills.  

I focused on writing neat high-quality code using OOP, making the game easy to adapt and even enabling users to write their own text adventures easily.

This is a console application. It uses C# (.NET 6.0 framework) and NUnit for testing.

### How to Play
1. Download this repository (or alternatively just download the "Into The Light" folder).
2. Change directory into the downloaded folder and then to the "Into The Light" folder.
3. Run `TextAdventure.exe`. Alternatively run `dotnet TextAdventure.dll`.
4. Play!

This is a Text Adventure in the tradition of the great 1970s Adventure games like Zork or The Hitchhiker's Guide to the Galaxy.   
You have to navigate the world by typing commands into the console.  
Traditionally they are commands like `Go to ...`, `Look at ...` or `Open ...`, but part of the fun is to try to work out the correct commands to progress in the game. If you type in an unkown command the game will tell you.  
  
![game-screenshot](./game-screenshot.jpg)  

### How to build your own text adventure
I built this adventure so that it is simple to edit. Other levels and text adventures can be built easily by editing the CSV file in the game directory. You can write your own adventure game, by looking at the `levels.csv` file inside the `TextAdventure` folder and editing this. You can write the levels and the actions that the player can perform in each level. My program will make it into a working text adventure.
Here is an example of the CSV file:  
  
![csv-screenshot](./csv-screenshot.jpg)

When working on this project, I created an overview of my classes with Excalidraw to help me keep an overview of the different variables and methods and how everything links together.

![classes-overview](./classes-overview.png)

I used NUnit to test the functions of the program. To understand what each of the functions do and how they work, you can read the tests. The test files are all in the /TextAdventure.Tests folder.

### How to run the tests:
1. Download this repository.
2. Change into the the `TextAdventure.Tests` directory.
3. Type in `dotnet test`.