namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrigen = c.String(),
                        IdDestino = c.String(),
                        resultado = c.String(),
                        Fecha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Historials");
        }
    }
}
