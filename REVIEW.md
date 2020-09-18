# Project Review

## Applicant name

Miran Jank

---

<!-- Your review goes here -->
Making this little game was quite fun, and only a slight introduction into real game development. As for game mechanics there really was nothing too complex, only procedural spawning always takes some time to thing through. Designing is a light weight task, and breaks narrow-minded programming, I like that a lot.

<!-- Explain why you did the things that way or any snippet that is word mentioning -->
I didn't make use of pooling, as I thought it really would not be necessary for such a game. It might be of great use in bullet-hell like games, but not if there are at most 5 platforms simulataniously beeing rendered. Worth mentioning are the several little particle effects, all made by hand. I'm especially fond of the fall effect, which's timing is perfect. Also I defined a super structure, the line, which encapsulates the left platform, score trigger, and right platform - for easier use and understanding of the backend.

<!-- If you had any issue and how you resolved them -->
Making the player move by having right mass, drag and PXmaterials is always tedious. It worked for a unique style, though it is possible to stick to walls. I don't like it, though it is no game-breaking bug.
