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
using System.Net.Http;
using xstrat.Json;
using xstrat.Ui;

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

                if (SettingsHandler.APIURL != null)
                {
                    client = new RestClient(SettingsHandler.APIURL);
                }
                else
                {
                    Notify.sendError("Settings Error", "Please enter a proper url to reach the server. Use https://app.xstrat.app/api as default");
                }
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
        #region logins
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
        #endregion
        #region Client requests
        public static async Task<(bool, string)> Games()
        {
            Waiting();
            var request = new RestRequest("games", Method.Get);
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
        #endregion
        #region team
        public static async Task<(bool, string)> JoinTeam(string id, string pw)
        {
            Waiting();
            var request = new RestRequest("team/join", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { join_password = pw });
            request.AddJsonBody(new { team_id = id});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                EndWaiting();
                return (false, "Invalid id or password");
            }
            EndWaiting();
            return (false, response.Content);
        }

        public static async Task<(bool, string)> LeaveTeam()
        {
            Waiting();
            var request = new RestRequest("team/leave", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }
        public static async Task<(bool, string)> VerifyAdmin()
        {
            Waiting();
            var request = new RestRequest("team/verifyadmin", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }
        public static async Task<(bool, string)> NewTeam(string name, int igame_id)
        {
                Waiting();
                if (name == null || name == "")
                {
                    return(false, "invalid input");
                }
                var request = new RestRequest("team/new", Method.Post);
                request.RequestFormat = DataFormat.Json;
                var param = new NewParams { name = name, game_id = igame_id };
                request.AddJsonBody(param);

                var response = await client.ExecuteAsync<RestResponse>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created) //success
                {
                    EndWaiting();
                    return (true, response.Content);
                }
                EndWaiting();
                return (false, response.Content);
        }
        public static async Task<(bool, string)> TeamJoinpassword()
        {
            Waiting();
            var request = new RestRequest("team/joinpassword", Method.Get);
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
        public static async Task<(bool, string)> UpdateNameTeam(string _newname)
        {
            Waiting();
            var request = new RestRequest("team/new", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { newname = _newname });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }
        public static async Task<(bool, string)> TeamMembers()
        {
            Waiting();
            var request = new RestRequest("team/members", Method.Get);
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
        public static async Task<(bool, string)> TeamInfo()
        {
            Waiting();
            var request = new RestRequest("team/info", Method.Get);
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
        public static async Task<(bool, string)> DeleteTeam()
        {
            Waiting();
            var request = new RestRequest("team/delete", Method.Post);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }
        public static async Task<(bool, string)> RenameTeam(string newname)
        {
            Waiting();
            var request = new RestRequest("team/rename ", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new {newname = newname});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }
        public static async Task<(bool, string)> GetColor()
        {
            Waiting();
            var request = new RestRequest("team/getcolor", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }
        public static async Task<(bool, string)> setColor(string color)
        {
            Waiting();
            var request = new RestRequest("team/setcolor", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new {color = color.Replace("#FF", "#")});

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, response.Content);
        }

        #endregion
        #region routines

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
        #endregion
        #region OffDays
        /// <summary>
        /// adds new routine to db by api call
        /// </summary>
        /// <returns></returns>
        public static async Task<(bool, string)> NewOffDay(int typ, string title, string start, string end)
        {
            Waiting();
            var request = new RestRequest("event/new", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { typ = typ, title = title, start = start, end = end});

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
        public static async Task<(bool, string)> DeleteOffDay(int id)
        {
            Waiting();
            var request = new RestRequest("event/delete", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { event_id = id });

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
        public static async Task<(bool, string)> GetUserOffDays()
        {
            Waiting();
            var request = new RestRequest("event/user", Method.Get);
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
        /// Loads all routines by api call
        /// </summary>
        /// <returns></returns>
        public static async Task<(bool, string)> GetTeamOffDays()
        {
            Waiting();
            var request = new RestRequest("event/team", Method.Get);
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
        public static async Task<(bool, string)> SaveOffDay(int id, int typ, string title, string start, string end)
        {
            Waiting();
            var request = new RestRequest("event/save", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new {id = id, typ = typ, title = title, start = start, end = end });

            var response = await client.ExecuteAsync<RestResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                EndWaiting();
                return (true, response.Content);
            }
            EndWaiting();
            return (false, "db error");
        }
        #endregion
        #region helper methodes

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
