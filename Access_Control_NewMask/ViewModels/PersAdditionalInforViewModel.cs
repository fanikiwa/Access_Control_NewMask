using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class PersAdditionalInforViewModel
    {


        #region Methods

        public void InsertPersAdditionalInfor(PersonalData_DTO _PersonalData_DTO)
        {
            bool IsNewpers = false;

            PersonnelRepository _PersonnelRepository = new PersonnelRepository();
            var pers = _PersonnelRepository.GetPersonnelByPersNumber(_PersonalData_DTO.PersonalNumber);
            if (pers == null)
            { return; }


            PersAdditionalInfoRepository _PersAdditionalInfoRepository = new PersAdditionalInfoRepository();
            var PersAdditionalInfor = _PersAdditionalInfoRepository.GetPersByNr(_PersonalData_DTO.PersonalNumber);
            if (PersAdditionalInfor == null)
            {
                IsNewpers = true;
                PersAdditionalInfor = new Pers_AdditionalInfo();
            }
            Pers_AdditionalInfo _Pers_AdditionalInfo = PersAdditionalInfor;

            _Pers_AdditionalInfo.Pers_Nr = _PersonalData_DTO.PersonalNumber;
            _Pers_AdditionalInfo.PhysicalAddress = _PersonalData_DTO.PhysicalAddress;
            _Pers_AdditionalInfo.Street = _PersonalData_DTO.Street;
            _Pers_AdditionalInfo.PlaceOfBirth = _PersonalData_DTO.PalceOfBirth;
            _Pers_AdditionalInfo.DOB = _PersonalData_DTO.DOB;
            _Pers_AdditionalInfo.Gender = _PersonalData_DTO.Gender;
            _Pers_AdditionalInfo.MaritalStatus = _PersonalData_DTO.MaritalStatus;
            _Pers_AdditionalInfo.Nationality = _PersonalData_DTO.Nationality;
            if ((_PersonalData_DTO.PostalCode ?? "").Trim() != string.Empty) _Pers_AdditionalInfo.PostalCode = _PersonalData_DTO.PostalCode;
            _Pers_AdditionalInfo.Salutation = _PersonalData_DTO.Salutation;
            _Pers_AdditionalInfo.Additonal = _PersonalData_DTO.Additonal;
            _Pers_AdditionalInfo.Bankname = _PersonalData_DTO.Bankname;
            _Pers_AdditionalInfo.AccountOwner = _PersonalData_DTO.AccountOwner;
            _Pers_AdditionalInfo.BankCode = _PersonalData_DTO.BankCode;
            _Pers_AdditionalInfo.AccountNo = _PersonalData_DTO.AccountNo;
            _Pers_AdditionalInfo.BIC = _PersonalData_DTO.BIC;
            _Pers_AdditionalInfo.IBAN = _PersonalData_DTO.IBAN;
            _Pers_AdditionalInfo.DriversLicense = _PersonalData_DTO.DriversLicense;
            _Pers_AdditionalInfo.Since = _PersonalData_DTO.Since;
            _Pers_AdditionalInfo.Children = _PersonalData_DTO.Children;
            _Pers_AdditionalInfo.TaxOfficee = _PersonalData_DTO.TaxOfficee;
            _Pers_AdditionalInfo.TaxClass = _PersonalData_DTO.TaxClass;
            _Pers_AdditionalInfo.HealthInsuarance = _PersonalData_DTO.HealthInsuarance;
            _Pers_AdditionalInfo.HealInsuaranceNo = _PersonalData_DTO.HealthInsuaranceNo;
            _Pers_AdditionalInfo.PensionInsuarance = _PersonalData_DTO.PensionInsuarance;
            _Pers_AdditionalInfo.SozVerzNo = _PersonalData_DTO.SozVerzNo;
            _Pers_AdditionalInfo.Contract = _PersonalData_DTO.Contract;
            _Pers_AdditionalInfo.EmployedFrom = _PersonalData_DTO.EmployedFrom;
            _Pers_AdditionalInfo.LearnedOccupation = _PersonalData_DTO.LearnedOccupation;
            _Pers_AdditionalInfo.EmployedAs = _PersonalData_DTO.EmployedAs;
            _Pers_AdditionalInfo.EmploymentType = _PersonalData_DTO.EmploymentType;
            _Pers_AdditionalInfo.ResidencePermit = _PersonalData_DTO.ResidencePermit;
            _Pers_AdditionalInfo.AuthorisedBy = _PersonalData_DTO.AuthorisedBy;
            _Pers_AdditionalInfo.ApprovedBy = _PersonalData_DTO.ApprovedBy;
            _Pers_AdditionalInfo.NoOfHours = _PersonalData_DTO.NoOfHours;
            _Pers_AdditionalInfo.EndOfContract = _PersonalData_DTO.EndOfContract;
            _Pers_AdditionalInfo.EliminatedOn = _PersonalData_DTO.EliminatedOn;
            _Pers_AdditionalInfo.Reason = _PersonalData_DTO.Reason;
            _Pers_AdditionalInfo.CertificateOfEmployment = _PersonalData_DTO.CertificateOfEmployment;

            if (IsNewpers == true)
            {
                _PersAdditionalInfoRepository.NewPersAddInfo(_Pers_AdditionalInfo);
            }
            else
            {

                _PersAdditionalInfoRepository.UpdatePersAddInfo(PersAdditionalInfor, _Pers_AdditionalInfo);
            }
        }

        protected internal void DeletepersAdditionalInfor(int PersNo)
        {
            if (PersNo != 0)
            {
                PersAdditionalInfoRepository _PersAdditionalInfoRepository = new PersAdditionalInfoRepository();
                var PersAdditionalInfo = _PersAdditionalInfoRepository.GetPersByNr(PersNo);
                if (PersAdditionalInfo != null)
                {
                    _PersAdditionalInfoRepository.DeletePersAddInfo(PersAdditionalInfo);

                }
            }


        }

        public PersonalData_DTO GerPers(string GetType, long ID)
        {
            PersDataRepository _PersDataRepository = new PersDataRepository();
            VwPersonnelData _VwPersonnelData = new VwPersonnelData();
            switch (GetType)
            {
            case "GetPersByID":
                _VwPersonnelData = _PersDataRepository.GetPersDataByID(ID);
                break;
            case "GetPersByNr":
                _VwPersonnelData = _PersDataRepository.GetPersDataByNr(ID);
                break;

            case "GetPersByClientNr":
                _VwPersonnelData = _PersDataRepository.GetPersByClientID(ID);
                break;

            case "GetPersByLocationID":
                _VwPersonnelData = _PersDataRepository.GetPersByLocationID(ID);
                break;

            case "GetPersByDepartmentID":
                _VwPersonnelData = _PersDataRepository.GetPersByDepartmentID(ID);
                break;
            }

            if (_VwPersonnelData != null)
            {
                PersonalData_DTO _PersonalData_DTO = new PersonalData_DTO
                {
                    ID = _VwPersonnelData.ID,
                    CardNumber1 = _VwPersonnelData.Card_Nr,

                    ClientID = _VwPersonnelData.ClientID,
                    LocationID = _VwPersonnelData.LocationID,
                    DepartmentID = _VwPersonnelData.DepartmentID,
                    CostCenterID = _VwPersonnelData.CostCenterID,

                    PersonalNumber = _VwPersonnelData.Pers_Nr,
                    Title = _VwPersonnelData.Title,
                    FirstName = _VwPersonnelData.FirstName,
                    FullName = _VwPersonnelData.FullName,
                    LastName = _VwPersonnelData.LastName,
                    PhysicalAddress = _VwPersonnelData.PhysicalAddress,
                    Street = _VwPersonnelData.Street,
                    PalceOfBirth = _VwPersonnelData.PlaceOfBirth,
                    DOB = _VwPersonnelData.DOB,
                    Gender = _VwPersonnelData.Gender,
                    MaritalStatus = _VwPersonnelData.MaritalStatus,
                    Nationality = _VwPersonnelData.Nationality,
                    PostalCode = _VwPersonnelData.PostalCode,
                    Salutation = _VwPersonnelData.Salutation,
                    Additonal = _VwPersonnelData.Additonal,
                    Bankname = _VwPersonnelData.Bankname,
                    AccountOwner = _VwPersonnelData.AccountOwner,
                    BankCode = _VwPersonnelData.BankCode,
                    AccountNo = _VwPersonnelData.AccountNo,
                    BIC = _VwPersonnelData.BIC,
                    IBAN = _VwPersonnelData.IBAN,
                    DriversLicense = _VwPersonnelData.DriversLicense,
                    Since = _VwPersonnelData.Since,
                    Children = _VwPersonnelData.Children,
                    TaxOfficee = _VwPersonnelData.TaxOfficee,
                    TaxClass = _VwPersonnelData.TaxClass,
                    HealthInsuarance = _VwPersonnelData.HealthInsuarance,
                    HealthInsuaranceNo = _VwPersonnelData.HealInsuaranceNo,
                    PensionInsuarance = _VwPersonnelData.PensionInsuarance,
                    SozVerzNo = _VwPersonnelData.SozVerzNo,
                    Contract = _VwPersonnelData.Contract,
                    EmployedFrom = _VwPersonnelData.EmployedFrom,
                    LearnedOccupation = _VwPersonnelData.LearnedOccupation,
                    EmployedAs = _VwPersonnelData.EmployedAs,
                    EmploymentType = _VwPersonnelData.EmploymentType,
                    ResidencePermit = _VwPersonnelData.ResidencePermit,
                    AuthorisedBy = _VwPersonnelData.AuthorisedBy,
                    ApprovedBy = _VwPersonnelData.ApprovedBy,
                    NoOfHours = _VwPersonnelData.NoOfHours,
                    EndOfContract = _VwPersonnelData.EndOfContract,
                    EliminatedOn = _VwPersonnelData.EliminatedOn,
                    Reason = _VwPersonnelData.Reason,
                    CertificateOfEmployment = _VwPersonnelData.CertificateOfEmployment

                };

                return _PersonalData_DTO;
            }

            else { PersonalData_DTO _personalData_DTO = new PersonalData_DTO(); return _personalData_DTO; }
        }

        #endregion

        internal void InsertPersClients(PersonalData_DTO _PersonalData_DTO)
        {
            if (_PersonalData_DTO.ClientID == 0) { return; }
            if (_PersonalData_DTO.ClientID == -1) { return; }
            if (_PersonalData_DTO.ClientID == null) { return; }

            ClientsRepository _ClientsRepository = new ClientsRepository();
            PersClientRepository _PersClientRepository = new PersClientRepository();
            var Client = _ClientsRepository.GetClientsById(Convert.ToInt32(_PersonalData_DTO.ClientID));
            if (Client != null)
            {
                Pers_Client _Pers_Client = new Pers_Client() { Pers_Nr = _PersonalData_DTO.PersonalNumber, ClientID = Client.Client_Nr };
                var PersClient = _PersClientRepository.GetPersClientByPersNo(Convert.ToInt32(_PersonalData_DTO.PersonalNumber));
                if (PersClient == null)
                {
                    _PersClientRepository.InsertPersClient(_Pers_Client);

                }
                else
                {
                    _PersClientRepository.UpdatePerz(PersClient, _Pers_Client);
                }

            }
        }

        internal void InsertPersLocation(PersonalData_DTO _PersonalData_DTO)
        {
            if (_PersonalData_DTO.LocationID == 0) { return; }
            if (_PersonalData_DTO.LocationID == -1) { return; }
            if (_PersonalData_DTO.LocationID == null) { return; }
            PersLocationRepository _PersLocationRepository = new PersLocationRepository();
            Pers_Locations _Pers_Locations = new Pers_Locations();
            var Location = _PersLocationRepository.GetLocation(Convert.ToInt32(_PersonalData_DTO.LocationID));
            if (Location == null)
            {
                _Pers_Locations.Pers_Nr = _PersonalData_DTO.PersonalNumber;
                _Pers_Locations.LocationID = _PersonalData_DTO.LocationID;
                _PersLocationRepository.NewLocation(_Pers_Locations);
            }
            else
            {
                Location.Pers_Nr = _PersonalData_DTO.PersonalNumber;
                Location.LocationID = _PersonalData_DTO.LocationID;
                _PersLocationRepository.EditLocation(Location);
            }


        }

        internal void InsertDepartment(PersonalData_DTO _PersonalData_DTO)
        {
            if (_PersonalData_DTO.DepartmentID == 0) { return; }
            if (_PersonalData_DTO.DepartmentID == -1) { return; }
            if (_PersonalData_DTO.DepartmentID == null) { return; }
            PersDepartmentRepository _PersDepartmentRepository = new PersDepartmentRepository();
            Pers_Departments _Pers_Departments = new Pers_Departments();
            var persDepartment = _PersDepartmentRepository.GetDepartmentByID(Convert.ToInt32(_PersonalData_DTO.DepartmentID));
            if (persDepartment == null)
            {
                _Pers_Departments.Pers_Nr = _PersonalData_DTO.PersonalNumber;
                _Pers_Departments.DepartmentID = Convert.ToInt32(_PersonalData_DTO.DepartmentID);
                _PersDepartmentRepository.NewDepartment(_Pers_Departments);
            }
            else
            {
                persDepartment.Pers_Nr = _PersonalData_DTO.PersonalNumber;
                persDepartment.DepartmentID = Convert.ToInt32(_PersonalData_DTO.DepartmentID);
                _PersDepartmentRepository.EditDepartment(persDepartment);
            }
        }

        public void UpdatepersonalDynamicFields(List<PersonalDynamicField_DTO> personalDynamicFields)
        {
            DynamicFieldsRepository dynamicFieldRepo = new DynamicFieldsRepository();
            DynamicField dynamicField = null;
            Pers_DynamicFields persDynamicField = null;

            foreach (PersonalDynamicField_DTO personalDynamicField in personalDynamicFields)
            {
                dynamicField = new DynamicField();
                dynamicField.FieldIndex = personalDynamicField.FieldIndex;
                dynamicField.FieldText = personalDynamicField.FieldText;
                dynamicFieldRepo.UpdateDynamicField(dynamicField);

                persDynamicField = new Pers_DynamicFields();
                persDynamicField.FieldIndex = personalDynamicField.FieldIndex;
                persDynamicField.Pers_Nr = personalDynamicField.PersonalNumber;
                persDynamicField.FieldValue = personalDynamicField.FieldValue;
                dynamicFieldRepo.UpdatepersonalDynamicField(persDynamicField);
            }
        }

        public List<PersonalDynamicField_DTO> GetPersonalDynamicFields(long personalNumber)
        {
            List<PersonalDynamicField_DTO> personalDynamicFields = new List<PersonalDynamicField_DTO>();
            PersonalDynamicField_DTO personalDynamicField = null;
            DynamicFieldsRepository dynamicFieldRepo = new DynamicFieldsRepository();

            var persDynamicFields = dynamicFieldRepo.PersonalDynamicFields(personalNumber);


            if (persDynamicFields.Count == 0)
            {
                var dynamicFields = dynamicFieldRepo.GetDynamicFields().ToList();

                foreach (DynamicField dynamicField in dynamicFields)
                {
                    personalDynamicField = new PersonalDynamicField_DTO();
                    personalDynamicField.FieldIndex = Convert.ToInt32(dynamicField.FieldIndex);
                    personalDynamicField.PersonalNumber = personalNumber;
                    personalDynamicField.FieldValue = "";
                    personalDynamicField.FieldText = dynamicField.FieldText;
                    personalDynamicFields.Add(personalDynamicField);
                }
            }
            foreach (var perDynamicField in persDynamicFields)
            {
                personalDynamicField = new PersonalDynamicField_DTO();
                personalDynamicField.FieldIndex = Convert.ToInt32(perDynamicField.FieldIndex);
                personalDynamicField.PersonalNumber = Convert.ToInt64(perDynamicField.Pers_Nr);
                personalDynamicField.FieldValue = perDynamicField.FieldValue;

                var dynamicField = dynamicFieldRepo.GetDynamicFields().Where(x => x.FieldIndex == personalDynamicField.FieldIndex).FirstOrDefault();

                if (dynamicField != null)
                {
                    personalDynamicField.FieldText = dynamicField.FieldText;
                }

                personalDynamicFields.Add(personalDynamicField);
            }


            return personalDynamicFields;
        }
    }
}