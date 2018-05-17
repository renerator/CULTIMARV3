using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace CultimarWebApp.Utils
{
    [Serializable]
    public class CapturaExcepciones : Exception
    {
        public CapturaExcepciones(Exception e)
        {
            var log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Fatal(e.Message);
            log.Error("Error no controlado: " + e);
            log.ErrorFormat(e.StackTrace);
        }
    }
}