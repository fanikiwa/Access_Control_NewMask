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
    public class PersonnelViewModel
    {
        #region Constructor
        public PersonnelViewModel() { }

        #endregion

        #region Properties

        private PersonnelRepository _PersonnelRepository = new PersonnelRepository();
        private AccessPlanRepository _AccessPlanRepository = new AccessPlanRepository();
        PersonalstammStammRepository _PersonalstammStammRepository = new PersonalstammStammRepository();
        VwPersonnelDataRepository _viewPersonnelRepository = new VwPersonnelDataRepository();
        private Personal Personnel = new Personal();
        private PersonalRepository _PersonnalRepository = new PersonalRepository();

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

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public PersonnelDto GetPersonnelById(long id)
        {

            var personnel = _PersonnelRepository.GetPersonnelById(id);
            if (personnel == null) return null;
            Personnel = personnel;
            return SearchResult(personnel);
        }

        public PersonnelDto GetPersonnelByPersNum(long pers_Nr)
        {
            var personnel = _PersonnelRepository.GetPersonnelByPersNumber(pers_Nr);
            if (personnel == null) return null;
            return SearchResult(personnel);
        }

        public PersonnelDto GetLastinsertedPersNum()
        {
            var personnel = _PersonnelRepository.GetLastInserted();
            if (personnel == null) return null;
            return SearchResult(personnel);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetPersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(e => e.Active).ToList();
            if (personnel.Count == 0) return null;
            return SearchResults(personnel);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetALLPersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(e => e.Active).ToList();
            //if (personnel.Count == 0) return null;
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            PersonnelDto personnelObj = new PersonnelDto() { ID = 0, FirstName = "Keine Auswahl", LastName = "", Pers_Nr = 0, PersNr = 0, PersonnelNr_string = "Keine", IdentificationNr_string = "Keine" };
            personnelList.Add(personnelObj);
            personnelList.AddRange(SearchResults(personnel));
            return personnelList;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetAllInactivePersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(e => e.Active == false).ToList();
            //if (personnel.Count == 0) return null;
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            PersonnelDto personnelObj = new PersonnelDto() { ID = 0, FirstName = "keine Auswahl", LastName = "", Pers_Nr = 0, PersNr = 0, PersonnelNr_string = "Keine", IdentificationNr_string = "Keine" };
            personnelList.Add(personnelObj);
            personnelList.AddRange(SearchResults(personnel));
            return personnelList;
        }

        public List<Personal> GetPersonnels()
        {
            return _PersonnelRepository.GetAllPersonnel().Where(p => p.Active).ToList();
        }

        public long GetLastPerNr()
        {
            return _PersonnelRepository.GetAllPersonnel().Max(x => x.Pers_Nr);
        }

        //public List<Personal> GetPersonnels(List<long> personnelIds)
        //{
        //    return _PersonnelRepository.GetAllPersonnel().Where(p => personnelIds.Contains(p.Pers_Nr)).ToList();
        //}
        public List<VwPersonnelData> GetPersonnels(List<long> personnelIds)
        {
            return _viewPersonnelRepository.GetAllPersonnel().Where(p => personnelIds.Contains(p.Pers_Nr)).ToList();
        }

        //public List<Personal> GetPersonnels(int personalIdFrom, int personalIdTo, int locationFrom, int locationTo,
        //                                        int departmentFrom, int departmentTo, int costCentreFrom, int costCentreTo)
        //{
        //    var personals = _PersonnelRepository.GetPersonalsQuery();
        //    var query = from Personal emp in personals select emp;
        //    //    if ((personalIdFrom > 0) || (personalIdTo > 0))
        //    //    {
        //    //        query = query.Where(p => p.ID >= personalIdFrom && p.ID <= personalIdTo);
        //    //    }

        //    //    if ((locationFrom > 0) || (locationTo > 0))
        //    //    {
        //    //        query = query.Where(p => p.LocationID >= locationFrom && p.LocationID <= locationTo);
        //    //    }

        //    //    if ((departmentFrom > 0) || (departmentTo > 0))
        //    //    {
        //    //        query = query.Where(p => p.DepartmentID >= departmentFrom && p.DepartmentID <= departmentTo);
        //    //    }

        //    //    if ((costCentreFrom > 0) || (costCentreTo > 0))
        //    //    {
        //    //        query = query.Where(p => p.CostCenterID >= costCentreFrom && p.CostCenterID <= costCentreTo);
        //    //    }

        //    var personalList = query.ToList();

        //    return personalList;
        //}
        //public List<VwPersonnelData> GetPersonnels(int personalIdFrom, int personalIdTo, int locationFrom, int locationTo,
        //                                        int departmentFrom, int departmentTo, int costCentreFrom, int costCentreTo)
        //{
        //    var personals = _viewPersonnelRepository.GetAllPersonnel();
        //    //var query = from VwPersonnelData emp in personals select emp;
        //    if ((personalIdFrom > 0) || (personalIdTo > 0))
        //    {
        //        personals = personals.Where(p => p.ID >= personalIdFrom && p.ID <= personalIdTo).ToList();
        //    }

        //    if ((locationFrom > 0) || (locationTo > 0))
        //    {
        //        personals = personals.Where(p => p.LocationID >= locationFrom && p.LocationID <= locationTo).ToList();
        //    }

        //    if ((departmentFrom > 0) || (departmentTo > 0))
        //    {
        //        personals = personals.Where(p => p.DepartmentID >= departmentFrom && p.DepartmentID <= departmentTo).ToList();
        //    }

        //    if ((costCentreFrom > 0) || (costCentreTo > 0))
        //    {
        //        personals = personals.Where(p => p.CostCenterID >= costCentreFrom && p.CostCenterID <= costCentreTo).ToList();
        //    }

        //    var personalList = personals.Distinct().ToList();

        //    return personalList;
        //}
        //[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]



        #region GetPersonal
        public List<VwPersonnelData> GetPersonnels(int personalIdFrom, int personalIdTo, int locationFrom, int locationTo,
                                       int departmentFrom, int departmentTo, int costCentreFrom, int costCentreTo)
        {
            var personals = _viewPersonnelRepository.GetAllPersonnel();
            //var query = from VwPersonnelData emp in personals select emp;
            if ((personalIdFrom > 0) || (personalIdTo > 0))
            {
                personals = personals.Where(p => p.Pers_Nr >= personalIdFrom && p.Pers_Nr <= personalIdTo).ToList();
            }

            if ((locationFrom > 0) || (locationTo > 0))
            {
                personals = personals.Where(p => p.LocationID >= locationFrom && p.LocationID <= locationTo).ToList();
            }

            if ((departmentFrom > 0) || (departmentTo > 0))
            {
                personals = personals.Where(p => p.DepartmentID >= departmentFrom && p.DepartmentID <= departmentTo).ToList();
            }

            if ((costCentreFrom > 0) || (costCentreTo > 0))
            {
                personals = personals.Where(p => p.CostCenterID >= costCentreFrom && p.CostCenterID <= costCentreTo).ToList();
            }

            var personalList = personals.Distinct().ToList();

            return personalList;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]


        #endregion


        public void CreatePersonnel(PersonnelDto personnel)
        {
            try
            {
                PopulateModel(personnel);
                _PersonnelRepository.NewPersonnel(Personnel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreatePersonnelCustom(PersonnelDto personnel)
        {
            try
            {
                PopulateModel(personnel);
                _PersonnelRepository.NewPersonnelCustom(Personnel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersonnel(PersonnelDto personnel)
        {
            try
            {
                if (personnel.ID == 0) return;
                PopulateModel(personnel);
                _PersonnelRepository.EditPersonnel(Personnel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdatePersonnelCustom(PersonnelDto personnel)
        {
            try
            {
                if (personnel.ID == 0) return;
                PopulateModel(personnel);
                _PersonnelRepository.EditPersonnelCustom(Personnel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonnel(PersonnelDto personnel)
        {
            if (personnel.ID == 0) return;
            Personnel.ID = personnel.ID;
            _PersonnelRepository.DeletePersonnel(Personnel);
        }

        private void PopulateModel(PersonnelDto personnel)
        {
            TbAccessPlan _tbAccessPlan = new TbAccessPlan();
            try
            {
                _tbAccessPlan = _AccessPlanRepository.GetAccessPlanByNumber(personnel.AccessPlanNo);
                if (personnel.ID == 0)
                {
                    Pers_Contact PersContacts = new Pers_Contact();
                    Pers_AdditionalInfo PersAdditionalInfo = new Pers_AdditionalInfo();
                    TbAccessPlanPersMapping _TbAccessPlanPersMapping = new TbAccessPlanPersMapping();

                    Personnel.Pers_Nr = personnel.PersNr;
                    Personnel.FirstName = personnel.FirstName;
                    Personnel.MiddleName = personnel.MiddleName;
                    Personnel.LastName = personnel.LastName;
                    Personnel.Active = true;
                    Personnel.EntryDate = Convert.ToDateTime(personnel.EntryDate);
                    Personnel.ExitDate = personnel.ExitDate;
                    if (personnel.PersType == 0)
                    {
                        Personnel.PersType = null;
                    }
                    else
                    {
                        Personnel.PersType = personnel.PersType;
                    }
                    Personnel.Memo = personnel.Memo;
                    Personnel.Imported = personnel.Imported;
                    Personnel.CardActive = personnel.CardActive;

                    PersContacts.ID = personnel.ID;
                    //PersContacts.PersNr = 1;
                    PersContacts.CompanyTel = personnel.CompanyTel;
                    PersContacts.PrivateTel = personnel.PrivateTel;
                    PersContacts.PrivateMobile = personnel.PrivateMobile;
                    PersContacts.CompanyEmail = personnel.CompanyEmail;
                    PersContacts.PrivateEmail = personnel.PrivateEmail;
                    PersContacts.PostalAddress = personnel.PostalAddress;
                    PersContacts.PostalCode = personnel.PostalCode;
                    PersContacts.CompanyFax = personnel.CompanyFax;
                    PersContacts.PrivateFax = personnel.PrivateFax;
                    PersContacts.CompanyMobile = personnel.CompanyMobile;

                    PersAdditionalInfo.ID = personnel.ID;
                    //PersAdditionalInfo.PersNr = 1;
                    PersAdditionalInfo.Position = personnel.Position;
                    PersAdditionalInfo.PhysicalAddress = personnel.PhysicalAddress;
                    PersAdditionalInfo.Street = personnel.Street;
                    PersAdditionalInfo.PlaceOfBirth = personnel.PlaceOfBirth;
                    PersAdditionalInfo.MaritalStatus = personnel.MaritalStatus;
                    PersAdditionalInfo.Profession = personnel.Profession;
                    PersAdditionalInfo.CompanyName = personnel.CompanyName;
                    PersAdditionalInfo.VehicleModel = personnel.VehicleModel;
                    PersAdditionalInfo.VehicleReg = personnel.VehicleReg;

                    //_TbAccessPlanPersMapping.AccessPlan_Nr = _tbAccessPlan.ID;
                    //_TbAccessPlanPersMapping.Pers_Nr = personnel.ID;

                    //Personnel.PersContacts.Add(PersContacts);
                    //Personnel.PersAdditionalInfoes.Add(PersAdditionalInfo);
                    //Personnel.TbAccessPlanPersMappings.Add(_TbAccessPlanPersMapping);

                }
                else
                {
                    Personnel = _PersonnelRepository.GetPersonnelById(personnel.ID);
                    Pers_Contact persCont = new Pers_Contact();
                    //if (Personnel.PersContacts.Count != 0)
                    //{
                    //persCont = (from s in Pers_Contacts where s. == personnel.ID select s).FirstOrDefault();

                    //persCont.CompanyTel = personnel.CompanyTel;
                    //persCont.PrivateTel = personnel.PrivateTel;
                    //persCont.PrivateMobile = personnel.PrivateMobile;
                    //persCont.CompanyEmail = personnel.CompanyEmail;
                    //persCont.PrivateEmail = personnel.PrivateEmail;
                    //persCont.PostalAddress = personnel.PostalAddress;
                    //persCont.PostalCode = personnel.PostalCode;
                    //persCont.CompanyFax = personnel.CompanyFax;
                    //persCont.PrivateFax = personnel.PrivateFax;
                    //persCont.CompanyMobile = personnel.CompanyMobile;
                    //}
                    //Pers_AdditionalInfo persInfo = new Pers_AdditionalInfo();
                    ////if (Personnel.PersAdditionalInfoes.Count != 0)
                    ////{
                    //    //persInfo = (from s in Personnel.PersAdditionalInfoes where s.PersonalID == personnel.ID select s).FirstOrDefault();
                    //    persInfo.Position = personnel.Position;
                    //    persInfo.PhysicalAddress = personnel.PhysicalAddress;
                    //    persInfo.Street = personnel.Street;
                    //    persInfo.PlaceOfBirth = personnel.PlaceOfBirth;
                    //    persInfo.MaritalStatus = personnel.MaritalStatus;
                    //    persInfo.Profession = personnel.Profession;
                    //    persInfo.CompanyName = personnel.CompanyName;
                    //    persInfo.VehicleModel = personnel.VehicleModel;
                    //    persInfo.VehicleReg = personnel.VehicleReg;
                    ////}
                    //TbAccessPlanPersMapping tbAccessPlanPersMapping = new TbAccessPlanPersMapping();
                    ////if (Personnel.TbAccessPlanPersMappings.Count != 0)
                    ////{
                    //    //tbAccessPlanPersMapping = (from s in Personnel.TbAccessPlanPersMappings where s.Personel_Nr == personnel.ID select s).FirstOrDefault();
                    //    tbAccessPlanPersMapping.AccessPlan_Nr = _tbAccessPlan.ID;
                    //    tbAccessPlanPersMapping.Pers_Nr = personnel.ID;
                    //    tbAccessPlanPersMapping.Location_ID = personnel.LocationID;
                    ////}
                    //else if (Personnel.TbAccessPlanPersMappings.Count == 0)
                    //{
                    //    AccessPlanPersMappingViewModel accessPlanPersMappingViewModel = new AccessPlanPersMappingViewModel();
                    //    TbAccessPlanPersMapping _mapping = new TbAccessPlanPersMapping();
                    //    _mapping.AccessPlan_Nr = _tbAccessPlan.ID;
                    //    _mapping.Personel_Nr = Convert.ToInt64(personnel.ID);
                    //    _mapping.Location_ID = personnel.LocationID;
                    //    accessPlanPersMappingViewModel.CreateMapping(_mapping);
                    //    tbAccessPlanPersMapping = accessPlanPersMappingViewModel.GetByPlanNumberByEmployeeNumber(Convert.ToInt64(_tbAccessPlan.ID), Convert.ToInt64(personnel.ID));
                    //    //  Personnel.TbAccessPlanPersMappings.Add(tbAccessPlanPersMapping);
                    //}
                }

                Personnel.Pers_Nr = personnel.PersNr;
                Personnel.CardActive = personnel.CardActive;

                Personnel.Active = true;
                Personnel.EntryDate = Convert.ToDateTime(personnel.EntryDate);
                Personnel.ExitDate = personnel.ExitDate;
                //Personnel.AccessStartDate = personnel.AccessStartDate;
                //Personnel.AccessEndDate = personnel.AccessEndDate;

                Personnel.FirstName = personnel.FirstName;
                Personnel.MiddleName = personnel.MiddleName;
                Personnel.LastName = personnel.LastName;
                ////Personnel.PersonnelNr = personnel.PersonnelNr;
                //Personnel.Title = personnel.Title;
                ////Personnel.PassportNr = personnel.IdPassportNo;
                if (personnel.PersType == 0)
                {
                    Personnel.PersType = null;
                }
                else
                {
                    Personnel.PersType = personnel.PersType;
                }
                //Personnel.VehicleType = personnel.VehicleType;
                //Personnel.DOB = personnel.DOB;
                //Personnel.Nationality = personnel.Nationality;
                Personnel.Card_Nr = personnel.IdentificationNr;
                Personnel.Memo = personnel.Memo;

                //Personnel.PINCode = personnel.PinCode;
                //Personnel.Menace = personnel.Menace;
                //Personnel.ActiveStatus = personnel.ActiveStatus;
                //Personnel.IdentificationActive = personnel.IdentificationActive;
                //Personnel.PincodeActive = personnel.PincodeActive;
                //Personnel.OnlyIdentificationActive = personnel.OnlyIdentificationActive;
                //Personnel.MenaceActive = personnel.MenaceActive; 
                //if ( personnel.LocationID == 0)
                //{
                //    Personnel.LocationID = null;
                //}
                //else
                //{
                //    Personnel.LocationID = personnel.LocationID;
                //}

                //if (personnel.DepartmentID == 0)
                //{
                //    Personnel.DepartmentID = null;
                //}
                //else
                //{
                //    Personnel.DepartmentID = personnel.DepartmentID;
                //}

                //if (personnel.CostCenterID == 0)
                //{
                //    Personnel.CostCenterID = null;
                //}
                //else
                //{
                //    Personnel.CostCenterID = personnel.CostCenterID;
                //} 
                Personnel.Imported = personnel.Imported;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private PersonnelDto SearchResult(Personal personnel)
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

        public TbAccessPlan GetPersonnelAccessPlan(Personal personal)
        {
            //AccessPlanPersMappingRepository accessPlanPersMappingRepository = new AccessPlanPersMappingRepository();
            TbAccessPlanPersMapping tbAccessPlanPersMapping = new TbAccessPlanPersMapping();
            AccessPlanRepository accessPlanRepository = new AccessPlanRepository();
            TbAccessPlan tbAccessPlan = new TbAccessPlan();

            try
            {
                //tbAccessPlanPersMapping = accessPlanPersMappingRepository.GetByEmployeeNumber(personal.ID).FirstOrDefault() ?? new TbAccessPlanPersMapping();
                tbAccessPlan = accessPlanRepository.GetAccessPlanById(tbAccessPlanPersMapping.AccessPlan_Nr) ?? new TbAccessPlan();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return tbAccessPlan;
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


        public void checkImport()
        {

            Personalstamm personnelDE = new Personalstamm();


            LocationRepository _LocationRepository = new LocationRepository();
            WerkeRepository _WerkeRepository = new WerkeRepository();

            DepartmentRepository _DepartmentRepository = new DepartmentRepository();
            AbteilungRepository _AbteilungRepository = new AbteilungRepository();

            CostCenterRepository _CostCenterRepository = new CostCenterRepository();
            KostenstellenRepository _KostenstellenRepository = new KostenstellenRepository();


            var locs = _WerkeRepository.GetLocations();
            foreach (var chkloc in locs)
            {
                checkLoc(Convert.ToInt32(chkloc.W_Nr));
            }

            var depts = _AbteilungRepository.GetDepartments();
            foreach (var chkloc in depts)
            {
                checkDept(Convert.ToInt32(chkloc.Abt_Nr));
            }

            var costs = _KostenstellenRepository.GetCostCentres();
            foreach (var chkloc in costs)
            {
                checkCost(Convert.ToInt32(chkloc.Kos_Nr));
            }



            var AllpersonnelDE = _PersonalstammStammRepository.GetAllPersonnel().Where(e => e.Pers_Nr > 0).ToList();
            var AllpersonnelEN = _PersonnelRepository.GetAllPersonnel().Where(e => e.Active).ToList();

            foreach (var perexist in AllpersonnelDE)
            {

                var enpers = AllpersonnelEN.Where(p => p.Pers_Nr == Convert.ToInt64(perexist.Pers_Nr)).FirstOrDefault();
                if (enpers == null)
                {
                    Personal personnel = new Personal();

                    Personnel.Card_Nr = Convert.ToInt64(perexist.Pers_Ausweis_Nr);
                    Personnel.Pers_Nr = Convert.ToInt64(perexist.Pers_Nr);
                    Personnel.FirstName = perexist.Pers_Name1;
                    Personnel.LastName = perexist.Pers_Name2;
                    //checkLoc(Convert.ToInt32(perexist.Pers_Werk));
                    //Personnel.LocationID = _LocationRepository.GetLocationByNr(Convert.ToInt32(perexist.Pers_Werk)).ID;
                    //checkDept(Convert.ToInt32(perexist.Pers_Abteilung));
                    //Personnel.DepartmentID =_DepartmentRepository.GetDepartmentByNr(Convert.ToInt32(perexist.Pers_Abteilung)).ID;
                    //checkCost(Convert.ToInt32(perexist.Pers_Kostenstelle));
                    //Personnel.CostCenterID =_CostCenterRepository.GetCostCenterByNr(Convert.ToInt32(perexist.Pers_Kostenstelle)).ID;
                    Personnel.Active = true;
                    Personnel.PersType = 1;
                    //Personnel.Archived = false;
                    //Personnel.IdentificationActive = false;
                    //Personnel.PincodeActive = false;
                    //Personnel.MenaceActive = false;
                    //Personnel.OnlyIdentificationActive = false;
                    Personnel.Imported = true;

                    //Personnel.PINCode = perexist.Pers_PinCode;

                    _PersonnelRepository.NewPersonnel(Personnel);
                }
            }

        }

        public void checkLoc(int Id)
        {
            Location _Location = new Location();
            LocationRepository _LocationRepository = new LocationRepository();
            LocationFederalStateRepository _LocationFederalStateRepository = new LocationFederalStateRepository();
            WerkeRepository _WerkeRepository = new WerkeRepository();

            var w = _WerkeRepository.GetLocationsById(Id);
            var l = _LocationRepository.GetLocationByNr(Id);

            if (l == null)
            {
                _Location.Location_Nr = Convert.ToInt64(w.W_Nr);
                _Location.Name = w.W_Bezeichnung;
                _Location.LocationFederalStateId = _LocationFederalStateRepository.GetAllLocationFederalStates().FirstOrDefault().ID;
                _LocationRepository.NewLocation(_Location);
            }

        }

        public void checkDept(int Id)
        {
            Department _Department = new Department();
            DepartmentRepository _DepartmentRepository = new DepartmentRepository();
            LocationRepository _LocationRepository = new LocationRepository();
            AbteilungRepository _AbteilungRepository = new AbteilungRepository();

            var a = _AbteilungRepository.GetDepartmentsById(Id);
            var d = _DepartmentRepository.GetDepartmentByNr(Id);
            if (d == null)
            {
                _Department.Department_Nr = Convert.ToInt64(a.Abt_Nr);
                _Department.Name = a.Abt_Bezeichnung;
                _Department.LocationId = _LocationRepository.GetLocationByNr(1).ID;
                _DepartmentRepository.NewDepartment(_Department);
            }
        }

        public void checkCost(int Id)
        {
            CostCenter _CostCenter = new CostCenter();
            CostCenterRepository _CostCenterRepository = new CostCenterRepository();
            LocationRepository _LocationRepository = new LocationRepository();
            KostenstellenRepository _KostenstellenRepository = new KostenstellenRepository();

            var k = _KostenstellenRepository.GetCostCentresById(Id);
            var c = _CostCenterRepository.GetCostCenterByNr(Id);

            if (c == null)
            {

                _CostCenter.CostCenter_Nr = Convert.ToInt64(k.Kos_Nr);
                _CostCenter.Name = k.Kos_Bezeichnung;
                _CostCenter.LocationId = _LocationRepository.GetLocationByNr(1).ID;
                _CostCenterRepository.NewCostCenters(_CostCenter);
            }
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<PersonnelDto> GetAllActivePersonnel()
        {
            var personnel = _PersonnelRepository.GetAllPersonnel().Where(p => p.Active).ToList();
            if (personnel.Count == 0) return null;
            List<PersonnelDto> personnelList = new List<PersonnelDto>();
            PersonnelDto personnelObj = new PersonnelDto()
            {
                ID = 0,
                FirstName = Resources.LocalizedText.nothing,
                LastName = "",
                Pers_Nr = 0,
            };
            personnelList.Add(personnelObj);
            personnelList.AddRange(CreateDto(personnel));
            return personnelList;
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
                personnelDto.ClientID = pers_Client.ClientID;
                //Locations
                personnelDto.LocationID = int.Parse(pers_Location.LocationID.ToString());
                //Departments
                personnelDto.DepartmentID = int.Parse(pers_Departments.DepartmentID.ToString());
                //CostCentres
                personnelDto.CostCenterID = int.Parse(pers_CostCenters.CostCenterID.ToString());

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return personnelDto;
        }


        #endregion
    }
}