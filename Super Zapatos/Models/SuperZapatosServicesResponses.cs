using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Models
{
    public class GetStoreResponse
    {
        public GetStoreResponse()
        {
            store = new Store();
        }

        public Store store { get; set; }
        public bool success { get; set; }
    }

    public class GetStoresResponse
    {
        public GetStoresResponse()
        {
            stores = new List<Store>();
        }

        public List<Store> stores { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
    }

    public class AlterEntityResponse
    {
        public bool success { get; set; }
    }

    public class GetArticleResponse
    {
        public GetArticleResponse()
        {
            article = new Article();
        }
        public Article article { get; set; }
        public bool success { get; set; }
    }

    public class GetArticlesResponse
    {
        public GetArticlesResponse()
        {
            articles = new List<Article>();
        }

        public List<Article> articles { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
    }
}