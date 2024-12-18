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

-  Created all art, including health counters which are not visible in the build
-  Implemented two unique enemy types and planned a third "enemy" that would impact player movement
-  Player collides with the screen on all but the right wall (intentionally)

## Sources

-  N/A

## Known Issues
-  The sprite rotation is wrong
-  The pigeons only move across half the screen
-  The enemy projectiles do not move once fired
-  The trajectory of the player projectiles angles slightly up or down randomly
-  The collision system I added is not able to access all the components it needs to funtion properly

### Requirements not completed

-  Did not add a visual health indicator
-  Did not add a scoring system
-  Did not implement the game over condition (outside of destroying the player object if health reaches 0)

