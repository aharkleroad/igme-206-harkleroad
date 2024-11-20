# Project Unity SHMUP

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Aizlynn Harkleroad
-   Section: 206.01

## Game Design

-   Camera Orientation: Topdown view
-   Camera Movement: Fixed camera, no movement, player will collide with the edge of the screen (no wrap around to the other side)
    - (If the player goes off the right side of the screen, they will lose)
-   Player Health: Player health will take the form of individual lives rather than a health bar
-   End Condition: The level ends when the player loses all their lives or exits the right side of the screen
-   Scoring: The player earns points by destroying enemies and obstacles

### Game Description

In this game, you are an airforce pilot, fighting to clear the skies of invading enemy planes for as long as you can, while avoiding the
many other obstacles that aim to get stuck in the propellor, bring down the plane, or ruin your paint job.

### Controls

-   Movement
    -   Up: W
    -   Down: S
    -   Left: A
    -   Right: D
-   Fire: Spacebar

## You Additions

Nothing has been added yet, but I want to design my own assets and add in a variety of different and fun enemies with unique attacks,
like other planes, birds, etc.

## Sources

-  N/A

## Known Issues

-  Player movement is way too slow, patched at the moment by multiplying the acceleration by 30 in the PhysicsSHMUP script
    -  Not affected by changing the player's mass
-  The sprite rotation is wrong by 270 degrees

### Requirements not completed

None

