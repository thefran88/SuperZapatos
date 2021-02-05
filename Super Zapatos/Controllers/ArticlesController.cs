using Newtonsoft.Json;
using Super_Zapatos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Super_Zapatos.Controllers
{
    public class ArticlesController : Controller
    {
        readonly string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        // GET: Articles
        public async Task<ActionResult> Index(int? StoresSelectedID)
        {
            var vm = new Articles_Index_VM();
            await vm.GetArticlesAsync(StoresSelectedID);

            return View(vm);
        }

        // GET: Articles/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await ArticlesServices.GetArticleAsync(id);

            if (response.success)
            {
                return View(response.article);
            }
            else
            {
                ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener el artículo.";
                return View("Error");
            }
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            var vm = new Articles_Create_VM();
            return View(vm);
        }

        // POST: Articles/Create
        [HttpPost]
        public async Task<ActionResult> Create(Articles_Create_VM vm)
        {
            ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener la tienda.";

            try
            {
                vm.Article.Store = new Store { id = vm.StoresSelectedID};
                var response = await ArticlesServices.PostArticlesAsync(vm.Article);

                if (response.success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var response = await ArticlesServices.GetArticleAsync((int)id);
                var vm = new Articles_Create_VM(response.article);
                if (response.success)
                {
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener el artículo.";
                    return View("Error");
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMsg = "Ocurrió un error al tratar de editar el artículo.";
                return View("Error");
            }
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Articles_Create_VM vm)
        {
            try
            {
                vm.Article.Store = new Store { id = vm.StoresSelectedID };
                var response = await ArticlesServices.PutArticlesAsync(vm.Article);

                if (response.success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await ArticlesServices.GetArticleAsync((int)id);

            if (response.success)
            {
                return View(response.article);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await ArticlesServices.DeleteArticlesAsync(id);

                if (response.success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
