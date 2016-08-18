using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class PersonalDocumentsViewModel
    {
        public PersonalDocumentDto GetPersonalDocumentData(long personalNumber)
        {
            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            PersonalDocumentRepository _personalDocsRepository = new PersonalDocumentRepository();


            var persData = _VwPersonnelDataRepository.GetAllPersonnel().Distinct().Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (persData == null)
            {
                return personalDocumentsDTO;
            }

            personalDocumentsDTO.PersonalNumber = personalNumber;
            personalDocumentsDTO.Name = persData.LastName;
            personalDocumentsDTO.FirstName = persData.FirstName;
            personalDocumentsDTO.DateofBirth = Convert.ToDateTime(persData.DOB);
            personalDocumentsDTO.Nationality = persData.Nationality;
            personalDocumentsDTO.PlaceOfBirth = persData.PlaceOfBirth;

            var identityCard = _personalDocsRepository.GetPersonalIdentityCard(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.IDCreatedIn = identityCard.CreatedIn;
            personalDocumentsDTO.IDNumber = identityCard.IDNumber;
            personalDocumentsDTO.IDAdditionalNumber = identityCard.AdditionalNumber;
            personalDocumentsDTO.IDDateOfIssue = Convert.ToDateTime(identityCard.DateOfIssue);
            personalDocumentsDTO.IDExpiryDate = Convert.ToDateTime(identityCard.ExpiryDate);
            personalDocumentsDTO.IDAddress = identityCard.Address;
            personalDocumentsDTO.IDIssuingAuthority = identityCard.IssuingAuthority;
            personalDocumentsDTO.IDMemo = identityCard.Memo;

            var passport = _personalDocsRepository.GetPersonalPassport(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.PPCreatedIn = passport.CreatedIn;
            personalDocumentsDTO.PPNumber = passport.PPNumber;
            personalDocumentsDTO.PPGender = passport.Gender;
            personalDocumentsDTO.PPDateOfIssue = Convert.ToDateTime(passport.DateOfIssue);
            personalDocumentsDTO.PPExpiryDate = Convert.ToDateTime(passport.ExpiryDate);
            personalDocumentsDTO.PPIssuingAuthority = passport.IssuingAuthority;
            personalDocumentsDTO.PPMemo = passport.Memo;

            var drivingLicense = _personalDocsRepository.GetPersonalDrivingLicense(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.DLCreatedIn = drivingLicense.CreatedIn;
            personalDocumentsDTO.DLNumber = drivingLicense.DLNumber;
            personalDocumentsDTO.DLDateOfIssue = Convert.ToDateTime(drivingLicense.DateOfIssue);
            personalDocumentsDTO.DLClass = drivingLicense.DLClass;
            personalDocumentsDTO.DLIssuingAuthority = drivingLicense.IssuingAuthority;
            personalDocumentsDTO.DLMemo = drivingLicense.Memo;

            var healthCard = _personalDocsRepository.GetPersonalHealthInsurance(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.HCBoxNumber = healthCard.BoxNumber;
            personalDocumentsDTO.HCCreatedIn = healthCard.CreatedIn;
            personalDocumentsDTO.HCItemNumber = healthCard.ItemNumber;
            personalDocumentsDTO.HCSecurityNumber = healthCard.SecurityNumber;
            personalDocumentsDTO.HCCardNumber = healthCard.CardNumber;
            personalDocumentsDTO.HCExpiryDate = Convert.ToDateTime(healthCard.ExpiryDate);
            personalDocumentsDTO.HCMemo = healthCard.Memo;

            Pers_AdditionalInfo personalAdditionalinfo = _personalDocsRepository.GetPersonalPersonalEyeColorAndHeight(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.Height = personalAdditionalinfo.Height;
            personalDocumentsDTO.EyeColor = personalAdditionalinfo.EyeColor;
            personalDocumentsDTO.PlaceOfBirth = personalAdditionalinfo.PlaceOfBirth;

            return personalDocumentsDTO;
        }

        public PersonalDocumentDto GetPersonalDocumentInactiveData(long personalNumber)
        {
            PersonalDocumentDto personalDocumentsDTO = new PersonalDocumentDto();
            VwPersonnelDataRepository _VwPersonnelDataRepository = new VwPersonnelDataRepository();
            PersonalDocumentRepository _personalDocsRepository = new PersonalDocumentRepository();


            var persData = _VwPersonnelDataRepository.GetAllInactivePersonnel().Distinct().Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (persData == null)
            {
                return personalDocumentsDTO;
            }

            personalDocumentsDTO.PersonalNumber = personalNumber;
            personalDocumentsDTO.Name = persData.LastName;
            personalDocumentsDTO.FirstName = persData.FirstName;
            personalDocumentsDTO.DateofBirth = Convert.ToDateTime(persData.DOB);
            personalDocumentsDTO.Nationality = persData.Nationality;
            personalDocumentsDTO.PlaceOfBirth = persData.PlaceOfBirth;

            var identityCard = _personalDocsRepository.GetPersonalIdentityCard(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.IDCreatedIn = identityCard.CreatedIn;
            personalDocumentsDTO.IDNumber = identityCard.IDNumber;
            personalDocumentsDTO.IDAdditionalNumber = identityCard.AdditionalNumber;
            personalDocumentsDTO.IDDateOfIssue = Convert.ToDateTime(identityCard.DateOfIssue);
            personalDocumentsDTO.IDExpiryDate = Convert.ToDateTime(identityCard.ExpiryDate);
            personalDocumentsDTO.IDAddress = identityCard.Address;
            personalDocumentsDTO.IDIssuingAuthority = identityCard.IssuingAuthority;
            personalDocumentsDTO.IDMemo = identityCard.Memo;

            var passport = _personalDocsRepository.GetPersonalPassport(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.PPCreatedIn = passport.CreatedIn;
            personalDocumentsDTO.PPNumber = passport.PPNumber;
            personalDocumentsDTO.PPGender = passport.Gender;
            personalDocumentsDTO.PPDateOfIssue = Convert.ToDateTime(passport.DateOfIssue);
            personalDocumentsDTO.PPExpiryDate = Convert.ToDateTime(passport.ExpiryDate);
            personalDocumentsDTO.PPIssuingAuthority = passport.IssuingAuthority;
            personalDocumentsDTO.PPMemo = passport.Memo;

            var drivingLicense = _personalDocsRepository.GetPersonalDrivingLicense(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.DLCreatedIn = drivingLicense.CreatedIn;
            personalDocumentsDTO.DLNumber = drivingLicense.DLNumber;
            personalDocumentsDTO.DLDateOfIssue = Convert.ToDateTime(drivingLicense.DateOfIssue);
            personalDocumentsDTO.DLClass = drivingLicense.DLClass;
            personalDocumentsDTO.DLIssuingAuthority = drivingLicense.IssuingAuthority;
            personalDocumentsDTO.DLMemo = drivingLicense.Memo;

            var healthCard = _personalDocsRepository.GetPersonalHealthInsurance(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.HCBoxNumber = healthCard.BoxNumber;
            personalDocumentsDTO.HCCreatedIn = healthCard.CreatedIn;
            personalDocumentsDTO.HCItemNumber = healthCard.ItemNumber;
            personalDocumentsDTO.HCSecurityNumber = healthCard.SecurityNumber;
            personalDocumentsDTO.HCCardNumber = healthCard.CardNumber;
            personalDocumentsDTO.HCExpiryDate = Convert.ToDateTime(healthCard.ExpiryDate);
            personalDocumentsDTO.HCMemo = healthCard.Memo;

            Pers_AdditionalInfo personalAdditionalinfo = _personalDocsRepository.GetPersonalPersonalEyeColorAndHeight(personalDocumentsDTO.PersonalNumber);
            personalDocumentsDTO.Height = personalAdditionalinfo.Height;
            personalDocumentsDTO.EyeColor = personalAdditionalinfo.EyeColor;
            personalDocumentsDTO.PlaceOfBirth = personalAdditionalinfo.PlaceOfBirth;

            return personalDocumentsDTO;
        }

        public void UpdatePersonalDocumentData(PersonalDocumentDto personalDocumentsDTO)
        {
            PersonalDocumentRepository _personalDocsRepository = new PersonalDocumentRepository();

            Pers_IdentityCard identityCard = new Pers_IdentityCard();
            identityCard.Pers_Nr = personalDocumentsDTO.PersonalNumber;
            identityCard.CreatedIn = personalDocumentsDTO.IDCreatedIn;
            identityCard.IDNumber = personalDocumentsDTO.IDNumber;
            identityCard.AdditionalNumber = personalDocumentsDTO.IDAdditionalNumber;
            identityCard.DateOfIssue = personalDocumentsDTO.IDDateOfIssue;
            identityCard.ExpiryDate = personalDocumentsDTO.IDExpiryDate;
            identityCard.Address = personalDocumentsDTO.IDAddress;
            identityCard.IssuingAuthority = personalDocumentsDTO.IDIssuingAuthority;
            identityCard.Memo = personalDocumentsDTO.IDMemo;
            _personalDocsRepository.UpdatePersonalIdentityCard(identityCard);

            Pers_Passport passport = new Pers_Passport();
            passport.Pers_Nr = personalDocumentsDTO.PersonalNumber;
            passport.CreatedIn = personalDocumentsDTO.PPCreatedIn;
            passport.PPNumber = personalDocumentsDTO.PPNumber;
            passport.Gender = personalDocumentsDTO.PPGender;
            passport.DateOfIssue = personalDocumentsDTO.PPDateOfIssue;
            passport.ExpiryDate = personalDocumentsDTO.PPExpiryDate;
            passport.IssuingAuthority = personalDocumentsDTO.PPIssuingAuthority;
            passport.Memo = personalDocumentsDTO.PPMemo;
            _personalDocsRepository.UpdatePersonalPassport(passport);

            Pers_DrivingLicense drivingLicense = new Pers_DrivingLicense();
            drivingLicense.Pers_Nr = personalDocumentsDTO.PersonalNumber;
            drivingLicense.CreatedIn = personalDocumentsDTO.DLCreatedIn;
            drivingLicense.DLNumber = personalDocumentsDTO.DLNumber;
            drivingLicense.DateOfIssue = personalDocumentsDTO.DLDateOfIssue;
            drivingLicense.DLClass = personalDocumentsDTO.DLClass;
            drivingLicense.IssuingAuthority = personalDocumentsDTO.DLIssuingAuthority;
            drivingLicense.Memo = personalDocumentsDTO.DLMemo;
            _personalDocsRepository.UpdatePersonalDrivingLicense(drivingLicense);

            Pers_HealthCard healthCard = new Pers_HealthCard();
            healthCard.Pers_Nr = personalDocumentsDTO.PersonalNumber;
            healthCard.BoxNumber = personalDocumentsDTO.HCBoxNumber;
            healthCard.CreatedIn = personalDocumentsDTO.HCCreatedIn;
            healthCard.ItemNumber = personalDocumentsDTO.HCItemNumber;
            healthCard.SecurityNumber = personalDocumentsDTO.HCSecurityNumber;
            healthCard.CardNumber = personalDocumentsDTO.HCCardNumber;
            healthCard.ExpiryDate = personalDocumentsDTO.HCExpiryDate;
            healthCard.Memo = personalDocumentsDTO.HCMemo;
            _personalDocsRepository.UpdatePersonalHealthInsurance(healthCard);

            Pers_AdditionalInfo personalAdditionalinfo = new Pers_AdditionalInfo();
            personalAdditionalinfo.Pers_Nr = personalDocumentsDTO.PersonalNumber;
            personalAdditionalinfo.Height = personalDocumentsDTO.Height;
            personalAdditionalinfo.DOB = personalDocumentsDTO.DateofBirth;
            personalAdditionalinfo.Nationality = personalDocumentsDTO.Nationality;
            personalAdditionalinfo.EyeColor = personalDocumentsDTO.EyeColor;
            personalAdditionalinfo.PlaceOfBirth = personalDocumentsDTO.PlaceOfBirth;
            _personalDocsRepository.UpdatePersonalEyeColorAndHeight(personalAdditionalinfo);
        }
    }
}