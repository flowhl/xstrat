﻿using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xstrat
{
    public static class ApiHandler
    {
        #region client functions
        public static RestClient client;

        /// <summary>
        /// creates restclient instance
        /// </summary>
        public async static void Initialize()
        {
            if(client == null)
            {
                client = new RestClient("http://localhost:3000/api");
            }
            var request = new RestRequest("/", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK) //success
            {
                MessageBox.Show("Api could not be reached. Please check your connection");
                App.Current.Shutdown();
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
            Waiting();
            var request = new RestRequest("register", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = _name, email = _email, password = _pw });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, "");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict) //duplicate
            {
                EndWaiting();
                return (false, "email allready registered");
            }
            EndWaiting();
            return (false, "db error");
        }


        public static async Task<(bool, string)> LoginAsync(string _email, string _pw)
        {
            Waiting();
            var request = new RestRequest("login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { email = _email, password = _pw });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }

        public static async Task<bool> VerifyToken(string token)
        {
            Waiting();
            var request = new RestRequest("verify", Method.Post);
            client.Authenticator = new JwtAuthenticator(token);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true);
            }
            client.Authenticator = null;
            EndWaiting();
            return (false);
        }

        public static async Task<bool> ResetEmail()
        {
            Waiting();
            throw new NotImplementedException();
            EndWaiting();
        }

        public static async Task<(bool, string)> NewRoutine()
        {
            Waiting();
            var request = new RestRequest("routines/new", Method.Post);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }

        public static async Task<(bool, string)> DeleteRoutine(int id)
        {
            Waiting();
            var request = new RestRequest("routines/delete", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { routine_id = id});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }

        public static async Task<(bool, string)> GetRoutineContent(int id)
        {
            Waiting();
            var request = new RestRequest("routines/content", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { routine_id = id});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }
        public static async Task<(bool, string)> GetAllRoutines()
        {
            Waiting();
            var request = new RestRequest("routines/all", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }
        public static async Task<(bool, string)> SaveRoutine(string ntitle, string ncontent, int n_id)
        {
            Waiting();
            var request = new RestRequest("routines/save", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { title = ntitle, content = ncontent, routine_id = n_id});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }
        public static async Task<(bool, string)> RenameRoutine(string ntitle, int n_id)
        {
            Waiting();
            var request = new RestRequest("routines/rename", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { title = ntitle, routine_id = n_id });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }

        private static void Waiting()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private static void EndWaiting()
        {
            Cursor.Current = Cursors.Default;
        }

        #endregion
    }
}
