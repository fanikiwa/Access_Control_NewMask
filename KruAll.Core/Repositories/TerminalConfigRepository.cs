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
    public class TerminalConfigRepository: KruAllBaseRepository<TerminalConfig>
    {
        #region Constructor

        public TerminalConfigRepository() { }

        #endregion
        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TerminalConfig> GetAllTerminalsInstances()
        {
            return base.GetAll().ToList();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public TerminalConfig GetTerminalInstance(long id)
        {
            return base.FindBy(e => e.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<TerminalReader> GetTerminalReaders()
        {
            PZE_Entities PZEContext = new PZE_Entities();
            return PZEContext.TerminalReaders.ToList();
        }

        public List<long> GetTerminalIDsForVisitorPlan(long visitorID)
        {
            List<long> terminalIDs = new List<long>();
            string sqlQuery = string.Empty;
            PZE_Entities PZEContext = new PZE_Entities();

            sqlQuery = "SELECT DISTINCT TerminalConfig.ID FROM VisitorAccessTime "
                     + "INNER JOIN Visitors ON Visitors.ID = VisitorAccessTime.VisitorId "
                     + "INNER JOIN TbVisitorPlan ON TbVisitorPlan.ID = VisitorAccessTime.VisitPlanId "
                     + "INNER JOIN ReaderVisitorPlan ON ReaderVisitorPlan.VisitorPlanId = TbVisitorPlan.ID "
                     + "INNER JOIN ReaderAssigned ON ReaderAssigned.BuildingPlanID = ReaderVisitorPlan.BuildingPlanID AND ReaderAssigned.DoorID = ReaderVisitorPlan.DoorID  "
                     + "INNER JOIN TerminalConfig ON TerminalConfig.ID = ReaderAssigned.TerminalID "
                     + "WHERE Visitors.VisitorID = " + visitorID + "";

            terminalIDs = PZEContext.Database.SqlQuery<long>(sqlQuery).ToList();
            return terminalIDs;
        }
        #endregion
    }
}
