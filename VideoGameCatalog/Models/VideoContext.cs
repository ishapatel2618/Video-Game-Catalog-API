using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VideoGameCatalog.Models
{
    public class VideoContext : DbContext
    {
        public VideoContext() : base("name=VideoContext") { }
        //public static VideoContext Create()
        //{
        //    return new VideoContext();
        //}
        public DbSet<VideoGame> Games { get; set; }
    }
}