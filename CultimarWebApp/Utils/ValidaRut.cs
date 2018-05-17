using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils
{
    public class ValidaRut
    {
        public static bool DigitoVerificador(string rutEnviado)
        {
            var control = false;
            if (string.IsNullOrEmpty(rutEnviado))
                return false;
            rutEnviado = rutEnviado.Replace("-", "");
            if (rutEnviado.Length < 2)
                return false;
            string sdv = rutEnviado.Substring(rutEnviado.Length - 1, 1).ToUpper();
            rutEnviado = rutEnviado.Substring(0, rutEnviado.Length - 1);


            int m = 2;
            int total = 0;
            for (int i = rutEnviado.Length - 1; i >= 0; i--)
            {
                total = total + Convert.ToInt32(rutEnviado.Substring(i, 1)) * m;
                if (m == 7)
                    m = 1;
                m++;
            }
            int res = 11 - (total % 11);
            string dvr = "0";
            if (res == 10)
            {
                dvr = "K";
            }
            else if (res == 11)
            {
                dvr = "0";
            }
            else
            {
                dvr = res.ToString();
            }
            if (sdv.Equals(dvr))
            {
                control = true;
            }
            return control;
        }
        
    }
}