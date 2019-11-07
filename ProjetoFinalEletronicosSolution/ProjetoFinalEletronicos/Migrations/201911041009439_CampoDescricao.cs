namespace ProjetoFinalEletronicos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoDescricao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Descricao");
        }
    }
}
