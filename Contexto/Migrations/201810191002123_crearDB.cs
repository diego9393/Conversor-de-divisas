namespace Contexto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearDB : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pais");
            AlterColumn("dbo.Pais", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pais", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Pais");
            AlterColumn("dbo.Pais", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Pais", "Id");
        }
    }
}
