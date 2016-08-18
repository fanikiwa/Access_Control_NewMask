using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class PersAdditionalInfoRepository : KruAllBaseRepository<Pers_AdditionalInfo>
    {


        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AdditionalInfo GetPersByNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_AdditionalInfo GetPersAdditionalInfoByNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AdditionalInfo> GetPersAddInfo()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersAddInfo(Pers_AdditionalInfo persaddInfo)
        {


            base.Add(persaddInfo);
            Save();

        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersAddInfoCustom(Pers_AdditionalInfo persaddInfo)
        {
            base.Add(persaddInfo);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]

        public void UpdatePersAddInfo(Pers_AdditionalInfo persaddInfo, Pers_AdditionalInfo _persaddInfo)
        {

            base.Delete(persaddInfo);
            base.Save();
            base.Add(_persaddInfo);
            base.Save();
        }
        public void EditPersAddInfo(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Edit(persaddInfo);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersAddInfoCustom(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Edit(persaddInfo);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersAddInfo(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Delete(persaddInfo);
            Save();
        }

        
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_AdditionalInfo> GetPersAdditionalInfos()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersAdditionalInfo(Pers_AdditionalInfo persaddInfo)
        {
            base.Add(persaddInfo);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersAdditionalInfoCustom(Pers_AdditionalInfo persaddInfo)
        {
            base.Add(persaddInfo);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]

        public void UpdatePersAdditionalInfo(Pers_AdditionalInfo persaddInfo, Pers_AdditionalInfo _persaddInfo)
        {

            base.Delete(persaddInfo);
            base.Save();
            base.Add(_persaddInfo);
            base.Save();
        }
        public void EditPersAdditionalInfo(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Edit(persaddInfo);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersAdditionalInfoCustom(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Edit(persaddInfo);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersAdditionalInfo(Pers_AdditionalInfo persaddInfo)
        {
            if (persaddInfo.ID == 0) return;
            base.Delete(persaddInfo);
            Save();
        }
        #endregion
    }
}
