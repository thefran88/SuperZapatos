using BasicAuthentication;
using Super_Zapatos.Data;
using Super_Zapatos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Super_Zapatos_Services.Controllers
{
    [BasicAuthentication]
    public class StoresController : ApiController
    {
        private MainContext db = new MainContext();

        //GET: /services/stores
        /// <summary>
        /// Load all the stores that are stored in the Database.
        /// </summary>
        [HttpGet]
        public IHttpActionResult GetStores()
        {
            bool success = true;
            try
            {
                var stores = db.Stores.ToList();
                int total_elements = stores.Count;

                return Json(new { stores, success, total_elements });
            }
            catch (Exception)
            {
                success = false;
                return Json(new { success });
            }
        }

        //GET: /stores/id
        /// <summary>
        /// Load the store the matches the given id.
        /// </summary>
        /// <param name="id">A numeric value of the ID of the store</param>
        /// <returns></returns>
        [HttpGet]
        [Route("services/stores/{id}")]
        public IHttpActionResult GetStore(int? id)
        {
            bool success = true;
            try
            {
                if (id == null)
                {
                    string error_msg = "Bad Request";
                    string error_code = "400";
                    success = false;

                    return Json(new { error_msg, error_code, success });
                }

                var store = db.Stores.Find(id);
                success = store != null;

                if (!success)
                {
                    string error_msg = "Record not Found";
                    string error_code = "404";
                    success = false;

                    return Json(new { error_msg, error_code, success });
                }

                return Json(new { store, success });
            }
            catch (Exception)
            {
                success = false;
                return Json(new { success });
            }
        }

        [HttpPost]
        [Route("services/stores/post/{store}")]
        public IHttpActionResult PostStore(Store store)
        {
            bool success = false;
            try
            {
                db.Stores.Add(store);
                db.SaveChanges();

                success = true;
                return Json(new { success });
            }
            catch (Exception)
            {
                return Json(new { success });
            }
        }

        [HttpPut]
        [Route("services/stores/put/{store}")]
        public IHttpActionResult PutStore(Store store)
        {
            bool success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(store).State = EntityState.Modified;
                    db.SaveChanges();

                    success = true;
                    return Json(new { success });
                }

                return Json(new { success });
            }
            catch (Exception)
            {
                return Json(new { success });
            }
        }

        [HttpDelete]
        [Route("services/stores/delete/{id}")]
        public IHttpActionResult DeleteStore(int id)
        {
            bool success = false;
            try
            {
                var store = new Store { id = id };

                if (!db.Stores.Local.Any(s => s.id == id))
                    db.Stores.Attach(store);

                db.Stores.Remove(store);
                db.SaveChanges();

                success = true;
                return Json(new { success });
            }
            catch (Exception)
            {
                return Json(new { success });
            }
        }
    }
}
