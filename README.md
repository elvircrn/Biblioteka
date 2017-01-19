# RPR Biblioteka

Disclaimer: repozitorij je bio privatan za vrijeme trajanja zadace

## Podaci o autoru:
	Elvir Crncevic, index: 17455

## User credentials za koristenje aplikacije

* Bibliotekar
    * Username: bibliotekar0 
    * Password: aaa
* Admin
    * Username: admin 
    * Password: admin
* Clan
    * Username: clan0 
    * Password: aaa

## Baza podataka

### Tabele
Za modeliranje baze podataka je koristen OracleManagedDataAccess.EntityFramework. To je omogucilo generisanje baze podataka uz 'neznatne' izmjene u samom modelu. U klasi ApplicationDbContext definisu su definisane sve tabele pomocu DBset propertija koje su napunjene kroz Seed metodu u Configuration klasi. Ova metoda je pokrenuta prije slanja zadace i nije preporucljivo njeno ponovno pokretanje. O dio ORM-a se nalaze u Bibliteka.Model, 
### Servisi
Biblioteka.BLL sadrzi service koji su zaduzeni za CRUD operacije. Svaki servis posjeduje objekat ApplicationDbContext preko kojeg pristupa bazi podataka. Kljucni dio implementacije svakog servisa (za primjer je uzet servis za knjige) je sljedece lazy (ili bar pokusaj) loadanja:

KnjigaManager.cs:
```csharp
ApplicationDbContext _context;
private static readonly int SifraLength = 10;

private List<Knjiga> _knjigasCache;

private List<Knjiga> _knjige
{
    get
    {
        if (_knjigasCache == null)
            return _knjigasCache = _context.Knjigas.Include("SpisakAutora").ToList();
        else
            return _knjigasCache;
    }
}
```
Ideja je da se svako pozivanje kontejnerskog objekta presretne sa pozivom na bazu(ako je to neophodno) i da se cache-iraju podaci ako to vec nije ucinjeno. To je ucinjeno za sve servise(managere) koji na pocetku dobijaju ApplicationDbContext objekat.

Program.cs


```csharp
using (ApplicationDbContext context = new ApplicationDbContext())
{
	Run(new LogInForm(DataAPI.Inject(context)));
}
//...
dataAPI.UserAPI = new UserManager(context);
//...
```


Funkcionalnost servisa je zadrzana u odnosu na prethodnu zadacu te oni sada rade sa bazom podataka... nadam se ...

### Serijalizacija

Xml serijalizacija i deserijalizacija je implementirana asinhrono za clanove, radnike i knjige, a binarna serijalizacija samo podrzava upise :(

### Animacija logo-a
Vrsi se crtanje Hilbertovog fraktala koji se restartuje kada dodje do kraja (jos nisam svjedocio tome).	
### Asinhroni rad sa datotekama
Xml serijalizacija radi asinhrono i implementirana je kroz klase u Common.XmlIO i Common.XmlSerializer. Common inace sadrzi pomocne metode, i gotovo svi projekti imaju referencu na ovaj paket klasa. Binarni Serializer, nazalost, radi samo sinhrono. 
### TPL

ClanManager.cs:
```csharp
public void AddClanRange(List<Clan> list)
{
    int ind = 0;
    var cd = new ConcurrentDictionary<int, Clan>(list
            .Select(x => new KeyValuePair<int, Clan>(ind++, x))
            .ToList());
    Parallel.ForEach(cd, x =>
    {
        AddClan(x.Value);
    });
}
// Concurrent Dictionary
public List<Knjiga> SearchByNaziv(string naziv, Comparator comparator = null)
{
    int ind = 0;
    var cd = new ConcurrentDictionary<int, Knjiga>(_knjige
        .Select(x => new KeyValuePair<int, Knjiga>(ind++, x))
        .ToList());

    if (comparator != null)
        return cd.Where(x => comparator(x.Value)).ToList().Select(x => x.Value).ToList();
    else
        return _knjige.Where(x => x.Naslov == naziv).ToList();
}
```

KnjigaManager.cs
```csharp
// Concurrent Dictionary
public List<Knjiga> SearchByNaziv(string naziv, Comparator comparator = null)
{
    int ind = 0;
    var cd = new ConcurrentDictionary<int, Knjiga>(_knjige
        .Select(x => new KeyValuePair<int, Knjiga>(ind++, x))
        .ToList());

    if (comparator != null)
        return cd.Where(x => comparator(x.Value)).ToList().Select(x => x.Value).ToList();
    else
        return _knjige.Where(x => x.Naslov == naziv).ToList();
}

```

WorkerManager.cs
```csharp
public void AddWorkerRange(List<Worker> list)
{
    int ind = 0;
    var cd = new ConcurrentDictionary<int, Worker>(list
        .Select(x => new KeyValuePair<int, Worker>(ind++, x))
        .ToList());

    Parallel.ForEach(cd, x =>
    {
        AddWorker(x.Value);
    });
}
```

## Paralelizacija serijalizacija (jedan primjer)
```csharp
using (var fbd = new FolderBrowserDialog())
{
    DialogResult result = fbd.ShowDialog();

    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
    {
        string path = fbd.SelectedPath + @"\clanovi.xml";

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            Task[] tasks = new Task[] { file.WriteAsync(Common.Serialization.XMLSerializer.SerializeToXmlString(_data.ClanAPI.GetClans()
                                                                                                           .Select(x => (Clan)x)
                                                                                                           .ToList())) };
            await Task.Factory.ContinueWhenAll(tasks, antecedents =>
             {
                 MessageBox.Show("Serijalizacija clanova zavrsena");
             }, CancellationToken.None, TaskContinuationOptions.None, uiContext);
        }
    }
}
```

## UWP Aplikacija
Ne egzistira...

Takodje nije pozeljno diskonektovati se sa interneta za vrijeme rada aplikacije.
