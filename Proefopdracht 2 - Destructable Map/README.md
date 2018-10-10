# Proefopdracht 2 - Destructable Map

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
|week 1 | Onderzoek | Onderzoek, Plan opstellen | Art ruw: Level + Bim, Level afbeelding vertaald naar 3D array | Explosie algoritme bij muisklik | Algoritme verhuizen naar nieuw vallend bom object (plaatsen bij muisklik) |
|week 2 | Spawnen van bommen | Bestuurbare speler (blokje) | Polish, Inleveren | Reflectie, Portfolio | Portfolio |

## Bronnen
Hoewel het grootste deel van de informatie die ik gebruik bestaat uit eigen theorie gebaseerd op observatie, had ik toch hier en daar een klein duwtje in de juiste richting nodig, deze duwtjes bestonden uit het bepalen van een explosie radius voor het vernietigen van het terrein, timeOut callbacks met parameters, correct vertalen van muispositie (voor het testen van de bommen) en het gebruiken van meerdere canvas lagen.

- [Tutorial voor maken van destructable terrain in Processing](https://gamedevelopment.tutsplus.com/tutorials/coding-destructible-pixel-terrain-how-to-make-everything-explode--gamedev-45)
- [Parameters meegeven aan functie met timeOut](https://stackoverflow.com/questions/1190642/how-can-i-pass-a-parameter-to-a-settimeout-callback)
- [Muispositie vertalen van browserpositie naar canvaspositie](https://www.html5canvastutorials.com/advanced/html5-canvas-mouse-coordinates/)
- [Gebruik van meerdere canvas lagen](https://stackoverflow.com/questions/3008635/html5-canvas-element-multiple-layers)
