namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombremigracion : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FactorConversions", new[] { "MonedaDestino_Id" });
            AddColumn("dbo.FactorConversions", "IdMonedaDestino_Id", c => c.Int());
            AddColumn("dbo.FactorConversions", "IdMonedaOrigen_Id", c => c.Int());
            CreateIndex("dbo.FactorConversions", "IdMonedaDestino_Id");
            CreateIndex("dbo.FactorConversions", "IdMonedaOrigen_Id");
            CreateIndex("dbo.FactorConversions", "monedaDestino_Id");
            AddForeignKey("dbo.FactorConversions", "IdMonedaDestino_Id", "dbo.Monedas", "Id");
            AddForeignKey("dbo.FactorConversions", "IdMonedaOrigen_Id", "dbo.Monedas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FactorConversions", "IdMonedaOrigen_Id", "dbo.Monedas");
            DropForeignKey("dbo.FactorConversions", "IdMonedaDestino_Id", "dbo.Monedas");
            DropIndex("dbo.FactorConversions", new[] { "monedaDestino_Id" });
            DropIndex("dbo.FactorConversions", new[] { "IdMonedaOrigen_Id" });
            DropIndex("dbo.FactorConversions", new[] { "IdMonedaDestino_Id" });
            DropColumn("dbo.FactorConversions", "IdMonedaOrigen_Id");
            DropColumn("dbo.FactorConversions", "IdMonedaDestino_Id");
            CreateIndex("dbo.FactorConversions", "MonedaDestino_Id");
        }
    }
}
