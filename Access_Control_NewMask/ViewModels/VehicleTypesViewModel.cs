using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class VehicleTypesViewModel
    {
        public DataTable GetVehicleTypeDataSource(String VehicleType_)
        {

            var VehiclesTypeList = new VehicleTypeRepository().getVehicleTypeByNames(VehicleType_);
            DataTable dtVehicleTypes = new DataTable();
            dtVehicleTypes.Columns.Add("ID");
            dtVehicleTypes.Columns.Add("Name");
            dtVehicleTypes.Columns.Add("Type");
            dtVehicleTypes.Columns.Add("showName");
            DataRow _DataRow;
            if (VehiclesTypeList.Count == 0)
            {
                int i = 0;
                for (i = 0; i < 25; i++)
                {
                    dtVehicleTypes.Rows.Add(i * -1, "", "", false);
                }
            }

            if (VehiclesTypeList != null)
            {
                foreach (VehicleType _VehicleType in VehiclesTypeList)
                {
                    _DataRow = dtVehicleTypes.NewRow();
                    _DataRow["ID"] = _VehicleType.ID;
                    _DataRow["Name"] = _VehicleType.Name;
                    _DataRow["Type"] = _VehicleType.Type;
                    _DataRow["showName"] = dtVehicleTypes.Rows.Count == 0 ? true : false;
                    dtVehicleTypes.Rows.Add(_DataRow);
                }

                if (VehiclesTypeList.Count < 18)
                {
                    for (int k = 0; k < (18 - VehiclesTypeList.Count); k++)
                    {
                        dtVehicleTypes.Rows.Add((k + 1) * -1, "", "", false);
                    }
                }


            }

            return dtVehicleTypes;
        }
    }
}