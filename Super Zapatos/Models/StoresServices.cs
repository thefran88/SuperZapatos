using Newtonsoft.Json;
using Super_Zapatos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Super_Zapatos_Services.Models
{
    public class StoresServices
    {
        private static readonly string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        public StoresServices()
        {

        }

        /// <summary>
        /// Call the "services/stores/id" API method.
        /// </summary>
        /// <param name="id">Numeric value. The id of the store.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<GetStoreResponse> GetStoreAsync(int id)
        {
            var finalResponse = new GetStoreResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.GetAsync(ApiUrl + "services/stores/" + id);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<GetStoreResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/stores/" API Method.
        /// </summary>
        /// <returns>A response object send by the api.</returns>
        public static async Task<GetStoresResponse> GetStoresAsync()
        {
            var storesResponse = new GetStoresResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.GetAsync(ApiUrl + "services/stores/");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    storesResponse = JsonConvert.DeserializeObject<GetStoresResponse>(responseDetails);
                }
            }

            return storesResponse;
        }

        /// <summary>
        /// Call the "services/stores/" API Method.
        /// </summary>
        /// <returns>A response object send by the api.</returns>
        public static GetStoresResponse GetStores()
        {
            var storesResponse = new GetStoresResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = client.GetAsync(ApiUrl + "services/stores/");
                if (httpResponse.Result.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Result.Content.ReadAsStringAsync().Result;

                    storesResponse = JsonConvert.DeserializeObject<GetStoresResponse>(responseDetails);
                }
            }

            return storesResponse;
        }

        /// <summary>
        /// Call the "services/stores/post/" API Method.
        /// </summary>
        /// <param name="store">Store object being inserted.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> PostStoresAsync(Store store)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                client.BaseAddress = new Uri(ApiUrl + "services/stores/post/");
                var httpResponse = await client.PostAsJsonAsync("store", store);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<AlterEntityResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/stores/put/" API Method.
        /// </summary>
        /// <param name="store">Store object being updated.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> PutStoresAsync(Store store)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                client.BaseAddress = new Uri(ApiUrl + "services/stores/put/");
                var httpResponse = await client.PutAsJsonAsync("store", store);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseDetails = httpResponse.Content.ReadAsStringAsync().Result;

                    finalResponse = JsonConvert.DeserializeObject<AlterEntityResponse>(responseDetails);
                }
            }

            return finalResponse;
        }

        /// <summary>
        /// Call the "services/stores/delete/id" API Method.
        /// </summary>
        /// <param name="id">Numeric value. The id of the store.</param>
        /// <returns>A response object send by the api.</returns>
        public static async Task<AlterEntityResponse> DeleteStoresAsync(int id)
        {
            var finalResponse = new AlterEntityResponse();

            using (var client = new HttpClient())
            {
                string HttpAuth = ConfigurationManager.AppSettings["HttpAuth"];
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + HttpAuth);
                var httpResponse = await client.DeleteAsync(ApiUrl + "services/stores/delete/" + id);

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