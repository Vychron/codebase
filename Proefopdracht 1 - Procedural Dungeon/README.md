# Procedurally Generated Dungeon

## Opdracht
De opdracht was om een algoritme te kunnen implementeren dat een willekeurig level genereert.
Mijn doel was om er een volledig functionele (simpele) dungeon crawler van te maken.

## Features
Wanneer je een specifiek onderdeel wilt uitlichten kun je dat in deze sectie benoemen.

- [Awesome Startup Transitie](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/UI%20%26%20Camera/TopDownCamera.cs)
- [4-Step Setup](https://github.com/Vychron/codebase/tree/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Level)
- [To&Fro Projectiles](https://github.com/Vychron/codebase/blob/master/Proefopdracht%201%20-%20Procedural%20Dungeon/Player/Bullet.cs)

## Software Anaylse 
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
