using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Super_Zapatos.Models
{
    public class ArticlesServices
    {
        private static readonly string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        public ArticlesServices()
        {

        }

        /// <summary>
        /// Call the "services/articles/stores/id" API method.
        /// </summary>
        /// <param name="id">Numeric value. The id of the article.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<GetArticleResponse> GetArticleAsync(int id)
        {
            var finalResponse = new GetArticleResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.GetAsync(ApiUrl + "services/articles/" + id);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<GetArticleResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/articles/" API Method.
        /// </summary>
        /// <returns>A response object send by the api.</returns>
        public static async Task<GetArticlesResponse> GetArticlesAsync()
        {
            var articlesResponse = new GetArticlesResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.GetAsync(ApiUrl + "services/articles/");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    articlesResponse = JsonConvert.DeserializeObject<GetArticlesResponse>(responseDetails);
                }
            }

            return articlesResponse;
        }

        /// <summary>
        /// Call the "services/articles/" API Method.
        /// </summary>
        /// <returns>A response object send by the api.</returns>
        public static GetArticlesResponse GetArticles()
        {
            var articlesResponse = new GetArticlesResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = client.GetAsync(ApiUrl + "services/articles/");

                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Result.Content.ReadAsStringAsync().Result;

                    articlesResponse = JsonConvert.DeserializeObject<GetArticlesResponse>(responseDetails);
                }
            }

            return articlesResponse;
        }

        /// <summary>
        /// Call the "services/articles/post/" API Method.
        /// </summary>
        /// <param name="article">Article object being inserted.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> PostArticlesAsync(Article article)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                client.BaseAddress = new Uri(ApiUrl + "services/articles/post/");
                var httpResponse = await client.PostAsJsonAsync("article", article);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<AlterEntityResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/articles/put/" API Method.
        /// </summary>
        /// <param name="article">Article object being updated.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> PutArticlesAsync(Article article)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                client.BaseAddress = new Uri(ApiUrl + "services/articles/put/");
                var httpResponse = await client.PutAsJsonAsync("article", article);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<AlterEntityResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/articles/delete/id" API Method.
        /// </summary>
        /// <param name="id">Numeric value. The id of the article.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> DeleteArticlesAsync(int id)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.DeleteAsync(ApiUrl + "services/articles/delete/" + id);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<AlterEntityResponse>(responseDetails);
                }
            }

            return finalResponse;
        }
    }
}