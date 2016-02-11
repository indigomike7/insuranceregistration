using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication1.DAL
{
    public abstract class DataAccess
    {
        private const string REFERENCE_CONNECTION_STRING_KEY = "Reference.Connection";
        public static string ConnectionString
        {
            get
            {
                return (string) ConfigurationManager.AppSettings[REFERENCE_CONNECTION_STRING_KEY];
            }
        }

    }
}