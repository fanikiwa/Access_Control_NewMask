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
    public class PersTranspondersRepository : KruAllBaseRepository<Pers_Transponders>
    {
        public PersTranspondersRepository() { }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Transponders> GetPersonnelTransponders(long persNr)
        {
            return base.GetAll().Where(x => x.PersNr == persNr).ToList();
        }

        //[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        //public Pers_Vehicles GetPersVehiclesByPersNr(long persNr)
        //{
        //    return base.FindBy(x => x.Pers_Nr == persNr).FirstOrDefault();
        //}
         
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Transponders GetPersTransponderByPersNr(long persNr)
        {
            return base.FindBy(x => x.PersNr == persNr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Transponders> GetPersonnelTransponders(long persNr, long transponderNr)
        {
            return base.GetAll().Where(x => x.PersNr == persNr && x.TransponderNr == transponderNr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Pers_Transponders GetTransponderById(long Id)
        {
            return base.FindBy(x => x.ID == Id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Transponders> GetPersTransponders(long Id)
        {
            return base.GetAll().Where(x => x.PersNr == Id).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Pers_Transponders> GetAllPersTransponders()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AddPersTransponder(Pers_Transponders persTransponder)
        {
            base.Add(persTransponder);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditPersTransponder(Pers_Transponders persTransponder)
        {
            if (persTransponder.ID <= 0) return;
            base.Edit(persTransponder);
        }

        public void SavePersTransponder()
        {
            base.Save();
        }

        public List<View_CardAllocationOverview> GetCardAllocationOverView()
        {
            KruAll.Core.Models.PZE_Entities dbConnection = new PZE_Entities();
            return dbConnection.View_CardAllocationOverview.Where(x => x.PersonnelActive == true).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeletePersTransponder(Pers_Transponders transponder)
        {
            if (transponder.ID == 0) return;
            var currentTransponder = GetTransponderById(transponder.ID);
            Delete(currentTransponder);
            Save();

        }
    }
}
