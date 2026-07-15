using System;

namespace HotelManagementSystem
{
    class Room
    {
        // Properties
        public int RoomNumber;
        public string RoomType; // Single, Double, Suite
        public double PricePerNight;
        public bool IsAvailable;

        // Constructor
        public Room(int roomNumber, string roomType, double pricePerNight)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = true; // Always available when first added
        }

        // Method to display room details
        public void DisplayRoom()
        {
            Console.WriteLine("Room #" + RoomNumber);
            Console.WriteLine("  Type: " + RoomType);
            Console.WriteLine("  Price per night: " + PricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("  Status: " + (IsAvailable ? "Available" : "Booked"));
        }
    }
}