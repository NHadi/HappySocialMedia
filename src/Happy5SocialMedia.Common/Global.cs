using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common
{
    public class Global
    {
        public static class API
        {
            public static string Version = "v1";
        }

        public static class Key
        {
            public static string EncryptDecrypt = "Happy5Key";
        }

        public static class Method
        {
            public static string GET = "GET";
            public static string POST = "POST";
            public static string PUT = "PUT";
            public static string DELETE = "DELETE";
        }


        public static class Status
        {
            public static string Accepted = "Accepted";
            public static string Request = "Request";
            public static string Pending = "Pending";
            public static string Declined = "Declined";
            public static string Read = "Read";
            public static string UnRead = "UnRead";
            public static string Replied = "Replied";
            public static string Delivered = "Delivered";            
        }


        public static class DbConnection
        {
            public static string UserConnection = "UserConnection";
            public static string MessageConnection = "MessageConnection";
            public static string ActivityConnection = "ActivityConnection";
            public static string PostConnection = "PostConnection";
        }
    }
}
