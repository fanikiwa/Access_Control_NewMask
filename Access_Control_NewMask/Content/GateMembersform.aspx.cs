﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using Access_Control_NewMask.ViewModels;
using Access_Control_NewMask.Dtos;
using System.Web.Services;
using System.Globalization;
using Access_Control_NewMask.Controllers;

namespace Access_Control_NewMask.Content
{
    public partial class GateMembersform : BasePage
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
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.MembersActive, out _AccessControlPermissionMode))
                mainCtl.RedirectToDashoard();

            AccessControlPermissionMode = _AccessControlPermissionMode;
            if (AccessControlPermissionMode != accessControlPermissionModes.Edit)
            {
                btnSave.Enabled = false; btnNew.Enabled = false; btnDelete.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Load Page without prompt for Save Right",
                  "allowZUTEdit = false;", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMemberGroups();
                LoadMembers();
                BindSearchGrid();
                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    cobMemberNr.Value = id.ToString();
                    cobMemberName.Value = id.ToString();
                    txtFvCurrentEntry.Text = cobMemberNr.SelectedIndex.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DisplayData", " DisplayDataOnLoad('" + id + "');", true);
                }
                else
                {
                    Response.Redirect("/Content/GateMembers.aspx");
                }
            }
        }

        protected void LoadMemberGroups()
        {
            List<MemberGroupDto> memberGroupList = new List<MemberGroupDto>();
            MemberGroupDto _member = new MemberGroupDto() { Id = 0, GroupNr = 0, GroupNumber = "Alle", GroupName = "Alle" };
            memberGroupList.Add(_member);
            //var memberGroups = new MembersViewModel().MemberGroups();
            var memberGroups = new MembersViewModel().FilterMemberGroups();
            memberGroupList.AddRange(memberGroups);

            cobMemberGroupNr.DataSource = memberGroupList;
            cobMemberGroupNr.DataBind();
            cobMemberGroupNr.SelectedIndex = 0;
            cobMemberGroupName.DataSource = memberGroupList;
            cobMemberGroupName.DataBind();
            cobMemberGroupName.SelectedIndex = 0;
        }

        protected void LoadMembers()
        {
            var members = new MembersViewModel().MemberDetails();
            List<MembersDataDto> memberList = new List<MembersDataDto>();
            MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
            memberList.Add(_member);
            memberList.AddRange(members);
            cobMemberNr.DataSource = memberList;
            cobMemberNr.DataBind();
            cobMemberName.DataSource = memberList;
            cobMemberName.DataBind();
            if (members.Count > 0)
            {
                cobMemberNr.SelectedIndex = 1;
                cobMemberName.SelectedIndex = 1;
                txtFvTotalEntries.Text = members.Count.ToString();
            }
            else
            {
                cobMemberNr.SelectedIndex = 0;
                cobMemberName.SelectedIndex = 0;
                txtFvTotalEntries.Text = "";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GateMembers.aspx");
        }

        protected void BindSearchGrid()
        {
            var membersData = new MembersViewModel().MemberSearchDetails();
            grdSearchMember.DataSource = membersData;
            grdSearchMember.DataBind();
        }

        protected void cobMemberName_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                var groupId = Convert.ToInt64(e.Parameter);
                if (groupId > 0)
                {
                    var members = new MembersViewModel().MemberDetails().Where(x => x.MemberGroupId == groupId).ToList();
                    List<MembersDataDto> memberList = new List<MembersDataDto>();
                    MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
                    memberList.Add(_member);
                    memberList.AddRange(members);
                    cobMemberName.DataSource = memberList;
                    cobMemberName.DataBind();
                    if (memberList.Count > 1)
                    {
                        cobMemberName.SelectedIndex = 1;
                    }
                }
                else
                {
                    var members = new MembersViewModel().MemberDetails();
                    List<MembersDataDto> memberList = new List<MembersDataDto>();
                    MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
                    memberList.Add(_member);
                    memberList.AddRange(members);
                    cobMemberName.DataSource = memberList;
                    cobMemberName.DataBind();
                    if (memberList.Count > 1)
                    {
                        cobMemberName.SelectedIndex = 1;
                    }
                }

            }
        }

        protected void cobMemberNr_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                var groupId = Convert.ToInt64(e.Parameter);
                if (groupId > 0)
                {
                    var members = new MembersViewModel().MemberDetails().Where(x => x.MemberGroupId == groupId).ToList();
                    List<MembersDataDto> memberList = new List<MembersDataDto>();
                    MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
                    memberList.Add(_member);
                    memberList.AddRange(members);
                    cobMemberNr.DataSource = memberList;
                    cobMemberNr.DataBind();
                    if (memberList.Count > 1)
                    {
                        cobMemberNr.SelectedIndex = 1;
                    }
                }
                else
                {
                    var members = new MembersViewModel().MemberDetails();
                    List<MembersDataDto> memberList = new List<MembersDataDto>();
                    MembersDataDto _member = new MembersDataDto() { ID = 0, MemberNumber = 0, SurName = "keine", FirstName = "" };
                    memberList.Add(_member);
                    memberList.AddRange(members);
                    cobMemberNr.DataSource = memberList;
                    cobMemberNr.DataBind();
                    if (memberList.Count > 1)
                    {
                        cobMemberNr.SelectedIndex = 1;
                    }
                }
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

        [WebMethod]
        public static List<MemberDynamicFieldDto> GetMemberDynamicFields(long memberId)
        {

            return new MemberFormViewModel().GetMemberDynamicFields(memberId);
        }
    }
}