using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Interfaces
{
    public interface IBookingRepository
    {
        void BookBoat(Booking booking);
        Dictionary<int, Booking> GetAllBookings();
        List<Booking> SearchBoatByCode(int id);
        void RemoveBookedBoat(Booking bookBoat);
        int GetCount(int id);
    }
}
