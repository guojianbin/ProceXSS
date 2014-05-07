using System.Configuration;

namespace ProceXSS.Configuration
{
    /* CONFIG SECTION XML
        <configSections>
              <section name="antiXssModuleSettings" type="XSSSecurity.XssConfigurationHandler"/>
        </configSections>   
     
        <antiXssModuleSettings redirectUrl="/Error.aspx" log="True" mode="Redirect" isActive="False" controlRegex="control regexi buraya gelecek">
          <excludeUrls>
            <add name="url1" value="/"/>
            <add name="url2" value="/test/default.aspx"/>
          </excludeUrls>
        </antiXssModuleSettings>
     */

    public class XssConfigurationHandler : ConfigurationSection, IXssConfigurationHandler
    {
        [ConfigurationProperty("redirectUrl", IsRequired = true)]
        public string RedirectUrl
        {
            get
            {
                return this["redirectUrl"] as string;
            }
        }

        [ConfigurationProperty("isActive", IsRequired = true)]
        public string IsActive
        {
            get
            {
                return this["isActive"] as string;
            }
        }

        [ConfigurationProperty("controlRegex")]
        public string ControlRegex
        {
            get
            {
                string result = string.Empty;

                if (this["controlRegex"] != null)
                {
                    result = this["controlRegex"] as string;
                }

                return result;
            }
        }

        [ConfigurationProperty("mode", IsRequired = true)]
        public string Mode
        {
            get
            {
                return this["mode"] as string;
            }
        }

        [ConfigurationProperty("log")]
        public string Log
        {
            get
            {
                string configValue = this["log"] as string;

                if (!string.IsNullOrEmpty(configValue))
                {
                    if (configValue.Equals(bool.TrueString))
                        return bool.TrueString;
                }

                return bool.FalseString;
            }
        }

        [ConfigurationProperty("excludeUrls")]
        public UrlExcludeFilterCollection ExcludeList
        {
            get
            {
                return this["excludeUrls"] as UrlExcludeFilterCollection;
            }
        }

        public static XssConfigurationHandler GetConfig()
        {
            return ConfigurationManager.GetSection("antiXssModuleSettings") as XssConfigurationHandler;
        }
    }
}