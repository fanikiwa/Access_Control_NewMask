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
    public class LocationRepository : KruAllBaseRepository<Location>
    {
        #region Constructor
        public LocationRepository() { }
        #endregion

        #region Methods
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Location> GetLocations()
        {
            return base.GetAll().OrderBy(x => x.Location_Nr).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Location GetLocationById(long id)
        {
            var location = base.FindBy(l => l.ID == id).FirstOrDefault();
            if (location != null && location.HolidayCalendarId == null)
            {
                location.HolidayCalendarId = 0;
            }

            return base.FindBy(l => l.ID == id).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Location GetLocationByNr(int id)
        {

            return base.FindBy(l => l.Location_Nr == id).FirstOrDefault();
        }
        public Location GetLocationByName(string name)
        {
            return base.FindBy(l => l.Name == name).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Location> GetLocationsByHolidayCalendar(long holidayCalendarId)
        {
            return base.GetAll().Where(l => l.HolidayCalendarId == holidayCalendarId).ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewLocation(Location location)
        {
            base.Add(location);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditLocation(Location location)
        {
            if (location.ID == 0) return;
            base.Edit(location);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteLocation(Location location)
        {
            if (location.ID == 0) return;
            var currentLocation = GetLocationById(location.ID);
            base.Delete(currentLocation);
            Save();
        }
        #endregion
    }
}
