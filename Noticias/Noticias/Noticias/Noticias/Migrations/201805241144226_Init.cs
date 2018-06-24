namespace Noticias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        NoticiasID = c.Int(nullable: false, identity: true),
                        Resumo = c.String(),
                        Texto = c.String(),
                        Titutlo = c.String(),
                        Data = c.DateTime(nullable: false),
                        CategoriaFK = c.Int(nullable: false),
                        JornalistaFK = c.Int(nullable: false),
                        FotografiaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoticiasID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaFK)
                .ForeignKey("dbo.Fotografos", t => t.FotografiaFK)
                .ForeignKey("dbo.Jornalistas", t => t.JornalistaFK)
                .Index(t => t.CategoriaFK)
                .Index(t => t.JornalistaFK)
                .Index(t => t.FotografiaFK);
            
            CreateTable(
                "dbo.Fotografos",
                c => new
                    {
                        FotografosID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.FotografosID);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagemID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Tipo = c.String(),
                        Directorio = c.String(),
                        NoticiaFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagemID)
                .ForeignKey("dbo.Noticias", t => t.NoticiaFK)
                .Index(t => t.NoticiaFK);
            
            CreateTable(
                "dbo.Jornalistas",
                c => new
                    {
                        JornalistasID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.JornalistasID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "JornalistaFK", "dbo.Jornalistas");
            DropForeignKey("dbo.Imagens", "NoticiaFK", "dbo.Noticias");
            DropForeignKey("dbo.Noticias", "FotografiaFK", "dbo.Fotografos");
            DropForeignKey("dbo.Noticias", "CategoriaFK", "dbo.Categorias");
            DropIndex("dbo.Imagens", new[] { "NoticiaFK" });
            DropIndex("dbo.Noticias", new[] { "FotografiaFK" });
            DropIndex("dbo.Noticias", new[] { "JornalistaFK" });
            DropIndex("dbo.Noticias", new[] { "CategoriaFK" });
            DropTable("dbo.Jornalistas");
            DropTable("dbo.Imagens");
            DropTable("dbo.Fotografos");
            DropTable("dbo.Noticias");
            DropTable("dbo.Categorias");
        }
    }
}
