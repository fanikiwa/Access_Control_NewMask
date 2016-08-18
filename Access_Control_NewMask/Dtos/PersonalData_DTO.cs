using Access_Control_NewMask.Controllers;
using System;

namespace Access_Control_NewMask.Dtos
{
    public class PersonalData_DTO
    {

        //    pExists.PersType = personnelType != 0 ? personnelType : (long?)null;
        //    pExists.Active = true;
        //    pExists.Memo = txtMemo.Text;
        //    pExists.Imported = chkImported.Checked;
        //    pExists.CardActive = chkIdentificationActive.Checked;
        //    PersClientRepository _PersClientRepository = new PersClientRepository();
        public long Pers_Nr { get; set; }
        public string MiddleName { get; set; }
        public Nullable<long> Card_Nr { get; set; }
        public string Card_Nr_Str
        {
            get
            {
                return Card_Nr == null ? "keine" : Card_Nr.ToString();
            }
        }
        public bool IdentificationActive { get; set; }
        public bool CardActive { get; set; }
        public System.DateTime? EntryDate { get; set; }
        public string EntryDateStr
        {
            get
            {
                return EntryDate != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", EntryDate) : null; ;
            }
        }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public string ExitDateStr
        {
            get
            {
                return ExitDate != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", ExitDate) : null;
            }
        }
        public Nullable<long> PersType { get; set; }

        //personType Name
        public string Name { get; set; }

        public bool Active { get; set; }
        public string Memo { get; set; }
        public Nullable<bool> Imported { get; set; }
        public Nullable<long> PinCode { get; set; }
        public Nullable<int> PinCodeType { get; set; }
        public Nullable<bool> PinCodeStatus { get; set; }
        //public Nullable<int> PinCodePassType { get; set; }
        public long? CarType { get; set; }
        public string CarRegnumber { get; set; }
        public string Position { get; set; }
        public long? AusweisPincode
        {
            get
            {
                return GetPinCode(AusweisPincodeStr ?? "");
            }
            set { }
        }
        private string ausweisPincodeStr;
        public string AusweisPincodeStr
        {
            get
            {
                return ausweisPincodeStr;
            }
            set
            {
                ausweisPincodeStr = value;
            }
        }
        public long? selectlocation { get; set; }

        public bool PincodeActives { get; set; }

        public long? NurPincode
        {
            get
            {
                return GetPinCode(NurPincodeStr ?? "");
            }
            set { }
        }

        private string nurPincodeStr;
        public string NurPincodeStr
        {
            get
            {
                return nurPincodeStr;
            }
            set
            {
                nurPincodeStr = value;
            }
        }
        public bool NurPincodeActive { get; set; }
        public long? SicherheitsPincode
        {
            get
            {
                return GetPinCode(SicherheitsPincodeStr ?? "");
            }
            set { }
        }

        private string sicherheitsPincode;
        public string SicherheitsPincodeStr
        {
            get
            {
                return sicherheitsPincode;
            }
            set
            {
                sicherheitsPincode = value;
            }
        }
        public bool MenaceActive { get; set; }








        public string companyName { get; set; }
        public string Idnumber { get; set; }
        public string companyNumber { get; set; }
        public string companyID { get; set; }

        public long ID { get; set; }
        public string AusweisNr { get; set; }

        public long PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public long? CardNumber1 { get; set; }
        public long CardNumber2 { get; set; }

        public long? CardNumber1a { get; set; }
        public long? CardNumber2a { get; set; }
        public string PinPassword { get; set; }
        public long? ClientID { get; set; }
        public long? LocationID { get; set; }
        public long? DepartmentID { get; set; }
        public long? _DepartmentID { get; set; }
        public long? CostCenterID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public string DateOfEntryStr
        {
            get
            {
                return DateOfEntry != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DateOfEntry) : null; ;
            }
        }
        public string AccessEntryDate
        {
            get
            {
                return DateOfEntry != null ? Convert.ToDateTime(DateOfEntry).ToString("dd-MM-yyyy") : null; ;
            }
        }
        public DateTime? AccessPlanDateFrom { get; set; }
        public DateTime? AccessPlanDateTo { get; set; }
        public DateTime? DateOfExit { get; set; }
        public string DateOfExitStr
        {
            get
            {
                return DateOfExit != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DateOfExit) : null; ;
            }
        }

        public string ExitAccessDate
        {
            get
            {
                return DateOfExit != null ? Convert.ToDateTime(DateOfExit).ToString("dd-MM-yyyy") : null; ;
            }
        }
        public string EmploymentPosition { get; set; }
        public string Qualification { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyMobile { get; set; }
        public string PrivatePhone { get; set; }
        public string PrivateMobile { get; set; }
        public string Fax { get; set; }
        public string CompanyEmail { get; set; }
        public string ZuttritsplanNr { get; set; }
        public string PrivateEmail { get; set; }
        public string CompTel { get; set; }
        public string PrivMobile { get; set; }
        public string PrivTel { get; set; }
        public string CompMobile { get; set; }

        public string Documents { get; set; }
        public string PersonalMemo { get; set; }
        public string AutomaticLogout { get; set; }

        public string PassPhoto { get; set; }
        public string PersonPhotoInBinary { get; set; }
        public long TarrifId { get; set; }

        public string BankCode { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Location { get; set; }
        public string PalceOfBirth { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string _PostalCode { get; set; }


        public string Children { get; set; }

        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public DateTime? DOB { get; set; }
        public String DOBStr
        {
            get
            {
                return DOB != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DOB) : null; ;
            }
        }

        public string Additonal { get; set; }
        public string Bankname { get; set; }
        public string AccountOwner { get; set; }
        public string MaritalStatus { get; set; }
        public string AccountNo { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string DriversLicense { get; set; }
        public DateTime? Since { get; set; }
        public string TaxOfficee { get; set; }
        public string TaxClass { get; set; }
        public string HealthInsuarance { get; set; }
        public string HealthInsuaranceNo { get; set; }
        public string PensionInsuarance { get; set; }
        public string SozVerzNo { get; set; }
        public string Contract { get; set; }
        public DateTime? EmployedFrom { get; set; }
        public string EmployedAs { get; set; }
        public string LearnedOccupation { get; set; }
        public string EmploymentType { get; set; }
        public string ResidencePermit { get; set; }
        public string AuthorisedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string NoOfHours { get; set; }
        public DateTime? EndOfContract { get; set; }
        public DateTime? EliminatedOn { get; set; }
        public string Reason { get; set; }
        public string CertificateOfEmployment { get; set; }
        public long AccessPlanNr { get; set; }
        public string AccessPlanDescription { get; set; }
        public int ActiveCardType { get; set; }

        public long clientNr { get; set; }

        public string ClientName { get; set; }

        private long? GetPinCode(string PincodeStr)
        {
            string decryptedPinCode = new EncryptionCtl().Decrypt(PincodeStr);
            long pinCode = 0;
            Int64.TryParse(decryptedPinCode, out pinCode);
            return pinCode > 0 && pinCode > 999 && pinCode < 10000 ? pinCode : new long?();
        }
    }
}