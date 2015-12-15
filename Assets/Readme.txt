Built in Unity 5.3.0f4

Clean House is a game about cleaning up all the building blocks in your room with your spherical object of power.
Your parents are coming home soon, and you need to clean your room up. If your parents step on a building block,
you surely will be grounded. Pick everything up before the timer runs out.

Bonus Features (and why I added them):
	Player can reach upper height by growing larger and being able to jump higher
		-Fairly simple improvement that allows a vertical layout of the level instead of a flat plane
		-Also allows a blockade for smaller magical spheres by requiring a minimum jump height to access the top most area
	Musical soundtrack with bonus track for successfully collecting all objects
		-Another fairly simple improvement that just makes the game feel a little bit more polished 
			(and a bit annoying due to repetitiveness, sorry about that)
	Pieces will fall off if you run into objects you can't pick up yet
		-Adds to the difficulty a bit since the player will be careful not to run into bigger objects at higher speeds
	Lose condition if you don't pick everything up in time (auto win by hitting the "c" key FTw)
		-Again adds to the difficulty of the game by putting a time limit on it
	Works on mobile
		-Probably one of the more important extra features, this game works on mobile with its own control scheme
		-Allows the game to reach both web and mobile audiences! More eyes on the game!
		-Controls could use some tuning, didnt have time to get USB debugging setup on my PC, so iterating was a
			little rough
	Tool
		-Counts legos on the scene, can be extended to help with balancing by giving it expected ratios
			between the different types of pickup sizes

PC Controls:
	WASD for movement
	Mouse to aim camera
	Space to jump
	Escape to exit game

Mobile Controls:
	Swipe screen to move camera
	Tilt to roll magic sphere
	Tap to jump

Time Spent: 
	~7 hours
	
Room for improvement:
	-Make it so that the overall form of the ball doesnt stretchout too far without maintaining
		a spherical shape
	-Dynamic camera that will stretch out as your sphere grow
	-Block camera from clipping through geometry

PS:
	I felt like this was a pretty solid 60/40 combination of a design/engineering task, which made it a
	ton of fun to be creative, thanks for that! I ended up using the visual studio coding style since it kept
	autoformatting me half the time. Also, sorry this wasn't as polished and feature heavy as I originally intended,
	had to do almost all of it in one night, in order to get it in ASAP.