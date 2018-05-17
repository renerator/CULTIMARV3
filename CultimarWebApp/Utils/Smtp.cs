using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CultimarWebApp.Utils
{
    public class ListaCorreosDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!TryGetValue(key, out value))
                {
                    value = Activator.CreateInstance<TValue>();
                    Add(key, value);
                }
                return value;
            }
            set { base[key] = value; }
        }
    }
    public class Smtp
    {
        //Conexión primaria

        static string smtpServer_1 = ConfigurationManager.AppSettings.Get("smtpServer_1");
        static string smtpPort_1 = ConfigurationManager.AppSettings.Get("smtpPort_1");
        static string smtpUser_1 = ConfigurationManager.AppSettings.Get("smtpUser_1");
        static string smtpPassword_1 = ConfigurationManager.AppSettings.Get("smtpPassword_1");
        static string mailfrom_1 = ConfigurationManager.AppSettings.Get("mailFrom_1");
        static string displayName_1 = ConfigurationManager.AppSettings.Get("displayName_1");


        //Conexión secundaria
        static string smtpServer_2 = ConfigurationManager.AppSettings.Get("smtpServer_2");
        static string smtpPort_2 = ConfigurationManager.AppSettings.Get("smtpPort_2");
        static string smtpUser_2 = ConfigurationManager.AppSettings.Get("smtpUser_2");
        static string smtpPassword_2 = ConfigurationManager.AppSettings.Get("smtpPassword_2");
        static string mailfrom_2 = ConfigurationManager.AppSettings.Get("mailFrom_2");
        static string displayName_2 = ConfigurationManager.AppSettings.Get("displayName_2");

        //Conexión tercera

        static string smtpServer_3 = ConfigurationManager.AppSettings.Get("smtpServer_3");
        static string smtpPort_3 = ConfigurationManager.AppSettings.Get("smtpPort_3");
        static string smtpUser_3 = ConfigurationManager.AppSettings.Get("smtpUser_3");
        static string smtpPassword_3 = ConfigurationManager.AppSettings.Get("smtpPassword_3");
        static string mailfrom_3 = ConfigurationManager.AppSettings.Get("mailFrom_3");
        static string displayName_3 = ConfigurationManager.AppSettings.Get("displayName_3");


        public static bool Send(MailMessage message)
        {
            var respuesta = new bool();
            try
            {
                if (SendByPrimario(message))
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw (new CapturaExcepciones(ex));
            }
            return respuesta;

        }

        static bool SendByPrimario(MailMessage message)
        {
            var respuesta = new bool();
            try
            {
                MailAddress mailFrom = new MailAddress(mailfrom_1, displayName_1);
                message.From = mailFrom;
                SmtpClient smtpClient = new SmtpClient(smtpServer_1, Convert.ToInt32(smtpPort_1));
                smtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpUser_1, smtpPassword_1);
                smtpClient.Credentials = credentials;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
                respuesta = true;
            }
            catch (Exception ex)
            {
                throw (new CapturaExcepciones(ex));
            }
            return respuesta;
        }

    }
}