using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProtoBoatRazorPage.Helpers;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Repository
{
    public class JsonBookBoatRepository: IBookingRepository
    {
        string JsonFileName = @"Data\JsonBooking.json";
        public void BookBoat(Booking booking)
        {
            Dictionary<int, Booking> bookings = GetAllBookings();
            List<int> orderIds = new List<int>();
            foreach (var ord in bookings)
            {
                orderIds.Add(ord.Value.Code);
            }
            if (orderIds.Count != 0)
            {
                int start = orderIds.Max();
                booking.Code = start + 1;
            }
            else
            {
                booking.Code = 0;
            }
            bookings.Add(booking.Code, booking);
            JsonFileWriter.WriteToJsonBooking(bookings, JsonFileName);
        }

        public Dictionary<int, Booking> GetAllBookings()
        {
            
            return JsonFileReader.ReadJsonBooking(JsonFileName);
        }

        public Dictionary<int, Booking> SearchBoatByCode(int id)
        {
            Dictionary<int, Booking> bookings = GetAllBookings();
            Dictionary<int, Booking> user = new Dictionary<int, Booking>();
            foreach (var b in bookings.Values)
            {
                if (b.User.Id == id)
                {
                    user.Add(id, b);
                }
            }
            return user;
        }

        public void RemoveBookedBoat(Booking bookedBoat)
        {
            Dictionary<int, Booking> bookings = GetAllBookings();
            bookings.Remove(bookedBoat.Code);
            JsonFileWriter.WriteToJsonBooking(bookings, JsonFileName);
        }
    }
}
