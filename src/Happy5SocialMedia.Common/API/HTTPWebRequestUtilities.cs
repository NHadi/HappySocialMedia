using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Happy5SocialMedia.Common.API
{
    public class HTTPWebRequestUtilities<T> where T:class
    {
        private readonly string _basePath;
        public HTTPWebRequestUtilities(string basePath){
            _basePath = basePath;
        }

        public T GetSingle(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_basePath + url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string ResponseString = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                ResponseString = reader.ReadToEnd();
            }

            var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

            var result = JsonConvert.DeserializeObject<T>(jsonObject["result"].ToString());
            return result;

        }
        public IEnumerable<T> Get(string url)
        {            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_basePath + url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string ResponseString = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                ResponseString = reader.ReadToEnd();
            }

            var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

            var result = JsonConvert.DeserializeObject<List<T>>(jsonObject["result"].ToString());

            return result;

        }

        public string ParseToJson(object data)
            => JsonConvert.SerializeObject(data);

        public T PostSingle(string url, object param)
        {
            try
            {                
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_basePath + url);
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(ParseToJson(param));
                }

                string ResponseString = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    ResponseString = streamReader.ReadToEnd();
                }
                
                var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

                var result = JsonConvert.DeserializeObject<T>(jsonObject["result"].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<T> Post(string url, object param)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_basePath + url);
                httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(ParseToJson(param));
                }

                string ResponseString = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    ResponseString = streamReader.ReadToEnd();
                }

                var jsonObject = (JObject)JsonConvert.DeserializeObject(ResponseString);

                var result = JsonConvert.DeserializeObject<List<T>>(jsonObject["result"].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public T Request(string method, string url, object param= null)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_basePath + url);

                if (method != Global.Method.GET)
                {
                    httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = method;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(ParseToJson(param));
                    }
                }

                string ResponseString = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    ResponseString = streamReader.ReadToEnd();
                }
                var result = JsonConvert.DeserializeObject<T>(ResponseString);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
