namespace Noticias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinhaPRimeiraMigracao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noticias", "FotografiaFK", "dbo.Fotografos");
            DropIndex("dbo.Noticias", new[] { "FotografiaFK" });
            AddColumn("dbo.Noticias", "Titulo", c => c.String());
            DropColumn("dbo.Noticias", "Titutlo");
            DropColumn("dbo.Noticias", "FotografiaFK");
            DropTable("dbo.Fotografos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fotografos",
                c => new
                    {
                        FotografosID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.FotografosID);
            
            AddColumn("dbo.Noticias", "FotografiaFK", c => c.Int(nullable: false));
            AddColumn("dbo.Noticias", "Titutlo", c => c.String());
            DropColumn("dbo.Noticias", "Titulo");
            CreateIndex("dbo.Noticias", "FotografiaFK");
            AddForeignKey("dbo.Noticias", "FotografiaFK", "dbo.Fotografos", "FotografosID");
        }
    }
}
