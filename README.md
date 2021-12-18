# Labb 3

Hejsan allihopa!
Hjärtligt välkomna till den tredje och sista labben. Den kommer också att fungera som 
inlämningsuppgift för er som vill ha VG.

## Vad ska vi göra?

Vi ska sätta tänderna i Dans favorit-patterns. Det är som ni kanske kommer ihåg är två bygg-patterns

- FluentBuilder, samt
- Factory

Vi ska bygga en fabrik ELLER en fluentbuilder för att skapa följande objekt:

```
        public int NoOfRooms { get; set; } = 1;
        public int NoOfWindows { get; set; } = 0;
        public string StreetAdress { get; set; }
        public bool HasSwimmingPool { get; set; }
        public int ParkingSpotsInGarage { get; set; }

        public bool HasGarage => ParkingSpotsInGarage > 0;
```

Denna klass hittar ni i House.cs. Den innehåller lite mer roligt, som konstruktorer samt en ToString().

Vi har vissa krav på det färdiga huset:

- Vi måste ha minst ett rum.
- Vi får inte ha negativt antal fönster.
- Vi får inte ha negativt antal parkeringsplatser.

### FluentBuildern

Var ska vi lägga logiken för att verifiera att kraven ovan är uppfyllda?

Man skulle kunna lägga den i antingen Set-metoderna (t.ex. SetNumberOfRooms) eller kanske ännu 
bättre i Build()-metoden. Vi lägger alltså in logik här för att stämma av att 
kraven är uppfyllda. Om de inte är uppfyllda kastar vi ett undantag. Då bromsar vi redan
på detta stadiet att vi går vidare i koden med objekt som inte är korrekt uppbyggt.

### Fabriken

Fabriken fungerar ju lite annorlunda än FluentBuildern.

Ni får här definiera upp minst tre olika typer av hus. 
Köper man hus via fabriken får man ta vad fabriken erbjuder :)

## Vad krävs för G?

För G krävs att ni implementerar minst en av de två bygg-patterna nämnda ovan.

## Vad krävs för VG?

Då vill jag ha BÄGGE patterns implementerade. Dessutom vill jag att det ska testas av. Det 
handlar om en omfattade testning där i alla de flesta fallen ska testas av och verifieras.

## Mapp-struktur

Jag tog mig friheten att skapa upp en mappstruktur för projektet.

- ITHS-CC-Labb3 innehåller i stort sett bara orginalet på House.cs.
- HouseF ska innehålla en eventuell fabrik och dess kod.
- HouseF.Tests ska innehålla eventuella tests för fabriken.
- HouseFB ska innehålla en eventuell FluentBuilders kod.
- HouseFB.Tests ska innehålla testen för FluentBuildern.

## Hur ska det redovisas?

Lite annorlunda här. Eftersom denna uppgiften blir lite större så vill jag ha en länk till 
ett repo på GitHub. Glöm då inte att bjuda in mig till repot om ni har det privat. Skicka sen 
ett mess på teams med länken.

Lägg gärna till en README.md eller README.txt om ni har något ni vill förmedla.