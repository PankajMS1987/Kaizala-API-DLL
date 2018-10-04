namespace Microsoft.Kaizala.Util
{
    using Microsoft.Kaizala.Models;
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    class APICallHandler
    {
        /// <summary>
        /// Http client object to call web API
        /// </summary>
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// Make Post API call on give path with given header
        /// </summary>
        /// <typeparam name="T">Class Name</typeparam>
        /// <param name="header">The Header</param>
        /// <param name="path">Post URL path</param>
        /// <returns>Returns response</returns>
        public static async Task<T> PostAsync<T>(NameValueCollection header, string path, string requestBody)
        {
            T data = default(T);
            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, path);
                message.Headers.Add("Accept", "application/json");
                foreach (string key in header)
                {

                    message.Headers.Add(key, header[key]);
                }
                message.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.SendAsync(message);
                data = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                data = (T)(Object)new ErrorDetails(e.Message, ErrorConstant.SERVICE_EXCEPTION_STRING, "");
            }

            return data;
        }

        /// <summary>
        /// Make Post API call on give path with given header
        /// </summary>
        /// <typeparam name="T">Class Name</typeparam>
        /// <param name="header">The Header</param>
        /// <param name="path">Post URL path</param>
        /// <returns>Returns response</returns>
        public static async Task<T> GetAsync<T>(NameValueCollection header, string path)
        {
            T data = default(T);
            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, path);
                message.Headers.Add("Accept", "application/json");
                foreach (string key in header)
                {
                    message.Headers.Add(key, header[key]);
                }
                HttpResponseMessage response = await client.SendAsync(message);
                data = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                data = (T)(Object)new ErrorDetails(e.Message, ErrorConstant.SERVICE_EXCEPTION_STRING, "");
            }
            return data;
        }

        /// <summary>
        /// Make Delete API call on give path with given header
        /// </summary>
        /// <typeparam name="T">Class Name</typeparam>
        /// <param name="header">The Header</param>
        /// <param name="path">Post URL path</param>
        /// <returns>Returns response</returns>
        public static async Task<T> DeleteAsync<T>(NameValueCollection header, string path)
        {
            T data = default(T);
            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, path);
                message.Headers.Add("Accept", "application/json");
                foreach (string key in header)
                {
                    message.Headers.Add(key, header[key]);
                }
                HttpResponseMessage response = await client.SendAsync(message);
                data = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                data = (T)(Object)new ErrorDetails(e.Message, ErrorConstant.SERVICE_EXCEPTION_STRING, "");
            }
            return data;
        }

        /// <summary>
        /// Make Post API call on give path with given header
        /// </summary>
        /// <typeparam name="T">Class Name</typeparam>
        /// <param name="header">The Header</param>
        /// <param name="path">Post URL path</param>
        /// <returns>Returns response</returns>
        public static async Task<T> PutAsync<T>(NameValueCollection header, string path, string requestBody)
        {
            T data = default(T);
            try
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, path);
                message.Headers.Add("Accept", "application/json");
                foreach (string key in header)
                {
                    message.Headers.Add(key, header[key]);
                }
                message.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(message);
                data = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                data = (T)(Object)new ErrorDetails(e.Message, ErrorConstant.SERVICE_EXCEPTION_STRING, "");
            }
            return data;
        }

    }
}
