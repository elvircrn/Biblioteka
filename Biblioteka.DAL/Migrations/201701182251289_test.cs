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
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "EC17455.Knjigas",
                c => new
                    {
                        KnjigaId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Naslov = c.String(maxLength: 200),
                        Sifra = c.String(maxLength: 200),
                        Zanr = c.String(maxLength: 200),
                        GodinaIzdanja = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ISBN = c.String(maxLength: 200),
                        Taken = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Konferencija = c.String(maxLength: 200),
                        AnimatorskaKuca = c.String(maxLength: 200),
                        BrojIzdanja = c.Decimal(precision: 10, scale: 0),
                        Specijalno = c.Decimal(precision: 1, scale: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.KnjigaId);
            
            CreateTable(
                "EC17455.Users",
                c => new
                    {
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserName = c.String(maxLength: 200),
                        Ime = c.String(maxLength: 200),
                        Prezime = c.String(maxLength: 200),
                        MaticniBroj = c.String(maxLength: 200),
                        DatumRodjenja = c.DateTime(nullable: false),
                        PasswordHash = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        ClanId = c.Decimal(precision: 10, scale: 0),
                        Comment = c.String(maxLength: 200),
                        Sifra = c.String(maxLength: 200),
                        State = c.Decimal(precision: 10, scale: 0),
                        Cash = c.Double(),
                        WorkerId = c.String(maxLength: 200),
                        ImageDataId = c.Decimal(precision: 10, scale: 0),
                        Occupation = c.String(maxLength: 200),
                        Salary = c.Double(),
                        UserAdminId = c.Decimal(precision: 10, scale: 0),
                        UniWorkerID = c.String(),
                        Index = c.String(),
                        Level = c.Decimal(precision: 10, scale: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("EC17455.ImageDatas", t => t.ImageDataId)
                .Index(t => t.ImageDataId);
            
            CreateTable(
                "EC17455.Records",
                c => new
                    {
                        RecordId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        KnjigaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ClanId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("EC17455.Users", t => t.ClanId, cascadeDelete: true)
                .ForeignKey("EC17455.Knjigas", t => t.KnjigaId, cascadeDelete: true)
                .Index(t => t.KnjigaId)
                .Index(t => t.ClanId);
            
            CreateTable(
                "EC17455.Roles",
                c => new
                    {
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                        DisplayName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "EC17455.ImageDatas",
                c => new
                    {
                        ImageDataId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ImageDate = c.DateTime(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageDataId);
            
            CreateTable(
                "EC17455.UserRoles",
                c => new
                    {
                        User_UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Role_RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("EC17455.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("EC17455.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "EC17455.KnjigaClans",
                c => new
                    {
                        Knjiga_KnjigaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Clan_UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Knjiga_KnjigaId, t.Clan_UserId })
                .ForeignKey("EC17455.Knjigas", t => t.Knjiga_KnjigaId, cascadeDelete: true)
                .ForeignKey("EC17455.Users", t => t.Clan_UserId, cascadeDelete: true)
                .Index(t => t.Knjiga_KnjigaId)
                .Index(t => t.Clan_UserId);
            
            CreateTable(
                "EC17455.KnjigaAuthors",
                c => new
                    {
                        Knjiga_KnjigaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Author_AuthorId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Knjiga_KnjigaId, t.Author_AuthorId })
                .ForeignKey("EC17455.Knjigas", t => t.Knjiga_KnjigaId, cascadeDelete: true)
                .ForeignKey("EC17455.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Knjiga_KnjigaId)
                .Index(t => t.Author_AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("EC17455.KnjigaAuthors", "Author_AuthorId", "EC17455.Authors");
            DropForeignKey("EC17455.KnjigaAuthors", "Knjiga_KnjigaId", "EC17455.Knjigas");
            DropForeignKey("EC17455.KnjigaClans", "Clan_UserId", "EC17455.Users");
            DropForeignKey("EC17455.KnjigaClans", "Knjiga_KnjigaId", "EC17455.Knjigas");
            DropForeignKey("EC17455.Users", "ImageDataId", "EC17455.ImageDatas");
            DropForeignKey("EC17455.UserRoles", "Role_RoleId", "EC17455.Roles");
            DropForeignKey("EC17455.UserRoles", "User_UserId", "EC17455.Users");
            DropForeignKey("EC17455.Records", "KnjigaId", "EC17455.Knjigas");
            DropForeignKey("EC17455.Records", "ClanId", "EC17455.Users");
            DropIndex("EC17455.KnjigaAuthors", new[] { "Author_AuthorId" });
            DropIndex("EC17455.KnjigaAuthors", new[] { "Knjiga_KnjigaId" });
            DropIndex("EC17455.KnjigaClans", new[] { "Clan_UserId" });
            DropIndex("EC17455.KnjigaClans", new[] { "Knjiga_KnjigaId" });
            DropIndex("EC17455.UserRoles", new[] { "Role_RoleId" });
            DropIndex("EC17455.UserRoles", new[] { "User_UserId" });
            DropIndex("EC17455.Records", new[] { "ClanId" });
            DropIndex("EC17455.Records", new[] { "KnjigaId" });
            DropIndex("EC17455.Users", new[] { "ImageDataId" });
            DropTable("EC17455.KnjigaAuthors");
            DropTable("EC17455.KnjigaClans");
            DropTable("EC17455.UserRoles");
            DropTable("EC17455.ImageDatas");
            DropTable("EC17455.Roles");
            DropTable("EC17455.Records");
            DropTable("EC17455.Users");
            DropTable("EC17455.Knjigas");
            DropTable("EC17455.Authors");
        }
    }
}
