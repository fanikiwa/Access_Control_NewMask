using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class PersonalTransponderViewModels
    {
        public DataTable TransponderRowData(long PersNr, int transponderType)
        {
            var personnalTransponders = new PersTranspondersRepository().GetPersonnelTransponders(PersNr).OrderBy(x => x.ID).ToList();
            var personnalTypeTransponders = personnalTransponders.FindAll(x => x.TransponderType == transponderType) ?? new List<Pers_Transponders>();
            var personnalTypeTranspondersXt = new List<Pers_Transponders>();
            var xt = personnalTypeTransponders.GroupBy(t => t.TransponderNr);
            foreach (var y in xt)
            {
                personnalTypeTranspondersXt.Add(y.LastOrDefault());
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            dt.Columns.Add("TransponderNr", typeof(string));
            dt.Columns.Add("TransponderType", typeof(Int32));
            dt.Columns.Add("TransponderStatus", typeof(bool));
            dt.Columns.Add("DateIssued", typeof(string));
            dt.Columns.Add("ValidFrom", typeof(string));
            dt.Columns.Add("ValidTo", typeof(string));
            dt.Columns.Add("TransponderDeactivatedOn", typeof(string));
            dt.Columns.Add("Action", typeof(string));
            dt.Columns.Add("Memo", typeof(string));
            if (personnalTypeTranspondersXt.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dt.Rows.Add((i + 1) * -1);
                }
            }
            else
            {

                foreach (var transponder in personnalTypeTranspondersXt)
                {


                    DataRow row = dt.NewRow();
                    row["ID"] = transponder.ID;
                    row["TransponderNr"] = transponder.TransponderNr;
                    row["TransponderType"] = transponder.TransponderType ?? 1;
                    row["TransponderStatus"] = transponder.TransponderStatus != null ? transponder.TransponderStatus : false;
                    row["DateIssued"] = transponder.ExtendedTo != null ? transponder.ExtendedTo : null;
                    row["ValidFrom"] = transponder.ValidFrom != null ? transponder.ValidFrom : null;
                    row["ValidTo"] = transponder.ValidTo != null ? transponder.ValidTo : null;
                    row["TransponderDeactivatedOn"] = transponder.TransponderDeactivatedOn != null ? transponder.TransponderDeactivatedOn : null;
                    row["Action"] = transponder.Action;
                    row["Memo"] = transponder.Memo;
                    dt.Rows.Add(row);

                }

                if (personnalTypeTranspondersXt.Count < 10)
                {
                    for (int i = 0; i < (10 - personnalTypeTranspondersXt.Count); i++)
                    {
                        dt.Rows.Add((i + 1) * -1);
                    }
                }

            }

            return dt;
        }

        public List<TransponderDto> TransPonders(long persNr, int transponderType)
        {
            var transponders = TransponderRowData(persNr, transponderType);
            List<TransponderDto> transList = new List<TransponderDto>();

            if (transponders.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow row in transponders.Rows)
                {

                    TransponderDto trans = new TransponderDto
                    {

                        ID = Convert.ToInt64(row[transponders.Columns["ID"]]),
                        TransponderNr = row[transponders.Columns["TransponderNr"]].GetType() == typeof(string) ? row[transponders.Columns["TransponderNr"]].ToString() : string.Empty,
                        TransponderType = row[transponders.Columns["TransponderType"]].GetType() == typeof(Int32) ? Convert.ToInt32(row[transponders.Columns["TransponderType"]].ToString()) : 1,
                        TransponderActive = row[transponders.Columns["TransponderStatus"]].GetType() == typeof(bool) ? Convert.ToBoolean(row[transponders.Columns["TransponderStatus"]]) : false,
                        TransponderInActive = row[transponders.Columns["TransponderStatus"]].GetType() == typeof(bool) ? !Convert.ToBoolean(row[transponders.Columns["TransponderStatus"]]) : false,
                        ExtendedTo = row[transponders.Columns["DateIssued"]].GetType() == typeof(string) ? Convert.ToDateTime(row[transponders.Columns["DateIssued"]]) : (DateTime?)null,
                        ValidFrom = row[transponders.Columns["ValidFrom"]].GetType() == typeof(string) ? Convert.ToDateTime(row[transponders.Columns["ValidFrom"]]) : (DateTime?)null,
                        ValidTo = row[transponders.Columns["ValidTo"]].GetType() == typeof(string) ? Convert.ToDateTime(row[transponders.Columns["ValidTo"]]) : (DateTime?)null,
                        TransponderDeactivatedOn = row[transponders.Columns["TransponderDeactivatedOn"]].GetType() == typeof(string) ? Convert.ToDateTime(row[transponders.Columns["TransponderDeactivatedOn"]]) : (DateTime?)null,
                        Action = row[transponders.Columns["Action"]].GetType() == typeof(string) ? row[transponders.Columns["Action"]].ToString() : string.Empty,
                        Memo = row[transponders.Columns["Memo"]].GetType() == typeof(string) ? row[transponders.Columns["Memo"]].ToString() : string.Empty,
                        Card = i,
                    };
                    transList.Add(trans);
                    i++;
                }
            }

            return transList;
        }

        public List<TransponderDto> TransPondersExtensions(long persNr, long transponderNr)
        {
            var persTransponders = (new PersTranspondersRepository().GetPersonnelTransponders(persNr, transponderNr) ?? new List<Pers_Transponders>()).
                OrderByDescending(x => x.ID).ToList();
            List<TransponderDto> transList = new List<TransponderDto>();

            for (int i = 0; i < 5; i++)
            {
                TransponderDto transponderDto = new TransponderDto();
                if (persTransponders.Count > i)
                {
                    transponderDto.ID = persTransponders[i].ExtendedTo != null ? persTransponders[i].ID : (i + 1) * -1;
                    transponderDto.ExtendedTo = persTransponders[i].ExtendedTo;
                }
                else
                {
                    transponderDto.ID = (i + 1) * -1;
                }

                transList.Add(transponderDto);
            }

            return transList.OrderByDescending(x => x.ID).ToList();
        }

    }
}