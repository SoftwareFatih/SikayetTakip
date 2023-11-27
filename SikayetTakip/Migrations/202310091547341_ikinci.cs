namespace SikayetTakip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ikinci : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.musteriler", "AdSoyad", c => c.String(nullable: false));
            AlterColumn("dbo.sikayetler", "Baslik", c => c.String(nullable: false));
            AlterColumn("dbo.sikayetler", "Detay", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.sikayetler", "Detay", c => c.String());
            AlterColumn("dbo.sikayetler", "Baslik", c => c.String());
            AlterColumn("dbo.musteriler", "AdSoyad", c => c.String());
        }
    }
}
