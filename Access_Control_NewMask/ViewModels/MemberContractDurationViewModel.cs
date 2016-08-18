using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class MemberContractDurationViewModel
    {
        public DataTable DurationRowData()
        {
            var durationRawData = new MemberDurationRepository().GetAllDurations().OrderBy(x=> x.DurationNr).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            dt.Columns.Add("DurationNr", typeof(string));
            dt.Columns.Add("Duration", typeof(string));
            dt.Columns.Add("IsSelected", typeof(bool));

            if (durationRawData.Count == 0)
            {
                for (int i = 0; i < 24; i++)   
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = (i + 1) * -1;
                    row["DurationNr"] = "";
                    row["Duration"] = "";
                    row["IsSelected"] = false;
                    //dt.Rows.Add((i + 1) * -1);
                    dt.Rows.Add(row);
                }
            }
            else
            {

                foreach (MemberDuration duration in durationRawData)
                {
                    

                    DataRow row = dt.NewRow();
                    row["ID"] = duration.ID;
                    row["DurationNr"] = duration.DurationNr;
                    row["Duration"] = duration.Duration;
                    row["IsSelected"] = false;

                    dt.Rows.Add(row);

                }

                if (durationRawData.Count < 24)
                {
                    for (int i = 0; i < (24 - durationRawData.Count); i++)
                    {
                        DataRow row = dt.NewRow();
                        row["ID"] = (i + 1) * -1;
                        row["DurationNr"] = "";
                        row["Duration"] = "";
                        row["IsSelected"] = false;
                        //dt.Rows.Add((i + 1) * -1);
                        dt.Rows.Add(row);
                    }
                }

            }

            return dt;
        }
    }
}