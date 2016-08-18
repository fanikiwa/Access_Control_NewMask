using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Access_Control_NewMask.App_Code;
using KruAll.Core.Repositories;
using KruAll.Core.Models;
using System.Web.Services;
using Access_Control_NewMask.Controllers;
using System.Globalization;

namespace Access_Control_NewMask.Content
{
    public partial class Customer : BasePage
    {
        ZUTMain mainCtl = new ZUTMain();
        public ClientsRepository _ClientsRepository = new ClientsRepository();
        public List<Client> clientsList = new List<Client>();
        public List<Client> clientsList2 = new List<Client>();
        public static accessControlPermissionModes AccessControlPermissionMode
        {
            get
            {
                return ZUTMain.LoadSessionItem<accessControlPermissionModes>("Clients_PMode");
            }
            set
            {
                HttpContext.Current.Session["Clients_PMode"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["Pers_Nr"] == null) mainCtl.RedirectToLoginPage();
            accessControlPermissionModes _AccessControlPermissionMode = accessControlPermissionModes.Read;
            if (!mainCtl.CheckForReadOrWritePermissions(accessControlPermissions.Clients, out _AccessControlPermissionMode))
                mainCtl.RedirectToSettings();

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
            this.Form.DefaultButton = this.btnSave.UniqueID;

            if (!IsPostBack)
            {
                LoadClientDetails();
                BindControls();
            }
        }

        protected void LoadClientDetails()
        {
            Client _Client = new Client()
            {
                ID = 0,
                Client_Nr = 0,
                Name = "Keine",
            };
            var AllClients = new ClientsRepository().GetClients();
            //clientsList.Add(_Client);
            //clientsList.AddRange(AllClients);
            //clientsList2.Add(_Client);
            //clientsList2.AddRange(AllClients);
            //clientsList2.RemoveAt(0);

            List<Client> clients = new List<Client>();
            clients.Add(_Client);
            clients.AddRange(AllClients);

            cboClientName2.DataSource = clients;
            cboClientName2.DataBind();

            cboCustomerNr.DataSource = clients;
            cboCustomerNr.DataBind();

            grdClientDetails.DataSource = AllClients;
            grdClientDetails.DataBind();
            grdClientDetails.FocusedRowIndex = -1;
        }
        void BindControls()
        {

            LocationFederalStateRepository _LocationFederalStateRepository = new LocationFederalStateRepository();
            var states = _LocationFederalStateRepository.GetAllLocationFederalStates();

            cboState.DataSource = states;
            cboState.DataBind();

        }
        protected void LoadClientDetailsByID(int cID)
        {
            var cDetails = new ClientsRepository().GetClientsById(cID);
            if (cDetails != null)
            {

                cboClientName2.Value = cDetails.ID.ToString();
                cboCustomerNr.Value = cDetails.ID.ToString();
                cboState.Value = cDetails.State.ToString();

                if (cDetails.State != null) { cboState.Value = cDetails.State.ToString(); } else { cboState.Value = "0"; };
                if (cDetails.Client_Nr != 0) { txtClientNr.Text = cDetails.Client_Nr.ToString(); } else { txtClientNr.Text = ""; };
                if (cDetails.Name != null) { txtClientName.Text = cDetails.Name.ToString(); } else { txtClientName.Text = ""; };
                if (cDetails.InfoText != null) { txtMemo.Text = cDetails.InfoText.ToString(); } else { txtMemo.Text = ""; };
                if (cDetails.Email != null) { txtEmail.Text = cDetails.Email.ToString(); } else { txtEmail.Text = ""; };
                if (cDetails.PersonInCharge != null) { txtName.Text = cDetails.PersonInCharge.ToString(); } else { txtName.Text = ""; };
                if (cDetails.Plz != null) { txtPLZ.Text = cDetails.Plz.ToString(); } else { txtPLZ.Text = ""; };
                if (cDetails.Street != null) { txtStreet.Text = cDetails.Street.ToString(); } else { txtStreet.Text = ""; };
                if (cDetails.Telephone != null) { txtTel.Text = cDetails.Telephone.ToString(); } else { txtTel.Text = ""; };
                if (cDetails.Mobile != null) { txtMob.Text = cDetails.Mobile.ToString(); } else { txtMob.Text = ""; };
                if (cDetails.HouseNr != null) { txtHouseNr.Text = cDetails.HouseNr.ToString(); } else { txtHouseNr.Text = ""; };
                if (cDetails.Function != null) { txtFunct.Text = cDetails.Function.ToString(); } else { txtFunct.Text = ""; };
                if (cDetails.Ort != null) { txtOrt.Text = cDetails.Ort.ToString(); } else { txtOrt.Text = ""; };

            }
            else
            {
                txtClientName.Text = string.Empty;
                txtClientNr.Text = string.Empty;
                txtMemo.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPLZ.Text = string.Empty;
                txtStreet.Text = string.Empty;
                txtTel.Text = string.Empty;
                txtMob.Text = string.Empty;
                txtHouseNr.Text = string.Empty;
                txtFunct.Text = string.Empty;
                txtOrt.Text = string.Empty;
            }
        }

        protected void EnablesControl()
        {
            cboCustomerNr.Enabled = true;
            cboClientName2.Enabled = true;
            btnDelete.Enabled = AccessControlPermissionMode == accessControlPermissionModes.Edit ? true : false;

        }
        protected void NextClientNr()
        {
            int clientNr = 0;
            var clientDetails = new ClientsRepository().GetClients();
            if (clientDetails.Count() > 0)
            {
                clientNr = Convert.ToInt32(clientDetails.Max(i => i.Client_Nr));
            }
            else
            {
                clientNr = 0;
            }
            int nextNr = clientNr + 1;
            txtClientNr.Text = nextNr.ToString();
            txtClientName.Focus();
            saveChangesonNew.Value = "1";
        }
        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Content/Settings.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            saveChangesonNew.Value = "1";
            cboCustomerNr.Value = 0;
            cboClientName2.Value = 0;

            cboCustomerNr.Enabled = false;
            cboClientName2.Enabled = false;

            ClearItems();
            NextClientNr();

        }
        protected void ClearItems()
        {
            txtClientName.Text = string.Empty;
            txtClientNr.Text = string.Empty;
            txtMemo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPLZ.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtMob.Text = string.Empty;
            txtHouseNr.Text = string.Empty;
            txtFunct.Text = string.Empty;
            txtOrt.Text = string.Empty;
            btnDelete.Enabled = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            saveChangesonNew.Value = "";
            ClientsRepository _clients = new ClientsRepository();
            Client clientDetails = new Client();

            var clientList = _clients.GetClients();
            //var clientExist = clientList.Where(x => x.Client_Nr == Convert.ToInt32(txtClientNr.Text)).FirstOrDefault();
            var clientExist = clientList.FirstOrDefault(x => x.ID == Convert.ToInt32(cboCustomerNr.Value));

            if (clientExist != null)
            {
                clientExist.Client_Nr = Convert.ToInt32(txtClientNr.Text);
                clientExist.Name = txtClientName.Text;
                clientExist.Plz = txtPLZ.Text;
                clientExist.Ort = txtOrt.Text;
                clientExist.PersonInCharge = txtName.Text;
                clientExist.Street = txtStreet.Text;
                clientExist.Telephone = txtTel.Text;
                clientExist.Mobile = txtMob.Text;
                clientExist.InfoText = txtMemo.Text;
                clientExist.HouseNr = txtHouseNr.Text;
                clientExist.State = Convert.ToInt32(cboState.Value) != 0 ? Convert.ToInt32(cboState.Value) : (long?)null;
                clientExist.Function = txtFunct.Text;
                clientExist.Email = txtEmail.Text;

                _clients.EditClient(clientExist);
                mainCtl.RedirectToPromptPage();
                LoadClientDetails();
                LoadClientDetailsByID(Convert.ToInt32(clientExist.ID));

            }
            else
            {
                clientDetails.Client_Nr = Convert.ToInt32(txtClientNr.Text);
                clientDetails.Name = txtClientName.Text;
                clientDetails.Plz = txtPLZ.Text;
                clientDetails.Ort = txtOrt.Text;
                clientDetails.PersonInCharge = txtName.Text;
                clientDetails.Street = txtStreet.Text;
                clientDetails.Telephone = txtTel.Text;
                clientDetails.Mobile = txtMob.Text;
                clientDetails.InfoText = txtMemo.Text;
                clientDetails.HouseNr = txtHouseNr.Text;
                clientDetails.State = Convert.ToInt32(cboState.Value) != 0 ? Convert.ToInt32(cboState.Value) : (long?)null;
                clientDetails.Function = txtFunct.Text;
                clientDetails.Email = txtEmail.Text;

                _clients.NewClient(clientDetails);
                LoadClientDetails();
                LoadClientDetailsByID(Convert.ToInt32(clientDetails.ID));

            }
            EnablesControl();
            mainCtl.RedirectToPromptPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteVehicleType(Convert.ToInt32(cboCustomerNr.Value));
        }
        protected void DeleteVehicleType(int cid)
        {
            var clientID = new ClientsRepository().GetClientsById(cid);

            if (clientID != null)
            {
                new ClientsRepository().DeleteClient(clientID);
            }

            LoadClientDetailsByID(Convert.ToInt32(cboCustomerNr.Value));
            LoadClientDetails();
            cboClientName2.SelectedIndex = 0;
            cboCustomerNr.SelectedIndex = 0;
            grdClientDetails.FocusedRowIndex = -1;
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
        public static void SetPromptRedirectPage(string pageName)
        {
            ZUTMain _mainCtl = new ZUTMain();
            _mainCtl.SetPromptRedirectPage(pageName);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }


        [WebMethod]
        public static Client GetCustomer(long id)
        {
            ClientsRepository _ClientsRepository = new ClientsRepository();
            Client _Client = new Client();

            var client = _ClientsRepository.GetClientsById(id);
            if (client == null)
            {
                return _Client;
            }
            if (client != null)
            {
                _Client.ID = client.ID;
                _Client.Client_Nr = client.Client_Nr;
                _Client.Name = client.Name;
                _Client.Plz = client.Plz;
                _Client.Ort = client.Ort;
                _Client.Street = client.Street;
                _Client.HouseNr = client.HouseNr;

                _Client.State = client.State;
                _Client.PersonInCharge = client.PersonInCharge;
                _Client.Function = client.Function;
                _Client.Telephone = client.Telephone;
                _Client.Mobile = client.Mobile;
                _Client.Email = client.Email;
                _Client.InfoText = client.InfoText;
            }
            return _Client;
        }


        [WebMethod]
        public static Client GetCustomerById(long id)
        {
            var client = new ClientsRepository().GetClientsById(id);
            Client _Client = new Client()
            {
                ID = client.ID,
                Client_Nr = client.Client_Nr,
                Name = client.Name,
                Plz = client.Plz,
                Ort = client.Ort,
                Street = client.Street,
                HouseNr = client.HouseNr,

                State = client.State,
                PersonInCharge = client.PersonInCharge,
                Function = client.Function,
                Telephone = client.Telephone,
                Mobile = client.Mobile,
                Email = client.Email,
                InfoText = client.InfoText,
            };
            return _Client;
        }
    }
}