using VideoGameCatalog.Models;
namespace VideoGameCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoGameCatalog.Models.VideoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoGameCatalog.Models.VideoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            /// INITIAL Prepopulation of Video Game Data
            context.Games.AddOrUpdate(v => v.p_GameId,
                new Models.VideoGame { p_GameId = 1, p_GameName = "The Last of Us Part 2", p_ReleaseDate = new DateTime(2020, 06, 19), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating),0), p_Ratings = "5", p_Category = Enum.GetName(typeof(Models.Categories), 0), p_Price = "$54.99" },
                new Models.VideoGame { p_GameId = 2, p_GameName = "Call of Duty: Modern Warfare", p_ReleaseDate = new DateTime(2019, 03, 10), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 1), p_Ratings = "5", p_Category = Enum.GetName(typeof(Models.Categories), 1), p_Price = "$59.99" },
                new Models.VideoGame { p_GameId = 3, p_GameName = "NBA 2K20", p_ReleaseDate = new DateTime(2018, 04, 11), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 2), p_Ratings = "4", p_Category = Enum.GetName(typeof(Models.Categories), 2), p_Price = "$19.99" },
                new Models.VideoGame { p_GameId = 4, p_GameName = "Sea of Thieves", p_ReleaseDate = new DateTime(2019, 01, 01), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 1), p_Ratings = "4", p_Category = Enum.GetName(typeof(Models.Categories), 3), p_Price = "$9.99" },
                new Models.VideoGame { p_GameId = 5, p_GameName = "Grand Theft Auto V", p_ReleaseDate = new DateTime(2019, 12, 19), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 3), p_Ratings = "4", p_Category = Enum.GetName(typeof(Models.Categories), 4), p_Price = "$17.99" },
                new Models.VideoGame { p_GameId = 6, p_GameName = "Forza Horizon 4", p_ReleaseDate = new DateTime(2019, 08, 01), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 2), p_Ratings = "3", p_Category = Enum.GetName(typeof(Models.Categories), 5), p_Price = "$24.99" },
                new Models.VideoGame { p_GameId = 7, p_GameName = "Need for Speed Heat", p_ReleaseDate = new DateTime(2018, 06, 05), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 3), p_Ratings = "4", p_Category = Enum.GetName(typeof(Models.Categories), 6), p_Price = "$59.99" },
                new Models.VideoGame { p_GameId = 8, p_GameName = "Minecraft Xbox One Edition", p_ReleaseDate = new DateTime(2018, 06, 04), p_ESRBRating = Enum.GetName(typeof(Models.ESRPRating), 0), p_Ratings = "3", p_Category = Enum.GetName(typeof(Models.Categories), 7), p_Price = "$54.99" }
                );
        }
    }
}
