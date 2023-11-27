namespace SikayetTakip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.musteriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sikayetler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Detay = c.String(),
                        KayitTarih = c.DateTime(nullable: false),
                        MusteriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.musteriler", t => t.MusteriId, cascadeDelete: true)
                .Index(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sikayetler", "MusteriId", "dbo.musteriler");
            DropIndex("dbo.sikayetler", new[] { "MusteriId" });
            DropTable("dbo.sikayetler");
            DropTable("dbo.musteriler");
        }
    }
}
