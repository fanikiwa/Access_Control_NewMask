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
    public class PersPinCodeRepository : KruAllBaseRepository<Pers_PinCode>
    {
        #region Constructor
        public PersPinCodeRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_PinCode> GetPinCodes()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_PinCode GetPinCodeByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPinCode(Pers_PinCode pincode)
        {
            base.Add(pincode);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPinCodeCustom(Pers_PinCode pincode)
        {
            base.Add(pincode);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPinCode(Pers_PinCode pincode)
        {
            if (pincode.ID == 0) return;
            base.Edit(pincode);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPinCodeCustom(Pers_PinCode pincode)
        {
            if (pincode.ID == 0) return;
            base.Edit(pincode);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePinCode(Pers_PinCode pincode)
        {
            if (pincode.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(pincode);
            Save();
        }
        #endregion
    }
}
