# Gameplay mechanic

Neontilt was inspired by "ball maze" games and "Arkanoid", the player is a ball that must destroy every block on a floor while avoiding falling into holes, the player needs to have good control of the ball.

## Ball Movement

At first I thought that the ball would move by virtue of the platform tilting, same as with ball maze games, but it was too slow, so I added a small amount of force to the tilting direction in such a way that it seems like it's the tilt alone that moves the ball.

## Ball Jump

The movement felt limited, so I added a jump(adding impulse up), that way we could have different heights in levels and the player has more agency. The movement still felt a bit limited so we chose to add a down slam(adding impulse down), to precisely fall where you want.

## Ball shadow

With the ball jump and down slam, we needed to add a way for the player to see where the ball will fall with the down slam, so I added a shadow object that follows the ball position but ignores the Z axis and instead uses the floor hight given by a raycast in the ball jumping script.



