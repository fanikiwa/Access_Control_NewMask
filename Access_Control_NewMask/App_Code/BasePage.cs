using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;

namespace Access_Control_NewMask.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string previousCulture = Convert.ToString(CultureInfo.CurrentCulture);                  //Get Previous Culture
            string previousUICulture = Convert.ToString(CultureInfo.CurrentUICulture);          //Get Previous UI Culture

            string culture = (Session["PreferredCulture"] == null) ? "" : Session["PreferredCulture"].ToString();               //If There's no Preferred Culture in Session, String Empty, Otherwise get the culture from the session

            if (!string.Equals(culture, "previousCulture") && !string.Equals(culture, ""))                          //If culture In Session is not as the previousCulture. Change
            {
                Culture = culture;
                UICulture = culture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
            else                                                //Maintain Previous Culture
            {
                Culture = previousCulture;
                UICulture = previousUICulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(previousCulture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(previousUICulture);
            }

            base.InitializeCulture();                   //Every form that derives this Class, Set the culture as above
        }

        public static string GetLocalizedText(string key)
        {
            var culture = (HttpContext.Current.Session["PreferredCulture"] != null) ? HttpContext.Current.Session["PreferredCulture"].ToString() : "de-DE";
            var cultureInfo = new CultureInfo(culture);

            string text = (HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo) != null) ?
                (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo) : "";

            return text;
        }

        protected override void OnLoad(EventArgs e)
        {
            DevExpress.Web.ASPxWebControl.RegisterBaseScript(this);
            base.OnLoad(e);
        }
    }
}