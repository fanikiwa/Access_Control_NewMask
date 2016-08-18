using Access_Control_NewMask.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Reflection;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using DatabaseDesignUpdator;

namespace Access_Control_NewMask
{
    public class Global : System.Web.HttpApplication
    {
        private const string CURRENT_DATABASE_VERSION = "20160208000";
        private const string APPLICATION_KEY = "AccessControl";

        protected void Application_Start(object sender, EventArgs e)
        {
            string imgDir = Server.MapPath(@"~/UserImages/");
            FileProcessor.PersPhotosFolder = imgDir + @"Personal";
            FileProcessor.VisitorsPhotosFolder = imgDir + @"Visitor";
            FileProcessor.MembersPhotosFolder = imgDir + @"Member";

            Directory.CreateDirectory(imgDir);
            Directory.CreateDirectory(FileProcessor.PersPhotosFolder);
            Directory.CreateDirectory(FileProcessor.VisitorsPhotosFolder);
            Directory.CreateDirectory(FileProcessor.MembersPhotosFolder);

            if (!DatabaseUpdate.CheckIdDatabaseExists(DatabaseUpdate.DatabaseName))
            {
                try
                {
                    DatabaseUpdate.PerformDatabaseUpdate(CURRENT_DATABASE_VERSION);
                }
                catch
                {

                }
            }

            GlobalSettingRepository _globalSettings = new GlobalSettingRepository();

            var settings = _globalSettings.GetglobalSettings().ToList();
            var currentVersionNumber = getApplicationVersionNumber();

          if (settings != null)
            {
                var TA_Version = settings.Where(x => x.AppName == APPLICATION_KEY).FirstOrDefault();

                if (TA_Version != null)
                {
                    if (TA_Version.Version != currentVersionNumber)
                    {
                        try
                        {
                            TA_Version.Version = currentVersionNumber;
                            _globalSettings.EditVersion(TA_Version);

                            DatabaseUpdate.PerformDatabaseUpdate(CURRENT_DATABASE_VERSION);

                        }
                        catch(Exception exc)
                        {

                        }
                    }
                }
                else
                {
                    try
                    {
                        DatabaseUpdate.PerformDatabaseUpdate(CURRENT_DATABASE_VERSION);
                        TA_Version = new Global_Settings();
                        TA_Version.AppName = APPLICATION_KEY;
                        TA_Version.Version = currentVersionNumber;
                        _globalSettings.AddVersion(TA_Version);
                    }
                    catch
                    {
                    }

                    
                }
            }
        }

        private string getApplicationVersionNumber()
        {
            string versionNumber = string.Empty;

            Assembly web = Assembly.GetExecutingAssembly();
            AssemblyName webName = web.GetName();

            versionNumber = "A" + webName.Version.Major + "." + webName.Version.Minor + "." + webName.Version.Build.ToString("000");

            return versionNumber;

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["PreferredCulture"] == null)
            {
                Session["PreferredCulture"] = "de-DE";
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}