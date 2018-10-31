namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        idPais = c.String(),
                        nombrePais = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pais");
        }
    }
}
