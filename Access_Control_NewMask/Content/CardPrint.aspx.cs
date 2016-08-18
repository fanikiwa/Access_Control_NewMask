using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.Controllers;
//using Microsoft.Reporting.WebForms;
//using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
//using Access_Control_NewMask.Reports;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.Content
{
    public partial class CardPrint : System.Web.UI.Page
    {
        //public static LocalReport LocalReport { get; set; }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var Id = Convert.ToInt64(Request["Id"]);
                //var Passtype = Convert.ToInt32(Request["Passtype"]);
                //KruAll.Core.Repositories.CardPrint cp = new KruAll.Core.Repositories.CardPrint();
                //var dt = new DataTable();

                //var cards = cp.getCardPrint(Id, ref dt, FileProcessor.PersPhotosFolder, Passtype);

                //string imagePath = "";
                //string persType = "";

                //dt.TableName = "dsCardPrint";
                //List<ReportParameter> repparams = new List<ReportParameter>();
                 
                //rv.ProcessingMode = ProcessingMode.Local;
                //var localReport = rv.LocalReport;
                //localReport.ReportPath = Server.MapPath("~/Reports/CardPrint.rdlc");

                //localReport.EnableExternalImages = true;

                //imagePath = System.IO.File.Exists(Server.MapPath("~/UserImages/Personal/" + cards.FirstName + cards.PersNr + ".png")) 
                //    ? new Uri(Server.MapPath("~/UserImages/Personal/" + cards.FirstName + cards.PersNr + ".png")).AbsoluteUri 
                //    : new Uri(Server.MapPath("~/UserImages/empty.png")).AbsoluteUri;

                //persType = System.IO.File.Exists(Server.MapPath("~/UserImages/PersType/" + cards.PersType + ".png"))
                //    ? new Uri(Server.MapPath("~/UserImages/PersType/" + cards.PersType + ".png")).AbsoluteUri
                //    : new Uri(Server.MapPath("~/UserImages/empty.png")).AbsoluteUri;

                //if (System.IO.File.Exists(persType))
                //{
                //    string qq = "";
                //}

                //repparams.Add(new ReportParameter("PersNr", cards.PersNr.ToString()));
                //repparams.Add(new ReportParameter("Client", cards.Client));
                //repparams.Add(new ReportParameter("FirstName", cards.FirstName));
                //repparams.Add(new ReportParameter("LastName", cards.LastName));
                //repparams.Add(new ReportParameter("ImagePath", imagePath));
                //repparams.Add(new ReportParameter("Date", cards.ExpireDate));
                //repparams.Add(new ReportParameter("PersType", persType));
                //localReport.SetParameters(repparams);

                //localReport.DataSources.Clear();
                //localReport.DataSources.Add(new ReportDataSource(dt.TableName, dt));
                //localReport.Refresh();
                //LocalReport = localReport;
            }

            DataTable dt = new DataTable();

            var Id = Convert.ToInt64(Request["Id"]);
            var Passtype = Convert.ToInt32(Request["Passtype"]);
            KruAll.Core.Repositories.CardPrint cp = new KruAll.Core.Repositories.CardPrint();
            var cards = cp.getCardPrint(Id, ref dt, FileProcessor.PersPhotosFolder, Passtype);

            List<PersonalCardPrint_DTO> personalDTO = new List<PersonalCardPrint_DTO>();
            personalDTO.Add( new PersonalCardPrint_DTO { FirstName = cards.FirstName, LastName = cards.LastName, Client = cards.Client, PersNr = cards.PersNr, ExpireDate = cards.ExpireDate, PicturePath= cards.PicturePath });

            HttpContext.Current.Session["personalCardPrint"] = personalDTO;

            PersonalCardPrintDocViewer.OpenReport(new PersonalCardPrint());

        }

        protected void PrintReport_OnClick(object sender, EventArgs e)
        {
            //ReportPrintDocument pd = new ReportPrintDocument(LocalReport);
            //pd.Print();
           
        }

        protected void PersonalCardPrint_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }
    }
}
