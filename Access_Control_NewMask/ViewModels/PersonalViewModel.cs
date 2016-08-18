using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Access_Control_NewMask.Dtos;

namespace Access_Control_NewMask.ViewModels
{
    public class PersonalViewModel
    {
        #region Properties

        private PersonalRepository _PersonnelRepository = new PersonalRepository();

        private PersAdditionalInfoViewModel _PersAdditionalInfoViewModel = new PersAdditionalInfoViewModel();
        private List<Pers_AdditionalInfo> _PersAdditionalInfoList = new List<Pers_AdditionalInfo>();

        private PersContactViewModel _PersContactViewModel = new PersContactViewModel();
        private List<Pers_Contact> _PersContactList = new List<Pers_Contact>();

        private PresClientViewModel _ClientViewModel = new PresClientViewModel();
        private List<Pers_Client> _PersClientList = new List<Pers_Client>();

        private PersLocationViewModel _PersLocationViewModel = new PersLocationViewModel();
        private List<Pers_Locations> _PersLocationList = new List<Pers_Locations>();

        private PersDepartmentViewModel _PercDepartmentViewModel = new PersDepartmentViewModel();
        private List<Pers_Departments> _PersDepartmentsList = new List<Pers_Departments>();

        private PersCostCentreViewModel _PercCostCentreViewModel = new PersCostCentreViewModel();
        private List<Pers_CostCenters> _PersCostCenterList = new List<Pers_CostCenters>();

        #endregion

        #region Constructor
        public PersonalViewModel()
        {
            _PersAdditionalInfoList = _PersAdditionalInfoViewModel.GetAllPersAdditionalInfo() ??
                new List<Pers_AdditionalInfo>();
            _PersContactList = _PersContactViewModel.GetAllPersContacts() ??
                new List<Pers_Contact>();
            _PersClientList = _ClientViewModel.GetAllPersClient() ??
                new List<Pers_Client>();
            _PersLocationList = _PersLocationViewModel.GetAllPersLocations() ??
                new List<Pers_Locations>();
            _PersDepartmentsList = _PercDepartmentViewModel.GetAllPersDepartment() ??
                new List<Pers_Departments>();
            _PersCostCenterList = _PercCostCentreViewModel.GetAllPersCostCenter() ??
                new List<Pers_CostCenters>();

        }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public PersonnelDto GetPersonnelById(long id)
        {
            var personnel = _PersonnelRepository.GetPersonnelById(id);
            if (personnel == null) return null;
            return CreateDto(personnel);
        }

        public PersonnelDto GetPersonnelByPersNr(long pers_Nr)
        {
            var personnel = _PersonnelRepository.GetPersonnelByNr(pers_Nr);
            if (personnel == null) return null;
            return CreateDto(personnel);
        }

