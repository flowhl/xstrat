using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xstrat
{
    public static class ApiHandler
    {
        #region client functions
        public static RestClient client;

        /// <summary>
        /// creates restclient instance
        /// </summary>
        public static void Initialize()
        {
            if(client == null)
            {
                client = new RestClient("http://localhost:3000/api");
            }            
        }

        /// <summary>
        /// adds baerer_token to client if not allready
        /// </summary>
        /// <param name="token"></param>
        public static void AddBearer(string token)
        {
            if (client.Authenticator == null)
            {
                client.Authenticator = new JwtAuthenticator(token);
            }
        }

        #endregion
        #region requests

        /// <summary>
        /// registers a new account
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        /// <param name="_pw"></param>
        /// <returns>
        /// (bool success, string error)
        /// </returns>
        public static async Task<(bool, string)> RegisterAsync(string _name, string _email, string _pw)
        {
            var request = new RestRequest("register", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = _name, email = _email, password = _pw });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                return (true, "");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict) //duplicate
            {
                return (false, "email allready registered");
            }
            return (false, "db error");
        }


        public static async Task<(bool, string)> LoginAsync(string _email, string _pw)
        {
            var request = new RestRequest("login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { email = _email, password = _pw });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                return (true, response.Content);
            }
            return (false, "db error");
        }

        public static async Task<bool> VerifyToken(string token)
        {
            var request = new RestRequest("verify", Method.Post);
            client.Authenticator = new JwtAuthenticator(token);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                return (true);
            }
            client.Authenticator = null;
            return (false);
        }

        public static async Task<bool> ResetEmail()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
