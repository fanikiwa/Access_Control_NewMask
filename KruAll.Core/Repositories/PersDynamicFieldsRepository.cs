

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
    public class PersDynamicFieldsRepository: KruAllBaseRepository<Pers_DynamicFields>
    {
        #region Constructor
        public PersDynamicFieldsRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_DynamicFields> GetPersDynamicFields()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_DynamicFields GetPersDynamicFieldByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersDynamicField(Pers_DynamicFields dynamicField)
        {
            base.Add(dynamicField);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersDynamicFieldCustom(Pers_DynamicFields dynamicField)
        {
            base.Add(dynamicField); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersDynamicField(Pers_DynamicFields dynamicField)
        {
            if (dynamicField.ID == 0) return;
            base.Edit(dynamicField);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersDynamicFieldCustom(Pers_DynamicFields dynamicField)
        {
            if (dynamicField.ID == 0) return;
            base.Edit(dynamicField); 
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersDynamicField(Pers_DynamicFields dynamicField)
        {
            if (dynamicField.ID == 0) return; 
            base.Delete(dynamicField);
            Save();
        }
        #endregion
    }
}
