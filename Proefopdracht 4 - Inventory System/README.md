# Test Assignment 4 - Inventory System

# English

The given assignment was making a re-useable inventory system, not bound to a UI or anything alike.
Furthermore the inventory had to be able to add, remove, sort and "use" it's contents.
In my version, those options of course are all present.

## Features
When you want to highlight a specific component, you can use this section to do so.

- [Re-useable Inventory script](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/Inventory.cs)
- [Unique item-icons gegenerated on pickup](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/InventorySlot) (SetTexture methode)

## Software Analysis 

For this assignment I compared Unity and JavaScript.<br>
Making this assignment in JavaScript would've been an easy feat thanks to the structure of arrays:<br>
- Arrays don't have a set size and accept every position you request.
- Arrays accept every type, making it possible to add everything you want to them.<br>
JavaScript would've been too easy.
In Unity it reeks of aiding tools to use for an inventory, like even a full-fledged pre-built inventory in the 2D Game Kit, as well as components for drag and drop within a UI to move data between containers.<br>
Thinking of using this also didn't amuse me, so i decided to throw out all pre-existing assets within Unity to help me, and build it up from the ground with my own knowledge as much as possible.

## Objectives 
What do you want yo achieve with this project? Formulate short, steady and achievable.
- Being able to create practical, re-useable script that contain all necessary functionality.
- Making an all-purpose inventpry that can be set up completely within the inspector.

## Schedule 
You have about 2 weeks, how do you schedule those weeks. When do you schedule to do what exactly?

| | Monday | Tuesday | Wednesday | Thursday | Friday |
| --- | --- | --- | --- | --- | --- |
|week 1 | | Thinking about and writing down all necessary and possible functionalities, and shrink them down to absolute requirements | Make List for inventory Items iwth options to add and delete | Create Item interface and test adding to list | Make I hotbar and link to inventory |
|week 2 | Turn list into array for mor practical use, add option to stack | Make inventory UI to show full inventory contents, setup player controls | Option to swap 2 items in inventory, Uploading | Reflection form + portfolio | Portfolio |

## Sources
I found my self in need of knowledge to check if a position within a list or array wasn't null without getting indexOutOfRange errors, and to convert a Texture2D to a sprite to use for the UI.
Therefore I have used the following sources:

- [Check if position isn't null](https://stackoverflow.com/questions/3949113/check-if-element-at-position-x-exists-in-the-list)
- [Convert Texture2D to Sprite](https://answers.unity.com/questions/650552/convert-a-texture2d-to-sprite.html)

## Instructions/Controls
Walk up against cubes to pick them up.<br>
- W/S: Forward/back
- A/D: Turn left/right
- E:   Open/close Inventory
- 1-8: Select hotbar slot
- Left mouse button: Use/select item in inventory



# Nederlands

De gegeven opdracht was het maken van een herbruikbaar inventory systeem, los van de UI o.d.
Verder moest de inventory inhoud kunnen toevoegen/verwijderen, moest de inhoud sorteerbaar zijn en 'gebruikt' kunnen worden.
In mijn uitvoering zijn alle mogelijkheden uiteraard aanwezig.

## Features
Wanneer je een specifiek onderdeel wilt uitlichten kun je dat in deze sectie benoemen.

- [Herbruikbaar Inventory script](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/Inventory.cs)
- [Unieke voorwerp-iconen gegenereerd bij oprapen van voorwerpen](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/InventorySlot) (SetTexture methode)

## Software Analyse 

Ook voor deze opdracht heb ik Unity en JavaScript met elkaar vergeleken, omdat ik vooraf altijd al een keuze maak, en deze vervolgens vergelijk met een andere optie.<br>
In JavaScript was de opdracht erg gemakkelijk geweest om uit te voeren vanwege de structuur van arrays hierin:<br>
- Arrays hebben geen vaste grootte en accepteren elke positie die je opvraagt.
- Arrays accepteren elk datatype, waardoor je er alles in kan stoppen wat je wil.<br>
JavaScript was dus een te makkelijke optie.
In Unity wemelt het van de hulpmiddelen die je zou kunnen gebruiken voor een inventory, zoals een volledig voorgebakken inventory in de 2D Game Kit, en componenten voor drag/drop binnenin een UI om data te verplaatsen tussen containers.<br>
Dit gebruiken zag ik eigenlijk ook niet zitten, dus ik heb gekozen om alle hulpmiddelen af te wijzen en volledig op eigen kennis te bouwen.

## Leerdoelen 
Wat wil je bereiken met dit project? Formuleer dit kort, krachtig en haalbaar.
- Het kunnen opbouwen van praktische, herbruikbare scripts waar alle benodigde functionaliteit in zit.
- Een all-purpose inventory maken die vanuit de inspector volledig ingesteld kan worden.

## Planning 
Je hebt grofweg 2 weken, hoe deel je deze twee weken in. Wat plan je wanneer om precies te doen?

| | maandag | dinsdag | woensdag | donderdag | vrijdag |
| --- | --- | --- | --- | --- | --- |
|week 1 | |  Nadenken en uitschrijven van alle nodige en mogelijke functionaliteiten van een inventory, en inkrimpen naar benodigdheden | Inventory Item List maken met opties voor toevoegen en verwijderen | Interface voor Items maken en toevoegen aan inventory list testen | UI Hotbar maken en koppelen aan inventory |
|week 2 | List omzetten naar array voor praktischer gebruik, optie voor stapelen toevoegen | Inventory UI maken om volledige inventory te tonen, speler controls instellen | Optie voor omwisselen van 2 items in inventory, Uploaden | Reflectieverslag + portfolio | Portfolio |

## Bronnen
De kennis die ik te kort kwam zat bij het controleren of een positie in een list of array niet null was zonder errors te krijgen, en het omzetten van een Texture2D naar een sprite voor de UI;
Hiervoor heb ik de volgende bronnen geraadpleegd:

- [Check if position isn't null](https://stackoverflow.com/questions/3949113/check-if-element-at-position-x-exists-in-the-list)
- [Convert Texture2D to Sprite](https://answers.unity.com/questions/650552/convert-a-texture2d-to-sprite.html)

## Instructies/Besturing
Loop tegen blokjes aan om deze op te rapen.<br>
- W/S: Vooruit/achteruit
- A/D: Draaien
- E:   Inventaris openen/sluiten
- 1-8: Hotbar slot selecteren
- Linker muisknop: Voorwerp gebruiken/voorwerp in inventaris selecteren
