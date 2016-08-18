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
    public class PersClientRepository : KruAllBaseRepository<Pers_Client>
    {


        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public void InsertPersClient(Pers_Client _PersClient)
        {
            base.Add(_PersClient);
            base.Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Client> GetAllPersClient()
        {
            return base.GetAll().OrderBy(x => x.Pers_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Client GetPersClientByPersNo(long PersNo)
        {
            return base.GetAll().Where(a => a.Pers_Nr == PersNo).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Client GetPersClientByClientID(long ClientID)
        {
            return base.GetAll().Where(a => a.ClientID == ClientID).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Client> GetAllPersClientByClientID(int ClientID)
        {
            return base.GetAll().Where(a => a.ClientID == ClientID).OrderBy(x => x.Pers_Nr).ToList();
        }

        public void UpdatePerz(Pers_Client a, Pers_Client _a)
        {

            a.Pers_Nr = _a.Pers_Nr;
            a.ClientID = _a.ClientID;
            base.Edit(a);
            base.Save();

        }
        public void UpdatePerz(Pers_Client a)
        {
            base.Edit(a);
            base.Save();

        }
        public void DeletePersClient(long PersNo)
        {
            if (base.GetAll().Any(a => a.Pers_Nr == PersNo))
            {
                var x = base.GetAll().Where(a => a.Pers_Nr == PersNo).ToList();

                foreach (var _entity in x)
                {
                    base.Delete(_entity);
                }

                base.Save();
            }
        }
        #endregion


    }
}
