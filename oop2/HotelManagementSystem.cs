using HotelManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oop2
{
    class Program
    {
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();

        static void Main(string[] args)
        {
            // Pre-load rooms with at least 6 rooms
            rooms.Add(new Room(101, "Single", 25.00));
            rooms.Add(new Room(102, "Double", 45.00));
            rooms.Add(new Room(103, "Suite", 85.00));
            rooms.Add(new Room(104, "Single", 30.00));
            rooms.Add(new Room(105, "Double", 50.00));
            rooms.Add(new Room(106, "Suite", 95.00));

            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== GRAND VISTA HOTEL - MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest");
                Console.WriteLine("3. Book a Room for a Guest");
                Console.WriteLine("4. View All Rooms");
                Console.WriteLine("5. View All Guests");
                Console.WriteLine("6. Search & Filter Rooms");
                Console.WriteLine("7. Guest & Booking Statistics");
                Console.WriteLine("8. Update Room Price");
                Console.WriteLine("9. Guest Lookup by Name");
                Console.WriteLine("10. Room Type Breakdown Report");
                Console.WriteLine("11. Check Out a Guest");
                Console.WriteLine("12. Remove Unavailable Rooms");
                Console.WriteLine("13. Extend Guest Stay");
                Console.WriteLine("14. Highest Revenue Booking");
                Console.WriteLine("15. Guest Pagination Viewer");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 0 to 15.");
                    continue;
                }

                switch (choice)
                {
                    case 0: exitApp = true; Console.WriteLine("Thank you for using Grand Vista Hotel System. Goodbye!"); break;
                    case 1: AddNewRoom(); break;
                    case 2: RegisterNewGuest(); break;
                    case 3: BookRoomForGuest(); break;
                    case 4: ViewAllRooms(); break;
                    case 5: ViewAllGuests(); break;
                    case 6: SearchFilterRooms(); break;
                    case 7: GuestBookingStatistics(); break;
                    case 8: UpdateRoomPrice(); break;
                    case 9: GuestLookupByName(); break;
                    case 10: RoomTypeBreakdownReport(); break;
                    case 11: CheckOutGuest(); break;
                    case 12: RemoveUnavailableRooms(); break;
                    case 13: ExtendGuestStay(); break;
                    case 14: HighestRevenueBooking(); break;
                    case 15: GuestPaginationViewer(); break;
                    default: Console.WriteLine("Invalid option. Please choose between 0 and 15."); break;
                }
            }
        }

        // ==========================================
        // CASE 01 - Add New Room
        // ==========================================
        static void AddNewRoom()
        {
            Console.Write("Enter room number: ");
            int roomNumber;
            try
            {
                roomNumber = int.Parse(Console.ReadLine());
                if (roomNumber <= 0)
                {
                    Console.WriteLine("Error: Room number must be positive!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid room number!");
                return;
            }

            // Check if room number already exists using LINQ Any()
            if (rooms.Any(r => r.RoomNumber == roomNumber))
            {
                Console.WriteLine("Error: Room number already exists!");
                return;
            }

            Console.Write("Enter room type (Single/Double/Suite): ");
            string roomType = Console.ReadLine();

            Console.Write("Enter price per night (OMR): ");
            double price;
            try
            {
                price = double.Parse(Console.ReadLine());
                if (price <= 0)
                {
                    Console.WriteLine("Error: Price must be positive!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid price!");
                return;
            }

            Room newRoom = new Room(roomNumber, roomType, price);
            rooms.Add(newRoom);

            Console.WriteLine("Room added successfully!");
            Console.WriteLine("Room #" + roomNumber + " - " + roomType + " - " + price.ToString("F2") + " OMR");
            Console.WriteLine("Total rooms: " + rooms.Count);
        }

        // ==========================================
        // CASE 02 - Register New Guest
        // ==========================================
        static void RegisterNewGuest()
        {
            Console.Write("Enter guest name: ");
            string guestName = Console.ReadLine();

            Console.Write("Enter check-in date (yyyy-MM-dd): ");
            DateTime checkInDate;
            try
            {
                checkInDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid date format!");
                return;
            }

            Console.Write("Enter number of nights: ");
            int nights;
            try
            {
                nights = int.Parse(Console.ReadLine());
                if (nights <= 0)
                {
                    Console.WriteLine("Error: Nights must be positive!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input!");
                return;
            }

            // Auto-generate guest ID using Count()
            string guestId = "G" + (guests.Count + 1).ToString("D3");

            Guest newGuest = new Guest(guestId, guestName, checkInDate, nights);
            guests.Add(newGuest);

            Console.WriteLine("Guest registered successfully!");
            Console.WriteLine("Guest ID: " + guestId);
            Console.WriteLine("Name: " + guestName);
            Console.WriteLine("Check-in: " + checkInDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Nights: " + nights);
        }

        // ==========================================
        // CASE 03 - Book a Room for a Guest
        // ==========================================
        static void BookRoomForGuest()
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            // Use FirstOrDefault() to find guest - no manual loop
            Guest guest = guests.FirstOrDefault(g => g.GuestId == guestId);

            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found!");
                return;
            }

            if (guest.RoomNumber != "Not Assigned")
            {
                Console.WriteLine("Error: Guest already has a room booked!");
                return;
            }

            Console.Write("Enter room number: ");
            int roomNumber;
            try
            {
                roomNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid room number!");
                return;
            }

            // Use FirstOrDefault() to find room - no manual loop
            Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Error: Room not found!");
                return;
            }

            if (!room.IsAvailable)
            {
                Console.WriteLine("Error: Room is already booked!");
                return;
            }

            // Assign room to guest
            guest.RoomNumber = roomNumber.ToString();
            room.IsAvailable = false;

            Console.WriteLine("Booking confirmed!");
            Console.WriteLine("Guest: " + guest.GuestName);
            Console.WriteLine("Room: " + room.RoomNumber);
            Console.WriteLine("Room Type: " + room.RoomType);
            Console.WriteLine("Price per night: " + room.PricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("Total nights: " + guest.TotalNights);
            Console.WriteLine("Total cost: " + guest.CalculateTotalCost(room.PricePerNight).ToString("F2") + " OMR");
        }

        // ==========================================
        // CASE 04 - View All Rooms
        // ==========================================
        static void ViewAllRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms have been added yet.");
                return;
            }

            // Use OrderBy() - no manual sorting
            var sortedRooms = rooms.OrderBy(r => r.RoomNumber);

            Console.WriteLine("Total rooms: " + rooms.Count);

            foreach (Room room in sortedRooms)
            {
                Console.WriteLine("Room #" + room.RoomNumber + " | " + room.RoomType + " | " + room.PricePerNight.ToString("F2") + " OMR | " + (room.IsAvailable ? "Available" : "Booked"));
            }
        }

        // ==========================================
        // CASE 05 - View All Guests
        // ==========================================
        static void ViewAllGuests()
        {
            if (guests.Count == 0)
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }

            // Use OrderBy() - no manual sorting
            var sortedGuests = guests.OrderBy(g => g.GuestName);

            Console.WriteLine("Total guests: " + guests.Count);

            foreach (Guest guest in sortedGuests)
            {
                Console.WriteLine(guest.GuestId + " | " + guest.GuestName + " | Room: " + guest.RoomNumber + " | " + guest.CheckInDate.ToString("yyyy-MM-dd") + " | " + guest.TotalNights + " nights");
            }
        }

        // ==========================================
        // CASE 06 - Search & Filter Rooms
        // ==========================================
        static void SearchFilterRooms()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n--- Search & Filter Rooms ---");
                Console.WriteLine("1. Show all available rooms");
                Console.WriteLine("2. Filter by room type");
                Console.WriteLine("3. Filter by max price");
                Console.WriteLine("4. Room price statistics");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        back = true;
                        break;

                    case 1:
                        // Where() to filter available rooms, OrderBy() for sorting
                        var availableRooms = rooms.Where(r => r.IsAvailable).OrderBy(r => r.PricePerNight);
                        int count = availableRooms.Count();

                        if (count == 0)
                        {
                            Console.WriteLine("No available rooms found.");
                        }
                        else
                        {
                            Console.WriteLine("Available rooms: " + count);
                            foreach (Room room in availableRooms)
                            {
                                Console.WriteLine("Room #" + room.RoomNumber + " | " + room.RoomType + " | " + room.PricePerNight.ToString("F2") + " OMR");
                            }
                        }
                        break;

                    case 2:
                        Console.Write("Enter room type (Single/Double/Suite): ");
                        string type = Console.ReadLine();

                        // Where() to filter by type
                        var roomsByType = rooms.Where(r => r.RoomType.ToLower() == type.ToLower());
                        int typeCount = roomsByType.Count();

                        if (typeCount == 0)
                        {
                            Console.WriteLine("No rooms found of type: " + type);
                        }
                        else
                        {
                            Console.WriteLine("Rooms of type '" + type + "': " + typeCount);
                            foreach (Room room in roomsByType)
                            {
                                Console.WriteLine("Room #" + room.RoomNumber + " | " + room.RoomType + " | " + room.PricePerNight.ToString("F2") + " OMR | " + (room.IsAvailable ? "Available" : "Booked"));
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter maximum price (OMR): ");
                        double maxPrice;
                        try
                        {
                            maxPrice = double.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }

                        // Where() to filter by price
                        var roomsByPrice = rooms.Where(r => r.IsAvailable && r.PricePerNight <= maxPrice).OrderBy(r => r.PricePerNight);
                        int priceCount = roomsByPrice.Count();

                        if (priceCount == 0)
                        {
                            Console.WriteLine("No available rooms found at or below " + maxPrice.ToString("F2") + " OMR");
                        }
                        else
                        {
                            Console.WriteLine("Available rooms at or below " + maxPrice.ToString("F2") + " OMR: " + priceCount);
                            foreach (Room room in roomsByPrice)
                            {
                                Console.WriteLine("Room #" + room.RoomNumber + " | " + room.RoomType + " | " + room.PricePerNight.ToString("F2") + " OMR");
                            }
                        }
                        break;

                    case 4:
                        // LINQ aggregation methods
                        int totalRooms = rooms.Count();
                        int availableCount = rooms.Count(r => r.IsAvailable);
                        double avgPrice = rooms.Average(r => r.PricePerNight);
                        double minPrice = rooms.Min(r => r.PricePerNight);
                        double maxPriceStat = rooms.Max(r => r.PricePerNight);

                        Console.WriteLine("===== ROOM PRICE STATISTICS =====");
                        Console.WriteLine("Total rooms: " + totalRooms);
                        Console.WriteLine("Available rooms: " + availableCount);
                        Console.WriteLine("Average price: " + avgPrice.ToString("F2") + " OMR");
                        Console.WriteLine("Cheapest room: " + minPrice.ToString("F2") + " OMR");
                        Console.WriteLine("Most expensive room: " + maxPriceStat.ToString("F2") + " OMR");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        // ==========================================
        // CASE 07 - Guest & Booking Statistics
        // ==========================================
        static void GuestBookingStatistics()
        {
            // Total registered guests and guests with room assigned
            int totalGuests = guests.Count();
            int guestsWithRoom = guests.Count(g => g.RoomNumber != "Not Assigned");

            // Total rooms and booked rooms
            int totalRooms = rooms.Count();
            int bookedRooms = rooms.Count(r => !r.IsAvailable);

            Console.WriteLine("===== GUEST & BOOKING STATISTICS =====");
            Console.WriteLine("Total registered guests: " + totalGuests);
            Console.WriteLine("Guests with room assigned: " + guestsWithRoom);
            Console.WriteLine("Total rooms: " + totalRooms);
            Console.WriteLine("Booked rooms: " + bookedRooms);

            // Average nights for active bookings
            var activeGuests = guests.Where(g => g.RoomNumber != "Not Assigned");
            if (activeGuests.Any())
            {
                double avgNights = activeGuests.Average(g => g.TotalNights);
                Console.WriteLine("Average nights per active booking: " + avgNights.ToString("F2"));
            }
            else
            {
                Console.WriteLine("No active bookings recorded.");
            }

            // Top 3 highest spending guests
            var topSpenders = guests.Where(g => g.RoomNumber != "Not Assigned")
                .OrderByDescending(g => g.CalculateTotalCost(rooms.First(r => r.RoomNumber == int.Parse(g.RoomNumber)).PricePerNight))
                .Take(3);

            Console.WriteLine("\n===== TOP 3 HIGHEST SPENDING GUESTS =====");
            if (topSpenders.Any())
            {
                foreach (Guest guest in topSpenders)
                {
                    Room room = rooms.First(r => r.RoomNumber == int.Parse(guest.RoomNumber));
                    double totalCost = guest.CalculateTotalCost(room.PricePerNight);
                    Console.WriteLine(guest.GuestName + " - Room " + guest.RoomNumber + " - " + guest.TotalNights + " nights - " + totalCost.ToString("F2") + " OMR");
                }
            }
            else
            {
                Console.WriteLine("No active bookings recorded.");
            }

            // Summary line per booked guest using Select()
            Console.WriteLine("\n===== BOOKING SUMMARY =====");
            var bookings = guests.Where(g => g.RoomNumber != "Not Assigned")
                .Select(g => new { Guest = g, Room = rooms.First(r => r.RoomNumber == int.Parse(g.RoomNumber)) });

            if (bookings.Any())
            {
                foreach (var booking in bookings)
                {
                    double totalCost = booking.Guest.CalculateTotalCost(booking.Room.PricePerNight);
                    Console.WriteLine(booking.Guest.GuestName + " - Room " + booking.Guest.RoomNumber + " - " + booking.Guest.TotalNights + " nights - " + totalCost.ToString("F2") + " OMR");
                }
            }
            else
            {
                Console.WriteLine("No active bookings recorded.");
            }
        }

        // ==========================================
        // CASE 08 - Update Room Price
        // ==========================================
        static void UpdateRoomPrice()
        {
            Console.Write("Enter room number: ");
            int roomNumber;
            try
            {
                roomNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid room number!");
                return;
            }

            // Use FirstOrDefault() - no manual loop
            Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Error: Room not found!");
                return;
            }

            Console.Write("Enter new price per night: ");
            double newPrice;
            try
            {
                newPrice = double.Parse(Console.ReadLine());
                if (newPrice <= 0)
                {
                    Console.WriteLine("Error: Price must be positive!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid price!");
                return;
            }

            double oldPrice = room.PricePerNight;
            room.PricePerNight = newPrice;

            Console.WriteLine("Price updated successfully!");
            Console.WriteLine("Old price: " + oldPrice.ToString("F2") + " OMR");
            Console.WriteLine("New price: " + newPrice.ToString("F2") + " OMR");
        }

        // ==========================================
        // CASE 09 - Guest Lookup by Name
        // ==========================================
        static void GuestLookupByName()
        {
            Console.Write("Enter name or partial name to search: ");
            string searchText = Console.ReadLine();

            // Where() with case-insensitive comparison
            var matchingGuests = guests.Where(g => g.GuestName.ToLower().Contains(searchText.ToLower()));

            int count = matchingGuests.Count();

            if (count == 0)
            {
                Console.WriteLine("No guests matched that search.");
                return;
            }

            Console.WriteLine("Matches found: " + count);
            foreach (Guest guest in matchingGuests)
            {
                Console.WriteLine(guest.GuestId + " | " + guest.GuestName + " | Room: " + guest.RoomNumber);
            }
        }

        // ==========================================
        // CASE 10 - Room Type Breakdown Report
        // ==========================================
        static void RoomTypeBreakdownReport()
        {
            string[] roomTypes = { "Single", "Double", "Suite" };

            Console.WriteLine("===== ROOM TYPE BREAKDOWN =====");

            foreach (string type in roomTypes)
            {
                int count = rooms.Count(r => r.RoomType == type);

                if (count > 0)
                {
                    double avgPrice = rooms.Where(r => r.RoomType == type).Average(r => r.PricePerNight);
                    Console.WriteLine(type + ": " + count + " rooms, Average price: " + avgPrice.ToString("F2") + " OMR");
                }
                else
                {
                    Console.WriteLine(type + ": 0 rooms, Average price: N/A");
                }
            }

            // Overall average price
            if (rooms.Any())
            {
                double overallAvg = rooms.Average(r => r.PricePerNight);
                Console.WriteLine("Overall average price across all rooms: " + overallAvg.ToString("F2") + " OMR");
            }
        }

        // ==========================================
        // CASE 11 - Check Out a Guest
        // ==========================================
        static void CheckOutGuest()
        {
            Console.Write("Enter Guest ID to check out: ");
            string guestId = Console.ReadLine();

            // FirstOrDefault() for guest lookup
            Guest guest = guests.FirstOrDefault(g => g.GuestId == guestId);

            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found!");
                return;
            }

            if (guest.RoomNumber == "Not Assigned")
            {
                Console.WriteLine("Error: This guest has no active booking.");
                return;
            }

            int roomNumber = int.Parse(guest.RoomNumber);

            // Second FirstOrDefault() for room lookup
            Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Error: Room not found!");
                return;
            }

            // Display final bill
            double totalCost = guest.CalculateTotalCost(room.PricePerNight);

            Console.WriteLine("===== FINAL BILL =====");
            Console.WriteLine("Guest: " + guest.GuestName);
            Console.WriteLine("Room: " + room.RoomNumber);
            Console.WriteLine("Room Type: " + room.RoomType);
            Console.WriteLine("Check-in: " + guest.CheckInDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Total nights: " + guest.TotalNights);
            Console.WriteLine("Price per night: " + room.PricePerNight.ToString("F2") + " OMR");
            Console.WriteLine("Total cost: " + totalCost.ToString("F2") + " OMR");

            Console.Write("Confirm checkout? (Y/N): ");
            string confirm = Console.ReadLine().ToUpper();

            if (confirm == "Y")
            {
                // Free the room
                room.IsAvailable = true;

                // Remove the guest
                guests.Remove(guest);

                Console.WriteLine("Checkout successful!");
                Console.WriteLine("Remaining guests: " + guests.Count);
                Console.WriteLine("Available rooms: " + rooms.Count(r => r.IsAvailable));

                // Confirm room is now available using Any()
                if (rooms.Any(r => r.RoomNumber == roomNumber && r.IsAvailable))
                {
                    Console.WriteLine("Room #" + roomNumber + " is now available.");
                }
            }
            else
            {
                Console.WriteLine("Checkout cancelled. No changes made.");
            }
        }

        // ==========================================
        // CASE 12 - Remove Unavailable Rooms
        // ==========================================
        static void RemoveUnavailableRooms()
        {
            // Identify rooms that are unavailable AND have no active guest
            var removableRooms = rooms.Where(r =>
                !r.IsAvailable &&
                !guests.Any(g => g.RoomNumber != "Not Assigned" && g.RoomNumber == r.RoomNumber.ToString()))
                .OrderBy(r => r.RoomNumber);

            int count = removableRooms.Count();

            if (count == 0)
            {
                Console.WriteLine("All unavailable rooms are currently occupied. No rooms can be decommissioned.");
                return;
            }

            Console.WriteLine("===== ROOMS SAFELY REMOVABLE =====");
            foreach (Room room in removableRooms)
            {
                Console.WriteLine("Room #" + room.RoomNumber + " | " + room.RoomType + " | " + room.PricePerNight.ToString("F2") + " OMR");
            }

            Console.WriteLine("Total removable rooms: " + count);
            Console.Write("Confirm removal? (Y/N): ");
            string confirm = Console.ReadLine().ToUpper();

            if (confirm == "Y")
            {
                // Use RemoveAll() with same condition
                int removed = rooms.RemoveAll(r =>
                    !r.IsAvailable &&
                    !guests.Any(g => g.RoomNumber != "Not Assigned" && g.RoomNumber == r.RoomNumber.ToString()));

                Console.WriteLine(removed + " rooms removed successfully!");
                Console.WriteLine("Updated total rooms: " + rooms.Count);

                // Display remaining rooms using Select()
                var remainingRooms = rooms.Select(r => new { r.RoomNumber, r.RoomType });
                Console.WriteLine("\nRemaining rooms:");
                foreach (var room in remainingRooms)
                {
                    Console.WriteLine("Room #" + room.RoomNumber + " - " + room.RoomType);
                }
            }
            else
            {
                Console.WriteLine("Removal cancelled. No rooms removed.");
            }
        }

        // ==========================================
        // CASE 13 - Extend Guest Stay
        // ==========================================
        static void ExtendGuestStay()
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            // FirstOrDefault() for guest lookup
            Guest guest = guests.FirstOrDefault(g => g.GuestId == guestId);

            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found!");
                return;
            }

            if (guest.RoomNumber == "Not Assigned")
            {
                Console.WriteLine("Error: This guest has no active booking to extend.");
                return;
            }

            Console.Write("Enter additional nights: ");
            int additionalNights;
            try
            {
                additionalNights = int.Parse(Console.ReadLine());
                if (additionalNights <= 0)
                {
                    Console.WriteLine("Error: Additional nights must be positive!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input!");
                return;
            }

            // Update guest's total nights
            guest.TotalNights = guest.TotalNights + additionalNights;

            // Calculate new total cost
            Room room = rooms.First(r => r.RoomNumber == int.Parse(guest.RoomNumber));
            double newTotalCost = guest.CalculateTotalCost(room.PricePerNight);

            Console.WriteLine("Stay extended successfully!");
            Console.WriteLine("Updated total nights: " + guest.TotalNights);
            Console.WriteLine("New total cost: " + newTotalCost.ToString("F2") + " OMR");
        }

        // ==========================================
        // CASE 14 - Highest Revenue Booking
        // ==========================================
        static void HighestRevenueBooking()
        {
            // Filter active guests
            var activeGuests = guests.Where(g => g.RoomNumber != "Not Assigned");

            if (!activeGuests.Any())
            {
                Console.WriteLine("No active bookings recorded.");
                return;
            }

            // Use Select() to project and OrderByDescending() + Take(1)
            var topBooking = activeGuests
                .Select(g => new
                {
                    Guest = g,
                    Room = rooms.First(r => r.RoomNumber == int.Parse(g.RoomNumber))
                })
                .OrderByDescending(b => b.Guest.CalculateTotalCost(b.Room.PricePerNight))
                .Take(1)
                .First();

            double totalCost = topBooking.Guest.CalculateTotalCost(topBooking.Room.PricePerNight);

            Console.WriteLine("===== HIGHEST REVENUE BOOKING =====");
            Console.WriteLine("Guest: " + topBooking.Guest.GuestName);
            Console.WriteLine("Room: " + topBooking.Guest.RoomNumber);
            Console.WriteLine("Total cost: " + totalCost.ToString("F2") + " OMR");
        }

        // ==========================================
        // CASE 15 - Guest Pagination Viewer
        // ==========================================
        static void GuestPaginationViewer()
        {
            if (guests.Count == 0)
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }

            int pageSize = 3;
            int totalPages = (int)Math.Ceiling((double)guests.Count / pageSize);

            Console.Write("Enter page number (1-" + totalPages + "): ");
            int pageNumber;
            try
            {
                pageNumber = int.Parse(Console.ReadLine());
                if (pageNumber < 1 || pageNumber > totalPages)
                {
                    Console.WriteLine("That page does not exist.");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid page number!");
                return;
            }

            // Use Skip() and Take() for pagination
            var pagedGuests = guests
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            Console.WriteLine("===== GUESTS - PAGE " + pageNumber + " OF " + totalPages + " =====");
            foreach (Guest guest in pagedGuests)
            {
                Console.WriteLine(guest.GuestId + " | " + guest.GuestName + " | Room: " + guest.RoomNumber + " | " + guest.TotalNights + " nights");
            }
        }
    }
}