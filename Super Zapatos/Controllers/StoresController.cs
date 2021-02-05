using Newtonsoft.Json;
using Super_Zapatos.Models;
using Super_Zapatos_Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Super_Zapatos.Controllers
{
    public class StoresController : Controller
    {
        readonly string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        // GET: Stores/:id
        public async Task<ActionResult> Index()
        {
            var response = await StoresServices.GetStoresAsync();

            if (response.success)
            {
                return View(response.stores);
            }
            else
            {
                ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener la lista de tiendas.";
                return View("Error");
            }
        }


        // GET: Stores/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await StoresServices.GetStoreAsync(id);

            if (response.success)
            {
                return View(response.store);
            }
            else
            {
                ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener la tienda.";
                return View("Error");
            }
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            var vm = new Store();
            return View(vm);
        }

        // POST: Stores/Create
        [HttpPost]
        public async Task<ActionResult> Create(Store vm)
        {
            ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener la tienda.";

            try
            {
                var response = await StoresServices.PostStoresAsync(vm);

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

        // GET: Stores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var response = await StoresServices.GetStoreAsync((int)id);

                if (response.success)
                {
                    return View(response.store);
                }
                else
                {
                    ViewBag.ErrorMsg = "Ocurrió un error al tratar de obtener la tienda.";
                    return View("Error");
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMsg = "Ocurrió un error al tratar de editar la tienda.";
                return View("Error");
            }
        }

        // POST: Stores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Store store)
        {
            try
            {
                var response = await StoresServices.PutStoresAsync(store);

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

        // GET: Stores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await StoresServices.GetStoreAsync((int)id);

            if (response.success)
            {
                return View(response.store);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Stores/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await StoresServices.DeleteStoresAsync(id);

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
