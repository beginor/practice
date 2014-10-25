// Playground - noun: a place where people can play

import UIKit;

extension Double {
    
    var km: Double { return self * 1_000.0; }
    var  m: Double { return self; }
    var cm: Double { return self / 100.0; }
    var mm: Double { return self / 1_000.0; }
    var ft: Double { return self / 3.28084; }
    
}

let oneInch = 25.4.mm;
let threeFeet = 3.ft;

let aMarathon = 42.km + 195.m;

struct Size {
    var width = 0.0, height = 0.0;
}

struct Point {
    var x = 0.0, y = 0.0;
}

struct Rect {
    var origin = Point();
    var size = Size();
}

let defaultRect = Rect();

let memberwiseRect = Rect(origin: Point(x: 2.0, y: 2.0),
    size: Size(width: 5.0, height: 5.0));

extension Rect {
    init(center: Point, size: Size) {
        let x = center.x - (size.width / 2);
        let y = center.y - (size.height / 2);
        self.init(origin: Point(x: x, y: y), size: size);
    }
}

let centerRect = Rect(center: Point(x: 4.0, y: 4.0),
    size: Size(width: 3.0, height: 3.0));

extension Int {
    func repetitions(task: () -> ()) {
        for i in 0..<self {
            task();
        }
    }
}

3.repetitions({
    println("Hello!");
});

extension Int {
    mutating func square() {
        self = self * self;
    }
}

var someInt = 3;
someInt.square();

extension Int {
    subscript(var index: Int) -> Int {
        var base = 1;
        while (index > 0) {
            base *= 10;
            --index;
        }
        return (self / base) % 10;
    }
}

746381295[0];
746381295[1];

extension Character {
    enum Kind {
        case Vowel, Consonant, Other
    }
    var kind: Kind {
        switch String(self).lowercaseString {
        case "a", "e", "i", "o", "u":
            return .Vowel
        case "b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
        "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z":
            return .Consonant
        default:
            return .Other
        }
    }
}

func printLetterKinds(word: String) {
    println("'\(word)' is made up of the following kinds of letters:")
    for character in word {
        switch character.kind {
        case .Vowel:
            print("vowel ");
        case .Consonant:
            print("consonant ");
        case .Other:
            print("other ");
        }
    }
    println("\n");
}
printLetterKinds("Hello");