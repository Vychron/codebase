# Test Assignment 1 - Procedurally Generated Dungeon

# English

The assignment was to be able to implement an algorithm for random level generation.
It was my goal to turn it into a complete (simple) Roguelike.

## Features
- [Awesome Startup Transition](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/UI%20%26%20Camera/TopDownCamera.cs)
- [4-Step Setup](https://github.com/Vychron/codebase/tree/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Level)
- [To&Fro Projectiles](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Player/Bullet.cs)

## Software Analysis 
I chose to work with Unity.
Generation of a level is lightweight and should be possible in every framework, but due to my upgrade to a playable game it seems more practical to me to have every object "think" for itself than to update everything that might change in any way every frame.

## Objective 
- Understanding and being able to implement an algorithm for procedurally generating an environment.

## Schedule 
| | Monday | Tuesday | Wednesday | Thursday | Friday |
| --- | --- | --- | --- | --- | --- |
|week 1 |Research procedural generation method|Basic generation working|Working prototype generator|Player actions (movement, attack), placehoder enemy|Enemy AI|
|week 2 |Enemy- + deco object spawning|Game Art|Finishing touch + upload|Reflection form + portfolio|Portfolio|

## Sources
To get an idea of how a procedural generation algorithm works, I observed the execution of one in the first few minutes of an Unity tutorial about this.¹<br>
For the first time ever I decided it was necessary to pause the game, but had no clue on how this works. A google search quickly answered my question.²<br>
To better understand the concept of object pooling, I looked up a tutorial about this.³

- [¹Level Generation tutorial](https://youtu.be/wnoLaui3uO4)
- [²Pausing the game](https://forum.unity.com/threads/pausing-a-game-without-settiing-timescale-to-0.55395/)
- [³Object Pooling](https://youtu.be/9-zDOJllPZ8)



# Nederlands

De opdracht was om een algoritme te kunnen implementeren dat een willekeurig level genereert.
Mijn doel was om er een volledig functionele (simpele) Roguelike van te maken.

## Features
- [Awesome Startup Transitie](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/UI%20%26%20Camera/TopDownCamera.cs)
- [4-Step Setup](https://github.com/Vychron/codebase/tree/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Level)
- [To&Fro Projectiles](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Player/Bullet.cs)

## Software Analyse 
Ik heb gekozen om in Unity Engine te werken.
Het genereren van een level is lichtgewicht en zou in elke framework mogelijk moeten zijn, maar vanwege mijn uitbreiding naar een speelbare game vind ik het praktischer om elk object voor zichzelf te kunnen laten 'denken' dan om elke frame alles wat mogelijk verandert opnieuw naar de canvas te schrijven.

## Leerdoelen 
- Een algoritme voor procedureel genereren van omgeving begrijpen en toe kunnen passen.

## Planning 
| | maandag | dinsdag | woensdag | donderdag | vrijdag |
| --- | --- | --- | --- | --- | --- |
|week 1 |Onderzoek procedural generation methode|Basis generatie werkend|Werkend prototype generator|Player actions (movement, attack), placeholder enemy|Enemy AI|
|week 2 |Enemy- + deco object spawning|Game Art|Finishing touch + upload|Reflectie+portfolio|Portfolio|

## Bronnen
Om een idee te krijgen van hoe een algoritme van procedural generation werkt, heb ik gekeken naar de uitvoering hiervan in de eerste 8 minuten van een Unity tutorial hierover.¹<br>
Voor het eerst heb ik besloten dat een pauze functie nodig was, maar had geen idee hoe dit werkt. een google search heeft mij als snel antwoord gegeven.²<br>
Om het concept van object pooling beter te begrijpen, heb ik hier een tutorial over opgezocht³.

- [¹Level Generation tutorial](https://youtu.be/wnoLaui3uO4)
- [²Pausing the game](https://forum.unity.com/threads/pausing-a-game-without-settiing-timescale-to-0.55395/)
- [³Object Pooling](https://youtu.be/9-zDOJllPZ8)
