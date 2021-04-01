# Reventure (Game-Server)
# Project Description #
Reventure is a web-browser adventure game where players can explore an open world to slay mobs and gain experience to reach the leaderboard's top score.
However, the mobs the player faces are strong and may appear in large numbers, being capable of defeating the player if the player is not careful. The project is divided into 2 parts: the server (this repo) and the client (https://github.com/2102-feb08-net/Game-Client).

# Technologies #
* C#
* <nolink>ASP.NET</nolink>
* Entity Framework
* HTML/CSS
* Angular
* TypeScript
* Okta
* Microsoft Azure
* SQL Server
* xUnit

# Features #
* Player can fight mobs.
* Mobs target player within a specific range.
* Player can acquire mob loot which increases character exp.
* Player can view their stats.
* Leaderboards based on player's total exp.

To-do list:
* Refactor authentication with Okta to allow multiple users to login to the game.
* Save player inventory to the database so that they can have their loot next time they log in.

# Getting Started #
Use the commands below to clone the client and server repositories:
```
git clone https://github.com/2102-feb08-net/Game-Client

git clone https://github.com/2102-feb08-net/Game-Server.git
```

Open Visual Studio Code and follow the instructions below:
1. To start the server:
   * Open the folder that contains the Game-Server repository
   * Open a new terminal in Visual Studio Code.
   * In the terminal:
      * Use the dotnet run command to run the project 'Game-Server-Solution/GameAPI'
         ```
         dotnet run -p Game-Server-Solution/GameAPI
         ```
2. To run the browser application:
   * Open the folder that contains the Game-Client repository in a new Visual Studio Code window.
   * Open a new terminal in Visual Studio Code.
   * In the terminal:
      * Use the cd command to move to the directory 'browser-game.'
         ```
         cd browser-game
         ```
      * Run the command 'npm install' to get all the packages and dependencies needed for the project to run. 
         ```
         npm install
         ```
      * Once the installation is finished, run the command 'ng serve -o' to launch the application in a new browser tab.
         ```
         ng serve -o
         ```

A new browser tab should have opened after a while and you can start playing the game!  

Alternatively, you can skip the steps before if you just want to play the game by following this link: https://reventure-game-client.azurewebsites.net/

# Usage #
Controls:
* W - Move up.
* A - Move left.
* S - Move down.
* D - Move right.
* Spacebar - Attack (The character will not be able to move when attacking).

Options:
* Stats - displays the current health, attack, defense, and other attributes of the player's character.
* Leaderboard - displays a list of players with the highest amount of exp.
* Logout - closes the player's session.
* Login - allows player to access the game and its character.

Objective:
* As mentioned in the project description, Reventure is an open world game where the player can kill mobs to gather exp and get to the top of the leaderboard. Mobs spawn at random locations in the map and may appear in big groups; they are strong and can bring the player down if the player is not careful.

# Contributors #
* Cole Samuelsen
* Hamza Butt
* Diego Rincon