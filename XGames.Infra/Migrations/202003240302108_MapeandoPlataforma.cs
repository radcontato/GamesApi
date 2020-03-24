namespace XGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapeandoPlataforma : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Console", newName: "ConsolePlataform");
            AlterColumn("dbo.ConsolePlataform", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsolePlataform", "Nome", c => c.String(maxLength: 100, unicode: false));
            RenameTable(name: "dbo.ConsolePlataform", newName: "Console");
        }
    }
}
