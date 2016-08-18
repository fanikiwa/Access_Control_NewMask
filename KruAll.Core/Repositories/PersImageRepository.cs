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
    public class PersImageRepository : KruAllBaseRepository<Pers_Photo>
    {
        #region Constructor
        public PersImageRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Photo> GetAllPersonnalPhotos()
        {
            return base.GetAll().ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Photo GetPersPhotoByPersNr(long Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Nr).FirstOrDefault();

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Photo GetPersonnalPhotoByPers_Nr(long pers_nr)
        {
            return base.GetAll().Where(x => x.Pers_Nr == pers_nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Photo GetPersonnalPhotoById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonnalPhoto(Pers_Photo persPhoto)
        {
            base.Add(persPhoto);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewPersonnalPhotoCustom(Pers_Photo persPhoto)
        {
            base.Add(persPhoto);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonnalPhoto(Pers_Photo persPhoto)
        {
            if (persPhoto.ID == 0) return;
            base.Edit(persPhoto);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersonnalPhotoCustom(Pers_Photo persPhoto)
        {
            if (persPhoto.ID == 0) return;
            base.Edit(persPhoto);
            //Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersonnalPhoto(Pers_Photo persPhoto)
        {
            if (persPhoto.ID == 0) return;
            var currentPhoto = GetPersonnalPhotoById(persPhoto.ID);
            Delete(currentPhoto);
            Save();
        }

        #endregion
    }
}
