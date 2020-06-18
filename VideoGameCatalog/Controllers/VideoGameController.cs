/*
 * Video Game Controller
*/
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VideoGameCatalog.Models;

namespace VideoGameCatalog.Controllers
{
    public class VideoGameController : ApiController
    {
        private VideoContext db = new VideoContext();

        public VideoGameController() { }

        [Route("api/getallgames")]
        public IEnumerable<VideoGame> GetAllVideoGames()
        {
            return db.Games;
        }

        // GET: api/Games
        public IQueryable<VideoGame> GetGames()
        {
            return db.Games;
        }

        [Route("api/getgame/{id}")]
        // GET: api/Games/5
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult GetGame(int id)
        {
            VideoGame game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGame(int id, VideoGame game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.p_GameId)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(VideoGame))]
        [Route("api/postgame/{id}")]
        public async Task<IHttpActionResult> PostGame(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VideoGame game = db.Games.FirstOrDefault((v) => v.p_GameId == id);

            // If no match - add, else update
            if (db.Games.FirstOrDefault((v) => v.p_GameId == game.p_GameId) == null)
            {
                db.Games.Add(game);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = game.p_GameId }, game);
            } else
            {
                db.Entry(game).State = EntityState.Modified;
                
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                { 
                    if (!GameExists(game.p_GameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtRoute("DefaultApi", new { id = game.p_GameId }, game);
            }
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(VideoGame))]
        [Route("api/game/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteGame(int id)
        {
            // VideoGame game = await db.Games.FindAsync(id);
            VideoGame game = db.Games.FirstOrDefault((v) => v.p_GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool GameExists(int id)
        {
            return db.Games.Count(e => e.p_GameId == id) > 0;
        }
    }

}