using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.User;
using wellness.Models.User;
using static System.Net.WebRequestMethods;

namespace wellness.WinUI
{
    public class ApiService
    {
        private string _resourceName = string.Empty;
        public string _endPoint = "https://localhost:7081/api/";

        public static UserLoginRequest request=new();
        private static string Token = "";

        public ApiService(string resourceName)
        {
            _resourceName=resourceName;
        }


        public async Task Authentication()
        {
            var user = await $"{_endPoint}{_resourceName}/login".PostJsonAsync(request).ReceiveJson<AuthResponse>();
            if (user!=null)
            {
                Token+=user.Token;
            }
        }


        public async Task<T> Get<T>(object search = null)
        {
            var query = string.Empty;
            if (search!=null)
            {
                query = await search.ToQueryString();
            }

            var list = await $"{_endPoint}{_resourceName}?{query}".WithOAuthBearerToken(Token).GetJsonAsync<T>();

            return list;
        }

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
