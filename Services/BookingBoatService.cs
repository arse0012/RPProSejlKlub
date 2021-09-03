using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Services
{
    public class BookingBoatService
    {
        private Dictionary<int, Boat> _bookItems;

        public BookingBoatService()
        {
            _bookItems = new Dictionary<int, Boat>();
        }

        public void Add(Boat boat)
        {
            if (!(_bookItems.Keys.Contains(boat.Id)))
                _bookItems.Add(boat.Id, boat);
        }

        public Dictionary<int, Boat> GetBookedBoat()
        {
            return _bookItems;
        }

        public void UpdateBooking(Boat boat)
        {
            Boat foundBoat = _bookItems[boat.Id];
            foundBoat.BookedTo = boat.BookedTo;
            foundBoat.BookedFrom = boat.BookedFrom;
            
        }

        public void RemoveBooking(int orderId)
        {
            foreach (var boat in _bookItems)
            {
                if (boat.Value.Id == orderId)
                {
                    _bookItems.Remove(boat.Value.Id);
                    break;
                }
            }
        }
    }
}
