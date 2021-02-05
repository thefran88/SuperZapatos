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
    public class ArticlesController : ApiController
    {
        private MainContext db = new MainContext();

        //GET: /services/articles
        /// <summary>
        /// Load all the articles that are in the Database.
        /// </summary>
        [HttpGet]
        public IHttpActionResult GetArticles()
        {
            bool success = false;
            try
            {
                var articles = db.Articles.ToList();
                int total_elements = articles.Count;

                success = true;
                return Json(new { articles, success, total_elements });
            }
            catch (Exception)
            {
                success = false;
                return Json(new { success });
            }
        }

        //GET: /services/stores
        /// <summary>
        /// Load all the articles from a specific store that are in the Database.
        /// </summary>
        /// <param name="id">A numeric value of the ID of the store</param>
        [HttpGet]
        [Route("services/articles/stores/{id}")]
        public IHttpActionResult GetArticles(int? id)
        {
            bool success = false;
            try
            {
                if (id == null)
                {
                    string error_msg = "Bad Request";
                    string error_code = "400";
                    success = false;

                    return Json(new { error_msg, error_code, success });
                }

                if (!db.Stores.Any(s => s.id == id))
                {
                    string error_msg = "Record not Found";
                    string error_code = "404";
                    success = false;

                    return Json(new { error_msg, error_code, success });
                }

                var articles = db.Articles.Where(a => a.store.id == id).ToList();
                int total_elements = articles.Count;

                success = true;

                return Json(new { articles, success, total_elements });
            }
            catch (Exception)
            {
                success = false;
                return Json(new { success });
            }
        }

        //GET: /articles/id
        /// <summary>
        /// Load the article the matches the given id.
        /// </summary>
        /// <param name="id">A numeric value of the ID of the article</param>
        /// <returns></returns>
        [HttpGet]
        [Route("services/articles/{id}")]
        public IHttpActionResult GetArticle(int? id)
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

                var article = db.Articles.Find(id);
                success = article != null;

                if (!success)
                {
                    string error_msg = "Record not Found";
                    string error_code = "404";
                    success = false;

                    return Json(new { error_msg, error_code, success });
                }

                return Json(new { article, success });
            }
            catch (Exception)
            {
                success = false;
                return Json(new { success });
            }
        }

        [HttpPost]
        [Route("services/articles/post/{article}")]
        public IHttpActionResult PostArticle(Article article)
        {
            bool success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedStore = new Store { id = article.store.id };

                    if (!db.Stores.Local.Any(s => s.id == selectedStore.id))
                    {
                        db.Stores.Attach(selectedStore);
                        article.store = selectedStore;
                    }

                    db.Articles.Add(article);
                    db.SaveChanges();

                    success = true;
                }

                return Json(new { success });
            }
            catch (Exception)
            {
                return Json(new { success });
            }
        }

        [HttpPut]
        [Route("services/articles/put/{article}")]
        public IHttpActionResult PutArticle(Article article)
        {
            bool success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedStore = db.Stores.Find(article.store.id);
                    var newArticle = db.Articles.Find(article.id);

                    newArticle.name = article.name;
                    newArticle.description = article.description;
                    newArticle.price = article.price;
                    newArticle.total_in_shelf = article.total_in_shelf;
                    newArticle.total_in_vault = article.total_in_vault;
                    
                    db.Articles.Attach(newArticle);

                    if (!db.Stores.Local.Any(s => s.id == selectedStore.id))
                    {
                        db.Stores.Attach(selectedStore);
                    }

                    newArticle.store = selectedStore;
                    db.Entry(newArticle).State = EntityState.Modified;
                    db.SaveChanges();

                    success = true;
                }

                return Json(new { success });
            }
            catch (Exception)
            {
                return Json(new { success });
            }
        }

        [HttpDelete]
        [Route("services/articles/delete/{id}")]
        public IHttpActionResult DeleteArticle(int id)
        {
            bool success = false;
            try
            {
                var article = new Article { id = id };

                if (!db.Articles.Local.Any(m => m.id == id))
                    db.Articles.Attach(article);

                db.Articles.Remove(article);
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
