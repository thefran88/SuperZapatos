using Newtonsoft.Json;
using Super_Zapatos_Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Super_Zapatos.Models
{
    public class Articles_Index_VM
    {
        #region Constructores
        public Articles_Index_VM()
        {
            ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            LoadSelects();
        }
        #endregion

        #region Propiedades
        private static string ApiUrl;

        public List<Article> Articles { get; set; }

        [Display(Name = "Tiendas")]
        [Required(ErrorMessage = "Favor especificar un tienda.")]
        public int StoresSelectedID { get; set; }
        public SelectList StoresSelect { get; set; }
        private List<Store> Stores { get; set; }
        #endregion

        #region Metodos
        /// <summary>
        /// Gets all articles from api. If a store id is spesified then get all articles from that store. 
        /// </summary>
        /// <param name="storeId">Numeric store id.</param>
        /// <returns>A list of articles.</returns>
        public async Task<List<Article>> GetArticlesAsync(int? storeId)
        {
            string path = ApiUrl + "services/articles/";
            if (storeId != null)
            {
                path += "stores/" + storeId;
                StoresSelectedID = (int)storeId;
            }

            var articlesResponse = new GetArticlesResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);

                var httpResponse = await client.GetAsync(path);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    articlesResponse = JsonConvert.DeserializeObject<GetArticlesResponse>(responseDetails);
                }
            }

            Articles = articlesResponse.articles;
            return Articles;
        }

        /// <summary>
        /// Load all selects used in the view.
        /// </summary>
        private void LoadSelects()
        {
            var response = StoresServices.GetStores();

            Stores = response.stores;
            StoresSelect = new SelectList(Stores, "id", "Name");
        }
        #endregion
    }

    public class Articles_Create_VM
    {
        #region Constructores
        public Articles_Create_VM()
        {
            Article = new Article();
            LoadSelects();
        }

        public Articles_Create_VM(Article article) : this()
        {
            Article = article;
            StoresSelectedID = article.Store.id;
        }
        #endregion

        #region Propiedades
        public Article Article { get; set; }

        [Display(Name = "Tiendas")]
        [Required(ErrorMessage = "Favor especificar un tienda.")]
        public int StoresSelectedID { get; set; }
        public SelectList StoresSelect { get; set; }
        List<Store> Stores { get; set; }
        #endregion

        #region Metodos
        private void LoadSelects()
        {
            var response = StoresServices.GetStores();

            Stores = response.stores;
            StoresSelect = new SelectList(Stores, "id", "name");
        }
        #endregion
    }
}