# Proefopdracht 4 - Inventory System

De gegeven opdracht was het maken van een herbruikbaar inventory systeem, los van de UI o.d.
Verder moest de inventory inhoud kunnen toevoegen/verwijderen, moest de inhoud sorteerbaar zijn en 'gebruikt' kunnen worden.
In mijn uitvoering zijn alle mogelijkheden uiteraard aanwezig.

## Features
Wanneer je een specifiek onderdeel wilt uitlichten kun je dat in deze sectie benoemen.

- [Herbruikbaar Inventory script](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/Inventory.cs)
- [Unieke voorwerp-iconen gegenereerd bij oprapen van voorwerpen](https://github.com/Vychron/codebase/edit/master/Proefopdracht%204%20-%20Inventory%20System/InventorySlot) (SetTexture methode)

## Software Anaylse 

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
