using System;

namespace HotelManagementSystem
{
    class Guest
    {
        // Properties
        public string GuestId;
        public string GuestName;
        public string RoomNumber; // "Not Assigned" if no room
        public DateTime CheckInDate;
        public int TotalNights;

        // Constructor
        public Guest(string guestId, string guestName, DateTime checkInDate, int totalNights)
        {
            GuestId = guestId;
            GuestName = guestName;
            RoomNumber = "Not Assigned";
            CheckInDate = checkInDate;
            TotalNights = totalNights;
        }

        // Method to display guest details
        public void DisplayGuest()
        {
            Console.WriteLine("Guest ID: " + GuestId);
            Console.WriteLine("  Name: " + GuestName);
            Console.WriteLine("  Room: " + RoomNumber);
            Console.WriteLine("  Check-in: " + CheckInDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("  Nights: " + TotalNights);
        }

        // Method to calculate total cost
        public double CalculateTotalCost(double pricePerNight)
        {
            return pricePerNight * TotalNights;
        }
    }
}