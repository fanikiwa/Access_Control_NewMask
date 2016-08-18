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
    public class PersArchiveRepository : KruAllBaseRepository<Pers_Archive>
    {


        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Archive GetPersArchiveByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Archive> GetPersArchive()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersArchive(Pers_Archive persarchive)
        {
            base.Add(persarchive);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersArchiveCustom(Pers_Archive persarchive)
        {
            base.Add(persarchive);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]

        public void UpdatePersArchive(Pers_Archive persarchive, Pers_Archive _persarchive)
        {

            base.Delete(persarchive);
            base.Save();
            base.Add(_persarchive);
            base.Save();
        }
        public void EditPersArchive(Pers_Archive persarchive)
        {
            if (persarchive.ID == 0) return;
            base.Edit(persarchive);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersArchiveCustom(Pers_Archive persarchive)
        {
            if (persarchive.ID == 0) return;
            base.Edit(persarchive);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersArchive(Pers_Archive persarchive)
        {
            if (persarchive.ID == 0) return;
            base.Delete(persarchive);
            Save();
        }
        #endregion
    }
}
