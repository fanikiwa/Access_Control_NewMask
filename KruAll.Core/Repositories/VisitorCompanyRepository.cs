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
    public class VisitorCompanyRepository : KruAllBaseRepository<VisitorCompanyTb>
    {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorCompanyTb> GetAllVisitorCompanies()
        {
            return base.GetAll().OrderBy(x=> x.CompanyNr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorCompanyTb GetVisitorCompanyById(long id)
        {
            return base.FindBy(cc => cc.ID == id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorCompanyTb GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.CompanyNr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorCompanyTb GetVisitorCompanyByNr(int Nr)
        {
            return base.FindBy(cc => cc.CompanyNr == Nr).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewVisitorCompany(VisitorCompanyTb VisitorCompany)
        {
            base.Add(VisitorCompany);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditVisitorCompany(VisitorCompanyTb VisitorCompany)
        {
            if (VisitorCompany.ID == 0) return;
            base.Edit(VisitorCompany);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteVisitorCompany(VisitorCompanyTb VisitorCompany)
        {
            if (VisitorCompany.ID == 0) return;
            var currentvehicleType = GetVisitorCompanyById(VisitorCompany.ID);
            base.Delete(currentvehicleType);
            Save();
        }

    }
}
