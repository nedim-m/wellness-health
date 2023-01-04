using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.User;
using static System.Net.WebRequestMethods;

namespace wellness.WinUI
{
    public class ApiService
    {
        private string _resourceName = string.Empty;
        public string _endPoint = "http://localhost:5101/api/Auth/login";

        public static string Username = string.Empty;
        public static string Password = string.Empty;

        public ApiService(string resourceName)
        {
            _resourceName=resourceName;
        }

         
        //public async Task<string>Authentication(string username, string password)
        //{
        //    var user = await _endPoint.PostJsonAsync<UserResponse>(username,password)
        //        return user.Token;
        //}


        //public async Task<T> Get<T>()
        //{

         
        //    var list = await _endPoint.WithOAuthBearerToken()



        //    return list;
        //}

        //public async Task<T> GetById<T>(object id)
        //{
        //    var result = await $"{_endPoint}{_resourceName}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

        //    return result;
        //}

        //public async Task<T> Post<T>(object request)
        //{
        //    try
        //    {
        //        var result = await $"{_endPoint}{_resourceName}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        //        return result;
        //    }
        //    catch (FlurlHttpException ex)
        //    {
        //        var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
        //        var stringBuilder = new StringBuilder();

        //        foreach (var error in errors)
        //        {
        //            stringBuilder.AppendLine($"{error.Key},{string.Join(",", error.Value)}");
        //        }
        //        MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return default(T);
        //    }


        //}


        //public async Task<T> Put<T>(object id, object request)
        //{
        //    var result = await $"{_endPoint}{_resourceName}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

        //    return result;
        //}

    }
}
