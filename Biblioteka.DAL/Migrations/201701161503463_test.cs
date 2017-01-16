namespace Biblioteka.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "EC17455.Authors",
                c => new
                    {
                        AuthorId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        Knjiga_KnjigaId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("EC17455.Knjigas", t => t.Knjiga_KnjigaId)
                .Index(t => t.Knjiga_KnjigaId);
            
            CreateTable(
                "EC17455.Users",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserName = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        MaticniBroj = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        PasswordHash = c.String(),
                        Email = c.String(),
                        ClanId = c.Decimal(precision: 10, scale: 0),
                        Comment = c.String(),
                        Sifra = c.String(),
                        State = c.Decimal(precision: 10, scale: 0),
                        Cash = c.Double(),
                        UniWorkerID = c.String(),
                        Index = c.String(),
                        Level = c.Decimal(precision: 10, scale: 0),
                        WorkerId = c.Decimal(precision: 10, scale: 0),
                        ImageDataId = c.Decimal(precision: 10, scale: 0),
                        Occupation = c.String(),
                        WorkerID = c.String(),
                        Salary = c.Double(),
                        UserAdminId = c.Decimal(precision: 10, scale: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("EC17455.ImageDatas", t => t.ImageDataId)
                .Index(t => t.ImageDataId);
            
            CreateTable(
                "EC17455.Roles",
                c => new
                    {
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        User_UserId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("EC17455.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "EC17455.Knjigas",
                c => new
                    {
                        KnjigaId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Naslov = c.String(),
                        Sifra = c.String(),
                        Zanr = c.String(),
                        GodinaIzdanja = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ISBN = c.String(),
                        Taken = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Konferencija = c.String(),
                        AnimatorskaKuca = c.String(),
                        BrojIzdanja = c.Decimal(precision: 10, scale: 0),
                        Specijalno = c.Decimal(precision: 1, scale: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Clan_UserId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.KnjigaId)
                .ForeignKey("EC17455.Users", t => t.Clan_UserId)
                .Index(t => t.Clan_UserId);
            
            CreateTable(
                "EC17455.ImageDatas",
                c => new
                    {
                        ImageDataId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ImageDate = c.DateTime(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("EC17455.Users", "ImageDataId", "EC17455.ImageDatas");
            DropForeignKey("EC17455.Roles", "User_UserId", "EC17455.Users");
            DropForeignKey("EC17455.Knjigas", "Clan_UserId", "EC17455.Users");
            DropForeignKey("EC17455.Authors", "Knjiga_KnjigaId", "EC17455.Knjigas");
            DropIndex("EC17455.Knjigas", new[] { "Clan_UserId" });
            DropIndex("EC17455.Roles", new[] { "User_UserId" });
            DropIndex("EC17455.Users", new[] { "ImageDataId" });
            DropIndex("EC17455.Authors", new[] { "Knjiga_KnjigaId" });
            DropTable("EC17455.ImageDatas");
            DropTable("EC17455.Knjigas");
            DropTable("EC17455.Roles");
            DropTable("EC17455.Users");
            DropTable("EC17455.Authors");
        }
    }
}
