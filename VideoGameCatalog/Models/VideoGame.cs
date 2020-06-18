/*
 * Video Game Module
*/
using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Code First Model for Video Game Catalog 
/// </summary>
namespace VideoGameCatalog.Models
{
    public class VideoGame
    {
        /// <summary>
        /// Default
        /// </summary>
        public VideoGame() { }

        /// <summary>
        /// Property: Video Game Id
        /// </summary>
        [Key]
        public int p_GameId { get; set; }

        /// <summary>
        /// Required Property: Video Game Name 
        /// </summary>
        [Required]
        public string p_GameName { get; set; }

        /// <summary>
        /// Required Property: Video Game Release Date 
        /// </summary>
        [Required]
        public DateTime? p_ReleaseDate { get; set; }

        /// <summary>
        /// Property: Video Game Rating 
        /// </summary>
        public string p_Ratings { get; set; }


        /// <summary>
        /// Property: Video Game ESRBRating
        /// </summary>
        public string p_ESRBRating { get; set; }

        /// <summary>
        /// Required Property: Video Game Category  
        /// </summary>
        [Required]
        public string p_Category { get; set; }

        /// <summary>
        /// Required Property: Video Game Price  
        /// </summary>
        [Required]
        public string p_Price { get; set; }

    }

    /// <summary>
    /// Predefined ESRPRating
    /// </summary>
    public enum ESRPRating
    {
        Teen,
        Mature,
        Adult,
        Everyone,
        RatingPending
    }

    /// <summary>
    /// Predefined Video Game Categories
    /// </summary>
    public enum Categories
    {
        PS4,
        XBOXONE,
        Nintendo,
        PCGaming,
        DigitalContent,
        Esports,
        VirtualReality,
        PreOwnedGames,
        RetroGaming,
        MorePlatforms
    }

}