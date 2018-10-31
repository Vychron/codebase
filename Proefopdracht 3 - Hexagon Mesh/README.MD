# Hexagon Mesh
## Opdracht
De opdracht was om een mesh te maken in de vorm van een hexagon.
Het doel van de opdracht was om zelf meshes te kunnen maken die niet standaard in Unity zitten.

## Features
- [Hexagon Mesh](https://github.com/Vychron/codebase/blob/master/Proefopdracht%203%20-%20Hexagon%20Mesh/HexMesh.cs)
- [PathFinding Algoritme](https://github.com/Vychron/codebase/blob/master/Proefopdracht%203%20-%20Hexagon%20Mesh/AStar.cs)

## Software Anaylse 
Ik heb vooral Unity onderzocht, gezien de opdracht bedoeld was om in Unity uit te voeren, maar ik heb ook gekeken naar mijn goede vriend Javascript en GameMaker Studio.
- Unity heeft natuurlijk beschikbare assets in de asset store wat ik rechtstreeks zou kunnen gebruiken, evenals de optie om meshes van 3D programma's te importeren. Vanzelfsprekend dat ik deze opties uitsluit.
- Javascript kan vrijwel moeiteloos vormen op de canvas tekenen, evenals een optie om zelf vormen te bedenken en direct te tekenen. Daarnaast heeft de Three.js library die een eigen mesh constructor heeft waarin je de hoeveelheden vertices naar wens in kan vullen.
- GameMaker Studio was een iets ander verhaal. GameMaker werkt volledig met sprites, waardoor een hexagon minder precies zal zijn al je deze tekent. Wel heeft de Room Editor de optie om een grid in te stellen, met opties voor rechthoekige- en driehoekige velden, waarvan de driehoekige velden rechtstreeks gebruikt kunnen worden voor positionering van een honeycomb patroon.

## Leerdoelen 
- Zelf meshes kunnen maken, en de structuur hiervan begrijpen.
- om kunnen gaan met uitleiningen in andere structuren dan een standaard rechthoekig grid.
- Een pathfinding algoritme kunnen maken en toepassen.

## Planning 
| | maandag | dinsdag | woensdag | donderdag | vrijdag |
| --- | --- | --- | --- | --- | --- |
|week 1 |Onderzoek naar Mesh Generatie|Polygonen tekenen|3D Mesh in vorm van hexagonaal prisma|Grid van hex-meshes maken|Uitlijnen van hex-meshes in honeycomb patroon|
|week 2 |Onderzoeken van A*|Zelf schrijven van een pathfinding algoritme|Restart + handmatige invoer|Reflectie+portfolio|Portfolio|

## Bronnen
Elke basis voor het maken van meshes in Unity ontbrak mij, een duidelijke uitleg heeft mij goed opweg geholpen¹.<br>
Ondanks een les over het principe van A* miste ik nog de kennis nodig voor implementatie².<br>
Bij het zoeken naar manieren om A* toe te passen bleek al snel dat er vooral gebruik gemaakt wordt van nodes, hier heb ik mij meer over moeten informeren³.

- [¹Custom meshes in Unity](https://www.youtube.com/watch?v=5c0MatF6G2M)
- [²Basics of A*](https://www.raywenderlich.com/3016-introduction-to-a-pathfinding)
- [³Usage of Nodes](https://www.youtube.com/watch?v=nhiFx28e7JY&t=1)

## Gebruiksaanwijzing:
Linkermuisknop - Kies startlocatie van pad.<br>
Rechtermuisknop - Kies eindlocatie van pad.<br>
