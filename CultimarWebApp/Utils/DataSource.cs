using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils
{
    public class DataSource
    {
        public static string coneccionPrimaria;
        public static bool cache;

        public static void SetParametros(string conn1)
        {
            coneccionPrimaria = conn1;
        }

        public static void SetCache(bool hasCache)
        {
            cache = hasCache;
        }

        public string ConeccionPrimaria { get { return coneccionPrimaria; } }
    }
}