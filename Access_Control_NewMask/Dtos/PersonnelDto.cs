using Access_Control_NewMask.Controllers;
using KruAll.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonnelDto
    {
        #region Constructor
        public PersonnelDto() { }

        #endregion

        #region Properties

        //The following properties are specific to an employee and are in Employee Table
        public long ID { get; set; }
        public int? LocationID { get; set; }
        public int? DepartmentID { get; set; }
        public Nullable<int> CostCenterID { get; set; }
        public long PersNr { get; set; }
        [Required(ErrorMessage = "Employee Number is required!")]
        public string PersonnelNr_string { get; set; }
        public long? PersType { get; set; }
        [Required(ErrorMessage = "Employee Pin-Code is required!")]
        public string PinCode { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Employee Status is required!")]
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? AccessStartDate { get; set; }
        public DateTime? AccessEndDate { get; set; }

        [Required(ErrorMessage = "Employee First Name is required!")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required!")]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string IdPassportNo { get; set; }
        public long? IdentificationNr { get; set; }
        public string IdentificationNr_string { get; set; }
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Employee Gender is required!")]
        public string Gender { get; set; }
        public string Nationality { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public long AccessPlanNo { get; set; } // Maps to TbAccessPlanPersMapping
        public string AccessPlanDescription { get; set; } //Maps to AccessPlanDescription
                                                          // public int? PINCode { get; set; }
        public int? Menace { get; set; }
        public int? ActiveStatus { get; set; }
        public bool? IdentificationActive { get; set; }
        public bool? PincodeActive { get; set; }
        public bool? OnlyIdentificationActive { get; set; }
        public bool? MenaceActive { get; set; }
        public bool Imported { get; set; }
        public int? VehicleType { get; set; }


        //The following properties Map to the fields in Person Type Table
        public string Memo { get; set; }

        //The following properties Map to the fields in Additional Info Table
        public string PhysicalAddress { get; set; }
        public string Street { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Position { get; set; }
        public string Profession { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleReg { get; set; }
        public string CompanyName { get; set; }

        public string companyNumber { get; set; }
        public string companyID { get; set; }


        //The following properties Map to the fields in Contacts Info Table
        public string CompanyMobile { get; set; }
        public string CompanyTel { get; set; }
        public string PrivateTel { get; set; }
        public string PrivateMobile { get; set; }
        public string CompanyEmail { get; set; }
        public string PrivateEmail { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string CompanyFax { get; set; }
        public string PrivateFax { get; set; }
        public int ContactID { get; set; }


        //The following properties Map to the fields in locations Table
        public int LocationNumber { get; set; }
        public string LocationName { get; set; }
        //The following properties Map to the fields in departments Table
        public int DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }

        //The following properties Map to the fields in costcenter Table

        public Nullable<int> CostCenterNumber { get; set; }
        public string CostCenterName { get; set; }
        public long PersonnelNr { get; set; }


        public string Fullname
        {
            get { return string.Format("{0},{1}", FirstName, LastName); }
        }
        public string PersNr_Fullname
        {
            get { return string.Format("{0}{1}{2} {3}", PersNr, '-', FirstName, LastName); }
        }
        public  Nullable<bool> Active { get; set; }
        public long Pers_Nr { get; set; }
        public bool CardActive { get; set; }





        public string Name { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public long? Card_Nr { get; set; }
        public string Card_NrStr { get { return Card_Nr == null ? Resources.LocalizedText.nothing : Card_Nr.ToString(); } }
        public long? Card_Nr1 { get; set; }
        public string Card_NrStr1 { get { return Card_Nr1 == null ? Resources.LocalizedText.nothing : Card_Nr1.ToString(); } }
        public long? Card_Nr2 { get; set; }
        public string Card_NrStr2 { get { return Card_Nr2 == null ? Resources.LocalizedText.nothing : Card_Nr2.ToString(); } }

        public int? ActiveCardType { get; set; }
        public string EntryDateStr { get { return EntryDate != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", EntryDate) : null; } }
        public string ExitDateStr { get { return ExitDate != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", ExitDate) : null; } }
        public string StreetNr { get; set; }
        public String DOBStr { get { return DOB != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DOB) : null; } }
        public string EmployedAs { get; set; }
        public long ClientID { get; set; }
        public long AccessPlanID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Passport_Nr { get; set; }
        public string PassPhoto { get; set; }
        
        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string Salutation { get; set; }
        public string Additonal { get; set; }
        public string Bankname { get; set; }
        public string AccountOwner { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string DriversLicense { get; set; }
        public Nullable<System.DateTime> Since { get; set; }
        public string Children { get; set; }
        public string TaxOfficee { get; set; }
        public string TaxClass { get; set; }
        public string HealthInsuarance { get; set; }
        public string HealInsuaranceNo { get; set; }
        public string PensionInsuarance { get; set; }
        public string SozVerzNo { get; set; }
        public string Contract { get; set; }
        public Nullable<System.DateTime> EmployedFrom { get; set; }
        public string LearnedOccupation { get; set; }
        public string EmploymentType { get; set; }
        public string ResidencePermit { get; set; }
        public string AuthorisedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string NoOfHours { get; set; }
        public Nullable<System.DateTime> EndOfContract { get; set; }
        public Nullable<System.DateTime> EliminatedOn { get; set; }
        public string Reason { get; set; }
        public string CertificateOfEmployment { get; set; }
        public System.DateTime ArchivedDate { get; set; }
        public long ArchivedBy { get; set; }
        public virtual Client Client { get; set; }
        public virtual CostCenter CostCenter { get; set; }
        public virtual Department Department { get; set; }
        public string CreatedIn { get; set; }
        public string DLNumber { get; set; }
        public Nullable<System.DateTime> DateOfIssue { get; set; }
        public string DLClass { get; set; }
        public string IssuingAuthority { get; set; }
        public Nullable<int> FieldIndex { get; set; }
        public string FieldValue { get; set; }
        public string BoxNumber { get; set; }
        public string ItemNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public string IDNumber { get; set; }
        public string AdditionalNumber { get; set; }
        public string Address { get; set; }
        public string PPNumber { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Pers_Passport { get; set; }
        //public string PinCode
        //{
        //    get
        //    {
        //        return GetPinCode(PincodeStr ?? "").ToString();
        //    }
        //    set
        //    {
        //    }
        //}
        public string PinCode1 { get; set; }
        private string PincodeStr;
        public Nullable<int> PinCodeType { get; set; }
        public Nullable<bool> PinCodeStatus { get; set; }
        public long TransponderNr { get; set; }
        public Nullable<bool> TransponderStatus { get; set; }
        public Nullable<System.DateTime> ValidFrom { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<System.DateTime> TransponderDeactivatedOn { get; set; }
        public Nullable<int> Action { get; set; }
        public Nullable<int> TransponderType { get; set; }
        public Nullable<System.DateTime> ExtendedTo { get; set; }
        public string PersTypeColor { get; set; }
        public Nullable<long> VehicleID { get; set; }
        public long VisitorID { get; set; }
        public virtual ICollection<PersonnelTariff> PersonnelTariffs { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
        private long? GetPinCode(string PincodeStr)
        {
            string decryptedPinCode = new EncryptionCtl().Decrypt(PincodeStr);
            long pinCode = 0;
            Int64.TryParse(decryptedPinCode, out pinCode);
            return pinCode > 0 && pinCode > 999 && pinCode < 10000 ? pinCode : new long?();
        }
        public DateTime? DateOfEntry { get; set; }
        public string DateOfEntryStr
        {
            get
            {
                return DateOfEntry != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DateOfEntry) : null; ;
            }
        }
        public DateTime? DateOfExit { get; set; }
        public string DateOfExitStr
        {
            get
            {
                return DateOfExit != null ? String.Format("{0:yyyy-MM-ddT00:00:00.0000Z}", DateOfExit) : null; ;
            }
        }


        #endregion
    }
}