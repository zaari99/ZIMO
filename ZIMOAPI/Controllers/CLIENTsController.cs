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
using ZIMOAPI;

namespace ZIMOAPI.Controllers
{
    public class CLIENTsController : ApiController
    {
        private FORMATIONEntities3 db = new FORMATIONEntities3();

        // GET: api/CLIENTs
        public IQueryable<CLIENT> GetCLIENTs()
        {
            return db.CLIENTs;
        }

        // GET: api/CLIENTs/5
        [ResponseType(typeof(CLIENT))]
        public IHttpActionResult GetCLIENT(int id)
        {
            CLIENT cLIENT = db.CLIENTs.Find(id);
            if (cLIENT == null)
            {
                return NotFound();
            }

            return Ok(cLIENT);
        }

        // PUT: api/CLIENTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLIENT(int id, CLIENT cLIENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENT.IDClient)
            {
                return BadRequest();
            }

            db.Entry(cLIENT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTExists(id))
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

        // POST: api/CLIENTs
        [ResponseType(typeof(CLIENT))]
        public IHttpActionResult PostCLIENT(CLIENT cLIENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTs.Add(cLIENT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cLIENT.IDClient }, cLIENT);
        }

        // DELETE: api/CLIENTs/5
        [ResponseType(typeof(CLIENT))]
        public IHttpActionResult DeleteCLIENT(int id)
        {
            CLIENT cLIENT = db.CLIENTs.Find(id);
            if (cLIENT == null)
            {
                return NotFound();
            }

            db.CLIENTs.Remove(cLIENT);
            db.SaveChanges();

            return Ok(cLIENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLIENTExists(int id)
        {
            return db.CLIENTs.Count(e => e.IDClient == id) > 0;
        }
    }
}