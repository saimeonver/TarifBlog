namespace TarifBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etikets",
                c => new
                    {
                        EtiketID = c.Int(nullable: false, identity: true),
                        EtiketAdi = c.String(),
                    })
                .PrimaryKey(t => t.EtiketID);
            
            CreateTable(
                "dbo.TarifEtikets",
                c => new
                    {
                        TarifEtiketID = c.Int(nullable: false, identity: true),
                        TarifID = c.Int(nullable: false),
                        EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarifEtiketID)
                .ForeignKey("dbo.Etikets", t => t.EtiketID, cascadeDelete: true)
                .ForeignKey("dbo.Tarifs", t => t.TarifID, cascadeDelete: true)
                .Index(t => t.TarifID)
                .Index(t => t.EtiketID);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        TarifID = c.Int(nullable: false, identity: true),
                        TarifAdi = c.String(),
                        Malzemeler = c.String(),
                        Yapilis = c.String(),
                        Foto = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        KategoriID = c.Int(),
                        UyeID = c.Int(),
                        Okunma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarifID)
                .ForeignKey("dbo.Kategoris", t => t.KategoriID)
                .ForeignKey("dbo.Uyes", t => t.UyeID)
                .Index(t => t.KategoriID)
                .Index(t => t.UyeID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        UyeID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Email = c.String(),
                        Sifre = c.String(),
                        AdSoyad = c.String(),
                        YetkiID = c.Int(),
                    })
                .PrimaryKey(t => t.UyeID)
                .ForeignKey("dbo.Yetkis", t => t.YetkiID)
                .Index(t => t.YetkiID);
            
            CreateTable(
                "dbo.Yetkis",
                c => new
                    {
                        YetkiID = c.Int(nullable: false, identity: true),
                        Yetkiler = c.String(),
                    })
                .PrimaryKey(t => t.YetkiID);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        İcerik = c.String(),
                        UyeID = c.Int(),
                        TarifID = c.Int(),
                        YorumTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.Tarifs", t => t.TarifID)
                .ForeignKey("dbo.Uyes", t => t.UyeID)
                .Index(t => t.UyeID)
                .Index(t => t.TarifID);
            
            CreateTable(
                "dbo.TarifEtiket1",
                c => new
                    {
                        Tarif_TarifID = c.Int(nullable: false),
                        Etiket_EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tarif_TarifID, t.Etiket_EtiketID })
                .ForeignKey("dbo.Tarifs", t => t.Tarif_TarifID, cascadeDelete: true)
                .ForeignKey("dbo.Etikets", t => t.Etiket_EtiketID, cascadeDelete: true)
                .Index(t => t.Tarif_TarifID)
                .Index(t => t.Etiket_EtiketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarifs", "UyeID", "dbo.Uyes");
            DropForeignKey("dbo.Yorums", "UyeID", "dbo.Uyes");
            DropForeignKey("dbo.Yorums", "TarifID", "dbo.Tarifs");
            DropForeignKey("dbo.Uyes", "YetkiID", "dbo.Yetkis");
            DropForeignKey("dbo.Tarifs", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.TarifEtiket1", "Etiket_EtiketID", "dbo.Etikets");
            DropForeignKey("dbo.TarifEtiket1", "Tarif_TarifID", "dbo.Tarifs");
            DropForeignKey("dbo.TarifEtikets", "TarifID", "dbo.Tarifs");
            DropForeignKey("dbo.TarifEtikets", "EtiketID", "dbo.Etikets");
            DropIndex("dbo.TarifEtiket1", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.TarifEtiket1", new[] { "Tarif_TarifID" });
            DropIndex("dbo.Yorums", new[] { "TarifID" });
            DropIndex("dbo.Yorums", new[] { "UyeID" });
            DropIndex("dbo.Uyes", new[] { "YetkiID" });
            DropIndex("dbo.Tarifs", new[] { "UyeID" });
            DropIndex("dbo.Tarifs", new[] { "KategoriID" });
            DropIndex("dbo.TarifEtikets", new[] { "EtiketID" });
            DropIndex("dbo.TarifEtikets", new[] { "TarifID" });
            DropTable("dbo.TarifEtiket1");
            DropTable("dbo.Yorums");
            DropTable("dbo.Yetkis");
            DropTable("dbo.Uyes");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Tarifs");
            DropTable("dbo.TarifEtikets");
            DropTable("dbo.Etikets");
        }
    }
}
