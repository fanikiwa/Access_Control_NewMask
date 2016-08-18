using KruAll.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access_Control_NewMask.Dtos;
using DevExpress.Web;
using System.Net;
using System.IO;

namespace Access_Control_NewMask.Controllers
{
    public class RegionHolidaysDownload
    {
         public enum Bundesland
        {
            BW = 1,
            BY = 2,
            BE = 3,
            BB = 4,
            HB = 5,
            HH = 6,
            HE = 7,
            MV = 8,
            NI = 9,
            NW = 10,
            RP = 11,
            SL = 12,
            SN = 13,
            ST = 14,
            SH = 15,
            TH = 16
        }

        public static List<Holiday> GetAllHolidaysForRegionID(int regionID, int Year)
        {
            Holiday holiday = null;
            List<Holiday> regionHolidays = new List<Holiday>();
            Dictionary<DateTime, string> rawHolidays = null;
            bool downloadAllRegions = false;
            const int NO_REGION_SELECTION = 0;


            downloadAllRegions = regionID == NO_REGION_SELECTION;


            switch (downloadAllRegions)
            {
                case true:
                    foreach (Bundesland bundesLand in Enum.GetValues(typeof(Bundesland)))
                    {
                        rawHolidays = getGermanFeiertage(bundesLand, Year);
                        foreach (DateTime holidayDate in rawHolidays.Keys)
                        {
                            holiday = new Holiday();
                            holiday.HolidayDate = holidayDate;
                            holiday.HolidayName = rawHolidays[holidayDate];
                            holiday.RegionID = (int)bundesLand;
                            regionHolidays.Add(holiday);
                        }
                    }
                    break;
                case false:
                    rawHolidays = getGermanFeiertage((Bundesland)regionID, Year);
                    foreach (DateTime holidayDate in rawHolidays.Keys)
                    {
                        holiday = new Holiday();
                        holiday.HolidayDate = holidayDate;
                        holiday.HolidayName = rawHolidays[holidayDate];
                        holiday.RegionID = regionID;
                        regionHolidays.Add(holiday);
                    }
                    break;
            }
            rawHolidays = getGermanFeiertage((Bundesland)regionID, Year);
            foreach (DateTime holidayDate in rawHolidays.Keys)
            {
                holiday = new Holiday();
                holiday.HolidayDate = holidayDate;
                holiday.HolidayName = rawHolidays[holidayDate];
                holiday.RegionID = regionID;
                regionHolidays.Add(holiday);
            }

            return regionHolidays;
        }

        private static Dictionary<DateTime, string> getGermanFeiertage(Bundesland Bundesland, int year)
        {
            var FT = new Dictionary<DateTime, string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("http://www.feiertage.net/csvfile.php?state=");
            sb.Append(Bundesland);
            sb.Append("&year=");
            sb.Append(year);
            sb.Append("&type=csv");

            string url = sb.ToString();

            var req = WebRequest.Create(url);
            try
            {
                var resp = req.GetResponse();
                var reader = new StreamReader(resp.GetResponseStream());
                string date = "";
                bool next = false;
                foreach (var f in reader.ReadToEnd().Split(';'))
                {
                    if (next)
                    {
                        FT.Add(Convert.ToDateTime(date), f);
                        next = false;
                    }
                    if (f.Contains('\n'))
                    {
                        date = f.Split('\n')[1];
                        next = true;
                        continue;
                    }
                    else next = false;
                }


            }
            catch (Exception exc)
            {
                return new Dictionary<DateTime, string>();
            }

            return FT;
        }
    }
}
