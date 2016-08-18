using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.ViewModels
{
    public class LocationViewModel
    {
        readonly LocationRepository _locationRepository = new LocationRepository();
        readonly HolidayCalendarRepository _holidayCalendarRepository = new HolidayCalendarRepository();

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Location> GetLocations()
        {
            return _locationRepository.GetLocations();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<LocationCalendarDto> GetLocationAndCalendar()
        {
            var Locations = _locationRepository.GetLocations();
            if (Locations.Count == 0) return null;
            return SearchResults(Locations);
        }

        public List<HolidayCalendar> HolidayCalendars()
        {
            var holidayCalendars = _holidayCalendarRepository.GetHolidayCalendars();
            holidayCalendars.Add(new HolidayCalendar
            {
                Id = 0,
                HolidayCalendarNumber = 0,
                HolidayCalendarName = "keine"
            });
            return holidayCalendars;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Location> GetLocationsByHolidayCalendar(long holidayCalendarId)
        {
            return _locationRepository.GetLocationsByHolidayCalendar(holidayCalendarId);
        }

        private List<LocationCalendarDto> SearchResults(IList<Location> AllLocations)
        {

            var LocationlListing = new List<LocationCalendarDto>();
            foreach (var location in AllLocations)
            {
                LocationlListing.Add(SearchResult(location));

            }
            return LocationlListing;
        }

        private LocationCalendarDto SearchResult(Location location)
        {
            LocationCalendarDto locationCalendarDto = new LocationCalendarDto();
            HolidayCalendar holidayCalendar = new HolidayCalendar();
            HolidayCalendarRepository holidayCalendarRepository = new HolidayCalendarRepository();
            holidayCalendar = holidayCalendarRepository.GetHolidayCalendarById(Convert.ToInt64(location.HolidayCalendarId));

            try
            {
                locationCalendarDto.ID = location.ID;
                locationCalendarDto.Location_Nr = location.Location_Nr;
                locationCalendarDto.Name = location.Name;
                locationCalendarDto.State = location.State;
                locationCalendarDto.Street = location.Street;
                locationCalendarDto.LocationHeadName = location.LocationHeadName;
                locationCalendarDto.LocationHeadPhone = location.LocationHeadPhone;
                locationCalendarDto.Feiertagskalender = holidayCalendar.HolidayCalendarName;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return locationCalendarDto;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditLocation(Location location)
        {
            _locationRepository.EditLocation(location);
        }
    }
}
