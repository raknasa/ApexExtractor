using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Configuration;

namespace APEXExtractor
{
    class ApexSettings
    {
        public static string ReadApexSetting(string key)
        {
            NameValueCollection nc = ConfigurationManager.AppSettings;
            try
            {
                return nc[key];
            }
            catch (Exception)
            {
                return "";
                
            }
        }
        public static void UpdateApexSetting(string key, string val)
        {
         
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = val;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

               
            }
            catch (Exception)
            {
              

            }
        }
    }
}
