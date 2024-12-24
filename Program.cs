using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = null;
            string command;

            while ((command = Console.ReadLine()) != "exit")
            {
                var parts = command.Split(' ');
                switch (parts[0])
                {
                    case "create_parking_lot":
                        int totalSlots = int.Parse(parts[1]);
                        parkingLot = new ParkingLot(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                        break;

                    case "park":
                        if (parkingLot != null)
                        {
                            string registrationNumber = parts[1];
                            string colour = parts[2];
                            string type = parts[3];
                            var vehicle = new Vehicle(registrationNumber, colour, type);
                            Console.WriteLine(parkingLot.ParkVehicle(vehicle));
                        }
                        break;

                    case "leave":
                        if (parkingLot != null)
                        {
                            int slot = int.Parse(parts[1]);
                            Console.WriteLine(parkingLot.LeaveVehicle(slot));
                        }
                        break;

                    case "status":
                        if (parkingLot != null)
                        {
                            parkingLot.Status();
                        }
                        break;

                    case "type_of_vehicles":
                        if (parkingLot != null)
                        {
                            string type = parts[1];
                            Console.WriteLine(parkingLot.GetVehicleCountByType(type));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        if (parkingLot != null)
                        {
                            string colour = parts[1];
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByColour(colour));
                        }
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        if (parkingLot != null)
                        {
                            string colour = parts[1];
                            Console.WriteLine(parkingLot.GetSlotNumbersByColour(colour));
                        }
                        break;

                    case "slot_number_for_registration_number":
                        if (parkingLot != null)
                        {
                            string registrationNumber = parts[1];
                            Console.WriteLine(parkingLot.GetSlotNumberForRegistrationNumber(registrationNumber));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                        if (parkingLot != null)
                        {
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByPlateType(isOdd: true));
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_even_plate":
                        if (parkingLot != null)
                        {
                            Console.WriteLine(parkingLot.GetRegistrationNumbersByPlateType(isOdd: false));
                        }
                        break;
                }
            }
        }
    }
}
