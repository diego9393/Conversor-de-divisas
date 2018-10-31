namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FactorConversions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonedaDestino_Id = c.Int(),
                        MonedaOrigen_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Monedas", t => t.MonedaDestino_Id)
                .ForeignKey("dbo.Monedas", t => t.MonedaOrigen_Id)
                .Index(t => t.MonedaDestino_Id)
                .Index(t => t.MonedaOrigen_Id);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificadorMoneda = c.String(),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FactorConversions", "MonedaOrigen_Id", "dbo.Monedas");
            DropForeignKey("dbo.FactorConversions", "MonedaDestino_Id", "dbo.Monedas");
            DropIndex("dbo.FactorConversions", new[] { "MonedaOrigen_Id" });
            DropIndex("dbo.FactorConversions", new[] { "MonedaDestino_Id" });
            DropTable("dbo.Monedas");
            DropTable("dbo.FactorConversions");
        }
    }
}
