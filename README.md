# NOVI README
https://gist.github.com/elvircrn/64805e34520c4909120419c7229d01d1



# RPR Biblioteka
---

## Nekoliko napomena:

### Broj indeksa: 17455
	Varijable u Program.cs su promijenjene u skladu sa requirementom.

### Aplikacija
	Konzolna aplikacija je implementirana u projektu 'Test' koji bi trebao biti start-up
	project.

### Za clanove i knjige vrijedi sljedece:
	Odabir ovih objekata se vrsi prema njihovoj jedinstvenoj generisanoj sifri. Npr, pri
	brisanju knjige iz biblioteke, unosi se sifra knjige koje se zeli izbrisati
	te se potom brise odgovarajuci item iz biblioteke. Ovo je opravdano cinjenicom
	da je korisnik u svakom trenutku u stanju dobiti listu svih objekata zajedno
	sa njihovim podacima.

### Eksterni dll
	Klasa parser (ciji je kod u potpunosti dostupan u folderu), je klasa cija 
	je svrha olaksavanje parsiranja podataka sa standardnog ulaza. Implementacija klase
	Paser.cs se nalazi u folderu 'Helpers'. Naziv biblioteke koju sam implementirao je 'IO',
	tj. IO.dll.

### Analiza podataka
	Obzirom na to da se sve radnje u biblioteci logiraju, moguce je lahko doci do 
	relevantnih analiza pomocu LINQa.
	LINQ ftw!

### Delegat
	Primjer koristenja delegata se moze vidjeti u klasi KnjigaManager.cs, tacnije
	u metodi SearchByNaziv.

### Kolekcije podataka
	Koriste se posvuda. :)
	
### Abstract
	abstract class UselessAbstract
	
### Placanje clanarine
	Svakoj osobi je napocetku dodjeljena nasumicna kolocina novca u opsegu od 10 do 1000KM.
	Nadalje, pozivom metode Naplati u klasi BibliotekaManager, trazimo od svakog 
	korisnika da isplati izvjsnu sumu novca. Ako on to ne moze uciniti, vraca sve knjige
	koje trenuto posjeduje i postaje zauvijek banovan iz biblioteke. Svaka pretpostavlja
	da je prosao odgovarajuci period da bi ona bila validn
