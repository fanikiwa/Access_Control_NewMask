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
    public class GlobalSettingRepository: KruAllBaseRepository<Global_Settings>
    {
        #region Constructor
        public GlobalSettingRepository() { }

        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Global_Settings> GetglobalSettings()
        {
            return base.GetAll().ToList();
        }

        public Global_Settings GetGlobalSettingByName(string name)
        {
            return base.FindBy(x => x.AppName == name).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVersion(Global_Settings _globalSettings)
        {
            if (_globalSettings.ID == 0) return;
            base.Edit(_globalSettings);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddVersion(Global_Settings _globalSettings)
        {
            base.Add(_globalSettings);
            Save();
        }

        #endregion
    }
}
