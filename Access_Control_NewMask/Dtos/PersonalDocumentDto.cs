using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonalDocumentDto
    {
        public PersonalDocumentDto()
        {
            this.PersonalNumber = 0;
        }
        public long PersonalNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Nationality { get; set; }
        public DateTime DateofBirth { get; set; }


        public string DateOfBirthFormated
        {
            get
            {
                return DateofBirth != null ? Convert.ToDateTime(DateofBirth).ToString("dd-MM-yyyy") : null; ;
            }
        }

        public string PlaceOfBirth { get; set; }
        public string IDCreatedIn { get; set; }
        public string IDNumber { get; set; }
        public string IDAdditionalNumber { get; set; }
        public DateTime? IDDateOfIssue { get; set; }

        public string IDDateOfIssuestr
        {
            get
            {
                return IDDateOfIssue != null ? Convert.ToDateTime(IDDateOfIssue).ToString("dd-MM-yyyy") : null; ;
            }
        }

        public DateTime? IDExpiryDate { get; set; }
        public string IDAddress { get; set; }
        public string IDIssuingAuthority { get; set; }
        public string IDMemo { get; set; }

        public string PPCreatedIn { get; set; }
        public string PPNumber { get; set; }
        public string PPGender { get; set; }
        public DateTime? PPDateOfIssue { get; set; }

        public string PPDateOfIssuestr
        {
            get
            {
                return PPDateOfIssue != null ? Convert.ToDateTime(PPDateOfIssue).ToString("dd-MM-yyyy") : null; ;
            }
        }

        public DateTime? PPExpiryDate { get; set; }
        public string PPIssuingAuthority { get; set; }
        public string PPMemo { get; set; }

        public string DLCreatedIn { get; set; }
        public string DLNumber { get; set; }
        public DateTime? DLDateOfIssue { get; set; }

        public string DLDateOfIssuestr
        {
            get
            {
                return DLDateOfIssue != null ? Convert.ToDateTime(DLDateOfIssue).ToString("dd-MM-yyyy") : null; ;
            }
        }

        public string DLClass { get; set; }
        public string DLIssuingAuthority { get; set; }
        public string DLMemo { get; set; }

        public string HCBoxNumber { get; set; }
        public string HCCreatedIn { get; set; }
        public string HCItemNumber { get; set; }
        public string HCSecurityNumber { get; set; }
        public string HCCardNumber { get; set; }
        public DateTime? HCExpiryDate { get; set; }
        public string HCMemo { get; set; }

        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string PlaceofBirth { get; set; }
    }
}