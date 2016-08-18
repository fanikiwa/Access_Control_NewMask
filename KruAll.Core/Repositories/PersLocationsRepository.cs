using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KruAll.Core.Repositories
{
    public class PersLocationsRepository : KruAllBaseRepository<Pers_Locations>
    {

        #region Constructor
        public PersLocationsRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Locations> GetAllPercLocations()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Locations GetPercLocationsById(long id)
        {
            return base.FindBy(p => p.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Locations GetPercLocationsPersNr(long Pers_Nr)
        {
            return base.FindBy(p => p.Pers_Nr == Pers_Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPercLocations(Pers_Locations contact, bool save = true)
        {
            base.Add(contact);
            if (save) Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPercLocations(Pers_Locations contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPercLocationsCustom(Pers_Locations contact)
        {
            if (contact.ID == 0) return;
            base.Edit(contact);
            //Save()
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePercLocations(Pers_Locations contact)
        {
            if (contact.ID == 0) return;
            //var currentLocation = GetLocationById(location.ID);
            base.Delete(contact);
            Save();
        }
        #endregion
    }
}
