using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using System.Web.Services;
using System.Globalization;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class GateMembersDocumente : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();

        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("GateMonitorMembers_PMode");
            }
            set
            {
                HttpContext.Current.Session["GateMonitorMembers_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.GateMonitorMembers, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnEntSave.Enabled = false; btnNew.Enabled = false; btnCancelDel.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    hiddenFieldMemberId.Value = id;
                    LoadMemberDocuments(Convert.ToInt64(id));
                }
                else
                {
                    Response.Redirect("/Content/GateMembers.aspx");
                }

            }
        }

        protected void LoadMemberDocuments(long id)
        {
            var member = new MembersDataRepository().GetMemberDataById(id);
            if (member == null) return;
            LoadMemberBasicDetails(member);
            var memberCard = member.MemberIdentityCards.FirstOrDefault();
            var memberPassport = member.MemberPassports.FirstOrDefault();
            var drivingLicence = member.MemberDrivingLicenses.FirstOrDefault();
            var healthCard = member.MemberHealthCards.FirstOrDefault();
            var commonInfo = member.MemberCommonInfoes.FirstOrDefault();
            LoadIdentityCard(memberCard);
            LoadMemberPassport(memberPassport);
            LoadDrivingLicence(drivingLicence);
            LoadHealthCard(healthCard);
            LoadCommonInfo(commonInfo);
        }
        protected void LoadMemberBasicDetails(MembersData memberData)
        {
            txtIDNationality.Text = memberData.Nationality;
            txtPPNationality.Text = memberData.Nationality;
            txtIDFirstName.Text = memberData.SurName;
            txtPPFirstName.Text = memberData.SurName;
            txtDLFirstName.Text = memberData.SurName;
            txtHIFirstName.Text = memberData.SurName;
            txtIDName.Text = memberData.FirstName;
            txtPPName.Text = memberData.FirstName;
            txtDLName.Text = memberData.FirstName;
            txtHIName.Text = memberData.FirstName;
            if (memberData.DateOfBirth != null)
            {
                dtIDDateOfBirth.Date = Convert.ToDateTime(memberData.DateOfBirth);
                dtPPDateOfBirth.Date = Convert.ToDateTime(memberData.DateOfBirth);
                dtDLDateOfBirth.Date = Convert.ToDateTime(memberData.DateOfBirth);
                dtHIDateOfBirth.Date = Convert.ToDateTime(memberData.DateOfBirth);
            }
        }
        protected void LoadIdentityCard(MemberIdentityCard card)
        {
            if (card != null)
            {
                txtIDCreatedIn.Text = card.CreatedIn;
                txtIDNumber.Text = card.IDNumber.ToString();
                txtIDAdditionalNumber.Text = card.AdditionalNumber;
                if (card.ExpiryDate != null)
                {
                    dtIDExpiryDate.Date = Convert.ToDateTime(card.ExpiryDate);
                }
                if (card.DateOfIssue != null)
                {
                    dtIDIssuedOn.Date = Convert.ToDateTime(card.DateOfIssue);
                }
                txtIDAddress.Text = card.Address;
                txtIDIssuingAuthority.Text = card.IssuingAuthority;
                txtIDMemo.Text = card.Memo;
            }

        }
        protected void LoadCommonInfo(MemberCommonInfo info)
        {
            if (info != null)
            {
                txtIDPlaceofBirth.Text = info.PlaceOfBirth;
                txtDLPlaceofBirth.Text = info.PlaceOfBirth;
                txtPPPlaceofBirth.Text = info.PlaceOfBirth;
                txtIDEyeColor.Text = info.EyeColor;
                txtPPEyeColor.Text = info.EyeColor;
                txtMemberHeight.Text = info.Height;
                txtPPSize.Text = info.Height;
            }

        }
        protected void LoadMemberPassport(MemberPassport passport)
        {
            if (passport != null)
            {
                txtPPCreatedIn.Text = passport.CreatedIn;
                txtPPNumber.Text = passport.PPNumber;
                txtPPGender.Text = passport.Gender;
                if (passport.DateOfIssue != null)
                {
                    dtPPIssuedOn.Date = Convert.ToDateTime(passport.DateOfIssue);
                }
                if (passport.ExpiryDate != null)
                {
                    dtPPExpiryDate.Date = Convert.ToDateTime(passport.ExpiryDate);
                }
                txtPPIssuingAuthority.Text = passport.IssuingAuthority;
                txtPPMemo.Text = passport.Memo;
            }

        }
        protected void LoadDrivingLicence(MemberDrivingLicense licence)
        {
            if (licence != null)
            {
                txtDLCreatedIn.Text = licence.CreatedIn;
                txtDLNumber.Text = licence.DLNumber;
                if (licence.DateOfIssue != null)
                {
                    dtDLIssuedOn.Date = Convert.ToDateTime(licence.DateOfIssue);
                }
                txtDLClass.Text = licence.DLClass;
                txtDLIssuingAuthority.Text = licence.IssuingAuthority;
                txtDLMemo.Text = licence.Memo;
            }

        }
        protected void LoadHealthCard(MemberHealthCard healthCard)
        {
            if (healthCard != null)
            {
                txtHIBoxOffice.Text = healthCard.BoxNumber;
                txtHICreatedIn.Text = healthCard.CreatedIn;
                txtHIMemberNumber.Text = healthCard.ItemNumber;
                txtHISecurityNumber.Text = healthCard.SecurityNumber;
                txtHICardNumber.Text = healthCard.CardNumber;
                if (healthCard.ExpiryDate != null)
                {
                    dtHIExpirationDate.Date = Convert.ToDateTime(healthCard.ExpiryDate);
                }
                txtHIMemo.Text = healthCard.Memo;
            }

        }

        [WebMethod]
        public static void DeleteIdentityCard(long memberId)
        {
            var card = new MemberIdentityCardRepository().GetCardByMemberId(memberId);
            if (card != null)
            {
                new MemberIdentityCardRepository().DeleteMemberCard(card);
            }
        }
        [WebMethod]
        public static void DeletePassport(long memberId)
        {
            var passport = new MemberPassportRepository().GetMemberPassportByMemberId(memberId);
            if (passport != null)
            {
                new MemberPassportRepository().DeleteMemberPassport(passport);
            }
        }
        [WebMethod]
        public static void DeleteLicence(long memberId)
        {
            var licence = new MemberDrivingLicenseRepository().GetLicenceByMemberId(memberId);
            if (licence != null)
            {
                new MemberDrivingLicenseRepository().DeleteLicence(licence);
            }
        }
        [WebMethod]
        public static void DeleteHealthCard(long memberId)
        {
            var healthCard = new MemberHealthCardRepository().GetHealthCardByMemberId(memberId);
            if (healthCard != null)
            {
                new MemberHealthCardRepository().DeleteHealthCard(healthCard);
            }
        }



        [WebMethod]
        public static new string GetLocalizedText(string key)
        {
            var culture = HttpContext.Current.Session["PreferredCulture"].ToString();
            var cultureInfo = new CultureInfo(culture);

            var text = (string)HttpContext.GetGlobalResourceObject("LocalizedText", key, cultureInfo);
            return text;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GateMembers.aspx");
        }
    }
}