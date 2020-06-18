namespace VideoGameCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoGames",
                c => new
                    {
                        p_GameId = c.Int(nullable: false, identity: true),
                        p_GameName = c.String(nullable: false),
                        p_ReleaseDate = c.DateTime(nullable: false),
                        p_Ratings = c.String(),
                        p_ESRBRating = c.String(),
                        p_Category = c.String(nullable: false),
                        p_Price = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.p_GameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideoGames");
        }
    }
}
