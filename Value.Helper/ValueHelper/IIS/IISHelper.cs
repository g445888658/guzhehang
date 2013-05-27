using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.IO;

namespace ValueHelper.IIS
{
    public class IISHelper
    {
        private String iisPath;

        private const String IISVirtualDirectory = "IIsWebVirtualDir";
        private const String IISWebServer = "IIsWebServer";

        public IISHelper(String iisserver)
        {
            this.iisPath = String.Format("IIS://{0}/W3SVC", iisserver);
        }

        public Boolean CreateWebSite(WebSiteInfo siteInfo)
        {
            try
            {
                var bindStr = String.Concat(siteInfo.IP, ":", siteInfo.Port, ":");
                if (webSiteExists(siteInfo.Name, bindStr)) return false;

                var root = new DirectoryEntry(this.iisPath);
                var websiteID = getNewWebSiteID();
                var newEntry = root.Children.Add(websiteID, IISWebServer);
                newEntry.Properties["ServerBindings"].Value = bindStr;
                newEntry.Properties["ServerComment"].Value = siteInfo.Name;
                newEntry.Properties["AccessFlags"].Value = 512 | 1;
                newEntry.CommitChanges();

                var virtualEntry = newEntry.Children.Add("root", IISVirtualDirectory);
                virtualEntry.CommitChanges();

                virtualEntry.Properties["Path"].Value = Path.Combine(siteInfo.Physicaldir, siteInfo.Virtualdir);
                virtualEntry.Invoke("AppCreate3", new Object[] { 2, siteInfo.ThreadPoolName, true });
                virtualEntry.Properties["AppFriendlyName"].Value = "ValueCreator";
                virtualEntry.CommitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean webSiteExists(String siteName, String bindStr)
        {
            var entry = new DirectoryEntry(this.iisPath);
            foreach (DirectoryEntry item in entry.Children)
            {
                if (item.SchemaClassName == IISWebServer)
                {
                    if (item.Properties["ServerBindings"].Value.ToString().Equals(bindStr))
                        return true;

                    if (item.Properties["ServerComment"].Value.ToString().Equals(siteName))
                        return true;
                }
            }
            return false;
        }

        private String getNewWebSiteID()
        {
            var entry = new DirectoryEntry(this.iisPath);
            Int32 index = 1;
            foreach (DirectoryEntry item in entry.Children)
            {
                if (item.SchemaClassName == IISWebServer)
                {

                    var Bool = Int32.TryParse(item.Name, out index);
                    index++;
                }
            }
            return index.ToString();
        }
    }
}
