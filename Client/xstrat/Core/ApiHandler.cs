using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xstrat.Core;

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
                Notify.sendError("API Error", "Api could not be reached. Please check your connection. XStrat will close now.");
                await Task.Delay(5000);
                //MessageBox.Show("Api could not be reached. Please check your connection");
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

        /// <summary>
        /// Login by api call
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="_pw"></param>
        /// <returns></returns>
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

        /// <summary>
        /// verifies the api token by api call
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
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

        /// <summary>
        /// sends email to reset password - not implemented yet!
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task<bool> ResetEmail()
        {
            Waiting();
            throw new NotImplementedException();
            EndWaiting();
        }

        /// <summary>
        /// adds new routine to db by api call
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// deletes routine by api call
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets routines content by api call
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Loads all routines by api call
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Saves routine by api call
        /// </summary>
        /// <param name="ntitle"></param>
        /// <param name="ncontent"></param>
        /// <param name="n_id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// renames a routine by api call
        /// </summary>
        /// <param name="ntitle"></param>
        /// <param name="n_id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets waiting cursor
        /// </summary>
        private static void Waiting()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        /// <summary>
        /// Removes waiting cursor
        /// </summary>
        private static void EndWaiting()
        {
            Cursor.Current = Cursors.Default;
        }

        #endregion
    }
}
