using Access_Control_NewMask.Controllers;
using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class PersonnelInactiveViewModel
    {
        private PersonnelInactiveRepository _PersonnelInactiveRepository = new PersonnelInactiveRepository();
        PersClientRepository _PersClientRepository = new PersClientRepository();
        PersonnelViewModel _PersonnelViewModel = new PersonnelViewModel();
        private PersLocationRepository _pers_locations = new PersLocationRepository();
        private PersDepartmentRepository _pers_departments = new PersDepartmentRepository();
        private PersCostCentreRepository _pers_costcenters = new PersCostCentreRepository();
        PersVehicleRepository _PersVehicleRepository = new PersVehicleRepository();
        PersAdditionalInfoRepository _PersAdditionalInfoRepository = new PersAdditionalInfoRepository();
        PersContactsRepository _PersContactsRepository = new PersContactsRepository();
        PersPinCodeRepository _PersPinCodeRepository = new PersPinCodeRepository();
        vwPersPinCodeRepository _vwPersPinCodeRepository = new vwPersPinCodeRepository();
        PersImageRepository _persPassportRepository = new PersImageRepository();
        AccessPlanPersMappingRepository _accessPlanPersMappingRepo = new AccessPlanPersMappingRepository();
        VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
        private Personal Personnel = new Personal();

        void savePerzClientMapping(int PerzNo, long ClientID, string State)
        {
            PersClientRepository r = new PersClientRepository();
            if (State == "save")
            {
                Pers_Client c = new Pers_Client();
                c.Pers_Nr = PerzNo;
                c.ClientID = ClientID;
                r.InsertPersClient(c);
            }

            if (State == "edit")
            {
                Pers_Client a = r.GetPersClientByPersNo(PerzNo);
                Pers_Client _a = new Pers_Client { ClientID = ClientID, Pers_Nr = PerzNo };
                r.UpdatePerz(a, _a);
            }

        }
        protected void SavePinCodes(List<Pers_PinCode> type_1, List<Pers_PinCode> type_2, List<Pers_PinCode> type_3, PersonalData_DTO personalData)
        {

            if (type_1.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                var pinTypeId = type_1.Max(x => x.ID);
                var pinType_1 = type_1.Find(x => x.ID == pinTypeId);
                pin = (personalData.AusweisPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.AusweisPincodeStr);
                pintype = 1;
                pinstatus = personalData.PincodeActives;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_1.ID, Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);


            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                if (personalData.AusweisPincode != 0)
                {
                    pin = (personalData.AusweisPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.AusweisPincodeStr);
                    pintype = 1;
                    pinstatus = personalData.PincodeActives;

                    Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                    new PersPinCodeRepository().NewPinCode(_PerPinCode);

                }

            }
            if (type_2.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                var pinTypeId = type_2.Max(x => x.ID);
                var pinType_2 = type_2.Find(x => x.ID == pinTypeId);
                pin = (personalData.NurPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.NurPincodeStr);
                pintype = 2;
                pinstatus = personalData.NurPincodeActive;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_2.ID, Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);

            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;

                pin = (personalData.NurPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.NurPincodeStr);
                pintype = 2;
                pinstatus = personalData.NurPincodeActive;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().NewPinCode(_PerPinCode);


            }
            if (type_3.Count > 0)
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;

                var pinTypeId = type_3.Max(x => x.ID);
                var pinType_3 = type_3.Find(x => x.ID == pinTypeId);
                pin = (personalData.SicherheitsPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.SicherheitsPincodeStr);
                pintype = 3;
                pinstatus = personalData.MenaceActive;

                Pers_PinCode _PerPinCode = new Pers_PinCode() { ID = pinType_3.ID, Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                new PersPinCodeRepository().EditPinCode(_PerPinCode);

            }
            else
            {
                string pin = "";
                int pintype = 0;
                var pinstatus = false;
                if (personalData.SicherheitsPincode != 0)
                {
                    pin = (personalData.SicherheitsPincodeStr ?? "").Trim() == "" ? null : new EncryptionCtl().Encrypt(personalData.SicherheitsPincodeStr);
                    pintype = 3;
                    pinstatus = personalData.MenaceActive;

                    Pers_PinCode _PerPinCode = new Pers_PinCode() { Pers_Nr = Convert.ToInt64(personalData.PersonalNumber), PinCode = pin, PinCodeType = pintype, PinCodeStatus = pinstatus };
                    new PersPinCodeRepository().NewPinCode(_PerPinCode);
                }

            }

        }
        private void SavePersonnalPassport(Pers_Photo photo, PersonalData_DTO personalData)
        {

            bool isNewAdditionalInfo = photo == null;

            if (isNewAdditionalInfo)
            {
                photo = new Pers_Photo();
            }

            //if (personalData.PassPhoto == string.Empty)
            //{
            //    return;
            //}

            photo.Pers_Nr = personalData.PersonalNumber;
            photo.Pers_Passport = FileProcessor.SaveImageFile(","
                + personalData.PassPhoto, personalData.FirstName + personalData.PersonalNumber.ToString());
            //personalData.PassPhoto;// Convert.FromBase64String(personalData.PassPhoto); ;

            switch (isNewAdditionalInfo)
            {
                case true:
                    _persPassportRepository.NewPersonnalPhoto(photo);
                    break;
                case false:
                    _persPassportRepository.EditPersonnalPhoto(photo);
                    break;
            }
        }
        protected void SaveAccessPlan(TbAccessPlanPersMapping accessPlan, PersonalData_DTO personalData)
        {
            int insert = accessPlan == null ? 0 : 1;
            AccessPlanPersMappingRepository _planMapping = new AccessPlanPersMappingRepository();
            var accessPLanNr = personalData.ZuttritsplanNr;
            if (string.IsNullOrEmpty(accessPLanNr)) return;
            var tbAccessPlan = new AccessPlanRepository().GetAccessPlanByNumber(Convert.ToInt64(accessPLanNr));
            if (tbAccessPlan == null) return;
            var location = Convert.ToInt32(personalData.selectlocation);
            var dateFrom = personalData.AccessPlanDateFrom;
            var dateTo = personalData.AccessPlanDateTo;
            switch (insert)
            {
                case 0:
                    TbAccessPlanPersMapping acessPlanInsert = new TbAccessPlanPersMapping()
                    {
                        Pers_Nr = Convert.ToInt64(personalData.PersonalNumber),
                        AccessPlan_Nr = tbAccessPlan.ID,
                        Location_ID = location > 0 ? location : (int?)null,
                        DateFrom = dateFrom,
                        DateTo = dateTo,
                        AutomaticLogout = personalData.AutomaticLogout
                    };
                    _planMapping.NewAccessPlanPersMapping(acessPlanInsert);

                    break;
                case 1:
                    TbAccessPlanPersMapping acessPlanEdit = new TbAccessPlanPersMapping()
                    {
                        ID = accessPlan.ID,
                        Pers_Nr = Convert.ToInt64(personalData.PersonalNumber),
                        AccessPlan_Nr = tbAccessPlan.ID,
                        Location_ID = location > 0 ? location : (int?)null,
                        DateFrom = dateFrom,
                        DateTo = dateTo,
                        AutomaticLogout = personalData.AutomaticLogout
                    };
                    _planMapping.EditAccessPlanPersMapping(acessPlanEdit);

                    break;
            }
        }

        public void EditPersonalInDatabase(PersonalData_DTO personalData)
        {
            Personal _personal = null;
            bool IsNewPersonal = false;

            _personal = _PersonnelInactiveRepository.GetPersonnelPersnur(personalData.PersonalNumber);

            if (_personal == null)
            {
                _personal = new Personal();
                IsNewPersonal = true;
            }

            if (_personal != null)
            {
                _personal.Pers_Nr = personalData.PersonalNumber;
                //_personal.Title = personalData.Salutation;
                _personal.FirstName = personalData.FirstName;
                _personal.LastName = personalData.LastName;
                _personal.Card_Nr = personalData.ActiveCardType == 1 ? personalData.CardNumber1a :
                    personalData.ActiveCardType == 2 ? personalData.CardNumber2a : null;// !string.IsNullOrEmpty(personalData.AusweisNr) ? Convert.ToInt64(personalData.AusweisNr) : (long?)null;
                _personal.CardActive = personalData.IdentificationActive;
                _personal.EntryDate = personalData.DateOfEntry;
                _personal.ExitDate = personalData.DateOfExit;
                _personal.PersType = personalData.PersType == 0 ? null : personalData.PersType;
                _personal.Active = true;
                //_personal.Imported = personalData.Imported;
                _personal.Memo = personalData.Memo;
                _personal.ActiveCardType = personalData.ActiveCardType;
                //_personal.StreetNr = personalData.StreetNr;
                //_personal.PostalCode = personalData._PostalCode; 
            }

            switch (IsNewPersonal)
            {
                case true:
                    _PersonnelInactiveRepository.NewPersonnel(_personal);
                    personalData.ID = _personal.ID;
                    break;
                case false:
                    _PersonnelInactiveRepository.EditPersonnel(_personal);

                    break;
            }
            if (personalData.companyName != "" && personalData.PersonalNumber != 0)
            {
                if (personalData.companyID == "0" || personalData.companyNumber == "0" || personalData.companyNumber == null || personalData.companyID == null)
                {
                    new PersClientRepository().DeletePersClient(Convert.ToInt64(personalData.PersonalNumber));
                }
                else {
                    var a = _PersClientRepository.GetPersClientByPersNo(Convert.ToInt64(personalData.PersonalNumber));
                    if (a == null)
                    {
                        savePerzClientMapping(Convert.ToInt32(personalData.PersonalNumber), Convert.ToInt64(personalData.companyID), "save");
                    }
                    else
                    {

                        var j = _PersonnelViewModel.GetLastinsertedPersNum();
                        savePerzClientMapping(Convert.ToInt32(personalData.PersonalNumber), Convert.ToInt64(personalData.companyID), "edit");
                    }
                }
            }
        }

        public void EditLocationDepartmentAndCostCenter(PersonalData_DTO personalData)
        {

            if (personalData.CostCenterID == null)
            {
                return;
            }

            var location = _pers_locations.GetLocations().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var department = _pers_departments.GetDepartments().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var costcenter = _pers_costcenters.GetCostCentres().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var veh = _PersVehicleRepository.GetVehicles().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var pinfo = _PersAdditionalInfoRepository.GetPersAddInfo().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var pcont = _PersContactsRepository.GetContacts().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var pincode = _vwPersPinCodeRepository.GetPersPinCodes().Where(x => x.Pers_Nr == personalData.PersonalNumber).FirstOrDefault();
            var persPassport = _persPassportRepository.GetPersonnalPhotoByPers_Nr(personalData.PersonalNumber);
            var accessPlan = _accessPlanPersMappingRepo.GetMappingByEmployeeNumber(personalData.PersonalNumber);
            var pincodeType_1 = _PersPinCodeRepository.GetPinCodes().Where(p => p.Pers_Nr == personalData.PersonalNumber && p.PinCodeType == 1).ToList();
            var pincodeType_2 = _PersPinCodeRepository.GetPinCodes().Where(p => p.Pers_Nr == personalData.PersonalNumber && p.PinCodeType == 2).ToList();
            var pincodeType_3 = _PersPinCodeRepository.GetPinCodes().Where(p => p.Pers_Nr == personalData.PersonalNumber && p.PinCodeType == 3).ToList();

            bool isNewLocation = location == null;
            bool isNewDepartment = department == null;
            bool isNewCostCenter = costcenter == null;

            if (isNewLocation)
            {
                location = new Pers_Locations();
            }

            if (isNewDepartment)
            {
                department = new Pers_Departments();
            }

            if (isNewCostCenter)
            {
                costcenter = new Pers_CostCenters();
            }

            location.Pers_Nr = personalData.PersonalNumber;
            location.LocationID = (personalData.LocationID ?? 0) == 0 ? null : personalData.LocationID;

            department.Pers_Nr = personalData.PersonalNumber;
            department.DepartmentID = (personalData.DepartmentID ?? 0) == 0 ? null : personalData.DepartmentID;

            costcenter.Pers_Nr = personalData.PersonalNumber;
            costcenter.CostCenterID = (personalData.CostCenterID ?? 0) == 0 ? null : personalData.CostCenterID;

            switch (isNewLocation)
            {
                case true:
                    _pers_locations.NewLocation(location);
                    break;
                case false:
                    _pers_locations.EditLocation(location);
                    break;
            }

            switch (isNewDepartment)
            {
                case true:
                    _pers_departments.NewDepartment(department);
                    break;
                case false:
                    _pers_departments.EditDepartment(department);
                    break;
            }

            switch (isNewCostCenter)
            {
                case true:
                    _pers_costcenters.NewCostCentre(costcenter);
                    break;
                case false:
                    _pers_costcenters.EditCostCentre(costcenter);
                    break;
            }
            if (veh == null)
            {
                if (personalData.CarType != 0)
                {
                    Pers_Vehicles _PerVeh = new Pers_Vehicles() { Pers_Nr = personalData.PersonalNumber, VehicleID = personalData.CarType };
                    _PersVehicleRepository.NewVehicles(_PerVeh);

                }
            }
            else
            {
                if (personalData.CarType != 0)
                {
                    veh.Pers_Nr = personalData.PersonalNumber;
                    veh.VehicleID = personalData.CarType;
                    _PersVehicleRepository.EditVehicles(veh);

                }
            }
            if (pinfo == null)
            {
                DateTime? dob;
                if (personalData.DateOfBirth != null) { dob = Convert.ToDateTime(personalData.DateOfBirth); } else { dob = null; };
                Pers_AdditionalInfo _PerAddInfo = new Pers_AdditionalInfo()
                {
                    Pers_Nr = Convert.ToInt64(personalData.PersonalNumber),
                    Street = personalData.Street,
                    DOB = personalData.DateOfBirth,
                    VehicleReg = personalData.CarRegnumber,
                    CompanyName = personalData.companyName,
                    Position = personalData.Position,
                    Nationality = personalData.Nationality,
                    PhysicalAddress = personalData.PhysicalAddress,
                    PostalCode = personalData.PostalCode,
                    StreetNr = personalData.StreetNr
                };
                _PersAdditionalInfoRepository.NewPersAddInfo(_PerAddInfo);

            }
            else
            {
                DateTime? dob;
                if (personalData.DateOfBirth != null) { dob = Convert.ToDateTime(personalData.DateOfBirth); } else { dob = null; };
                pinfo.Street = personalData.Street;
                pinfo.DOB = personalData.DateOfBirth;
                pinfo.VehicleReg = personalData.CarRegnumber;
                pinfo.CompanyName = personalData.companyName;
                pinfo.Position = personalData.Position;
                pinfo.Nationality = personalData.Nationality;
                pinfo.PhysicalAddress = personalData.PhysicalAddress;
                pinfo.PostalCode = personalData.PostalCode;
                pinfo.StreetNr = personalData.StreetNr;
                _PersAdditionalInfoRepository.EditPersAddInfo(pinfo);

            }

            if (pcont == null)
            {
                Pers_Contact _PerCont = new Pers_Contact()
                {
                    Pers_Nr = Convert.ToInt64(personalData.PersonalNumber),
                    CompanyTel = personalData.CompTel,
                    PrivateMobile = personalData.PrivMobile,
                    PrivateTel = personalData.PrivTel,
                    PrivateEmail = personalData.PrivateEmail,
                    CompanyMobile = personalData.CompMobile,
                    CompanyEmail = personalData.CompanyEmail,

                };
                _PersContactsRepository.NewContact(_PerCont);

            }
            else
            {
                pcont.CompanyTel = personalData.CompTel;
                pcont.PrivateMobile = personalData.PrivMobile;
                pcont.PrivateTel = personalData.PrivTel;
                pcont.PrivateEmail = personalData.PrivateEmail;
                pcont.CompanyMobile = personalData.CompMobile;
                pcont.CompanyEmail = personalData.CompanyEmail;

                _PersContactsRepository.EditContact(pcont);

            }


            if (personalData.PersonalNumber != 0)
            {
                SavePinCodes(pincodeType_1, pincodeType_2, pincodeType_3, personalData);
                SavePersonnalPassport(persPassport, personalData);
            }
            if (!string.IsNullOrEmpty(personalData.ZuttritsplanNr))
            {

                SaveAccessPlan(accessPlan, personalData);
            }
        }
        public List<Personal> GetAllInactivePersonnel()
        {
            return _PersonnelInactiveRepository.GetAllInactivePersonnel().Where(i => i.Active == false).OrderBy(x => x.Pers_Nr).ToList();
        }

        public PersonnelDto GetLastinsertedPersNum()
        {
            var personnel = _PersonnelInactiveRepository.GetLastInserted();
            if (personnel == null) return null;
            return SearchResult(personnel);
        }

        public PersonnelDto SearchResult(Personal personnel)
        {
            PersonnelDto personnelDto = new PersonnelDto();
            try
            {
                personnelDto.ID = personnel.ID;
                //personnelDto.LocationID = personnel.LocationID;
                //personnelDto.DepartmentID = personnel.DepartmentID;
                //personnelDto.CostCenterID = personnel.CostCenterID;
                personnelDto.EntryDate = personnel.EntryDate;
                personnelDto.ExitDate = personnel.ExitDate;
                //personnelDto.AccessStartDate = personnel.AccessStartDate;
                //personnelDto.AccessEndDate = personnel.AccessEndDate;
                personnelDto.FirstName = personnel.FirstName;
                personnelDto.MiddleName = personnel.MiddleName;
                personnelDto.LastName = personnel.LastName;
                personnelDto.PersonnelNr = personnel.Pers_Nr;
                personnelDto.PersNr = personnel.Pers_Nr;
                personnelDto.PersonnelNr_string = personnel.Pers_Nr.ToString();
                personnelDto.Title = personnel.Title;
                //personnelDto.IdPassportNo = personnel.PassportNr;
                personnelDto.PersType = personnel.PersType;
                personnelDto.Pers_Nr = personnel.Pers_Nr;
                personnelDto.CardActive = personnel.CardActive;
                //personnelDto.VehicleType = personnel.VehicleType ?? 0;
                personnelDto.IdentificationNr = personnel.Card_Nr;
                personnelDto.IdentificationNr_string = personnel.Card_Nr != null ? personnel.Card_Nr.ToString() : "Keine";
                //personnelDto.DOB = personnel.DOB;
                //personnelDto.Nationality = personnel.Nationality;
                personnelDto.Memo = personnel.Memo;
                //personnelDto.LocationName = personnel.Location.Name;
                //personnelDto.DepartmentName = personnel.Department.Name;

                //personnelDto.PinCode = personnel.PINCode;
                //personnelDto.Menace = personnel.Menace;
                personnelDto.Active = personnel.Active;
                personnelDto.IdentificationActive = personnel.CardActive;
                //personnelDto.PincodeActive = personnel.PincodeActive;
                //personnelDto.OnlyIdentificationActive = personnel.OnlyIdentificationActive;
                //personnelDto.MenaceActive = personnel.MenaceActive;
                personnelDto.Imported = personnel.Imported;

                //if (personnel.PersContacts.Count != 0)
                //{
                //    personnelDto.CompanyTel = personnel.PersContacts.FirstOrDefault().CompanyTel;
                //    personnelDto.PrivateTel = personnel.PersContacts.FirstOrDefault().PrivateTel;
                //    personnelDto.PrivateMobile = personnel.PersContacts.FirstOrDefault().PrivateMobile;
                //    personnelDto.CompanyEmail = personnel.PersContacts.FirstOrDefault().CompanyEmail;
                //    personnelDto.PrivateEmail = personnel.PersContacts.FirstOrDefault().PrivateEmail;
                //    personnelDto.PostalAddress = personnel.PersContacts.FirstOrDefault().PostalAddress;
                //    personnelDto.PostalCode = personnel.PersContacts.FirstOrDefault().PostalCode;
                //    personnelDto.CompanyFax = personnel.PersContacts.FirstOrDefault().CompanyFax;
                //    personnelDto.PrivateFax = personnel.PersContacts.FirstOrDefault().PrivateFax;
                //    personnelDto.CompanyMobile = personnel.PersContacts.FirstOrDefault().CompanyMobile;
                //}
                //if (personnel.PersAdditionalInfoes.Count != 0)
                //{
                //    personnelDto.Position = personnel.PersAdditionalInfoes.FirstOrDefault().Position;
                //    personnelDto.PhysicalAddress = personnel.PersAdditionalInfoes.FirstOrDefault().PhysicalAddress;
                //    personnelDto.Street = personnel.PersAdditionalInfoes.FirstOrDefault().Street;
                //    personnelDto.PlaceOfBirth = personnel.PersAdditionalInfoes.FirstOrDefault().PlaceOfBirth;
                //    personnelDto.MaritalStatus = personnel.PersAdditionalInfoes.FirstOrDefault().MaritalStatus;
                //    personnelDto.Profession = personnel.PersAdditionalInfoes.FirstOrDefault().Profession;
                //    personnelDto.CompanyName = personnel.PersAdditionalInfoes.FirstOrDefault().CompanyName;
                //    personnelDto.VehicleModel = personnel.PersAdditionalInfoes.FirstOrDefault().VehicleModel;
                //    personnelDto.VehicleReg = personnel.PersAdditionalInfoes.FirstOrDefault().VehicleReg;
                //}
                //if (personnel.TbAccessPlanPersMappings.Count != 0) 
                //{                    
                //    personnelDto.AccessPlanNo = personnel.TbAccessPlanPersMappings.FirstOrDefault().AccessPlan_Nr;
                //    //personnelDto.AccessPlanDescription = personnel.TbAccessPlans.FirstOrDefault().AccessPlanDescription;
                //    personnelDto.AccessPlanDescription  = personnel.TbAccessPlanPersMappings.FirstOrDefault().TbAccessPlan.AccessPlanDescription;                   
                //}
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return personnelDto;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public PersonnelDto GetPersonnelById(long id)
        {

            var personnel = _PersonnelInactiveRepository.GetPersonnelById(id);
            if (personnel == null) return null;
            Personnel = personnel;
            return SearchResult(personnel);
        }

        public PersonnelDto GetPersonnelByPersNum(long pers_Nr)
        {
            var personnel = _PersonnelInactiveRepository.GetPersonnelByPersNumber(pers_Nr);
            if (personnel == null) return null;
            return SearchResult(personnel);
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetPersonnel()
        {
            var personnel = _PersonnelInactiveRepository.GetAllInactivePersonnel().ToList();
            if (personnel.Count == 0) return null;
            return SearchResults(personnel);
        }

        private List<PersonnelDto> SearchResults(IList<Personal> AllPersonnel)
        {

            var personnelListing = new List<PersonnelDto>();
            foreach (var personnel in AllPersonnel)
            {
                personnelListing.Add(SearchResult(personnel));

            }
            return personnelListing;
        }




    }
}