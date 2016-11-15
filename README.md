# RPR Biblioteka
---

## Nekoliko napomena:


### Odabir itema
	Za sljedece iteme u biblioteci:
	* Clanovi
	* Knjige
	se odabir vrsi prema njihovoj jedinstvenoj sifri generisanoj. Npr, pri
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