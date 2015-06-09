using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HouApp_Web.Data;
using HouApp_Web.Data.Models;

namespace HouApp_Web.Controllers
{
    public class ImageCollabsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ImageCollabsApi
        public IQueryable<ImageCollab> GetImageCollabs()
        {
            return db.ImageCollabs;
        }

        // GET: api/ImageCollabsApi/5
        [ResponseType(typeof(ImageCollab))]
        public IHttpActionResult GetImageCollab(int id)
        {
            ImageCollab imageCollab = db.ImageCollabs.Find(id);
            if (imageCollab == null)
            {
                return NotFound();
            }

            return Ok(imageCollab);
        }

        // PUT: api/ImageCollabsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageCollab(int id, ImageCollab imageCollab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageCollab.ImageCollabId)
            {
                return BadRequest();
            }

            db.Entry(imageCollab).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageCollabExists(id))
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

        // POST: api/ImageCollabsApi
        [ResponseType(typeof(ImageCollab))]
        public IHttpActionResult PostImageCollab(ImageCollab imageCollab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageCollabs.Add(imageCollab);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imageCollab.ImageCollabId }, imageCollab);
        }

        // DELETE: api/ImageCollabsApi/5
        [ResponseType(typeof(ImageCollab))]
        public IHttpActionResult DeleteImageCollab(int id)
        {
            ImageCollab imageCollab = db.ImageCollabs.Find(id);
            if (imageCollab == null)
            {
                return NotFound();
            }

            db.ImageCollabs.Remove(imageCollab);
            db.SaveChanges();

            return Ok(imageCollab);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageCollabExists(int id)
        {
            return db.ImageCollabs.Count(e => e.ImageCollabId == id) > 0;
        }
    }
}