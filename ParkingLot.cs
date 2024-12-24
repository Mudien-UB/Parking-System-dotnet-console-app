using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    private Vehicle[] _slots;
    private int _totalSlots;

    public ParkingLot(int totalSlots) {
        _totalSlots = totalSlots;
        _slots = new Vehicle[totalSlots];
    }

    public string ParkVehicle(Vehicle vehicle) {
        for (int i = 0; i < _totalSlots; i++) {
            if (_slots[i] == null) {
                _slots[i] = vehicle;
                return $"Allocated slot number: {i + 1}";
            }
        }
        return "Sorry, parking lot is full";
    }

    public string LeaveVehicle(int slot) {
        if (slot < 1 || slot > _totalSlots) {
            return "Slot not found";
        } else {
            if (_slots[slot - 1] != null) {
                _slots[slot - 1] = null;
                return $"Slot number {slot} is free";
            } else {
                return "Slot not found";
            }
        }
    }

    public void Status() {
        Console.WriteLine("Slot No.\tRegistration No\tType\tColour");
        for (int i = 0; i < _totalSlots; i++) {
            if (_slots[i] != null) {
                var vehicle = _slots[i];
                Console.WriteLine($"{i + 1}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Colour}");
            }
        }
    }

    public int GetVehicleCountByType(string type) {
        return _slots.Count(v => v != null && v.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
    }

    public string GetRegistrationNumbersByColour(string colour) {
        var vehicles = _slots.Where(v => v != null && v.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
                              .Select(v => v.RegistrationNumber);
        return string.Join(", ", vehicles);
    }

    public string GetSlotNumbersByColour(string colour) {
        var slots = new List<int>();
        for (int i = 0; i < _totalSlots; i++) {
            if (_slots[i] != null && _slots[i].Colour.Equals(colour, StringComparison.OrdinalIgnoreCase)) {
                slots.Add(i + 1);
            }
        }
        return string.Join(", ", slots);
    }

    public string GetSlotNumberForRegistrationNumber(string registrationNumber) {
        for (int i = 0; i < _totalSlots; i++) {
            if (_slots[i] != null && _slots[i].RegistrationNumber == registrationNumber) {
                return (i + 1).ToString();
            }
        }
        return "Not found";
    }
    public string GetRegistrationNumbersByPlateType(bool isOdd) {
        var vehicles = _slots.Where(v => v != null &&
                                         IsOddPlate(v.RegistrationNumber) == isOdd)
                              .Select(v => v.RegistrationNumber);
        return string.Join(", ", vehicles);
    }

    private bool IsOddPlate(string registrationNumber) {
        if (string.IsNullOrWhiteSpace(registrationNumber)) {
            return false;
        }
        var lastDigit = registrationNumber.LastOrDefault(char.IsDigit);
        return lastDigit % 2 != 0;
    }
}
