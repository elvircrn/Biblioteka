namespace Biblioteka.DAL.Migrations
{
    using Common.Security;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Drawing;

    internal sealed class Configuration : DbMigrationsConfiguration<Biblioteka.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Biblioteka.DAL.ApplicationDbContext context)
        {
            #region Roles
            Role roleAdmin = new Role("ADMIN", "Admin");
            Role roleWorker = new Role("WORKER", "Bibliotekar");
            Role roleClan = new Role("CLAN", "Clan");
            Role roleTech = new Role("TECH", "Tehnicar");

            context.Roles.AddOrUpdate(roleAdmin);
            context.Roles.AddOrUpdate(roleWorker);
            context.Roles.AddOrUpdate(roleClan);
            context.Roles.AddOrUpdate(roleTech);
            #endregion

            #region Authors
            Author author1 = new Author { Name = "Ivo Andric" };
            Author author2 = new Author { Name = "Christopher Hitchens" };
            Author author3 = new Author { Name = "Branko Copic" };

            context.Authors.AddOrUpdate(author1);
            context.Authors.AddOrUpdate(author2);
            context.Authors.AddOrUpdate(author3);

            List<Author> defaultAuthors = new List<Author>() { author1, author2, author3 };
            #endregion

            #region Users
            User userAdmin = new User
            {
                Ime = "admin",
                Prezime = "admin",
                DatumRodjenja = new DateTime(1996, 7, 2),
                MaticniBroj = "123456789123",
                UserName = "admin",
                PasswordHash = Hash.Encode("admin"),
                Roles = new List<Role>() { roleAdmin },
            };
            context.Users.AddOrUpdate(userAdmin);
            #endregion

            #region Clans
            for (int i = 0; i < 10; i++)
            {
                Clan clan = new Clan
                {
                    Ime = "ClanIme" + i.ToString(),
                    Prezime = "ClanPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, i + 1),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "clan" + i.ToString(),
                    PasswordHash = Hash.Encode("aaa"),
                    Sifra = i.ToString(),
                    Roles = new List<Role>() { roleClan },
                };
                context.Clans.AddOrUpdate(clan);
            }
            #endregion

            #region Knjigas
            for (int i = 1; i <= 3; i++)
            {
                context.Knjigas.AddOrUpdate(new Knjiga
                {
                    Naslov = "Naslov1",
                    GodinaIzdanja = 1233 + i * 40,
                    ISBN = "ISBN-13 978-3-642-11746-" + i.ToString(),
                    Taken = false,
                    Zanr = "Zanr" + i.ToString(),
                    SpisakAutora = defaultAuthors
                });
            }
            #endregion

            #region ImageDatas
            ImageData imageData = new ImageData
            {
                Image = ImageData.ImageToByte(new Bitmap(200, 200)),
                ImageDate = DateTime.Now
            };
            #endregion

            #region Workers
            for (int i = 0; i < 10; i++)
            {
                Worker worker = new Worker
                {
                    Ime = "BibliotekarIme" + i.ToString(),
                    Prezime = "BibliotekarPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, 1),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "bibliotekar" + i.ToString(),
                    PasswordHash = Hash.Encode("aaa"),
                    WorkerId = i.ToString(),
                    Occupation = "Bibliotekar",
                    Salary = NumberGenerator.GetRandomNumber(1000),
                    ImageData = imageData, // Consider not doing this here
                    Roles = new List<Role>() { roleWorker }
                };
                context.Workers.AddOrUpdate(worker);
            }
            for (int i = 10; i < 20; i++)
            {
                Worker worker = new Worker
                {
                    Ime = "DomarIme" + i.ToString(),
                    Prezime = "DomarPrezime" + i.ToString(),
                    DatumRodjenja = new DateTime(1996, 7, i),
                    MaticniBroj = "123456789123" + i.ToString(),
                    UserName = "worker" + i.ToString(),
                    PasswordHash = "", // Domari nemaju pristupne podatke sistemu
                    WorkerId = i.ToString(),
                    Occupation = "Domar",
                    Salary = NumberGenerator.GetRandomNumber(1000),
                    ImageData = imageData,
                    Roles = new List<Role>() { roleWorker }
                };
                context.Workers.AddOrUpdate(worker);
            }
            #endregion

            context.SaveChanges();
        }
    }
}
