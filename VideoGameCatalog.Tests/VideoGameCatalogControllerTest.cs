using System;
using VideoGameCatalog.Controllers;
using VideoGameCatalog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VideoGameCatalog;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Results;

namespace VideoGameCatalog.Tests
{
    [TestClass]
    public class VideoGameCatalogControllerTest
    {
        private VideoContext dbt = new VideoContext();

        [TestMethod]
        public void GetAllVideoGames_ReturnAllVideoGames()
        {
            var testVideoGames = GetTestVideoGames();
            var controller = new VideoGameController();

            var results = controller.GetAllVideoGames().ToList();
            Assert.AreEqual(testVideoGames.Count, results.Count);
        }

        [TestMethod]
        public void GetAllVideoGames_ParticularVideoGames()
        {
            var testVideoGames = GetTestVideoGames();
            var controller = new VideoGameController();
            var result = controller.GetGame(1) as OkNegotiatedContentResult<VideoGame>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testVideoGames[0].p_GameId, result.Content.p_GameId);
        }

        [TestMethod]
        public void GetAllVideoGames_VideoGamesNotFound()
        {
            var controller = new VideoGameController();
            var result = controller.GetGame(15);

            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetExist_True()
        {
            int testGameId = 1;
            var testVideoGames = GetTestVideoGames();
            var testResult = testVideoGames.Count(e => e.p_GameId == testGameId) > 0;

            Assert.AreEqual(testResult, true);
        }

        [TestMethod]
        public void GetExist_False()
        {
            int testGameId = 100;
            var testVideoGames = GetTestVideoGames();
            var testResult = testVideoGames.Count(e => e.p_GameId == testGameId) > 0;

            Assert.AreEqual(testResult, false);
        }


        private List<VideoGame> GetTestVideoGames()
        {
            var testVideoGames = new List<VideoGame>();
            testVideoGames.Add(new VideoGame { p_GameId = 1, p_GameName = "The Last of Us Part 2", p_ReleaseDate = new DateTime(2020, 06, 19), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 0), p_Ratings = "5", p_Category = Enum.GetName(typeof(Categories), 0), p_Price = "$54.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 2, p_GameName = "Call of Duty: Modern Warfare", p_ReleaseDate = new DateTime(2019, 03, 10), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 1), p_Ratings = "5", p_Category = Enum.GetName(typeof(Categories), 1), p_Price = "$59.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 3, p_GameName = "NBA 2K20", p_ReleaseDate = new DateTime(2018, 04, 11), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 2), p_Ratings = "4", p_Category = Enum.GetName(typeof(Categories), 2), p_Price = "$19.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 4, p_GameName = "Sea of Thieves", p_ReleaseDate = new DateTime(2019, 01, 01), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 1), p_Ratings = "4", p_Category = Enum.GetName(typeof(Categories), 3), p_Price = "$9.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 5, p_GameName = "Grand Theft Auto V", p_ReleaseDate = new DateTime(2019, 12, 19), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 3), p_Ratings = "4", p_Category = Enum.GetName(typeof(Categories), 4), p_Price = "$17.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 6, p_GameName = "Forza Horizon 4", p_ReleaseDate = new DateTime(2019, 08, 01), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 2), p_Ratings = "3", p_Category = Enum.GetName(typeof(Categories), 5), p_Price = "$24.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 7, p_GameName = "Need for Speed Heat", p_ReleaseDate = new DateTime(2018, 06, 05), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 3), p_Ratings = "4", p_Category = Enum.GetName(typeof(Categories), 6), p_Price = "$59.99" });
            testVideoGames.Add(new VideoGame { p_GameId = 8, p_GameName = "Minecraft Xbox One Edition", p_ReleaseDate = new DateTime(2018, 06, 04), p_ESRBRating = Enum.GetName(typeof(ESRPRating), 0), p_Ratings = "3", p_Category = Enum.GetName(typeof(Categories), 7), p_Price = "$54.99" });
            return testVideoGames;
        }
    }
}
