namespace XGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsolePlataform",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_JOGADOR_EMAIL");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Player", "UK_JOGADOR_EMAIL");
            DropTable("dbo.Player");
            DropTable("dbo.ConsolePlataform");
        }
    }
}
