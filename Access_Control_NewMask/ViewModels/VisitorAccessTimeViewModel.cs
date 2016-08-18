using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class VisitorAccessTimeViewModel
    {
        #region Constructor
        public VisitorAccessTimeViewModel() { }

        #endregion

        #region Properties

        private VisitorAccessTimeRepository _accessTimeRepository = new VisitorAccessTimeRepository();

        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeById(long id)
        {

            return _accessTimeRepository.GetAccessTimeById(id);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByVisitInstanceId(long id)
        {

            return _accessTimeRepository.GetAccessTimeByVisitInstanceId(id);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public VisitorAccessTime GetAccessTimeByVisitor_Id(long id)
        {

            return _accessTimeRepository.GetAccessTimeByVisitor_Id(id);
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<VisitorAccessTime> GetAllAccessTime()
        {

            return _accessTimeRepository.GetAllVisitorAccessTime();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void CreateAccessTime(VisitorAccessTime accessTime)
        {
            _accessTimeRepository.NewAccessTime(accessTime);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void UpdateAccessTime(VisitorAccessTime accessTime)
        {
            _accessTimeRepository.EditAccessTime(accessTime);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteAccessTime(VisitorAccessTime accessTime)
        {
            _accessTimeRepository.DeleteAccessTime(accessTime);
        }


        #endregion
    }
}