# Purpose

The purpose of the game is to click on the items shot up from the bottom of the screen. The items fall back to the bottom of the screen in a parrabolic motion. Items are split into two categories, "good" and "bad". Good items add to player score, and if one falls back to the bottom of the screen, it's game over. For each item clicked, the player's score (displayed on the upper left) increments with respect to the clicked item's point value. Good items have a positive score value while bad items have a negative value.

# The flow

## Main Menu

The game begins with a main menu which displays the name of the game with some good and bad items floating around, spinning. There is a catchy background song. On the main menu, there are three buttons for difficulty, `easy`, `normal`, and `hard`. The difficulty affects the rate at which items are spawned during the game.

- For `easy`, items are spawned once a second.
- For `normal`, items are spawned once every 0.66 seconds.
- For `hard`, items are spawned once every 0.33 seconds.
  A description at the bottom of the menu is seen explaining the game, as follows:

```
Click on all the good items to get points, but watch out for the bad items!
If you miss a good item, it's game over!
```

## Game

The game begins with the difficulty chosen in the main menu.
When the game begins, the player's score is 0, it is shown to the upper left. Items begin to spawn from below the horizon and fly upwards before falling back down. For every good item the player clicks their score is incremented, while for every bad item their score is decremented. The background is a checkered white, with sides of darker grey. The game is over for a `good` item not clicked by the player.
Spawned good items have a green highlight, whereas spawned bad items have a red highlight. When a player clicks the item, the corresponding added score is displayed right before the item is replaced by an explosion particle effect.

## Game over

The game is over for a `good` item not clicked by the player. On game over, the player's final score is displayed and there is an option to go back to the main menu, as well as an option to replay the game.

# References

## Figma (planning)

[Here](https://www.figma.com/file/5rNdEejC3g8weiB6F5Wr51/ClickGame?node-id=0%3A1)

## Hosted project

[Here](https://play.unity.com/mg/other/webgl-builds-264815)
