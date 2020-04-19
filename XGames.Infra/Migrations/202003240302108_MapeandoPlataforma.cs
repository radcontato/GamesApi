namespace XGames.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MapeandoPlataforma : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsolePlataform", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsolePlataform", "Nome", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
