# Test assignment 2 - Destructable Map

# English

The assignment was about making a destroyable map as seen in Worms, with terrain that could be damaged by, for instance, dropping bombs down on it.
I expanded this to a small Endless Dodger game with the objective of endlessly avoiding falling bombs.

## Software Anaylsis 

For this assignment I took a look at Unity and JavaScript:
- In Unity a destructable map can be quickly created by using the height data of a Terrain object. Furthermore there's an assortment of ready-to-use destructable object assets in the Unity Asset Store for both 2D and 3D.
- In javaScript there are no built-in properties that could give me instant results, with as closest option using the ImageData of a canvas element.

Using Unity seemed too easy to me, so i chose to challenge myself with JavaScript.

To me the challenge was mostly thinking out collision detection, and the restriction of using the ImageData of the canvas.

Afterwards I added an extra challenge to keep the entire assignment under 40KB in size. Final size (including images) was 34KB.

## Objectives 
For this assignment i had multiple objectives to achieve:
- Applying collision detection in JavaScript
- Creating my own algorithm for 2D Terrain Destruction
- Create an algorithm to restore the damage of the previously mentioned algorithm.

## Schedule 
Je hebt grofweg 2 weken, hoe deel je deze twee weken in. Wat plan je wanneer om precies te doen?

| | Monday | Tuesday | Wednesday | Thursday | Friday |
| --- | --- | --- | --- | --- | --- |
|week 1 | Research | Research, Planning tasks | Art raw: Level + Bomb, Level image translated to 3D array | Explosion algorithm on mouseclick | Moving Algorithm to new falling bomb object (spawn on click) |
|week 2 | Spawning of bombs | Moveable player (cube) | Polish, Hand in | Reflection form, portfolio | Portfolio |

## Sources
Although most of the information I used consists of my own theory based on observation, I still needed a small nudge in the right direction. Those nudges were determining the explotion radius for the destruction of the terrain, timeOut callbacks with parameters, translating mouse position to canvas position (to test the bombs) and usage of multiple canvas layers.

- [Tutorial for making destructable terrain in Processing](https://gamedevelopment.tutsplus.com/tutorials/coding-destructible-pixel-terrain-how-to-make-everything-explode--gamedev-45)
- [passing arguments to functions with timeOut](https://stackoverflow.com/questions/1190642/how-can-i-pass-a-parameter-to-a-settimeout-callback)
- [Translate mouse position to canvas position](https://www.html5canvastutorials.com/advanced/html5-canvas-mouse-coordinates/)
- [Using multiple canvas layers](https://stackoverflow.com/questions/3008635/html5-canvas-element-multiple-layers)



# Nederlands

De opdracht was om een destroyable map te maken zoals in worms, die vernietigd kon worden door bijvoorbeeld bommen te laten vallen.
Verder uitgebreid tot kleine Endless Dodger game waarin het doel is om vallende bommen te blijven ontwijken.

## Features
Er zijn geen features aanwezig die ik specifiek wil highlighten

## Software Anaylse 

Voor deze proefopdracht heb ik Unity en JavaScript onderzocht:
- In Unity kan een destructable map al snel gecreëerd worden met het gebruik van de hoogtedata van een Terrain object. verder is er een assortiment aan kant-en-klare destructable object assets te vinden in de Unity Asset Store voor zowel 2D als 3D.
- In JavaScript zitten geen kant-en-klare eigenschappen die mij direct resultaat kunnen geven, met als dichtstbijzijnde optie het gebruiken van de ImageData van een canvas.

Het gebruik van Unity leek mij een te makkelijke optie, dus ik koos voor JavaScript om mijzelf een uitdaging te geven.

De uitdaging zat hem voor mij vooral in het volledig uitdenken van collision detectie, en de beperking tot het gebruik van de ImageData van de canvas.

Later heb ik als extra uitdaging besloten om de volledige opdracht kleiner dan 40kb te houden. Uiteindelijke grootte is 34kb geworden.

## Leerdoelen 
Voor deze proefopdracht had ik meerdere leerdoelen om te bereiken:
- Collision detectie kunnen toepassen in JavaScript
- Een eigen algoritme bedenken voor 2D Terrain Destruction
- Een algoritme bedenken voor het herstellen van de schade aangericht met het bovenstaande algoritme.

## Planning 
Je hebt grofweg 2 weken, hoe deel je deze twee weken in. Wat plan je wanneer om precies te doen?

| | maandag | dinsdag | woensdag | donderdag | vrijdag |
| --- | --- | --- | --- | --- | --- |
|week 1 | Onderzoek | Onderzoek, Plan opstellen | Art ruw: Level + Bom, Level afbeelding vertaald naar 3D array | Explosie algoritme bij muisklik | Algoritme verhuizen naar nieuw vallend bom object (plaatsen bij muisklik) |
|week 2 | Spawnen van bommen | Bestuurbare speler (blokje) | Polish, Inleveren | Reflectie, Portfolio | Portfolio |

## Bronnen
Hoewel het grootste deel van de informatie die ik gebruik bestaat uit eigen theorie gebaseerd op observatie, had ik toch hier en daar een klein duwtje in de juiste richting nodig, deze duwtjes bestonden uit het bepalen van een explosie radius voor het vernietigen van het terrein, timeOut callbacks met parameters, correct vertalen van muispositie (voor het testen van de bommen) en het gebruiken van meerdere canvas lagen.

- [Tutorial voor maken van destructable terrain in Processing](https://gamedevelopment.tutsplus.com/tutorials/coding-destructible-pixel-terrain-how-to-make-everything-explode--gamedev-45)
- [Parameters meegeven aan functie met timeOut](https://stackoverflow.com/questions/1190642/how-can-i-pass-a-parameter-to-a-settimeout-callback)
- [Muispositie vertalen van browserpositie naar canvaspositie](https://www.html5canvastutorials.com/advanced/html5-canvas-mouse-coordinates/)
- [Gebruik van meerdere canvas lagen](https://stackoverflow.com/questions/3008635/html5-canvas-element-multiple-layers)
