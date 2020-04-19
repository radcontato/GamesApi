namespace XGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, maxLength: 255, unicode: false),
                        Producer = c.String(maxLength: 50, unicode: false),
                        Distributor = c.String(maxLength: 50, unicode: false),
                        Genre = c.String(nullable: false, maxLength: 30, unicode: false),
                        Site = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
