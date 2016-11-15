# RPR Biblioteka
---

## Nekoliko napomena:


### Za clanove i knjige vrijedi sljedece:
	Odabir ovih objekata se vrsi prema njihovoj jedinstvenoj generisanoj sifri. Npr, pri
	brisanju knjige iz biblioteke, unosi se sifra knjige koje se zeli izbrisati
	te se potom brise odgovarajuci item iz biblioteke. Ovo je opravdano cinjenicom
	da je korisnik u svakom trenutku u stanju dobiti listu svih objekata zajedno
	sa njihovim podacima.

### Eksterni dll
	Klasa parser (ciji je kod u potpunosti dostupan u folderu), je klasa cija 
	je svrha olaksavanje parsiranja podataka sa standardnog ulaza.

### Analiza podataka
	Obzirom na to da se sve radnje u biblioteci logiraju, moguce je lahko doci do 
	relevantnih analiza pomocu LINQa.
	LINQ ftw!

### Delegat
	Primjer koristenja delegata se moze vidjeti u klasi KnjigaManager.cs, tacnije
	u metodi SearchByNaziv.

### Kolekcije podataka
	Koriste se posvuda. :)
	
### Placanje clanarine
	Svakoj osobi je napocetku dodjeljena nasumicna kolocina novca u opsegu od 10 do 1000KM.
	Nadalje, pozivom metode Naplati u klasi BibliotekaManager, trazimo od svakog 
	korisnika da isplati izvjsnu sumu novca. Ako on to ne moze uciniti, vraca sve knjige
	koje trenuto posjeduje i postaje zauvijek banovan iz biblioteke.