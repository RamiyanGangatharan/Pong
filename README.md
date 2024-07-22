# Pong Game

## Overview
Pong Game is a modern take on the classic arcade game where you play solo, hitting the ball against the wall. The game includes multiple scenes such as Main Menu, Game Over, and an About section to provide information about the game and its creators.

## Features
- Single-player mode
- Simple and intuitive controls
- Game Over screen when the game ends
- About section with game and developer information

## Scenes
- **MainMenu**: The main menu of the game where you can start the game or view the about section.
- **MainScene**: The main gameplay scene where the Pong game takes place.
- **GameOver**: The scene displayed when the game ends, showing a message and providing options to restart or return to the main menu.
- **About**: Provides information about the game, developers, credits, and contact details.

## Controls
- **Player**:
  - Move Up: `W`
  - Move Down: `S`

## Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/pong-game.git
    ```
2. Open the project in Unity.
3. Ensure all necessary scenes are added to the Build Settings:
    - MainMenu
    - MainScene
    - GameOver
    - About
4. Play the game in the Unity Editor or build it for your preferred platform.

## Usage
### Starting the Game
- Launch the game and navigate to the Main Menu.
- Select "Start Game" to begin playing.
- To view information about the game, select "About."

### Ending the Game
- The game ends when the ball passes the player's paddle.
- The Game Over screen will appear, displaying a message and options to restart or return to the main menu.

### Exiting the Game
- To exit the game, select the "Exit" button from the Main Menu or the Game Over screen.
- In standalone builds, this will close the game application.

## About Section
The About section includes:
- Game Title and Version
- Game Description
- Developer Information
- Credits
- Contact Information
- Legal Information
- Special Thanks

## Development
### Scripts
- **GameController.cs**: Manages the overall game logic, including score updates, UI updates, and game over conditions.
- **BallController.cs**: Controls the ball's behavior, movement, and collision with the paddle and walls.
- **MainMenuController.cs**: Handles navigation between the Main Menu, About section, and game scenes.

### Setting Up the About Panel
1. Create a new UI Panel in the Main Menu scene.
2. Add Text components for each section of the About information.
3. Add a Button to close the About panel and return to the Main Menu.
4. Assign these UI elements to the `MainMenuController` script in the Unity Inspector.

## License
Pong Game © 2024 by John Doe and Jane Smith. All rights reserved.

## Special Thanks
Special thanks to our family and friends for their support during development.
