namespace ProjetoFinalEletronicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionametosTabelas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "MarcaId", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "MarcaId");
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropIndex("dbo.Produtoes", new[] { "MarcaId" });
            DropColumn("dbo.Produtoes", "CategoriaId");
            DropColumn("dbo.Produtoes", "MarcaId");
        }
    }
}
