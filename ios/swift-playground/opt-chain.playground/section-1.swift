// Playground - noun: a place where people can play

class Person {
    var residence: Residence?
}

class Residence {
    
    var rooms = [Room]();
    
    var numberOfRooms: Int {
        return rooms.count;
    }
    
    subscript(i: Int) -> Room {
        return rooms[i];
    }
    
    func printNumberOfRooms() {
        println("The number of rooms is \(numberOfRooms)");
    }
    
    var address: Address?;
}

class Room {
    
    let name: String;
    
    init(name: String) { self.name = name; }
    
}

class Address {
    
    var buildingName: String?;
    
    var buildingNumber: String?;
    
    var street: String?;
    
    func buildingIdentifier() -> String? {
        if buildingName {
            return buildingName;
        }
        else if buildingNumber {
            return buildingNumber;
        }
        else {
            return nil;
        }
    }
}

let john = Person()
john.residence = Residence();

let rc = john.residence?.numberOfRooms;

if let roomCount = john.residence?.numberOfRooms {
    println("John's residence has \(roomCount) room(s).")
}
else {
    println("Unable to retrieve the number of rooms.")
}