        public PersonnelDto GetLastInsertedPersNr()
        {
            var personnel = _PersonnelRepository.GetLastInserted();
            if (personnel == null) return null;
            return CreateDto(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetPersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(p => p.Active).ToList();
            if (personnel.Count == 0) return null;
            return CreateDto(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetAllActivePersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(p => p.Active).ToList();
            //if (personnel.Count == 0) return null;
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            PersonnelDto personnelObj = new PersonnelDto()
            {
                ID = 0,
                FirstName = "keine",
                LastName = "Auswahl",
                Pers_Nr = 0,
                Active = false
            };
            personnelList.Add(personnelObj);
            personnelList.AddRange(CreateDto(personnel));
            return personnelList;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetAllInActivePersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(p => p.Active == false).ToList();
            //if (personnel.Count == 0) return null;
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            PersonnelDto personnelObj = new PersonnelDto()
            {
                ID = 0,
                FirstName = Resources.LocalizedText.nothing,
                LastName = "",
                Pers_Nr = 0,
                PersNr = 0,
                Active = false
            };
            personnelList.Add(personnelObj);
            personnelList.AddRange(CreateDto(personnel));
            return personnelList;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreatePersonnel(Personal personnel, bool save = true)
        {
            _PersonnelRepository.AddPersonnel(personnel, save);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersonnel(Personal personnel, bool save = true)
        {
            if (personnel.ID == 0) return;
            _PersonnelRepository.EditPersonnel(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonnel(Personal personnel)
        {
            if (personnel.ID == 0) return;
            _PersonnelRepository.DeletePersonnel(personnel);
        }

        private PersonnelDto CreateDto(Personal personnel)
        {
            PersonnelDto personnelDto = new PersonnelDto();

            Pers_AdditionalInfo persAdditionalInfo = _PersAdditionalInfoList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                _PersAdditionalInfoList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                new Pers_AdditionalInfo();

            Pers_Contact pers_Contact = _PersContactList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                 _PersContactList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                  new Pers_Contact();

            Pers_Client pers_Client = _PersClientList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                   _PersClientList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                  new Pers_Client();

            Pers_Locations pers_Location = _PersLocationList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                   _PersLocationList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                  new Pers_Locations();

            Pers_Departments pers_Departments = _PersDepartmentsList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                  _PersDepartmentsList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                  new Pers_Departments();

            Pers_CostCenters pers_CostCenters = _PersCostCenterList.Any(pers => pers.Pers_Nr == personnel.Pers_Nr) ?
                  _PersCostCenterList.FirstOrDefault(pers => pers.Pers_Nr == personnel.Pers_Nr) :
                  new Pers_CostCenters();

            try
            {
                personnelDto.ID = personnel.ID;
                personnelDto.Pers_Nr = personnel.Pers_Nr;
                personnelDto.Card_Nr1 = personnel.Card_Nr;
                personnelDto.EntryDate = personnel.EntryDate;
                personnelDto.ExitDate = personnel.ExitDate;
                personnelDto.FirstName = personnel.FirstName;
                personnelDto.MiddleName = personnel.MiddleName;
                personnelDto.LastName = personnel.LastName;
                personnelDto.Title = personnel.Title;
                personnelDto.PersType = personnel.PersType;
                personnelDto.Pers_Nr = personnel.Pers_Nr;
                personnelDto.CardActive = personnel.CardActive;
                personnelDto.Memo = personnel.Memo;
                personnelDto.Active = personnel.Active;
                personnelDto.Imported = personnel.Imported;
                personnelDto.DOB = persAdditionalInfo.DOB;
                //Additional Info
                personnelDto.EmployedAs = persAdditionalInfo.EmployedAs;
                //Personnel Contact
                personnelDto.CompanyTel = pers_Contact.CompanyTel;
                personnelDto.PrivateTel = pers_Contact.PrivateTel;
                personnelDto.CompanyFax = pers_Contact.CompanyFax;
                personnelDto.CompanyMobile = pers_Contact.CompanyMobile;
                personnelDto.PrivateMobile = pers_Contact.PrivateMobile;
                personnelDto.CompanyEmail = pers_Contact.CompanyEmail;
                personnelDto.PrivateEmail = pers_Contact.PrivateEmail;
                //Client
                //personnelDto.ClientID = pers_Client.ClientID;
                //Locations
                //personnelDto.LocationID = int.Parse(pers_Location.LocationID.ToString());
                ////Departments
                //personnelDto.DepartmentID = int.Parse(pers_Departments.DepartmentID.ToString());
                ////CostCentres
                //personnelDto.CostCenterID = int.Parse(pers_CostCenters.CostCenterID.ToString());

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return personnelDto;
        }

        private List<PersonnelDto> CreateDto(List<Personal> PersonnelList)
        {
            var personnelListing = new List<PersonnelDto>();

            foreach (var personnel in PersonnelList)
            {
                personnelListing.Add(CreateDto(personnel));
            }

            return personnelListing;
        }

        //var Pinecode = new vwPersPinCodeRepository().GetPersPinCodes().Where(x => x.Pers_Nr == Convert.ToInt64(Personalnumber)).FirstOrDefault();
        //  function FilterLocations(val)

        //List<KruAll.Core.Models.Client> persClientList = new List<KruAll.Core.Models.Client>();

        //    persClientList.AddRange(ClientList);
        //    cboClientID.DataSource = persClientList.OrderBy(x => x.Client_Nr);
        //    cboClientID.DataBind();
        //    cboClientName.DataSource = persClientList.OrderBy(x => x.Client_Nr);
        //    cboClientName.DataBind();
        //cboLocationIndexChanged
        //var AllpersonnelEN = _PersonnelRepository.GetAllPersonnel().Where(e => e.Active).ToList();
    }
        #endregion
}
