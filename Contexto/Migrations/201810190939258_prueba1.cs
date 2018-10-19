namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pais", "Nombre", c => c.String());
            DropColumn("dbo.Pais", "nombrePais");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pais", "nombrePais", c => c.String());
            DropColumn("dbo.Pais", "Nombre");
        }
    }
}
