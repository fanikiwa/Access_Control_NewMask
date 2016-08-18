using KruAll.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class PersonalDocumentRepository
    {
        PZE_Entities databaseConnection = null;
        public PersonalDocumentRepository()
        {
            databaseConnection = new PZE_Entities();
        }
        public void UpdatePersonalIdentityCard(Pers_IdentityCard personalID)
        {
            var existingID = databaseConnection.Pers_IdentityCard.Where(x => x.Pers_Nr == personalID.Pers_Nr).FirstOrDefault();

            if (existingID != null)
            {
                databaseConnection.Pers_IdentityCard.Remove(existingID);
                databaseConnection.SaveChanges();
            } 
                databaseConnection.Pers_IdentityCard.Add(personalID);
                databaseConnection.SaveChanges();
            
        }

        public void DeleteIdentityCard(Pers_IdentityCard personalID)
        {
            var existingID = databaseConnection.Pers_IdentityCard.Where(x => x.Pers_Nr == personalID.Pers_Nr).FirstOrDefault();
            if (existingID != null)
            {
                databaseConnection.Pers_IdentityCard.Remove(existingID);
                databaseConnection.SaveChanges();
            }
            else
            {
                return;
            }
        }

        public Pers_IdentityCard GetPersonalIdentityCard(long personalNumber)
        {
            Pers_IdentityCard personalID = databaseConnection.Pers_IdentityCard.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (personalID == null)
            {
                personalID = new Pers_IdentityCard();
            }

            return personalID;
        }

        public void UpdatePersonalPassport(Pers_Passport personalPP)
        {
            var existingPP = databaseConnection.Pers_Passport.Where(x => x.Pers_Nr == personalPP.Pers_Nr).FirstOrDefault();

            if (existingPP != null)
            {
                databaseConnection.Pers_Passport.Remove(existingPP);
                databaseConnection.SaveChanges();
            }

            databaseConnection.Pers_Passport.Add(personalPP);
            databaseConnection.SaveChanges();

        }
        public void DeletePersonalPassport(Pers_Passport personalPP)
        {
            var existingPP = databaseConnection.Pers_Passport.Where(x => x.Pers_Nr == personalPP.Pers_Nr).FirstOrDefault();

            if (existingPP != null)
            {
                databaseConnection.Pers_Passport.Remove(existingPP);
                databaseConnection.SaveChanges();
            }
            else
            {
                return;
            } 
        }
        public Pers_Passport GetPersonalPassport(long personalNumber)
        {
            Pers_Passport personalPP = databaseConnection.Pers_Passport.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (personalPP == null)
            {
                personalPP = new Pers_Passport();
            }

            return personalPP;
        }

        public void UpdatePersonalDrivingLicense(Pers_DrivingLicense personalDL)
        {
            var existingDL = databaseConnection.Pers_DrivingLicense.Where(x => x.Pers_Nr == personalDL.Pers_Nr).FirstOrDefault();

            if (existingDL != null)
            {
                databaseConnection.Pers_DrivingLicense.Remove(existingDL);
                databaseConnection.SaveChanges();
            }

            databaseConnection.Pers_DrivingLicense.Add(personalDL);
            databaseConnection.SaveChanges();

        }
        public void DeleteDrivingLicense(Pers_DrivingLicense personalDL)
        {
            var existingDL = databaseConnection.Pers_DrivingLicense.Where(x => x.Pers_Nr == personalDL.Pers_Nr).FirstOrDefault();

            if (existingDL != null)
            {
                databaseConnection.Pers_DrivingLicense.Remove(existingDL);
                databaseConnection.SaveChanges();
            }
            else
            {
                return;
            } 

        }
        public Pers_DrivingLicense GetPersonalDrivingLicense(long personalNumber)
        {
            Pers_DrivingLicense personalDL = databaseConnection.Pers_DrivingLicense.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (personalDL == null)
            {
                personalDL = new Pers_DrivingLicense();
            }

            return personalDL;
        }

        public void UpdatePersonalHealthInsurance(Pers_HealthCard personalHC)
        {
            var existingHC = databaseConnection.Pers_HealthCard.Where(x => x.Pers_Nr == personalHC.Pers_Nr).FirstOrDefault();

            if (existingHC != null)
            {
                databaseConnection.Pers_HealthCard.Remove(existingHC);
                databaseConnection.SaveChanges();
            }

            databaseConnection.Pers_HealthCard.Add(personalHC);
            databaseConnection.SaveChanges();

        }

        public void DeleteHealthInsurance(Pers_HealthCard personalHC)
        {
            var existingHC = databaseConnection.Pers_HealthCard.Where(x => x.Pers_Nr == personalHC.Pers_Nr).FirstOrDefault();

            if (existingHC != null)
            {
                databaseConnection.Pers_HealthCard.Remove(existingHC);
                databaseConnection.SaveChanges();
            }
            else
            {
                return;
            } 
        }

        public Pers_HealthCard GetPersonalHealthInsurance(long personalNumber)
        {
            Pers_HealthCard personalHC = databaseConnection.Pers_HealthCard.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (personalHC == null)
            {
                personalHC = new Pers_HealthCard();
            }

            return personalHC;
        }

        public void UpdatePersonalEyeColorAndHeight(Pers_AdditionalInfo personalAdditionalInfo)
        {
            var existingAI = databaseConnection.Pers_AdditionalInfo.Where(x => x.Pers_Nr == personalAdditionalInfo.Pers_Nr).FirstOrDefault();

            if (existingAI != null)
            {
                existingAI.Height = personalAdditionalInfo.Height;
                existingAI.DOB = personalAdditionalInfo.DOB;
                existingAI.EyeColor = personalAdditionalInfo.EyeColor;
                existingAI.PlaceOfBirth = personalAdditionalInfo.PlaceOfBirth;
                existingAI.Nationality = personalAdditionalInfo.Nationality;
                databaseConnection.SaveChanges();
            }
            else
            {
                databaseConnection.Pers_AdditionalInfo.Add(personalAdditionalInfo);
                databaseConnection.SaveChanges();
            }
        }

        public Pers_AdditionalInfo GetPersonalPersonalEyeColorAndHeight(long personalNumber)
        {
            Pers_AdditionalInfo personalAI = databaseConnection.Pers_AdditionalInfo.Where(x => x.Pers_Nr == personalNumber).FirstOrDefault();

            if (personalAI == null)
            {
                personalAI = new Pers_AdditionalInfo();
            }

            return personalAI;
        }
    }
}
