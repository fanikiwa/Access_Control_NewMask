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
    public class AssignReaderRepository: KruAllBaseRepository<ReaderAssigned>
    {
        #region Constructor
        public AssignReaderRepository() { }

        #endregion

        #region Methods

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ReaderAssigned> GetAllAssignedReaders()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ReaderAssigned> GetAssignedReadersByBuildingPlan(long buildingPlanId)
        {
            return base.GetAll().Where(e => e.BuildingPlanID == buildingPlanId).ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<ReaderAssigned> GetReadersByDoorId(long buildingPlanId, int doorId)
        {
            return base.GetAll().Where(e => e.BuildingPlanID == buildingPlanId && e.DoorID == doorId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public ReaderAssigned GetAssignedReaderById(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void AssignReder(ReaderAssigned reader)
        {
            base.Add(reader);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditAssignedReader(ReaderAssigned reader)
        {
            if (reader.ID == 0) return;
            base.Edit(reader);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAssignedReader(ReaderAssigned reader)
        {
            if (reader.ID == 0) return;
            //var currentReader = GetAssignedReaderById(reader.ID);
            Delete(reader);
            Save();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteReader(ReaderAssigned reader)
        {
            if (reader.ID == 0) return;
            var currentReader = GetAssignedReaderById(reader.ID);
            Delete(currentReader);
            Save();
        }

        #endregion
    }
}
